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
using System.Diagnostics;
using System.Windows.Forms;
using DevExpress.XtraRichEdit.Model;
using System.Data.SqlClient;

namespace NganHang
{
    public partial class frmNV : Form
    {
   
        int vitri;
        String macn = "";
        bool btn_Add_clicked = false;
        public frmNV()
        {
            InitializeComponent();
        }

        private void frmNV_Load(object sender, EventArgs e)
        {
            DS.EnforceConstraints = false;
            this.dS_CHINHANHTableAdapter.Fill(this.DS.DS_CHINHANH);

            this.NHANVIENTableAdapter.Connection.ConnectionString = Program.connstr;
            this.NHANVIENTableAdapter.Fill(this.DS.NHANVIEN);

            this.gD_CHUYENTIENTableAdapter.Connection.ConnectionString = Program.connstr;
            this.gD_CHUYENTIENTableAdapter.Fill(this.DS.GD_CHUYENTIEN);

            this.gD_GOIRUTTableAdapter.Connection.ConnectionString = Program.connstr;
            this.gD_GOIRUTTableAdapter.Fill(this.DS.GD_GOIRUT);
            
            macn = ((DataRowView)bdsNV[0])["MACN"].ToString();

            BindingSource newBindingSource = new BindingSource(Program.bds_dspm.DataSource, Program.bds_dspm.DataMember);

            //cmbChiNhanh.DataSource = Program.bds_dspm; // sao chép bds_ds đã load ở form đăng nhập
            cmbChiNhanh.DataSource = frmDangNhap.GetListSubcription("SELECT * FROM V_DS_PHANMANH");
            cmbChiNhanh.DisplayMember = "TENCN";
            cmbChiNhanh.ValueMember = "TENSERVER";
            cmbChiNhanh.SelectedIndex = Program.mChinhanh;

            /*cmbCNFinal.DataSource = newBindingSource; // sao chép bds_ds đã load ở form đăng nhập
            cmbCNFinal.DisplayMember = "TENCN";
            cmbCNFinal.ValueMember = "TENSERVER";
            cmbCNFinal.SelectedIndex = Program.mChinhanh;*/


            panelControl3.Enabled = btnChuyenEmployee.Visible =  btnUndo.Enabled = btnSave.Enabled  = btnMoveEmployee.Enabled= btnChuyenEmployee.Enabled = false;

            if (Program.mGroup == "NganHang")
            {
                cmbChiNhanh.Enabled = true;
                btnAdd.Enabled = btnUpdate.Enabled = btnSave.Enabled = btnDelete.Enabled = btnMoveEmployee.Enabled = btnUndo.Enabled = false;
            }
            else
            {
                btnAdd.Enabled = btnUpdate.Enabled = btnSave.Enabled = btnDelete.Enabled = btnMoveEmployee.Enabled = btnUndo.Enabled = true;
                cmbChiNhanh.Enabled = false;
            }

        }
        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsNV.Position;
            txtMANV.Focus();
            panelControl3.Enabled = true;
            bdsNV.AddNew();

            txtMACN.Text = macn;//tự gán mã chi nhánh = chi nhánh đang đăng nhập của tài khoản thuộc chi nhánh
            btnAdd.Enabled = btnUpdate.Enabled = btnDelete.Enabled = btnReload.Enabled = btnExit.Enabled = false;
            btnSave.Enabled = btnUndo.Enabled = true;
            gcNV.Enabled = false; txtMACN.Enabled = false;
            btn_Add_clicked = true;
            trangThaiXoaCheckBox.Checked = false; 
            // Tạo mã nhân viên mới gán vào ô mã
            string strlenh1 = "EXEC sp_TaoMaNV";
            Program.myReader = Program.ExecSqlDataReader(strlenh1);
            Program.myReader.Read();
            //Debug.WriteLine(Program.myReader.GetString(0));
            string generatedStaffId = Program.myReader.GetString(0);
            Program.myReader.Close();
            txtMANV.Text = generatedStaffId;
            //program.myreader = program.execsqldatareader(strlenh1);
            //Console.Write()
            //if (Program.myReader == null) return;
            //Program.myReader.Read();
        }

