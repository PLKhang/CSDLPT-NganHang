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
    public partial class frmTaoLoginKH : Form
    {
        public frmTaoLoginKH()
        {
            InitializeComponent();
        }

        private void frmTaoLoginKH_Load(object sender, EventArgs e)
        {
            DS.EnforceConstraints = false;
            this.v_EX_LoginNameKHTableAdapter.Connection.ConnectionString = Program.connstr;
            this.v_EX_LoginNameKHTableAdapter.Fill(this.DS.V_EX_LoginNameKH);
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            if (txtLoginNameKH.Text.Trim() == "")
            {
                MessageBox.Show("Tên đăng nhập không thể để trắng");
                txtLoginNameKH.Focus();
                return;
            }

            if (txtPassKH.Text == "")
            {
                MessageBox.Show("Mật khẩu không thể trống");
                txtPassKH.Focus();
                return;
            }

            if (txtPassKHConfir.Text != txtPassKH.Text)
            {
                MessageBox.Show("Mật khẩu và mật khẩu nhập lại không khớp nhau");
                txtPassKHConfir.Focus();
                return;
            }

            if (txtPassKHConfir.Text == "")
            {
                MessageBox.Show("Mật khẩu nhập lại không thể trống");
                txtPassKH.Focus();
                return;
            }

            try
            {
                /*string cmd = "exec sp_TaoLogin '" + txtLoginNameKH.Text + "',"
                            + "'" + txtPassKH.Text + "',"
                            + "N'" + cMNDComboBox.Text + "',"
                            + "N'KhachHang'";*/
                int result = Program.CreateLogin(txtLoginNameKH.Text, cMNDComboBox.Text, txtPassKH.Text, "KhachHang");
                if (result == 1) 
                {
                    MessageBox.Show("Login name bị trùng!!", "", MessageBoxButtons.OK);
                    txtLoginNameKH.Focus() ;
                }
                else if (result == 2)
                {
                    MessageBox.Show("User name bị trùng!!", "", MessageBoxButtons.OK);
                    cMNDComboBox.Focus();
                }
                else if (result == 0)
                {
                    MessageBox.Show("Success!!", "", MessageBoxButtons.OK);
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tạo login cho khách hàng", ex.Message, MessageBoxButtons.OK);
                return;
            }

        }
    }
}
