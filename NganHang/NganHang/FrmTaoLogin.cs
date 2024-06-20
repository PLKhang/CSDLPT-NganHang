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
            // TODO: This line of code loads data into the 'DS.V_EX_LoginName' table. You can move, or remove it, as needed.
            this.v_EX_LoginNameTableAdapter.Fill(this.DS.V_EX_LoginName);
            DS.EnforceConstraints = false;
            this.nhanVienTableAdapter.Connection.ConnectionString = Program.connstr;
            this.nhanVienTableAdapter.Fill(this.DS.NHANVIEN);
            //string cmd = "SELECT * FROM V_EX_LoginName";
            //DataTable dt = new DataTable(); //trả về một data table.
            //SqlDataAdapter da = new SqlDataAdapter(cmd, Program.conn); // Tạo ra một đối tượng thuộc lớp SqlDataAdapter có 2 tham số là chuỗi lệnh và đối tượng SqlConnection.
            //da.Fill(dt);    // Muốn tải số liệu từ View,Table từ DataAdapter vào DataTable thì ta dùng Fill -> dt sẽ chứa các danh sách phân mảnh.

            //cmbMANV.DataSource = dt;  // gán bds_dspm ở Program cho DataSource ở cmbChiNhanh. //
            //cmbMANV.DisplayMember = "MANV"; cmbMANV.ValueMember = "MANV";
            //cmbMANV.DropDownStyle = ComboBoxStyle.DropDownList;
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


            //Debug.WriteLine(txtLoginName.Text);
            //Debug.WriteLine(txtPass.Text);
            //Debug.WriteLine(txtPassConfir.Text);

            //string cmd = "exec v_ex_loginname";
            //Program.myReader = Program.ExecSqlDataReader(cmd);
            //Program.myReader.Read();
            //string generatedStaffId = Program.myReader.GetString(0);
            //Program.myReader.Close();

            string cmd = "exec sp_TaoLogin '" + txtLoginName.Text + "',"
                        + "'" + txtPass.Text + "',"
                        + "N'" + txtLoginName.Text + "',"
                        + "N'" + Program.mGroup + "'";

            Program.myReader = Program.ExecSqlDataReader(cmd);
            Program.myReader.Close();
            MessageBox.Show("DEO!!", "", MessageBoxButtons.OK);
            
        }
    }
}
