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
using DevExpress.Data;

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

            cmbChiNhanh.DataSource = Program.bds_dspm; // sao chép bds_ds đã load ở form đăng nhập
            //cmbChiNhanh.DataSource = frmDangNhap.GetListSubcription("SELECT * FROM V_DS_PHANMANH");
            cmbChiNhanh.DisplayMember = "TENCN";
            cmbChiNhanh.ValueMember = "TENSERVER";
            cmbChiNhanh.SelectedIndex = Program.mChinhanh;

            panelControl3.Enabled = btnChuyenEmployee.Visible =  btnUndo.Enabled = btnSave.Enabled  = btnMoveEmployee.Enabled= btnChuyenEmployee.Enabled = false;

            if (Program.mGroup == "NganHang")
            {
                cmbChiNhanh.Enabled = true;
                btnAdd.Enabled = btnUpdate.Enabled = btnSave.Enabled = btnDelete.Enabled = btnMoveEmployee.Enabled = btnUndo.Enabled = btnUnDelete.Enabled = false;
            }
            else
            {
                btnAdd.Enabled = btnUpdate.Enabled = btnSave.Enabled = btnDelete.Enabled = btnMoveEmployee.Enabled = btnUndo.Enabled = btnUnDelete.Enabled = true;
                cmbChiNhanh.Enabled = false;
            }

        }
        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsNV.Position;           
            panelControl3.Enabled = true;
            bdsNV.AddNew();

            txtMACN.Text = macn;//tự gán mã chi nhánh = chi nhánh đang đăng nhập của tài khoản thuộc chi nhánh
            btnAdd.Enabled = btnUpdate.Enabled = btnDelete.Enabled = btnReload.Enabled = btnExit.Enabled = btnUnDelete.Enabled = btnMoveEmployee.Enabled = false;
            btnSave.Enabled = btnUndo.Enabled = true;
            gcNV.Enabled = false; txtMACN.Enabled = false;
            btn_Add_clicked = true; 

            // Tạo mã nhân viên mới gán vào ô mã
            string strlenh1 = "EXEC sp_TaoMaNV";
            Program.myReader = Program.ExecSqlDataReader(strlenh1);
            Program.myReader.Read();
            string generatedStaffId = Program.myReader.GetString(0);
            Program.myReader.Close();
            txtMANV.Text = generatedStaffId;
        }

        private void btnUndo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bdsNV.CancelEdit();//hai trường hợp: đang thêm bỏ thêm, đang sửa bỏ sửa
            if (btnAdd.Enabled == false) bdsNV.Position = vitri;
            gcNV.Enabled = true;
            panelControl3.Enabled = false;
            btnAdd.Enabled = btnUpdate.Enabled = btnDelete.Enabled = btnReload.Enabled = btnExit.Enabled = btnUnDelete.Enabled = btnMoveEmployee.Enabled = true;
            btnChuyenEmployee.Visible = false;
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
                btnAdd.Enabled = btnUpdate.Enabled = btnDelete.Enabled = btnReload.Enabled = btnExit.Enabled = btnUnDelete.Enabled = btnMoveEmployee.Enabled = false;
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
            manv = (((DataRowView)bdsNV[bdsNV.Position])["MANV"].ToString().TrimEnd());//giữ lại vị trí nv hiện tại
            int trang_thai_xoa = int.Parse(((DataRowView)bdsNV[bdsNV.Position])["TrangThaiXoa"].ToString().TrimEnd());
            if (trang_thai_xoa == 1)
            {
                MessageBox.Show("Không thể xoá nhân viên đã nghỉ", "", MessageBoxButtons.OK);
                return;
            }        
            if (manv == Program.username)
            {
                MessageBox.Show("Không thể xóa nhân viên đang đăng nhập", "", MessageBoxButtons.OK);
                return;
            }
            if (MessageBox.Show("Bạn có thật sự muốn xoá nhân viên " + manv + " ??", "Xác nhận",
                MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    //bdsNV.RemoveCurrent();
                    //this.NHANVIENTableAdapter.Connection.ConnectionString = Program.connstr;
                    //this.NHANVIENTableAdapter.Update(this.DS.NHANVIEN);
                    //MessageBox.Show("Xoá thành công nhân viên " + manv, "", MessageBoxButtons.OK);

                    int result = Program.ExecSqlAndGetReturnedValue2("sp_XoaNV", new SqlParameter("@MANV", manv));
                    switch (result)
                    {
                        case 0:
                            MessageBox.Show("Xóa nhân viên thành công!\nNhân viên có MANV = " + manv +" đã được đặt trạng thái xóa là True.", "Success!", MessageBoxButtons.OK);
                            
                            //Nếu NV có tài khoản thì xóa login
                            int existUsername = Program.ExecSqlAndGetReturnedValue2("sp_Existed_Username", new SqlParameter("@Username", manv));
                            if (existUsername == 1)
                            {
                                int deleteLoginCompleted = Program.DeleteLogin(manv);
                                if (deleteLoginCompleted == 0)
                                    MessageBox.Show("Đã xóa tài khoản login!\nNhân viên " + manv + " sẽ không thể đăng nhập vào chi nhánh này!", "Xóa login thành công", MessageBoxButtons.OK);
                                else if (deleteLoginCompleted == 1)
                                    MessageBox.Show("Có lỗi hệ thống khi xóa login của NV: " + manv, "Xóa login không thành công", MessageBoxButtons.OK);

                            }
                            break;
                        case 1:
                            MessageBox.Show("MANV không tồn tại", "Lỗi", MessageBoxButtons.OK);
                            break;
                        case 2:
                            MessageBox.Show("Không thể xóa nhân viên đã bị xóa", "Lỗi", MessageBoxButtons.OK);
                            break;
                        default:
                            MessageBox.Show("SP_XoaNV trả về giá trị không mong muốn.", "Lỗi", MessageBoxButtons.OK);
                            break;
                    }
                    //RELOAD lại dsNV
                    this.NHANVIENTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.NHANVIENTableAdapter.Fill(this.DS.NHANVIEN);
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
            //String cmnd = ((DataRowView)bdsNV[bdsNV.Position])["CMND"].ToString().TrimEnd();
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
                MessageBox.Show("Số điện thoại nhân viên không đúng 10 chữ số!", "", MessageBoxButtons.OK);
                txtSODT.Focus();
                return;
            }
            if (!txtCMND.Text.All(Char.IsDigit))
            {
                MessageBox.Show("CMND nhân viên không hợp lệ!", "", MessageBoxButtons.OK);
                txtCMND.Focus();
                return;
            }
            if (txtCMND.Text.Length != 10)
            {
                MessageBox.Show("CMND của khách hàng không đúng định dạng (10 số)", "", MessageBoxButtons.OK);
                txtCMND.Focus();
                return;
            }
            if (txtCMND.Text.Trim() == "")
            {
                MessageBox.Show("CMND của khách hàng không được trống!", "", MessageBoxButtons.OK);
                txtCMND.Focus();
                return;
            }
            if (btn_Add_clicked)
            {
                int tmp = Program.ExecSqlAndGetReturnedValue2("sp_Existed_CMND_NV", new SqlParameter("@CMND", txtCMND.Text));
                Debug.WriteLine("sp return: " + tmp);
                if (tmp == 1)
                {
                    MessageBox.Show("CMND nhân viên đã tồn tại! \nVui lòng nhập lại!", "", MessageBoxButtons.OK);
                    return;
                }
                else
                {
                    
                    try {
                        string cmd = "EXEC sp_ThemNV '" + txtCMND.Text + "',"
                            + "N'" + txtHO.Text + "',"
                            + "N'" + txtTEN.Text + "',"
                            + "N'" + cmbPHAI.Text + "',"
                            + "'" + txtSODT.Text + "',"
                            + "N'" + txtDIACHI.Text + "'";

                        Program.ExecSqlNonQuery(cmd);
                        MessageBox.Show("Lưu thành công!!", "", MessageBoxButtons.OK);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi lưu nhân viên. \n" + ex.Message, "", MessageBoxButtons.OK);
                        return;
                    }
                }
            }
            else
            {
                try
                {
                    /*bdsNV.EndEdit(); //kết thúc quá trình hiệu chỉnh (ghi vào datasource)
                    bdsNV.ResetCurrentItem();//đưa thông tin lên lưới
                    this.NHANVIENTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.NHANVIENTableAdapter.Update(this.DS.NHANVIEN);
                    Program.myReader.Close();*/
                    /*string cmd = "EXEC sp_SuaThongTinNV '" + txtMANV.Text + "',"
                        + "'" + txtCMND.Text + "',"
                        + "N'" + txtHO.Text + "',"
                        + "N'" + txtTEN.Text + "',"
                        + "N'" + cmbPHAI.Text + "',"
                        + "'" + txtSODT.Text + "',"
                        + "N'" + txtDIACHI.Text + "'";*/
                    //Program.ExecSqlNonQuery(cmd);

                    int result = Program.ExecSqlAndGetReturnedValue2("sp_SuaThongTinNV",
                                                                    new SqlParameter("@MANV", txtMANV.Text),
                                                                    new SqlParameter("@CMND", txtCMND.Text),
                                                                    new SqlParameter("@HO", txtHO.Text),
                                                                    new SqlParameter("@TEN", txtTEN.Text),
                                                                    new SqlParameter("@PHAI", cmbPHAI.Text),
                                                                    new SqlParameter("@SODT", txtSODT.Text),
                                                                    new SqlParameter("@DIACHI", txtDIACHI.Text));
                    if (result == 2)
                    {
                        MessageBox.Show("Trùng CMND với nhân viên khác!!", "Lỗi", MessageBoxButtons.OK);
                        return;
                    }
                    else if (result == 0)
                    {
                        MessageBox.Show("Lưu thành công!!", "Success", MessageBoxButtons.OK);  
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi ghi nhân viên. \n" + ex.Message, "", MessageBoxButtons.OK);
                    return;
                }
            }

            //RELOAD lại dsNV
            this.NHANVIENTableAdapter.Connection.ConnectionString = Program.connstr;
            this.NHANVIENTableAdapter.Fill(this.DS.NHANVIEN);

            gcNV.Enabled = true;
            btnAdd.Enabled = btnUpdate.Enabled = btnDelete.Enabled = btnReload.Enabled = btnExit.Enabled = true;
            btnSave.Enabled = btnUndo.Enabled = false;
            panelControl3.Enabled = false;

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
                this.NHANVIENTableAdapter.Connection.ConnectionString = Program.connstr;
                this.NHANVIENTableAdapter.Fill(this.DS.NHANVIEN);

                this.gD_CHUYENTIENTableAdapter.Connection.ConnectionString = Program.connstr;
                this.gD_CHUYENTIENTableAdapter.Fill(this.DS.GD_CHUYENTIEN);

                this.gD_GOIRUTTableAdapter.Connection.ConnectionString = Program.connstr;
                this.gD_GOIRUTTableAdapter.Fill(this.DS.GD_GOIRUT);
                //macn = ((DataRowView)bdsNV[0])["MACN"].ToString();
            }
        }


        private void btnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void btnMoveEmployee_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int trang_thai_xoa = int.Parse(((DataRowView)bdsNV[bdsNV.Position])["TrangThaiXoa"].ToString().TrimEnd());
            String manv = (((DataRowView)bdsNV[bdsNV.Position])["MANV"].ToString().TrimEnd());
            if (manv == Program.username)
            {
                MessageBox.Show("Không thể chuyển nhân viên đang đăng nhập", "", MessageBoxButtons.OK);
                return;
            }
            else if (trang_thai_xoa == 0)
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
            try
            {
                if (MessageBox.Show("Bạn muốn chuyển nhân viên " + manv + " sang chi nhánh khac " + "??", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    Program.ExecSqlNonQuery("EXEC sp_ChuyenChiNhanh '" + manv + "'");
                    //Nếu NV có tài khoản thì xóa login
                    int existUsername = Program.ExecSqlAndGetReturnedValue2("sp_Existed_Username", new SqlParameter("@Username", manv));
                    if (existUsername == 1)
                    {
                        int deleteLoginCompleted = Program.DeleteLogin(manv);
                        if (deleteLoginCompleted == 0)
                            MessageBox.Show("Đã xóa tài khoản login!\nNhân viên " + manv + " sẽ không thể đăng nhập vào chi nhánh này!", "Xóa login thành công", MessageBoxButtons.OK);
                        else if (deleteLoginCompleted == 1)
                            MessageBox.Show("Có lỗi hệ thống khi xóa login của NV: " + manv, "Xóa login không thành công", MessageBoxButtons.OK);

                    }
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

        private void btnUnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            String manv = (((DataRowView)bdsNV[bdsNV.Position])["MANV"].ToString().TrimEnd());//giữ lại vị trí nv hiện tại
            int trang_thai_xoa = int.Parse(((DataRowView)bdsNV[bdsNV.Position])["TrangThaiXoa"].ToString().TrimEnd());
            if (trang_thai_xoa == 0)
            {
                MessageBox.Show("Nhân viên này chưa bị xóa!", "Fail!", MessageBoxButtons.OK);
                return;
            }
            if (MessageBox.Show("Bạn có thật sự muốn hủy xóa cho nhân viên: " + manv + "?", "Xác nhận!",
                MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    //bdsNV.RemoveCurrent();
                    //this.NHANVIENTableAdapter.Connection.ConnectionString = Program.connstr;
                    //this.NHANVIENTableAdapter.Update(this.DS.NHANVIEN);
                    //MessageBox.Show("Xoá thành công nhân viên " + manv, "", MessageBoxButtons.OK);

                    int result = Program.ExecSqlAndGetReturnedValue2("sp_HuyXoaNV", new SqlParameter("@MANV", manv));
                    switch (result)
                    {
                        case 0:
                            MessageBox.Show("Khôi phục nhân viên thành công!\nNhân viên có MANV = " + manv + " đã được đặt trạng thái xóa là False.", "Success!", MessageBoxButtons.OK);
                            break;
                        case 1:
                            MessageBox.Show("MANV không tồn tại!", "Lỗi", MessageBoxButtons.OK);
                            break;
                        case 2:
                            MessageBox.Show("Không thể thao tác cho nhân viên chưa bị xóa!", "Lỗi", MessageBoxButtons.OK);
                            break;
                        case 3:
                            MessageBox.Show("Nhân viên đang làm việc tại chi nhánh khác!", "Lỗi", MessageBoxButtons.OK);
                            break;
                        default:
                            MessageBox.Show("SP_HuyXoaNV trả về giá trị không mong muốn.", "Lỗi", MessageBoxButtons.OK);
                            break;
                    }
                    //RELOAD lại dsNV
                    this.NHANVIENTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.NHANVIENTableAdapter.Fill(this.DS.NHANVIEN);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi khôi phục nhân viên. Thử lại!\n" + ex.Message, "", MessageBoxButtons.OK);
                    this.NHANVIENTableAdapter.Fill(this.DS.NHANVIEN);
                    bdsNV.Position = bdsNV.Find("MANV", manv);
                    return;
                }
            }
        }
    }
}
