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
using DevExpress.XtraReports.UI;

namespace NganHang
{
    public partial class Frpt_DanhSachTaiKhoan_ChiNhanh : Form
    {
        public Frpt_DanhSachTaiKhoan_ChiNhanh()
        {
            InitializeComponent();
        }

        private void Frpt_DanhSachTaiKhoan_ChiNhanh_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dS.HOTENNV' table. You can move, or remove it, as needed.
            this.HOTENNVTableAdapter.Fill(this.dS.HOTENNV);
            this.HOTENNVTableAdapter.Connection.ConnectionString = Program.connstr;
            cmbChiNhanh.DataSource =Program.bds_dspm;
            cmbChiNhanh.DisplayMember = "TenCN";
            cmbChiNhanh.ValueMember = "TenServer";
            cmbChiNhanh.SelectedIndex = Program.mChinhanh;
            /*if(Program.mGroup == "NganHang")
                cmbChiNhanh.Enabled = true;
            else cmbChiNhanh.Enabled =false;*/
            if (Program.mGroup == "NganHang")
            {
                cmbChiNhanh.Enabled = true;
                cmbLoai.Enabled = true;
            }
            else
            {
                cmbLoai.Enabled = false;
                cmbLoai.Text = "Chi nhánh hiện tại";
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
                this.HOTENNVTableAdapter.Fill(this.dS.HOTENNV);
                this.HOTENNVTableAdapter.Connection.ConnectionString = Program.connstr;
            }
        }
    }
}