        private void btnUndo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bdsNV.CancelEdit();//hai trường hợp: đang thêm bỏ thêm, đang sửa bỏ sửa
            if (btnAdd.Enabled == false) bdsNV.Position = vitri;
            gcNV.Enabled = true;
            panelControl3.Enabled = false;
            btnAdd.Enabled = btnUpdate.Enabled = btnDelete.Enabled = btnReload.Enabled = btnExit.Enabled = true;
            btnSave.Enabled = btnUndo.Enabled = false;
        }

        private void btnUpdate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //chỉ cho sửa thông tin nếu TTX = 0
            int trang_thai_xoa = int.Parse(((DataRowView)bdsNV[bdsNV.Position])["TrangThaiXoa"].ToString().TrimEnd());
            if (trang_thai_xoa == 0)
            {
                vitri = bdsNV.Position;
                panelControl3.Enabled = true;
                btnAdd.Enabled = btnUpdate.Enabled = btnDelete.Enabled = btnReload.Enabled = btnExit.Enabled = false;
                btnSave.Enabled = btnUndo.Enabled = true;
                gcNV.Enabled = false; txtMACN.Enabled = false;
            } else
            {
                MessageBox.Show("Không Thể Chỉnh Sửa Thông Tin Của Nhân Viên Đã Xoá", "ERROR",MessageBoxButtons.OK);
                return;
            }

        }

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.NHANVIENTableAdapter.Connection.ConnectionString = Program.connstr;
                this.NHANVIENTableAdapter.Fill(this.DS.NHANVIEN);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi reload: " + ex.Message, "", MessageBoxButtons.OK);
                return;
            }
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            String manv = "";
            manv = (((DataRowView)bdsNV[bdsNV.Position])["MANV"].ToString().TrimEnd());
            int trang_thai_xoa = int.Parse(((DataRowView)bdsNV[bdsNV.Position])["TrangThaiXoa"].ToString().TrimEnd());
            if (trang_thai_xoa == 1)
            {
                MessageBox.Show("Không thể xoá nhân viên đã nghỉ", "", MessageBoxButtons.OK);
                return;
            }
            if (bdsGR.Count > 0)
            {
                MessageBox.Show("Không thể xoá nhân viên, vì đã thực hiện giao dịch gửi rút tiền cho khách hàng", "", MessageBoxButtons.OK);
                return;
            }
            if (bdsCT.Count > 0)
            {
                MessageBox.Show("Không thể xoá nhân viên, vì đã thực hiện giao dịch chuyển tiền cho khách hàng", "", MessageBoxButtons.OK);
                return;
            }
            
            if (MessageBox.Show("Bạn có thật sự muốn xoá nhân viên " + manv + " ??", "Xác nhận",
                MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    //manv = int.Parse(((DataRowView)bdsNV[bdsNV.Position])["MANV"].ToString()); //giữ lại vị trí nv hiện tại
                    bdsNV.RemoveCurrent();
                    this.NHANVIENTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.NHANVIENTableAdapter.Update(this.DS.NHANVIEN);
                    MessageBox.Show("Xoá thành công nhân viên " + manv, "", MessageBoxButtons.OK);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xoá nhân viên. Bạn hãy xoá lại\n" + ex.Message, "", MessageBoxButtons.OK);
                    this.NHANVIENTableAdapter.Fill(this.DS.NHANVIEN);
                    bdsNV.Position = bdsNV.Find("MANV", manv);
                    return;
                }
            }
            if (bdsNV.Count == 0) btnDelete.Enabled = false; //hết nhân viên rồi thì k xoá đc nữa
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            String manv = ((DataRowView)bdsNV[bdsNV.Position])["MANV"].ToString().TrimEnd();
            String cmnd = ((DataRowView)bdsNV[bdsNV.Position])["CMND"].ToString().TrimEnd();
            if (txtMANV.Text.Trim() == "")
            {
                MessageBox.Show("Mã nhân viên không được trống", "", MessageBoxButtons.OK);
                txtMANV.Focus();
                return;
            }
            if (txtHO.Text.Trim() == "")
            {
                MessageBox.Show("Họ nhân viên không được trống", "", MessageBoxButtons.OK);
                txtHO.Focus();
                return;
            }
            if (txtTEN.Text.Trim() == "")
            {
                MessageBox.Show("Tên nhân viên không được trống", "", MessageBoxButtons.OK);
                txtTEN.Focus();
                return;
            }
            if (txtDIACHI.Text.Trim() == "")
            {
                MessageBox.Show("Địa chỉ không được trống", "", MessageBoxButtons.OK);
                txtDIACHI.Focus();
                return;
            }
            if (!txtSODT.Text.All(Char.IsDigit))
            {
                MessageBox.Show("Số điện thoại không hợp lệ", "", MessageBoxButtons.OK);
                txtSODT.Focus();
                return;
            }
            if (txtSODT.Text.Length != 10)
            {
                MessageBox.Show("Số điện thoại nhân viên không đúng 10 chữ số", "", MessageBoxButtons.OK);
                txtSODT.Focus();
                return;
            }
            if (!txtCMND.Text.All(Char.IsDigit))
            {
                MessageBox.Show("CMND nhân viên không hợp lệ", "", MessageBoxButtons.OK);
                txtCMND.Focus();
                return;
            }
            if (txtCMND.Text.Length < 10)
            {
                MessageBox.Show("CMND của khách hàng không đúng định dạng (10 số)", "", MessageBoxButtons.OK);
                txtCMND.Focus();
                return;
            }
            if (txtCMND.Text.Trim() == "")
            {
                MessageBox.Show("CMND của khách hàng không được trống", "", MessageBoxButtons.OK);
                txtCMND.Focus();
                return;
            }
 
            // Kiểm tra mã nhân viên tồn tại trên site chủ
            //viết 1 SP kiểm tra mã trùng. gọi SP đó thông qua hàm ExecSqlDataReader dưới dạng có hay không!! 
            if ( cmnd != txtCMND.Text.TrimEnd())
            {
                Program.myReader.Close();
                string strlenh1 = "EXEC sp_Existed_CMND_NV '" + txtCMND.Text.TrimEnd() + "'";
                Program.myReader = Program.ExecSqlDataReader(strlenh1);
                int tmp = int.Parse(Program.myReader.GetString(0));
                Program.myReader.Read();
                
                if (tmp == 1)
                {
                    MessageBox.Show("CMND nhân viên đã tồn tại \nVui lòng nhập lại", "", MessageBoxButtons.OK);
                    return;
                }
                Program.myReader.Close();
            }


            try
            {
                //bdsNV.EndEdit(); //kết thúc quá trình hiệu chỉnh (ghi vào datasource)
                //bdsNV.ResetCurrentItem();//đưa thông tin lên lưới
                //this.NHANVIENTableAdapter.Connection.ConnectionString = Program.connstr;
                //this.NHANVIENTableAdapter.Update(this.DS.NHANVIEN);
                //Program.myReader.Close();
                string cmd = "EXEC sp_SuaThongTinNV '" + txtMANV.Text + "'," 
                    + "'" + txtCMND.Text + "'," 
                    + "N'" + txtHO.Text + "'," 
                    + "N'" + txtTEN.Text + "'," 
                    + "N'" + cmbPHAI.Text + "'," 
                    + "'" + txtSODT.Text + "'," 
                    + "N'" + txtDIACHI.Text + "'";

                Program.myReader = Program.ExecSqlDataReader(cmd);
                Program.myReader.Close();
                MessageBox.Show("Lưu thành công!!", "", MessageBoxButtons.OK);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ghi nhân viên. \n" + ex.Message, "", MessageBoxButtons.OK);
                return;
            }
            gcNV.Enabled = true;
            btnAdd.Enabled = btnUpdate.Enabled = btnDelete.Enabled = btnReload.Enabled = btnExit.Enabled = true;
            btnSave.Enabled = btnUndo.Enabled = false;
            panelControl3.Enabled = false;
        }

        private void cmbChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cmbChiNhanh.SelectedValue.ToString() == "System.Data.DataRowView")
            //    return;
            //Program.servername = cmbChiNhanh.SelectedValue.ToString();
            //if (cmbChiNhanh.SelectedIndex != Program.mChinhanh)
            //{
            //    Program.mlogin = Program.remotelogin;
            //    Program.password = Program.remotepassword;
            //}
            //else
            //{
            //    Program.mlogin = Program.mloginDN;
            //    Program.password = Program.passwordDN;
            //}
            //if (Program.KetNoi() == 0) MessageBox.Show("Lỗi kết nối về chi nhánh mới", "", MessageBoxButtons.OK);
            //else
            //{
            //    this.NHANVIENTableAdapter.Connection.ConnectionString = Program.connstr;
            //    this.NHANVIENTableAdapter.Fill(this.DS.NHANVIEN);

            //    this.gD_CHUYENTIENTableAdapter.Connection.ConnectionString = Program.connstr;
            //    this.gD_CHUYENTIENTableAdapter.Fill(this.DS.GD_CHUYENTIEN);

            //    this.gD_GOIRUTTableAdapter.Connection.ConnectionString = Program.connstr;
            //    this.gD_GOIRUTTableAdapter.Fill(this.DS.GD_GOIRUT);
            //    //macn = ((DataRowView)bdsNV[0])["MACN"].ToString();
            //}

            if (cmbChiNhanh.SelectedValue.ToString() == "System.Data.DataRowView")
            {
                return;
            }

            Program.servername1 = cmbChiNhanh.SelectedValue.ToString();
            if (Program.KetNoiCosoKhac() == 0) return;
            else
            {
                this.NHANVIENTableAdapter.Connection.ConnectionString = Program.connstr1;
                this.NHANVIENTableAdapter.Fill(this.DS.NHANVIEN);

                gD_CHUYENTIENTableAdapter.Connection.ConnectionString = Program.connstr1;
                this.gD_CHUYENTIENTableAdapter.Fill(this.DS.GD_CHUYENTIEN);

                gD_GOIRUTTableAdapter.Connection.ConnectionString = Program.connstr1;
                this.gD_GOIRUTTableAdapter.Fill(this.DS.GD_GOIRUT);
            }
        }


        private void btnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void btnMoveEmployee_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int trang_thai_xoa = int.Parse(((DataRowView)bdsNV[bdsNV.Position])["TrangThaiXoa"].ToString().TrimEnd());
            if(trang_thai_xoa == 0)
            {
                btnUndo.Enabled = btnExit.Enabled = btnChuyenEmployee.Visible = btnChuyenEmployee.Enabled = btnChuyenEmployee.Enabled = true;
                panelControl3.Enabled = btnAdd.Enabled = btnUpdate.Enabled = btnDelete.Enabled = btnReload.Enabled = btnSave.Enabled = gcNV.Enabled = false;
            }
            else
            {
                MessageBox.Show("Khong the chuyen nhan vien da xoa", "ERROR", MessageBoxButtons.OK);
                return;
            }
        }

        private void btnChuyenEmployee_Click(object sender, EventArgs e)
        {
            vitri = bdsNV.Position;
            String manv = (((DataRowView)bdsNV[bdsNV.Position])["MANV"].ToString().TrimEnd());
            //string MACN = cmbCNFinal.SelectedValue.ToString();
            //if (cmbCNFinal.SelectedIndex == Program.mChinhanh)
            //{
            //    MessageBox.Show("Chi nhánh chuyển đi phải khác chi nhánh ban đầu", "", MessageBoxButtons.OK);
            //    return;
            //}
            try
            {
                if (MessageBox.Show("Bạn muốn chuyển nhân viên " + manv + " sang chi nhánh khac " + "??", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    Program.ExecSqlNonQuery("EXEC sp_ChuyenChiNhanh '" + manv + "'");
                }
                
                MessageBox.Show("Success" , "Info", MessageBoxButtons.OK);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi chuyen nhân viên. \n" + ex.Message, "", MessageBoxButtons.OK);
                return;
            }
            btnAdd.Enabled = btnUpdate.Enabled = btnDelete.Enabled = btnReload.Enabled = btnExit.Enabled = gcNV.Enabled = true;
            btnSave.Enabled = btnUndo.Enabled  = btnChuyenEmployee.Enabled = false;
            this.NHANVIENTableAdapter.Fill(this.DS.NHANVIEN);
        }

    }
}
