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
                this.khachHangTableAdapter.Connection.ConnectionString = Program.connstr;
                this.khachHangTableAdapter.Fill(this.DS.KHACHHANG);
                this.taiKhoanTableAdapter.Connection.ConnectionString = Program.connstr;
                this.taiKhoanTableAdapter.Fill(this.DS.TAIKHOAN);
            }
        }

        private void kHACHHANGBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsKH.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DS);

        }

        private void frmChuyenTien_Load(object sender, EventArgs e)
        {
            DS.EnforceConstraints = false;
            this.khachHangTableAdapter.Connection.ConnectionString = Program.connstr;
            this.khachHangTableAdapter.Fill(this.DS.KHACHHANG);
            this.taiKhoanTableAdapter.Connection.ConnectionString = Program.connstr;
            this.taiKhoanTableAdapter.Fill(this.DS.TAIKHOAN);
            this.CHUYENTIEN_INFORECEIVERTableAdapter.Fill(this.DS.CHUYENTIEN_INFORECEIVER);
            macn = ((DataRowView)bdsKH[0])["MACN"].ToString();
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

                        Program.ExecSqlNonQuery("EXEC sp_ChuyenTien '" + txtSoTKChuyen.Text
                                                            + "','" + txtSoTKNhan.Text
                                                            + "','" + nuSoTien.Value
                                                            + "','" + dt
                                                            + "','" + txtMANV.Text + "'");
                        /*DS.EnforceConstraints = false;
                        this.khachHangTableAdapter.Connection.ConnectionString = Program.connstr;
                        this.khachHangTableAdapter.Fill(this.DS.KHACHHANG);
                        this.taiKhoanTableAdapter.Connection.ConnectionString = Program.connstr;
                        this.taiKhoanTableAdapter.Fill(this.DS.TAIKHOAN);*/
                        System.Windows.Forms.MessageBox.Show("Giao Dịch Thành Công ", "", MessageBoxButtons.OK);
                    }

                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show("Lỗi reload: " + ex.Message, "", MessageBoxButtons.OK);
                }
                taiKhoanGridControl.Enabled = khachHangGridControl.Enabled = true;
                hOTENRECTextBox.Text = cMNDTextBox.Text = txtSoTKNhan.Text = txtMACN.Text = "";
                pnlGD.Enabled = false;
                bdsTK.Position = vitri;
                return;
            }
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            bdsTK.Position = vitri;
            bdsTK.CancelEdit();//hai trường hợp: đang thêm bỏ thêm, đang sửa bỏ sửa
            pnlGD.Enabled = false;
            khachHangGridControl.Enabled = taiKhoanGridControl.Enabled = true;
            hOTENRECTextBox.Text = cMNDTextBox.Text = txtSoTKNhan.Text = txtMACN.Text = "";
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            bdsTK.Position = vitri;
            bdsTK.CancelEdit();//hai trường hợp: đang thêm bỏ thêm, đang sửa bỏ sửa
            pnlGD.Enabled = true;
            khachHangGridControl.Enabled = taiKhoanGridControl.Enabled = true;
            hOTENRECTextBox.Text = cMNDTextBox.Text = txtSoTKNhan.Text = txtMACN.Text = "";
            hOTextBox.Text = tENTextBox.Text = cMNDTextBox1.Text = txtSoTKChuyen.Text = sODUTextEdit.Text = "";
            try
            {
                this.taiKhoanTableAdapter.Connection.ConnectionString = Program.connstr;
                this.taiKhoanTableAdapter.Fill(this.DS.TAIKHOAN);
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
                txtSoTKNhan.Text = ""; hOTENRECTextBox.Clear(); cMNDTextBox.Clear();
                return;
            }
        }
    }
}
