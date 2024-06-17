﻿using NGANHANG;
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
    public partial class frmKH : Form
    {
        int vitri = 0;
        String macn = "";
        bool btn_Add_clicked = false;
        public frmKH()
        {
            InitializeComponent();
        }

        private void kHACHHANGBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsKH.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DS);

        }

        private void frmKH_Load(object sender, EventArgs e)
        {
            DS.EnforceConstraints = false;
            this.KHACHHANGTableAdapter.Connection.ConnectionString = Program.connstr;
            this.KHACHHANGTableAdapter.Fill(this.DS.KHACHHANG);

            macn = ((DataRowView)bdsKH[0])["MACN"].ToString();
            cmbChiNhanh.DataSource = Program.bds_dspm; // sao chép bds_ds đã load ở form đăng nhập
            cmbChiNhanh.DisplayMember = "TENCN";
            cmbChiNhanh.ValueMember = "TENSERVER";
            cmbChiNhanh.SelectedIndex = Program.mChinhanh;
            panelControl2.Enabled = btnUndo.Enabled = btnSave.Enabled = false;
            if (Program.mGroup == "NganHang")
            {
                cmbChiNhanh.Enabled = true;
                btnAdd.Enabled = btnUpdate.Enabled = btnSave.Enabled = btnDelete.Enabled = btnUndo.Enabled = false;
            }
            else
            {
                btnAdd.Enabled = btnUpdate.Enabled = btnSave.Enabled = btnDelete.Enabled  = btnUndo.Enabled = true;
                cmbChiNhanh.Enabled = false;
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
                this.KHACHHANGTableAdapter.Connection.ConnectionString = Program.connstr;
                this.KHACHHANGTableAdapter.Fill(this.DS.KHACHHANG);
            }
        }

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsKH.Position;
            panelControl2.Enabled = true;
            txtCMND.Focus();
            bdsKH.AddNew();
            txtMACN.Text = macn;//tự gán mã chi nhánh = chi nhánh đang đăng nhập của tài khoản thuộc chi nhánh
            btnAdd.Enabled = btnUpdate.Enabled = btnDelete.Enabled = btnReload.Enabled = btnExit.Enabled = false;
            btnSave.Enabled = btnUndo.Enabled = true;
            gcKH.Enabled = false; txtMACN.Enabled = false;
            btn_Add_clicked = true;
        }

        private void btnUpdate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsKH.Position;
            panelControl2.Enabled = true;
            btnAdd.Enabled = btnUpdate.Enabled = btnDelete.Enabled = btnReload.Enabled = btnExit.Enabled = false;
            btnSave.Enabled = btnUndo.Enabled = true;
            gcKH.Enabled = false; txtMACN.Enabled = false;
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            String CMND = ((DataRowView)bdsKH[bdsKH.Position])["CMND"].ToString();
            if (txtCMND.Text.Length != 10)
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
            if (dateNgayCap.DateTime > DateTime.Now || dateNgayCap.Text.Trim() == "")
            {
                MessageBox.Show("Ngày cấp CMND khách hàng trống hoặc mốc thời gian là trước hiện tại", "", MessageBoxButtons.OK);
                dateNgayCap.Focus();
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
            // Kiểm tra cmnd tồn tại trên site chủ
            //viết 1 SP kiểm tra mã trùng. gọi SP đó thông qua hàm ExecSqlDataReader dưới dạng có hay không!! 
            if (btn_Add_clicked == true || CMND != txtCMND.Text)//khi click update, MANV mới khác với MANV cũ thì kiểm tra có trùng MANV không
            {
                Program.myReader.Close();
                string strlenh1 = "EXEC sp_Existed_CMND_KH '" + txtCMND.Text + "'";
                Program.myReader = Program.ExecSqlDataReader(strlenh1);
                Program.myReader.Read();
                if (Program.myReader.HasRows)
                {
                    MessageBox.Show("CMND khách hàng đã tồn tại \nVui lòng nhập lại", "", MessageBoxButtons.OK);
                    return;
                }
                Program.myReader.Close();
            }
            String dt = String.Format("{0:yyyy-MM-dd HH:mm:ss.fff}", DateTime.Now);
            //Program.ExecSqlNonQuery("EXEC sp_ThemKH '" + txtCMND.Text + "','" + txtHO.Text + "','" + txtTEN.Text + "','" + txtDIACHI.Text + "','" + cmbPhai.SelectedItem.ToString() + "','" + dt + "','" + txtSODT.Text + "','" + macn + "'");
            //this.KHACHHANGTableAdapter.Connection.ConnectionString = Program.connstr;
            //this.KHACHHANGTableAdapter.Update(this.DS.KHACHHANG); 
            try
            {
                bdsKH.EndEdit(); //kết thúc quá trình hiệu chỉnh (ghi vào datasource)
                bdsKH.ResetCurrentItem();//đưa thông tin lên lưới
                this.KHACHHANGTableAdapter.Connection.ConnectionString = Program.connstr;
                this.KHACHHANGTableAdapter.Update(this.DS.KHACHHANG);
                MessageBox.Show("Lưu thành công!!", "", MessageBoxButtons.OK);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ghi khách hàng. \n" + ex.Message, "", MessageBoxButtons.OK);
                return;
            }
            gcKH.Enabled = true;
            btnAdd.Enabled = btnUpdate.Enabled = btnDelete.Enabled = btnReload.Enabled = btnExit.Enabled = true;
            btnSave.Enabled = btnUndo.Enabled = false;
            panelControl2.Enabled = false;
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Double cmnd = Double.Parse(((DataRowView)bdsKH[bdsKH.Position])["CMND"].ToString().TrimEnd());
            //Program.myReader.Close();
            //string strlenh1 = "EXEC frmKhachHang_ExistsGD '" + txtCMND.Text + "'";
            //Program.myReader = Program.ExecSqlDataReader(strlenh1);
            //Program.myReader.Read();
            //if (Program.myReader.HasRows)
            //{
            //    MessageBox.Show("Khách hàng đã thực hiện giao dịch \nKhông thể xoá", "", MessageBoxButtons.OK);
            //    return;
            //}
            //Program.myReader.Close();
            if (bdsTK.Count > 0)
            {
                MessageBox.Show("Không thể xoá khách hàng, vì đã tài khoản liên kết với khách hàng", "", MessageBoxButtons.OK);
                return;
            }    
            if (MessageBox.Show("Bạn có thật sự muốn xoá khách hàng có CMND " + cmnd + " ??", "Xác nhận",
                    MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    bdsKH.RemoveCurrent();
                    this.KHACHHANGTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.KHACHHANGTableAdapter.Update(this.DS.KHACHHANG);
                    //Program.ExecSqlNonQuery("EXEC frmKhachHang_DeleteAccountNonGD '" + cmnd + "'");
                    MessageBox.Show("Xoá thành công khánh hàng có CMND " + cmnd, "", MessageBoxButtons.OK);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xoá CMND. Bạn hãy xoá lại\n" + ex.Message, "", MessageBoxButtons.OK);
                    this.KHACHHANGTableAdapter.Fill(this.DS.KHACHHANG);
                    bdsKH.Position = bdsKH.Find("CMND", cmnd);
                    return;
                }
            }
            if (bdsKH.Count == 0) btnDelete.Enabled = false; //hết khách hàng rồi thì k xoá đc nữa
        }

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.KHACHHANGTableAdapter.Connection.ConnectionString = Program.connstr;
                this.KHACHHANGTableAdapter.Fill(this.DS.KHACHHANG);
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
            gcKH.Enabled = true;

            panelControl2.Enabled = false;
            btnAdd.Enabled = btnUpdate.Enabled = btnDelete.Enabled = btnReload.Enabled = btnExit.Enabled = true;
            btnSave.Enabled = btnUndo.Enabled = false;
        }

        private void btnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
    }
}
