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
            lblStartdate.Text = dayFrom.ToString("dd/MM/yyyy");
            lblStartdate1.Text = dayFrom.AddDays(-1).ToString("dd/MM/yyyy");
            lblEnddate.Text = lblEnddate1.Text = dayTo.ToString("dd/MM/yyyy");
            lblSoTK.Text = stk;

            this.sqlDataSource1.Connection.ConnectionString = Program.connstr;
            this.sqlDataSource1.Queries[0].Parameters[0].Value = stk;
            this.sqlDataSource1.Queries[0].Parameters[1].Value = dayFrom;
            this.sqlDataSource1.Queries[0].Parameters[2].Value = dayTo;
        }
    }

}
