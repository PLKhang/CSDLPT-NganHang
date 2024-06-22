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
using DevExpress.XtraEditors;

namespace NganHang
{
    public partial class frpt_DanhSachTaiKhoan_ChiNhanh : Form
    {
        public frpt_DanhSachTaiKhoan_ChiNhanh()
        {
            InitializeComponent();
        }

        private void Frpt_DanhSachTaiKhoan_ChiNhanh_Load(object sender, EventArgs e)
        {
            DS.EnforceConstraints = false;
            this.HOTENNVTableAdapter.Fill(this.DS.HOTENNV);
            this.HOTENNVTableAdapter.Connection.ConnectionString = Program.connstr;
            cmbChiNhanh.DataSource = frmDangNhap.GetListSubcription("SELECT * FROM V_DS_PHANMANH");
            cmbChiNhanh.DisplayMember = "TENCN";
            cmbChiNhanh.ValueMember = "TENSERVER";
            cmbChiNhanh.SelectedIndex = Program.mChinhanh;
            if (Program.mGroup == "NganHang")
            {
                cmbChiNhanh.Enabled = true;
            }
            else
            {
                cmbChiNhanh.Enabled = false;
            }
        }
        private void cmbChiNhanh_SelectedIndexChanged_1(object sender, EventArgs e)
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
                this.HOTENNVTableAdapter.Connection.ConnectionString = Program.connstr;
                this.HOTENNVTableAdapter.Fill(this.DS.HOTENNV);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void previewButton_Click(object sender, EventArgs e)
        {
            string dayBD = DateTime.Parse(startdateTimePicker.Value.ToString()).ToString("yyyy-MM-dd 00:00:00");
            string dayKT = DateTime.Parse(enddateTimePicker.Value.ToString()).ToString("yyyy-MM-dd 23:59:59");
            string macn = (cmbChiNhanh.SelectedIndex == 0 ? "BENTHANH" : "TANDINH");
            char type = (cbTatCaChiNhanh.Checked ? 'T' : 'C');
            int compare = dayBD.CompareTo(dayKT);
            if (compare >= 0)
            {
                MessageBox.Show("Ngày bắt đầu phải nhỏ hơn ngày kết thúc", "", MessageBoxButtons.OK);
                return;
            }
            try
            {

                Xrpt_TaiKhoan rpt = new Xrpt_TaiKhoan(macn, type, startdateTimePicker.Value, enddateTimePicker.Value);

                //rpt.lblTieuDe.Text = “DANH SÁCH PHIẾU “ +cmbLoai.Text.ToUpper() + “ NHÂN VIÊN LẬP TRONG NĂM “ +cmbNam.Text;
                //rpt.lblSoTK.Text = cmbSOTK.Text;
                rpt.lblMaNV.Text = Program.username;
                rpt.lblName.Text = Program.mHoten;
                rpt.lblExportDate.Text = DateTime.Now.ToString();
                rpt.lblStartdate.Text = startdateTimePicker.Value.ToShortDateString();
                rpt.lblEnddate.Text = enddateTimePicker.Value.ToShortDateString();
                if (cbTatCaChiNhanh.Checked)
                {
                    rpt.lblLoai.Text = "Tất cả chi nhánh";
                }
                else
                {
                    rpt.lblLoai.Text = cmbChiNhanh.Text;
                }

                ReportPrintTool print = new ReportPrintTool(rpt);
                print.ShowPreviewDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tạo báo cáo: " + ex.Message, "ERROR", MessageBoxButtons.OK);
                return;
            }
        }      
    }
}
