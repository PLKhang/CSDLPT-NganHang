using DevExpress.XtraBars;
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
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmMain()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
            btn_DangNhap.PerformClick();
        }
        private void Main_Load(object sender, EventArgs e)
        {
            btn_DangXuat.Enabled = btn_DK.Enabled = false;
            rib_NghiepVu.Visible = rib_BaoCao.Visible = false;   
        }
        private Form CheckExists(Type ftype)
        {
            foreach (Form f in this.MdiChildren)
                if (f.GetType() == ftype)
                    return f;   //nếu frmMain đã tồn tại thì trả về f, không thì trả về null.
            return null;
        }
        private void btn_DangNhap_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            /*if (Program.mloginDN != "")
            {
                MessageBox.Show("Bạn cần đăng xuất trước khi thực hiện hành động này");
                return;
            }*/
            Form frm = this.CheckExists(typeof(frmDangNhap));
            if (frm != null) frm.Activate();
            else
            {
                frmDangNhap f = new frmDangNhap();
                f.MdiParent = this;
                f.Show();
            }
        }
        private void btn_DangXuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            /*if (Program.mloginDN == "")
            {
                MessageBox.Show("Bạn phải đăng nhập trước khi đăng xuất!", "", MessageBoxButtons.OK);
                return;
            }
            else
            {
                try
                {
                    Program.servername = "";
                    Program.username = "";
                    Program.mlogin = "";
                    Program.password = "";
                    Program.mloginDN = "";
                    Program.passwordDN = "";
                    if (Program.conn.State == ConnectionState.Open) Program.conn.Close();   //Nếu đang mở kết nối thì ta đóng lại.

                    Form[] childArray = this.MdiChildren;   //Đóng hết tất cả form con đang mở.
                    foreach (Form childForm in childArray)
                    {
                        childForm.Close();
                    }

                    rib_BaoCao.Visible  = rib_NghiepVu.Visible = btn_DangXuat.Enabled = btn_DK.Enabled = false;
                    btn_DangNhap.Enabled = true;
                    MANV.Text = "MANV "; HOTEN.Text = "HOTEN "; NHOM.Text = "NHOM";
                    MessageBox.Show("Đăng xuất thành công.", "", MessageBoxButtons.OK);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "", MessageBoxButtons.OK);
                    return;
                }
            }
            return;*/
            Program.servername = "";
            Program.username = "";
            Program.mlogin = "";
            Program.password = "";
            Program.mloginDN = "";
            Program.passwordDN = "";
            if (Program.conn.State == ConnectionState.Open) Program.conn.Close();   //Nếu đang mở kết nối thì ta đóng lại.

            Form[] childArray = this.MdiChildren;   //Đóng hết tất cả form con đang mở.
            foreach (Form childForm in childArray)
            {
                childForm.Close();
            }

            rib_BaoCao.Visible = rib_NghiepVu.Visible = btn_DangXuat.Enabled = btn_DK.Enabled = false;
            btn_DangNhap.Enabled = true;
            MANV.Text = "Mã Nhân Viên "; HOTEN.Text = "Họ Tên "; NHOM.Text = "Nhóm";
            MessageBox.Show("Đăng xuất thành công.", "", MessageBoxButtons.OK);
        }
        private void btn_TaoTK_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            /*if (Program.mloginDN == "")
            {
                MessageBox.Show("Bạn phải đăng nhập trước khi tạo tài khoản!", "", MessageBoxButtons.OK);
                return;
            }*/

            Form frm = this.CheckExists(typeof(FrmTaoLogin));
            if (frm != null) frm.Activate();
            else
            {
                FrmTaoLogin f = new FrmTaoLogin();
                f.MdiParent = this;
                f.Show();
            }
        }
        public void HienThiMenu()
        {
            MANV.Text = "Tên Người Dùng: " + Program.username;
            HOTEN.Text = ";Họ tên: " + Program.mHoten.Trim('\r', '\n');
            NHOM.Text = ";Nhóm: " + Program.mGroup;
            // Phân quyền
            rib_BaoCao.Visible  = rib_NghiepVu.Visible = btn_DangXuat.Enabled = btn_DK.Enabled = true;
            btn_DangNhap.Enabled = false;
            // tiếp tục if trên Program.mGroup để bật/tắt các nút lệnh trên menu chính
            if (Program.mGroup == "NganHang")
            {
                rib_NghiepVu.Visible = rib_BaoCao.Visible = rb_ChuyenVien.Visible = true;
                rb_NgiepVuTien.Visible  =  false;
            }
            else if (Program.mGroup == "KhachHang")
            {
                btn_DK.Visibility = btnOpenCustomerAccount.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                rib_NghiepVu.Visible  = false;
                rib_BaoCao.Visible = true;
                btn_LietKeTK.Visibility = btn_LietKeKH.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            else
            {
                btnOpenCustomerAccount.Visibility = btn_LietKeTK.Visibility = btn_LietKeKH.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                rib_NghiepVu.Visible = rib_BaoCao.Visible = true;
                btn_DK.Visibility = btn_LietKeTK.Visibility = btn_LietKeKH.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                rb_ChuyenVien.Visible = rb_NgiepVuTien.Visible =  true;
            }
            /*           if (Program.mGroup == "NGANHANG")
                       {
                           btn_GuiRut.Enabled = false;
                           btn_ChuyenTien.Enabled = false;
                           btn_SaoKe.Enabled = true;
                           btn_LietKeTK.Enabled = true;
                           btn_LietKeKH.Enabled = true;
                           btnMoTK.Enabled = false;
                       }
                       if (Program.mGroup == "CHINHANH")
                       {
                           btn_SaoKe.Enabled = false;
                           btn_LietKeTK.Enabled = false;
                           btn_LietKeKH.Enabled = false;
                           btn_GuiRut.Enabled = true;
                           btn_ChuyenTien.Enabled = true;
                           btnMoTK.Enabled = true;
                       }
           */
        }
        private void btn_NhanVien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(frmNV));
            if (frm != null) frm.Activate();
            else
            {
                frmNV f = new frmNV();
                f.MdiParent = this;
                f.Show();
            }
        }
        private void btnKhachHang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(frmKH));
            if (frm != null) frm.Activate();
            else
            {
                frmKH f = new frmKH();
                f.MdiParent = this;
                f.Show();
            }
        }
        private void btn_ChuyenTien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(frmChuyenTien));
            if (frm != null) frm.Activate();
            else
            {
                frmChuyenTien f = new frmChuyenTien();
                f.MdiParent = this;
                f.Show();
            }
        }
        private void btn_GuiRut_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(frmGuiRutTien));
            if (frm != null) frm.Activate();
            else
            {
                frmGuiRutTien f = new frmGuiRutTien();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnOpenCustomerAccount_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(frmTaiKhoanNganHang));
            if (frm != null) frm.Activate();
            else
            {
                frmTaiKhoanNganHang f = new frmTaiKhoanNganHang();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btn_SaoKe_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(frpt_SaoKeTaiKhoanNganHang));
            if (frm != null) frm.Activate();
            else
            {
                frpt_SaoKeTaiKhoanNganHang f = new frpt_SaoKeTaiKhoanNganHang();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btn_LietKeTK_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(frpt_DanhSachTaiKhoan_ChiNhanh));
            if (frm != null) frm.Activate();
            else
            {
                frpt_DanhSachTaiKhoan_ChiNhanh f = new frpt_DanhSachTaiKhoan_ChiNhanh();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btn_LietKeKH_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(frpt_DanhSachKhachHang_NganHang));
            if (frm != null) frm.Activate();
            else
            {
                frpt_DanhSachKhachHang_NganHang f = new frpt_DanhSachKhachHang_NganHang();
                f.MdiParent = this;
                f.Show();
            }
        }
    }
}