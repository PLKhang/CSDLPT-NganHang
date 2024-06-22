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
            string macn = ((DataRowView)bdsHoTenNV[0])["MACN"].ToString();
            int compare = dayBD.CompareTo(dayKT);
            if (compare >= 0)
            {
                MessageBox.Show("Ngày bắt đầu phải nhỏ hơn ngày kết thúc", "", MessageBoxButtons.OK);
                return;
            }
            try
            {
               /* Xrpt_DanhSachTaiKhoan_ChiNhanh rptAll = new Xrpt_DanhSachTaiKhoan_ChiNhanh(macn, dayBD, dayKT);
                Xrpt_DanhSachTaiKhoan_TatCaChiNhanh rptSingle = new Xrpt_DanhSachTaiKhoan_TatCaChiNhanh(macn, dayBD, dayKT);

                //rpt.lblTieuDe.Text = “DANH SÁCH PHIẾU “ +cmbLoai.Text.ToUpper() + “ NHÂN VIÊN LẬP TRONG NĂM “ +cmbNam.Text;
                //rpt.lblHoTen.Text = Program.mHoten;

                ReportPrintTool print;
                if (cbTatCaChiNhanh.Checked == true)
                {
                    print = new ReportPrintTool(rptAll);
                }
                else
                {
                    print = new ReportPrintTool(rptSingle);
                }
                print.ShowPreviewDialog();*/
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tạo báo cáo: " + ex.Message, "ERROR", MessageBoxButtons.OK);
                return;
            }
        }      
    }
}
