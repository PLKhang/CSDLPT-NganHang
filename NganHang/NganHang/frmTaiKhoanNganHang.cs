using DevExpress.XtraEditors;
using NGANHANG;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            this.bdsKH.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DS);

        }

        private void frmTaiKhoanNganHang_Load(object sender, EventArgs e)
        {
            
            DS.EnforceConstraints = false;
            this.kHACHHANGTableAdapter.Connection.ConnectionString = Program.connstr;
            this.kHACHHANGTableAdapter.Fill(this.DS.KHACHHANG);
            this.tAIKHOANTableAdapter.Connection.ConnectionString = Program.connstr;
            this.tAIKHOANTableAdapter.Fill(this.DS.TAIKHOAN);
            this.gD_GOIRUTTableAdapter.Fill(this.DS.GD_GOIRUT);
            this.gD_CHUYENTIENTableAdapter.Fill(this.DS.GD_CHUYENTIEN);

            macn = ((DataRowView)bdsKH[0])["MACN"].ToString();
            cmbChiNhanh.DataSource = Program.bds_dspm; // sao chép bds_ds đã load ở form đăng nhập
            cmbChiNhanh.DisplayMember = "TENCN";
            cmbChiNhanh.ValueMember = "TENSERVER";
            cmbChiNhanh.SelectedIndex = Program.mChinhanh;
            panel2.Enabled = btnUndo.Enabled = btnSave.Enabled = false;
            if (Program.mGroup == "NganHang")
            {
                cmbChiNhanh.Enabled = true;
                btnAdd.Enabled = btnUpdate.Enabled = btnSave.Enabled = btnDelete.Enabled = btnUndo.Enabled = false;
            }
            else
            {
                cmbChiNhanh.Enabled = false;
                btnAdd.Enabled = btnUpdate.Enabled = btnSave.Enabled = btnDelete.Enabled = btnUndo.Enabled = true;
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
                this.kHACHHANGTableAdapter.Connection.ConnectionString = Program.connstr;
                this.kHACHHANGTableAdapter.Fill(this.DS.KHACHHANG);
            }
        }

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsKH.Position;
            panel2.Enabled = true;          
            txtMACN.Text = macn;//tự gán mã chi nhánh = chi nhánh đang đăng nhập của tài khoản thuộc chi nhánh
            btnAdd.Enabled = btnUpdate.Enabled = btnDelete.Enabled = btnReload.Enabled = btnExit.Enabled = false;
            btnSave.Enabled = btnUndo.Enabled = true;
            gcKH.Enabled = gcTK.Enabled = false;
            String dt = String.Format("{0:yyyy-MM-dd HH:mm:ss.fff}", DateTime.Now);
            dateEditNgayMoTK.Text = dt;
        }

        private void btnUpdate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string cmnd = (((DataRowView)bdsTK_FK[bdsTK_FK.Position])["CMND"].ToString()); //giữ lại vị trí nv hiện tại
            if (bdsCT.Count > 0)
            {
                MessageBox.Show("Không thể chỉnh sửa tài khoản, vì đã thực hiện giao dịch chuyển tiền cho tài khoản này", "", MessageBoxButtons.OK);
                return;
            }
            if(bdsGR.Count > 0)
            {
                MessageBox.Show("Không thể chỉnh sửa tài khoản, vì đã thực hiện giao dịch gửi rút tiền cho tài khoản này", "", MessageBoxButtons.OK);
                return;
            }
            try
            {
                vitri = bdsKH.Position;
                panel2.Enabled = true;
                btnAdd.Enabled = btnUpdate.Enabled = btnDelete.Enabled = btnReload.Enabled = btnExit.Enabled = false;
                btnSave.Enabled = btnUndo.Enabled = true;
                gcKH.Enabled = gcTK.Enabled = false; 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiệu chỉnh tài khoản. Bạn hãy hiệu chỉnh lại\n" + ex.Message, "", MessageBoxButtons.OK);
                this.tAIKHOANTableAdapter.Fill(this.DS.TAIKHOAN);
                 bdsTK_FK.Position = bdsTK_FK.Find("CMND", cmnd);
                 return;
            }
            if (bdsTK_FK.Count == 0) btnUpdate.Enabled = false;
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            String sotk = (((DataRowView)bdsTK_FK[bdsTK_FK.Position])["CMND"].ToString()).TrimEnd();

            if (txtSOTK.Text.Trim() == "")
            {
                MessageBox.Show("Số Tài Khoản không được trống", "", MessageBoxButtons.OK);
                txtSOTK.Focus();
                return;
            }
            if (!txtSOTK.Text.All(Char.IsDigit))
            {
                MessageBox.Show("Số điện thoại không hợp lệ (Chỉ được có số)", "", MessageBoxButtons.OK);
                txtSOTK.Focus();
                return;
            }

            // Kiểm tra mã nhân viên tồn tại trên site chủ
            //viết 1 SP kiểm tra mã trùng. gọi SP đó thông qua hàm ExecSqlDataReader dưới dạng có hay không!! 
            //if (btn_Add_clicked == true || sotk != nuSODU.Text.TrimEnd())
            //{
            //    Program.myReader.Close();
            //    string strlenh1 = "EXEC sp_Existed_CMND_NV '" + nuSODU.Text.TrimEnd() + "'";
            //    Program.myReader = Program.ExecSqlDataReader(strlenh1);
            //    Program.myReader.Read();
            //    if (Program.myReader.HasRows)
            //    {
            //        MessageBox.Show("CMND nhân viên đã tồn tại \nVui lòng nhập lại", "", MessageBoxButtons.OK);
            //        return;
            //    }
            //    Program.myReader.Close();
            //}
            try
            {
                //bdsNV.EndEdit(); //kết thúc quá trình hiệu chỉnh (ghi vào datasource)
                //bdsNV.ResetCurrentItem();//đưa thông tin lên lưới
                //this.NHANVIENTableAdapter.Connection.ConnectionString = Program.connstr;
                //this.NHANVIENTableAdapter.Update(this.DS.NHANVIEN);
                MessageBox.Show("Lưu thành công!!", "", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ghi nhân viên. \n" + ex.Message, "", MessageBoxButtons.OK);
                return;
            }
            gcTK.Enabled = true;
            btnAdd.Enabled = btnUpdate.Enabled = btnDelete.Enabled = btnReload.Enabled = btnExit.Enabled = true;
            btnSave.Enabled = btnUndo.Enabled = false;
            panel2.Enabled = false;
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string cmnd = (((DataRowView)bdsTK_FK[bdsTK_FK.Position])["CMND"].ToString()); //giữ lại vị trí nv hiện tại
            if (bdsGR.Count > 0)
            {
                MessageBox.Show("Không thể chỉnh sửa tài khoản, vì đã thực hiện giao dịch chuyển tiền cho tài khoản này", "", MessageBoxButtons.OK);
                return;
            }
            if (bdsCT.Count > 0)
            {
                MessageBox.Show("Không thể chỉnh sửa tài khoản, vì đã thực hiện giao dịch gửi rút tiền cho tài khoản này", "", MessageBoxButtons.OK);
                return;
            }

           try
           {                 
                bdsTK_FK.RemoveCurrent();
                this.tAIKHOANTableAdapter.Connection.ConnectionString = Program.connstr;
                this.tAIKHOANTableAdapter.Update(this.DS.TAIKHOAN);
                MessageBox.Show("Xoá thành công nhân viên " + cmnd, "", MessageBoxButtons.OK);
           }
            catch (Exception ex)
             {
                MessageBox.Show("Lỗi xoá nhân viên. Bạn hãy xoá lại\n" + ex.Message, "", MessageBoxButtons.OK);
                this.tAIKHOANTableAdapter.Fill(this.DS.TAIKHOAN);
                bdsTK_FK.Position = bdsTK_FK.Find("CMND", cmnd);
                return;
            }
            if (bdsTK_FK.Count == 0) btnUpdate.Enabled = false;
        }

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.kHACHHANGTableAdapter.Connection.ConnectionString = Program.connstr;
                this.kHACHHANGTableAdapter.Fill(this.DS.KHACHHANG);
                this.tAIKHOANTableAdapter.Connection.ConnectionString = Program.connstr;
                this.tAIKHOANTableAdapter.Update(this.DS.TAIKHOAN);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi reload: " + ex.Message, "", MessageBoxButtons.OK);
                return;
            }
        }

        private void btnUndo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bdsKH.CancelEdit();//hai trường hợp: đang thêm bỏ thêm, đang sửa bỏ sửa
            if (btnAdd.Enabled == false) bdsKH.Position = vitri;
            gcKH.Enabled = gcTK.Enabled = true;

            panel2.Enabled = false;
            btnAdd.Enabled = btnUpdate.Enabled = btnDelete.Enabled = btnReload.Enabled = btnExit.Enabled = true;
            btnSave.Enabled = btnUndo.Enabled = false;
            dateEditNgayMoTK.Text = "";
        }

        private void btnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
    }
}
