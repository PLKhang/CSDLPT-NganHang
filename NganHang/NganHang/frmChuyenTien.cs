using NGANHANG;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace NganHang
{
    public partial class frmChuyenTien : Form
    {
        String macn = "";
        int vitri = 0;
        public frmChuyenTien()
        {
            InitializeComponent();
        }

        private void reload_Adapter()
        {
            // TODO: This line of code loads data into the 'dS.GetAllKH' table. You can move, or remove it, as needed.
            this.getAllKHTableAdapter.Connection.ConnectionString = Program.connstr;
            this.getAllKHTableAdapter.Fill(this.DS.GetAllKH);
            // TODO: This line of code loads data into the 'DS.TK_KH' table. You can move, or remove it, as needed.
            this.tK_KHTableAdapter.Connection.ConnectionString = Program.connstr;
            this.tK_KHTableAdapter.Fill(this.DS.TK_KH);
            // TODO: This line of code loads data into the 'DS.CHUYENTIEN_INFORECEIVER' table. You can move, or remove it, as needed.
            this.cHUYENTIEN_INFORECEIVERTableAdapter.Connection.ConnectionString = Program.connstr;
            this.cHUYENTIEN_INFORECEIVERTableAdapter.Fill(this.DS.CHUYENTIEN_INFORECEIVER);
        }
        private void resetText()
        {
            hOTextBox.Text = hOTENRECTextBox.Text = tENTextBox.Text = cMNDTextBox1.Text = cMNDTextBox.Text = txtSoTKChuyen.Text = sODUTextEdit.Text = txtSoTKNhan.Text = "";
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
            if (Program.KetNoi() == 0) System.Windows.Forms.MessageBox.Show("Lỗi kết nối về chi nhánh mới", "", MessageBoxButtons.OK);
            else
            {
                DS.EnforceConstraints = false;
                this.getAllKHTableAdapter.Connection.ConnectionString = Program.connstr;
                this.getAllKHTableAdapter.Fill(this.DS.GetAllKH);
                this.tK_KHTableAdapter.Connection.ConnectionString = Program.connstr;
                this.tK_KHTableAdapter.Fill(this.DS.TK_KH);
            }
        }

        private void kHACHHANGBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.getAllKHBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DS);

        }

        private void frmChuyenTien_Load(object sender, EventArgs e)
        {
            DS.EnforceConstraints = false;
            reload_Adapter();
            macn = ((DataRowView)getAllKHBindingSource[0])["MACN"].ToString();
            cmbChiNhanh.DataSource = Program.bds_dspm; // sao chép bds_ds đã load ở form đăng nhập
            cmbChiNhanh.DisplayMember = "TENCN";
            cmbChiNhanh.ValueMember = "TENSERVER";
            cmbChiNhanh.SelectedIndex = Program.mChinhanh;
            pnlGD.Enabled = true;
            txtMANV.Text = Program.username;
            if (Program.mGroup == "NganHang")
            {
                cmbChiNhanh.Enabled = true;
            }
            else
            {
                cmbChiNhanh.Enabled = false;
            }

        }

        private void btnChuyenTien_Click(object sender, EventArgs e)
        {
            if (txtSoTKChuyen.Text.Length != 9 || txtSoTKNhan.Text.Length != 9)
            {
                System.Windows.Forms.MessageBox.Show("Vui lòng chọn tài khoản chuyển/nhận", "", MessageBoxButtons.OK);
            }
            else if (nuSoTien.Value == 0)
            {
                System.Windows.Forms.MessageBox.Show("Số tiền chuyển phải lớn hơn 0 VND", "", MessageBoxButtons.OK);
            }
            else
            {
                try
                {
                    String dt = String.Format("{0:yyyy-MM-dd HH:mm:ss.fff}", DateTime.Now);
                    if (System.Windows.Forms.MessageBox.Show("Xác Nhận Giao Dịch??", "Xác nhận",
                    MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {

                        int result = Program.ExecSqlNonQuery("EXEC sp_ChuyenTien '" + txtSoTKChuyen.Text
                                                            + "','" + txtSoTKNhan.Text
                                                            + "','" + nuSoTien.Value
                                                            + "','" + dt
                                                            + "','" + txtMANV.Text + "'");
                        if (result == 0)
                        {
                            System.Windows.Forms.MessageBox.Show("Giao Dịch Thành Công ", "Success", MessageBoxButtons.OK);

                        }
                        else
                        {
                            System.Windows.Forms.MessageBox.Show("Giao Dịch Thất Bại ", "Fail", MessageBoxButtons.OK);

                        }
                    }

                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show("Lỗi reload: " + ex.Message, "", MessageBoxButtons.OK);
                }

                reload_Adapter();
                resetText();
                taiKhoanGridControl.Enabled = khachHangGridControl.Enabled = true;
                tK_KHBindingSource.Position = vitri;
                return;
            }
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            tK_KHBindingSource.Position = vitri;
            tK_KHBindingSource.CancelEdit();//hai trường hợp: đang thêm bỏ thêm, đang sửa bỏ sửa
            reload_Adapter();
            pnlGD.Enabled = false;
            khachHangGridControl.Enabled = taiKhoanGridControl.Enabled = true;
            resetText();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            tK_KHBindingSource.Position = vitri;
            tK_KHBindingSource.CancelEdit();//hai trường hợp: đang thêm bỏ thêm, đang sửa bỏ sửa
            reload_Adapter();
            resetText();
            pnlGD.Enabled = true;
            khachHangGridControl.Enabled = taiKhoanGridControl.Enabled = true;
            resetText();
            try
            {
                this.tK_KHTableAdapter.Connection.ConnectionString = Program.connstr;
                this.tK_KHTableAdapter.Fill(this.DS.TK_KH);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Lỗi reload: " + ex.Message, "", MessageBoxButtons.OK);
                return;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtSoTKNhan_TextChanged(object sender, EventArgs e)
        {
            if(txtSoTKNhan.Text.Trim() == txtSoTKChuyen.Text.Trim())
            {
                System.Windows.MessageBox.Show("Số TK nhận bị trùng số tk chuyển", "error", MessageBoxButton.OK);
                txtSoTKNhan.Text = ""; hOTENRECTextBox.Text = ""; cMNDTextBox.Text = "";
                return;
            }
        }

        private void khachHangGridControl_Click(object sender, EventArgs e)
        {

        }
    }
}
