using DevExpress.XtraReports.UI;
using NGANHANG;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace NganHang
{
    public partial class Xrpt_TaiKhoan : DevExpress.XtraReports.UI.XtraReport
    {
        public Xrpt_TaiKhoan()
        {
            InitializeComponent();
        }
        public Xrpt_TaiKhoan(string MaCN, char type, DateTime dayFrom, DateTime dayTo)
        {
            InitializeComponent();
            this.sqlDataSource1.Connection.ConnectionString = Program.connstr;
            this.sqlDataSource1.Queries[0].Parameters[0].Value = dayFrom;
            this.sqlDataSource1.Queries[0].Parameters[1].Value = dayTo;
            this.sqlDataSource1.Queries[0].Parameters[2].Value = type;
            this.sqlDataSource1.Queries[0].Parameters[3].Value = MaCN;
            this.sqlDataSource1.Fill();
        }
    }
}
