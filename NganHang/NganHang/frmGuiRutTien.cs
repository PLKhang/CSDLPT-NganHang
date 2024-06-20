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
    public partial class frmGuiRutTien : Form
    {
        String macn = "";
        int vitri = 0;
        public frmGuiRutTien()
        {
            InitializeComponent();
        }

        private void kHACHHANGBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsKH.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DS);

        }

        private void frmGuiRutTien_Load(object sender, EventArgs e)
        {
            DS.EnforceConstraints = false;
            this.khachHangTableAdapter.Connection.ConnectionString = Program.connstr;
            this.khachHangTableAdapter.Fill(this.DS.KHACHHANG);
            this.taiKhoanTableAdapter.Connection.ConnectionString = Program.connstr;
            this.taiKhoanTableAdapter.Fill(this.DS.TAIKHOAN);
            this.gD_GOIRUTTableAdapter.Connection.ConnectionString = Program.connstr;
            this.gD_GOIRUTTableAdapter.Fill(this.DS.GD_GOIRUT);
            macn = ((DataRowView)bdsKH[0])["MACN"].ToString();
            cmbChiNhanh.DataSource = Program.bds_dspm; // sao chép bds_ds đã load ở form đăng nhập
            cmbChiNhanh.DisplayMember = "TENCN";
            cmbChiNhanh.ValueMember = "TENSERVER";
            cmbChiNhanh.SelectedIndex = Program.mChinhanh;
            pnlGD.Enabled = false;
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
                DS.EnforceConstraints = false;
                this.khachHangTableAdapter.Connection.ConnectionString = Program.connstr;
                this.khachHangTableAdapter.Fill(this.DS.KHACHHANG);
                this.taiKhoanTableAdapter.Connection.ConnectionString = Program.connstr;
                this.taiKhoanTableAdapter.Fill(this.DS.TAIKHOAN);
                this.gD_GOIRUTTableAdapter.Connection.ConnectionString = Program.connstr;
                this.gD_GOIRUTTableAdapter.Fill(this.DS.GD_GOIRUT);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            bdsTK.Position = vitri;
            bdsTK.CancelEdit();//hai trường hợp: đang thêm bỏ thêm, đang sửa bỏ sửa
            pnlGD.Enabled = false;
            gD_GOIRUTGridControl.Enabled = tAIKHOANGridControl.Enabled = true;
            txtSOTK.Text = cmbLoaiGD.Text = "";
            
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

        private void cmbLoaiGD_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLoaiGD.Text == "Gửi tiền")
            {
                btnXacNhan.Text = "Gửi tiền";
            }
            else if (cmbLoaiGD.Text == "Rút tiền")
            {
                btnXacNhan.Text = "Rút tiền";
            }
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            String dt = String.Format("{0:yyyy-MM-dd HH:mm:ss.fff}", DateTime.Now);
            String loaiGD = (cmbLoaiGD.SelectedIndex == 0) ? "GT" : "RT";
            try
            {
                if (loaiGD == "")
                {
                    MessageBox.Show("Bạn chưa chọn loại giao dịch", "", MessageBoxButtons.OK);
                }
                if (txtSoTien.Value < 100000)
                {
                    MessageBox.Show("Số tiền giao dịch thấp nhất là 100.000đ\nBạn hãy nhập lại...", "", MessageBoxButtons.OK);
                    txtSoTien.Focus();
                    return;
                }
                Program.ExecSqlNonQuery("EXEC SP_GuiRut '" + txtSOTK.Text 
                                            + "','" + txtSoTien.Value 
                                            + "','" + loaiGD 
                                            + "','" + dt 
                                            + "','" + txtMANV.EditValue + "'");
                this.taiKhoanTableAdapter.Connection.ConnectionString = Program.connstr;
                this.taiKhoanTableAdapter.Fill(this.DS.TAIKHOAN);
                this.gD_GOIRUTTableAdapter.Connection.ConnectionString = Program.connstr;
                this.gD_GOIRUTTableAdapter.Fill(this.DS.GD_GOIRUT);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Giao Dịch: " +ex.Message, "Error", MessageBoxButtons.OK);
                return;
            }
            gD_GOIRUTGridControl.Enabled = tAIKHOANGridControl.Enabled = true;
            pnlGD.Enabled = false;
            bdsTK.Position = vitri;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            vitri = bdsTK.Position;
            gD_GOIRUTGridControl.Enabled = tAIKHOANGridControl.Enabled = false;
            pnlGD.Enabled = true;
            txtMANV.EditValue = Program.username;
            txtSOTK.Text = ((DataRowView)bdsTK[bdsTK.Position])["SOTK"].ToString();
        }
    }
}
