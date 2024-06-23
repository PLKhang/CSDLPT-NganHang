using DevExpress.Mvvm.Native;
using DevExpress.XtraReports.UI;
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
    public partial class frpt_DanhSachKhachHang_NganHang : Form
    {
        public frpt_DanhSachKhachHang_NganHang()
        {
            InitializeComponent();
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_XacNhan_Click(object sender, EventArgs e)
        {
            string dt = string.Format("{0:yyyy-MM-dd HH:mm:ss}", DateTime.Now);
            try
            {
                Xrpt_DanhSachKhachHang rpt = new Xrpt_DanhSachKhachHang();
                rpt.lblName.Text = Program.mHoten;
                rpt.lblExportDate.Text = dt;
                rpt.lblMaNV.Text = Program.username;

                ReportPrintTool printTool = new ReportPrintTool(rpt);
                printTool.ShowPreviewDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tạo báo cáo: " + ex.Message, "ERROR", MessageBoxButtons.OK);
                return;
            }
        }
    }
}
