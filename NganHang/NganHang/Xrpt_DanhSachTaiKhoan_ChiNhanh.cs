using DevExpress.XtraReports.UI;
using NGANHANG;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace NganHang
{
    public partial class Xrpt_DanhSachTaiKhoan_ChiNhanh : DevExpress.XtraReports.UI.XtraReport
    {
        public Xrpt_DanhSachTaiKhoan_ChiNhanh()
        {
            InitializeComponent();
        }
 /*       public Xrpt_DanhSachTaiKhoan_ChiNhanh(DateTime batdau, DateTime ketthuc, string loai, string macn)
        {
            InitializeComponent();
            this.sqlDataSource1.Connection.ConnectionString = Program.connstr;
            this.sqlDataSource1.Queries[0].Parameters[0].Value = batdau;
            this.sqlDataSource1.Queries[0].Parameters[1].Value = ketthuc;
            this.sqlDataSource1.Queries[0].Parameters[2].Value = loai;
            this.sqlDataSource1.Queries[0].Parameters[3].Value = macn;
            this.sqlDataSource1.Fill();
        }*/
    }
}
