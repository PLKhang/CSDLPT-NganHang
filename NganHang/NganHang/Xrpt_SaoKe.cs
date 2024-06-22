using DevExpress.XtraReports.UI;
using NGANHANG;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using DevExpress.Mvvm.POCO;

namespace NganHang
{
    public partial class Xrpt_SaoKe : DevExpress.XtraReports.UI.XtraReport
    {
        public Xrpt_SaoKe()
        {
            InitializeComponent();
        }

        public Xrpt_SaoKe(string stk, DateTime dayFrom, DateTime dayTo)
        {
            InitializeComponent();
            lblStartdate.Text = dayFrom.ToShortDateString();
            lblStartdate1.Text = dayFrom.AddDays(-1).ToShortDateString();
            lblEnddate.Text = lblEnddate1.Text = dayTo.ToShortDateString();
            lblSoTK.Text = stk;

            this.sqlDataSource1.Connection.ConnectionString = Program.connstr;
            this.sqlDataSource1.Queries[0].Parameters[0].Value = stk;
            this.sqlDataSource1.Queries[0].Parameters[1].Value = dayFrom;
            this.sqlDataSource1.Queries[0].Parameters[2].Value = dayTo;
            this.sqlDataSource1.Fill();

            DataTable dataTable = sqlDataSource1.Result[sqlDataSource1.Queries[0].Name] as DataTable;
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                // Lấy giá trị đầu tiên của dòng đầu tiên
                var firstColumnFirstRow = dataTable.Rows[0][0].ToString();

                // Lấy giá trị cuối cùng của dòng cuối cùng
                var lastColumnLastRow = dataTable.Rows[dataTable.Rows.Count - 1][4].ToString();

                // Cập nhật các nhãn với giá trị tương ứng
                lblMoneyStartdate.Text = "Chịu";
                lblMoneyEnddate.Text = lastColumnLastRow;
            }
            else
            {
                lblMoneyStartdate.Text = "No data";
                lblMoneyEnddate.Text = "No data";
            }
            lblName.Text = "Tên khách hàng";
            lblCMND.Text = "Số CMND";
        }
    }

}
