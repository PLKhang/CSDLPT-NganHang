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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
            btn_DangNhap.PerformClick();
        }
        private Form CheckExists(Type ftype)
        {
            foreach (Form f in this.MdiChildren)
                if (f.GetType() == ftype)
                    return f;   //nếu frmMain đã tồn tại thì trả về f, không thì trả về null.
            return null;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            btn_DangXuat.Enabled = btn_DK.Enabled = false;
        }
        private void btn_DangNhap_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Program.mloginDN != "")
            {
                MessageBox.Show("Bạn cần đăng xuất trước khi thực hiện hành động này");
                return;
            }

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
            if (Program.mloginDN == "")
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

                    rib_BaoCao.Visible = rib_DanhMuc.Visible = rib_NghiepVu.Visible = btn_DangXuat.Enabled = btn_DK.Enabled = false;
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
            return;
        }
        private void btn_TaoTK_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Program.mloginDN == "")
            {
                MessageBox.Show("Bạn phải đăng nhập trước khi tạo tài khoản!", "", MessageBoxButtons.OK);
                return;
            }

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
            MANV.Text = "Mã NV: " + Program.username;
            HOTEN.Text = "; Họ tên: " + Program.mHoten.Trim('\r', '\n');
            NHOM.Text = "; Nhóm: " + Program.mGroup;
            // Phân quyền
            rib_BaoCao.Visible = rib_DanhMuc.Visible = rib_NghiepVu.Visible = btn_DangXuat.Enabled = btn_DK.Enabled = true;
            btn_DangNhap.Enabled = false;
            // tiếp tục if trên Program.mGroup để bật/tắt các nút lệnh trên menu chính
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
        private void btnMoTK_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
/*            Form frm = this.CheckExists(typeof(frmTaoTKKH));
            if (frm != null) frm.Activate();
            else
            {
                frmTaoTKKH f = new frmTaoTKKH();
                f.MdiParent = this;
                f.Show();
            }*/
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
            Form frm = this.CheckExists(typeof(frmKH));
            if (frm != null) frm.Activate();
            else
            {
                frmKH f = new frmKH();
                f.MdiParent = this;
                f.Show();
            }
        }
    }
}
