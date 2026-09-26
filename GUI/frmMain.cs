using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmMain : Form
    {
        frmDoiMatKhau frmDMK;
        public static bool bDangNhap;
        public static TaiKhoan_DTO CurrentUser;
        public frmMain()
        {
            InitializeComponent();
            this.IsMdiContainer = true;

            bDangNhap = false;
            CurrentUser = null;
            HienThiMenu();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            HienThiMenu();
            mnuDangNhap_Click(sender, e);
        }
        private void MoFormDuyNhat(Form frmCon)
        {
            foreach (Form f in this.MdiChildren)
            {
                f.Close();
            }

            frmCon.MdiParent = this;
            frmCon.Dock = DockStyle.Fill;
            frmCon.Show();
        }

        public void HienThiMenu()
        {
            mnuDangNhap.Enabled = !bDangNhap;
            mnuDangXuat.Enabled = bDangNhap;

            if (bDangNhap == true && CurrentUser != null)
            {
                mnuDoiMatKhau.Enabled = true;
                lblTrangThai.Text = "Nhân viên: " + CurrentUser.TenHienThi + " | Đăng nhập lúc: " + DateTime.Now.ToString("HH:mm:ss");

                int iQuyen = CurrentUser.LoaiTaiKhoan;

                switch (iQuyen)
                {
                    case 1: 
                        mnuQuanly.Enabled = true;
                        mnuBanHang.Enabled = true;
                        mnuBaoCao.Enabled = true;

                        mnuDanhMuc.Enabled = true;
                        mnuDoUong.Enabled = true;
                        mnuBan.Enabled = true;
                        mnuDieuChinhGia.Enabled = true;
                        mnuHoaDon.Enabled = true;
                        mnuKho.Enabled = true;
                        break;
                    case 0: 
                        mnuQuanly.Enabled = true;
                        mnuBanHang.Enabled = true;
                        mnuBaoCao.Enabled = false;

                        mnuDanhMuc.Enabled = false;
                        mnuDoUong.Enabled = false;
                        mnuBan.Enabled = false;
                        mnuDieuChinhGia.Enabled = false;
                        mnuHoaDon.Enabled = true;
                        mnuKho.Enabled = false;

                        break;
                }
            }
            else
            {
                lblTrangThai.Text = "Trạng thái: Chưa đăng nhập";
                mnuQuanly.Enabled = false;
                mnuBanHang.Enabled = false;  
                mnuBaoCao.Enabled = false;
                mnuDoiMatKhau.Enabled = false;
                mnuKho.Enabled = false;
            }
        }

        private void mnuDangNhap_Click(object sender, EventArgs e)
        {
            MoFormDuyNhat(new frmDangNhap());

        }
        private void mnuBanHang_Click(object sender, EventArgs e)
        {
            MoFormDuyNhat(new frmBanHang());
        }

        private void mnuDanhMuc_Click(object sender, EventArgs e)
        {
            MoFormDuyNhat(new frmDanhMuc());
        }

        private void mnuDoUong_Click(object sender, EventArgs e)
        {
            MoFormDuyNhat(new frmThucUong());
        }

        private void mnuBan_Click(object sender, EventArgs e)
        {
            MoFormDuyNhat(new frmBan());
        }

        private void mnuDieuChinhGia_Click(object sender, EventArgs e)
        {
            MoFormDuyNhat(new frmDieuChinhGia());
        }

        private void mnuHoaDon_Click(object sender, EventArgs e)
        {
            MoFormDuyNhat(new frmQLHoaDon());
        }

        private void mnuDangXuat_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren) f.Close();
            bDangNhap = false;
            CurrentUser = null;
            HienThiMenu();
        }

        private void mnuTaiKhoan_Click(object sender, EventArgs e)
        {
            MoFormDuyNhat(new frmQLTaiKhoan());
        }

        private void mnuDoiMatKhau_Click(object sender, EventArgs e)
        {

            if (frmDMK == null || frmDMK.IsDisposed)
            {
                frmDMK = new frmDoiMatKhau(CurrentUser);
                frmDMK.MdiParent = this;
                frmDMK.Show();
            }
            else frmDMK.Activate();
        }

        private void mnuNguyenLieu_Click(object sender, EventArgs e)
        {

            MoFormDuyNhat(new frmNguyenLieu());
        }

        private void mnuCongThuc_Click(object sender, EventArgs e)
        {

            MoFormDuyNhat(new frmDinhMuc());
        }

        private void mnuDoanhThu_Click(object sender, EventArgs e)
        {

            MoFormDuyNhat(new frmBCDoanhThu());
        }

        private void mnuDinhMucNL_Click(object sender, EventArgs e)
        {
            MoFormDuyNhat(new frmCTDinhMucNguyenLieu());
        }

        private void mnuSaoLuu_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog saoluuFolder = new FolderBrowserDialog();
            saoluuFolder.Description = "Chọn thư mục lưu trữ";
            if (saoluuFolder.ShowDialog() == DialogResult.OK)
            {
                string sDuongDan = saoluuFolder.SelectedPath;
                if (CSDL_BUS.SaoLuu(sDuongDan) == true)
                    MessageBox.Show("Đã sao lưu dữ liệu vào " + sDuongDan);
                else
                    MessageBox.Show("Thao tác không thành công");
            }
        }

        private void mnuPhucHoi_Click(object sender, EventArgs e)
        {
            OpenFileDialog phuchoiFile = new OpenFileDialog();
            phuchoiFile.Filter = "*.bak|*.bak";
            phuchoiFile.Title = "Chọn tập tin phục hồi (.bak)";
            if (phuchoiFile.ShowDialog() == DialogResult.OK && phuchoiFile.CheckFileExists == true)
            {
                string sDuongDan = phuchoiFile.FileName;
                if (CSDL_BUS.PhucHoi(sDuongDan) == true)
                    MessageBox.Show("Thành công");
                else
                    MessageBox.Show("Thất bại");
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát chương trình không?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát chương trình?", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void mnuThongTin_Click(object sender, EventArgs e)
        {
            MoFormDuyNhat(new AboutBox());

        }

        private void mnuHuongDan_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "HDSD.chm");
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát chương trình?", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Application.Exit();
            }
        }

       
    }
}