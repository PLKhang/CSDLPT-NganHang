namespace NganHang
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btn_DangNhap = new DevExpress.XtraBars.BarButtonItem();
            this.btn_DK = new DevExpress.XtraBars.BarButtonItem();
            this.btn_DangXuat = new DevExpress.XtraBars.BarButtonItem();
            this.btn_NhanVien = new DevExpress.XtraBars.BarButtonItem();
            this.btnKhachHang = new DevExpress.XtraBars.BarButtonItem();
            this.btn_ChuyenTien = new DevExpress.XtraBars.BarButtonItem();
            this.btn_GuiRut = new DevExpress.XtraBars.BarButtonItem();
            this.btnOpenCustomerAccount = new DevExpress.XtraBars.BarButtonItem();
            this.btn_SaoKe = new DevExpress.XtraBars.BarButtonItem();
            this.btn_LietKeTK = new DevExpress.XtraBars.BarButtonItem();
            this.btn_LietKeKH = new DevExpress.XtraBars.BarButtonItem();
            this.rib_HeThong = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rib_NghiepVu = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rb_ChuyenVien = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rb_NgiepVuTien = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rib_BaoCao = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup17 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup18 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup19 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup6 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup7 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup8 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.MANV = new System.Windows.Forms.ToolStripStatusLabel();
            this.HOTEN = new System.Windows.Forms.ToolStripStatusLabel();
            this.NHOM = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.ribbon.SearchEditItem,
            this.btn_DangNhap,
            this.btn_DK,
            this.btn_DangXuat,
            this.btn_NhanVien,
            this.btnKhachHang,
            this.btn_ChuyenTien,
            this.btn_GuiRut,
            this.btnOpenCustomerAccount,
            this.btn_SaoKe,
            this.btn_LietKeTK,
            this.btn_LietKeKH});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 14;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rib_HeThong,
            this.rib_NghiepVu,
            this.rib_BaoCao});
            this.ribbon.Size = new System.Drawing.Size(1316, 193);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // btn_DangNhap
            // 
            this.btn_DangNhap.Caption = "Đăng Nhập";
            this.btn_DangNhap.Id = 1;
            this.btn_DangNhap.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_DangNhap.ImageOptions.SvgImage")));
            this.btn_DangNhap.Name = "btn_DangNhap";
            this.btn_DangNhap.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_DangNhap_ItemClick);
            // 
            // btn_DK
            // 
            this.btn_DK.Caption = "Đăng Ký";
            this.btn_DK.Id = 2;
            this.btn_DK.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_DK.ImageOptions.Image")));
            this.btn_DK.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btn_DK.ImageOptions.LargeImage")));
            this.btn_DK.Name = "btn_DK";
            this.btn_DK.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_TaoTK_ItemClick);
            // 
            // btn_DangXuat
            // 
            this.btn_DangXuat.Caption = "Đăng Xuất";
            this.btn_DangXuat.Id = 3;
            this.btn_DangXuat.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_DangXuat.ImageOptions.Image")));
            this.btn_DangXuat.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btn_DangXuat.ImageOptions.LargeImage")));
            this.btn_DangXuat.Name = "btn_DangXuat";
            this.btn_DangXuat.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_DangXuat_ItemClick);
            // 
            // btn_NhanVien
            // 
            this.btn_NhanVien.Caption = "Nhân Viên";
            this.btn_NhanVien.Id = 4;
            this.btn_NhanVien.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_NhanVien.ImageOptions.Image")));
            this.btn_NhanVien.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btn_NhanVien.ImageOptions.LargeImage")));
            this.btn_NhanVien.Name = "btn_NhanVien";
            this.btn_NhanVien.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_NhanVien_ItemClick);
            // 
            // btnKhachHang
            // 
            this.btnKhachHang.Caption = "Khách Hàng";
            this.btnKhachHang.Id = 5;
            this.btnKhachHang.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnKhachHang.ImageOptions.Image")));
            this.btnKhachHang.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnKhachHang.ImageOptions.LargeImage")));
            this.btnKhachHang.Name = "btnKhachHang";
            this.btnKhachHang.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnKhachHang_ItemClick);
            // 
            // btn_ChuyenTien
            // 
            this.btn_ChuyenTien.Caption = "Chuyển Tiền";
            this.btn_ChuyenTien.Id = 6;
            this.btn_ChuyenTien.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_ChuyenTien.ImageOptions.SvgImage")));
            this.btn_ChuyenTien.Name = "btn_ChuyenTien";
            this.btn_ChuyenTien.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_ChuyenTien_ItemClick);
            // 
            // btn_GuiRut
            // 
            this.btn_GuiRut.Caption = "Gửi Rút";
            this.btn_GuiRut.Id = 7;
            this.btn_GuiRut.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_GuiRut.ImageOptions.SvgImage")));
            this.btn_GuiRut.Name = "btn_GuiRut";
            this.btn_GuiRut.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_GuiRut_ItemClick);
            // 
            // btnOpenCustomerAccount
            // 
            this.btnOpenCustomerAccount.Caption = "Tài Khoản Khách Hàng";
            this.btnOpenCustomerAccount.Id = 8;
            this.btnOpenCustomerAccount.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnOpenCustomerAccount.ImageOptions.SvgImage")));
            this.btnOpenCustomerAccount.Name = "btnOpenCustomerAccount";
            this.btnOpenCustomerAccount.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnOpenCustomerAccount_ItemClick);
            // 
            // btn_SaoKe
            // 
            this.btn_SaoKe.Caption = "Sao Kê Tài Khoản";
            this.btn_SaoKe.Id = 10;
            this.btn_SaoKe.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_SaoKe.ImageOptions.SvgImage")));
            this.btn_SaoKe.Name = "btn_SaoKe";
            this.btn_SaoKe.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_SaoKe_ItemClick);
            // 
            // btn_LietKeTK
            // 
            this.btn_LietKeTK.Caption = "Danh Sách Tài Khoản Mở";
            this.btn_LietKeTK.Id = 11;
            this.btn_LietKeTK.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_LietKeTK.ImageOptions.SvgImage")));
            this.btn_LietKeTK.Name = "btn_LietKeTK";
            this.btn_LietKeTK.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_LietKeTK_ItemClick);
            // 
            // btn_LietKeKH
            // 
            this.btn_LietKeKH.Caption = "Thống Kê Thông Tin Khách Hàng";
            this.btn_LietKeKH.Id = 12;
            this.btn_LietKeKH.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_LietKeKH.ImageOptions.SvgImage")));
            this.btn_LietKeKH.Name = "btn_LietKeKH";
            this.btn_LietKeKH.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_LietKeKH_ItemClick);
            // 
            // rib_HeThong
            // 
            this.rib_HeThong.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.rib_HeThong.Name = "rib_HeThong";
            this.rib_HeThong.Text = "Hệ Thống";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btn_DangNhap);
            this.ribbonPageGroup1.ItemLinks.Add(this.btn_DK);
            this.ribbonPageGroup1.ItemLinks.Add(this.btn_DangXuat);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            // 
            // rib_NghiepVu
            // 
            this.rib_NghiepVu.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rb_ChuyenVien,
            this.rb_NgiepVuTien});
            this.rib_NghiepVu.Name = "rib_NghiepVu";
            this.rib_NghiepVu.Text = "Nghiệp Vụ";
            // 
            // rb_ChuyenVien
            // 
            this.rb_ChuyenVien.ItemLinks.Add(this.btn_NhanVien);
            this.rb_ChuyenVien.ItemLinks.Add(this.btnKhachHang);
            this.rb_ChuyenVien.ItemLinks.Add(this.btnOpenCustomerAccount);
            this.rb_ChuyenVien.Name = "rb_ChuyenVien";
            // 
            // rb_NgiepVuTien
            // 
            this.rb_NgiepVuTien.ItemLinks.Add(this.btn_ChuyenTien);
            this.rb_NgiepVuTien.ItemLinks.Add(this.btn_GuiRut);
            this.rb_NgiepVuTien.Name = "rb_NgiepVuTien";
            // 
            // rib_BaoCao
            // 
            this.rib_BaoCao.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup17,
            this.ribbonPageGroup18,
            this.ribbonPageGroup19});
            this.rib_BaoCao.Name = "rib_BaoCao";
            this.rib_BaoCao.Text = "Báo Cáo";
            // 
            // ribbonPageGroup17
            // 
            this.ribbonPageGroup17.ItemLinks.Add(this.btn_SaoKe);
            this.ribbonPageGroup17.Name = "ribbonPageGroup17";
            // 
            // ribbonPageGroup18
            // 
            this.ribbonPageGroup18.ItemLinks.Add(this.btn_LietKeTK);
            this.ribbonPageGroup18.Name = "ribbonPageGroup18";
            // 
            // ribbonPageGroup19
            // 
            this.ribbonPageGroup19.ItemLinks.Add(this.btn_LietKeKH);
            this.ribbonPageGroup19.Name = "ribbonPageGroup19";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 665);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1316, 30);
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            // 
            // ribbonPageGroup5
            // 
            this.ribbonPageGroup5.Name = "ribbonPageGroup5";
            // 
            // ribbonPageGroup6
            // 
            this.ribbonPageGroup6.Name = "ribbonPageGroup6";
            // 
            // ribbonPageGroup7
            // 
            this.ribbonPageGroup7.Name = "ribbonPageGroup7";
            // 
            // ribbonPageGroup8
            // 
            this.ribbonPageGroup8.Name = "ribbonPageGroup8";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MANV,
            this.HOTEN,
            this.NHOM});
            this.statusStrip1.Location = new System.Drawing.Point(0, 639);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1316, 26);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // MANV
            // 
            this.MANV.Name = "MANV";
            this.MANV.Size = new System.Drawing.Size(52, 20);
            this.MANV.Text = "MANV";
            // 
            // HOTEN
            // 
            this.HOTEN.Name = "HOTEN";
            this.HOTEN.Size = new System.Drawing.Size(57, 20);
            this.HOTEN.Text = "HOTEN";
            // 
            // NHOM
            // 
            this.NHOM.Name = "NHOM";
            this.NHOM.Size = new System.Drawing.Size(55, 20);
            this.NHOM.Text = "NHOM";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1316, 695);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.IconOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("frmMain.IconOptions.SvgImage")));
            this.IsMdiContainer = true;
            this.Name = "frmMain";
            this.Ribbon = this.ribbon;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage rib_HeThong;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup5;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup6;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup7;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup8;
        private DevExpress.XtraBars.BarButtonItem btn_DangNhap;
        private DevExpress.XtraBars.BarButtonItem btn_DK;
        private DevExpress.XtraBars.BarButtonItem btn_DangXuat;
        private DevExpress.XtraBars.BarButtonItem btn_NhanVien;
        private DevExpress.XtraBars.BarButtonItem btnKhachHang;
        private DevExpress.XtraBars.Ribbon.RibbonPage rib_NghiepVu;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rb_ChuyenVien;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rb_NgiepVuTien;
        private DevExpress.XtraBars.BarButtonItem btn_ChuyenTien;
        private DevExpress.XtraBars.BarButtonItem btn_GuiRut;
        private DevExpress.XtraBars.BarButtonItem btnOpenCustomerAccount;
        private DevExpress.XtraBars.Ribbon.RibbonPage rib_BaoCao;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup17;
        private DevExpress.XtraBars.BarButtonItem btn_SaoKe;
        private DevExpress.XtraBars.BarButtonItem btn_LietKeTK;
        private DevExpress.XtraBars.BarButtonItem btn_LietKeKH;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup18;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup19;
        private System.Windows.Forms.StatusStrip statusStrip1;
        public System.Windows.Forms.ToolStripStatusLabel MANV;
        public System.Windows.Forms.ToolStripStatusLabel HOTEN;
        public System.Windows.Forms.ToolStripStatusLabel NHOM;
    }
}