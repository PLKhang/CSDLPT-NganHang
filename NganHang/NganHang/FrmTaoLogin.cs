using NGANHANG;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NganHang
{
    public partial class FrmTaoLogin : Form
    {
        public FrmTaoLogin()
        {
            InitializeComponent();
        }

        private void nHANVIENBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsNV.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DS);

        }

        private void FrmTaoLogin_Load(object sender, EventArgs e)
        {
            DS.EnforceConstraints = false;
            this.v_EX_LoginNameTableAdapter.Connection.ConnectionString = Program.connstr;
            this.v_EX_LoginNameTableAdapter.Fill(this.DS.V_EX_LoginName);
            this.nhanVienTableAdapter.Connection.ConnectionString = Program.connstr;
            this.nhanVienTableAdapter.Fill(this.DS.NHANVIEN);
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            if (cmbMANV.SelectedItem == null)
            {
                MessageBox.Show("Xin hãy chọn mã nhân viên");
                cmbMANV.Focus();
                return;
            }

            if (txtLoginName.Text.Trim() == "")
            {
                MessageBox.Show("Tên đăng nhập không thể để trắng");
                txtLoginName.Focus();
                return;
            }

            if (txtPass.Text == "")
            {
                MessageBox.Show("Mật khẩu không thể trống");
                txtPass.Focus();
                return;
            }

            if (txtPassConfir.Text != txtPass.Text)
            {
                MessageBox.Show("Mật khẩu và mật khẩu nhập lại không khớp nhau");
                txtPassConfir.Focus();
                return;
            }

            if (txtPassConfir.Text == "")
            {
                MessageBox.Show("Mật khẩu nhập lại không thể trống");
                txtPass.Focus();
                return;
            }
            try
            {
                /*string cmd = "exec sp_TaoLogin '" + txtLoginName.Text + "',"
                            + "'" + txtPass.Text + "',"
                            + "N'" + cmbMANV.Text + "',"
                            + "N'" + Program.mGroup;*/
                int result = Program.CreateLogin(txtLoginName.Text, cmbMANV.Text, txtPass.Text, Program.mGroup);
                if (result == 1)
                {
                    MessageBox.Show("Login name bị trùng!!", "", MessageBoxButtons.OK);
                    txtLoginName.Focus();
                }
                else if (result == 2)
                {
                    MessageBox.Show("User name bị trùng!!", "", MessageBoxButtons.OK);
                    cmbMANV.Focus();
                }
                else
                {
                    MessageBox.Show("Thành Công!!", "", MessageBoxButtons.OK);
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tạo login cho nhân viên", ex.Message, MessageBoxButtons.OK);
                return;
            }
        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmbMANV_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void hOTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtLoginName_TextChanged(object sender, EventArgs e)
        {

        }

        private void tENTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPass_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtPassConfir_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}
