using DevExpress.Data.Svg;
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
            this.rlTKKHBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DS);
        }


        private void frpt_SaoKeTaiKhoanNganHang_Load(object sender, EventArgs e)
        {
            this.getAllKHTableAdapter.Connection.ConnectionString = Program.connstr;
            this.getAllKHTableAdapter.Fill(this.DS.GetAllKH);
            this.tK_KHTableAdapter.Connection.ConnectionString = Program.connstr;
            this.tK_KHTableAdapter.Fill(this.DS.TK_KH);

            DS.EnforceConstraints = false;
            if(Program.mGroup == "KhachHang")
            {
                cmbCMND.Text = Program.username;
                cmbCMND.Enabled = false;
            }
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_SaoKe_Click(object sender, EventArgs e)
        {
            string dayBD = DateTime.Parse(startDateTimePicker.Value.ToString()).ToString("yyyy-MM-dd 00:00:00");
            string dayKT = DateTime.Parse(endDateTimePicker.Value.ToString()).ToString("yyyy-MM-dd 23:59:59");
            int compare = dayBD.CompareTo(dayKT);
            if (compare >= 0)
            {
                MessageBox.Show("Ngày bắt đầu phải nhỏ hơn ngày kết thúc", "Lỗi", MessageBoxButtons.OK);
                return;
            }
            string now = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd 00:00:00");
            if (endDateTimePicker.Value > DateTime.Now)
            {
                MessageBox.Show("Ngày kết thúc không được lớn hơn ngày hiện tại", "Lỗi", MessageBoxButtons.OK);
                return;
            }
            try
            {
                Xrpt_SaoKe rpt = new Xrpt_SaoKe(cmbSOTK.Text, startDateTimePicker.Value, endDateTimePicker.Value);

                //rpt.lblTieuDe.Text = “DANH SÁCH PHIẾU “ +cmbLoai.Text.ToUpper() + “ NHÂN VIÊN LẬP TRONG NĂM “ +cmbNam.Text;
                //rpt.lblSoTK.Text = cmbSOTK.Text;
                rpt.lblName.Text = txtHO.Text.Trim() + ' ' + txtTEN.Text.Trim();
                rpt.lblCMND.Text = cmbCMND.Text;
                rpt.lblCreateDate.Text = DateTime.Now.ToString();
                //rpt.lblStarDay.Text = dayBD;
                //rpt.lblEndDay.Text = dayKT;

                ReportPrintTool print = new ReportPrintTool(rpt);
                print.ShowPreviewDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tạo báo cáo: " + ex.Message, "ERROR", MessageBoxButtons.OK);
                return;
            }
        }
        private void kHACHHANGBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.getAllKHBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DS);
        }
    }
}
