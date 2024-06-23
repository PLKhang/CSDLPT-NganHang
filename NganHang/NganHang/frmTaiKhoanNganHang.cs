using DevExpress.XtraCharts.Native;
using DevExpress.XtraEditors;
using NGANHANG;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NganHang
{
    public partial class frmTaiKhoanNganHang : Form
    {
        int vitri = 0;
        String macn = "";
        bool btn_Add_clicked = false;
        public frmTaiKhoanNganHang()
        {
            InitializeComponent();
        }

        private void kHACHHANGBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.kHACHHANGBindingSource.EndEdit();
            this.tableAdapterManager1.UpdateAll(this.khachHang);

        }
        private void frmTaiKhoanNganHang_Load(object sender, EventArgs e)
        {
            try
            {
                // Tắt EnforceConstraints để tránh lỗi ràng buộc khi tải dữ liệu
                khachHang.EnforceConstraints = false;

                // Thiết lập chuỗi kết nối cho các TableAdapter và tải dữ liệu
                this.kHACHHANGTableAdapter1.Connection.ConnectionString = Program.connstr;
                this.kHACHHANGTableAdapter1.Fill(this.khachHang.KHACHHANG);

                this.tAIKHOANTableAdapter1.Connection.ConnectionString = Program.connstr;
                this.tAIKHOANTableAdapter1.Fill(this.khachHang.TAIKHOAN);


                // Lấy mã chi nhánh từ dòng đầu tiên của BindingSource bdsKH và gán cho biến macn
                if (kHACHHANGBindingSource.Count > 0)
                {
                    macn = ((DataRowView)kHACHHANGBindingSource[0])["MACN"].ToString();
                }

                // Cài đặt dữ liệu cho ComboBox chi nhánh
                cmbChiNhanh.DataSource = Program.bds_dspm; // sao chép bds_ds đã load ở form đăng nhập
                cmbChiNhanh.DisplayMember = "TENCN";
                cmbChiNhanh.ValueMember = "TENSERVER";
                cmbChiNhanh.SelectedIndex = Program.mChinhanh;

                // Cài đặt trạng thái ban đầu cho các điều khiển
                panel2.Enabled = btnUndo.Enabled = btnSave.Enabled = false;

                if (Program.mGroup == "NganHang")
                {
                    cmbChiNhanh.Enabled = true;
                    btnAdd.Enabled = btnSave.Enabled = btnUndo.Enabled = false;
                }
                else
                {
                    cmbChiNhanh.Enabled = false;
                    btnAdd.Enabled = btnSave.Enabled = btnUndo.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load dữ liệu: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void cmbChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbChiNhanh.SelectedValue.ToString() == "System.Data.DataRowView")
                return;
            Program.servername = cmbChiNhanh.SelectedValue.ToString();
            if (cmbChiNhanh.SelectedIndex != Program.mChinhanh)
            {
                Program.mlogin = Program.remotelogin;
                Program.password = Program.remotepassword;
            }
            else
            {
                Program.mlogin = Program.mloginDN;
                Program.password = Program.passwordDN;
            }
            if (Program.KetNoi() == 0) MessageBox.Show("Lỗi kết nối về chi nhánh mới", "", MessageBoxButtons.OK);
            else
            {
                this.kHACHHANGTableAdapter1.Connection.ConnectionString = Program.connstr;
                this.kHACHHANGTableAdapter1.Fill(this.khachHang.KHACHHANG);
            }
        }

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = kHACHHANGBindingSource.Position;
            panel2.Enabled = true;
            string cmd1 = "EXEC sp_TaoSTK";
            Program.myReader=Program.ExecSqlDataReader(cmd1);
            Program.myReader.Read();
            string generatedSTK = Program.myReader.GetString(0);
             Program.myReader.Close();
            txtSOTK.Text = generatedSTK;    
            txtMACN.Text = macn;//tự gán mã chi nhánh = chi nhánh đang đăng nhập của tài khoản thuộc chi nhánh
            btnAdd.Enabled  =  btnReload.Enabled = btnExit.Enabled = false;
            btnSave.Enabled = btnUndo.Enabled = true;
            gcKH.Enabled = gcTK.Enabled = false;
            String dt = String.Format("{0:yyyy-MM-dd HH:mm:ss.fff}", DateTime.Now);
            dateEditNgayMoTK.Text = dt;
            btn_Add_clicked = true;
        }
        
        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (btn_Add_clicked == false)
            {
                return;
            }
            
          
            if (txtSOTK.Text.Trim() == "")
            {
                MessageBox.Show("Số Tài Khoản không được trống", "", MessageBoxButtons.OK);
                txtSOTK.Focus();
                return;
            }
            if (!txtSOTK.Text.All(Char.IsDigit))
            {
                MessageBox.Show("Số tài khoản không hợp lệ (Chỉ được có số)", "", MessageBoxButtons.OK);
                txtSOTK.Focus();
                return;
            }

            //kiểm tra mã nhân viên tồn tại trên site chủ
            //viết 1 sp kiểm tra mã trùng.gọi sp đó thông qua hàm execsqldatareader dưới dạng có hay không!!
            if (true)
            {
                int tmp = Program.ExecSqlAndGetReturnedValue("sp_Existed_STK",  new SqlParameter("@SOTK", txtSOTK.Text));
         
                if (tmp == 1)
                {
                    MessageBox.Show("Số tài khoản đã tồn tại.\nVui lòng nhập lại.", "", MessageBoxButtons.OK);
                    return;
                }
            }

            try
            {
                // Định dạng ngày tháng theo chuẩn SQL (ví dụ yyyy-MM-dd)
                //string formattedDate = ((DateTime)dateEditNgayMoTK.EditValue).ToString("yyyy-MM-dd");

                // Xây dựng câu lệnh SQL với định dạng ngày tháng đúng
                string cmd = "EXEC sp_TaoTK_KH '" + txtSOTK.Text.Trim() + "', '"
                                              + cMND.Text.Trim() + "', "
                                              + nuSODU.Value.ToString() + ", '"
                                              + txtMACN.Text.Trim() + "', '"
                                              + dateEditNgayMoTK.EditValue + "'";

                Program.myReader = Program.ExecSqlDataReader(cmd);
                Program.myReader.Close();
                MessageBox.Show("Thêm thành công!!", "", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm tài khoản. \n" + ex.Message, "", MessageBoxButtons.OK);
                return;
            }
            gcTK.Enabled = true;
            gcKH.Enabled = true;
            btnAdd.Enabled = btnReload.Enabled = btnExit.Enabled = true;
            btnSave.Enabled = btnUndo.Enabled = false;
            panel2.Enabled = false;
            btn_Add_clicked = false;
            btnReload_ItemClick(sender,null);
        }

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.kHACHHANGTableAdapter1.Connection.ConnectionString = Program.connstr;
                this.kHACHHANGTableAdapter1.Fill(this.khachHang.KHACHHANG);
                this.tAIKHOANTableAdapter1.Connection.ConnectionString = Program.connstr;
                this.tAIKHOANTableAdapter1.Fill(this.khachHang.TAIKHOAN);
                
                gcTK.Refresh();
                gcKH.Refresh(); 

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi reload: " + ex.Message, "", MessageBoxButtons.OK);
                return;
            } 
        }

        private void btnUndo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            kHACHHANGBindingSource.CancelEdit();//hai trường hợp: đang thêm bỏ thêm, đang sửa bỏ sửa
            if (btnAdd.Enabled == false) kHACHHANGBindingSource.Position = vitri;
            txtSOTK.Text= string.Empty;
            gcKH.Enabled = gcTK.Enabled = true;

            panel2.Enabled = false;
            btnAdd.Enabled =  btnReload.Enabled = btnExit.Enabled = true;
            btnSave.Enabled = btnUndo.Enabled = false;
            dateEditNgayMoTK.Text = "";
        }

        private void btnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

       

        private void Close_Click(object sender, EventArgs e)
        {
            Close();
        }

   
    }
}
