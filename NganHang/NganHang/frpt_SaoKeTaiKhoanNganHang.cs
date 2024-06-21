using DevExpress.XtraEditors;
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
    public partial class frpt_SaoKeTaiKhoanNganHang : Form
    {
        public frpt_SaoKeTaiKhoanNganHang()
        {
            InitializeComponent();
        }

        private void tAIKHOANBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsTK.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DS);

        }


        private void frpt_SaoKeTaiKhoanNganHang_Load(object sender, EventArgs e)
        {
            DS.EnforceConstraints = false;
            this.kHACHHANGTableAdapter.Fill(this.DS.KHACHHANG);
            this.kHACHHANGTableAdapter.Connection.ConnectionString = Program.connstr;
            this.tAIKHOANTableAdapter.Fill(this.DS.TAIKHOAN);
            this.tAIKHOANTableAdapter.Connection.ConnectionString = Program.connstr;
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_SaoKe_Click(object sender, EventArgs e)
        {
            string hoten = txtHO.Text.Trim() + txtTEN.Text.Trim();
            string dayBD = DateTime.Parse(startDateTimePicker.Value.ToString()).ToString("yyyy-MM-dd 00:00:00");
            string dayKT = DateTime.Parse(endDateTimePicker.Value.ToString()).ToString("yyyy-MM-dd 23:59:59");
            int compare = dayBD.CompareTo(dayKT);
            if (compare >= 0)
            {
                MessageBox.Show("Ngày bắt đầu phải nhỏ hơn ngày kết thúc", "", MessageBoxButtons.OK);
                return;
            }
            try
            {
                //Xrpt_SaoKeTaiKhoanNganHang rpt = new Xrpt_SaoKeTaiKhoanNganHang(cmbSOTK.Text, dayBD, dayKT);

                //rpt.lblTieuDe.Text = “DANH SÁCH PHIẾU “ +cmbLoai.Text.ToUpper() + “ NHÂN VIÊN LẬP TRONG NĂM “ +cmbNam.Text;
                /*rpt.lblSoTK.Text = cmbSOTK.Text;
                rpt.lblHoTenKH.Text = hoten;
                rpt.lblCMND.Text = txtCMND.Text;
                rpt.lblStarDay.Text = dayBD;
                rpt.lblEndDay.Text = dayKT;

                ReportPrintTool print = new ReportPrintTool(rpt);
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
