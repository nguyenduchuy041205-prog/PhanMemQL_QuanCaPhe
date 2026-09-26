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
    public partial class frmDoiMatKhau : Form
    {
        private TaiKhoan_DTO currentAccount;

        public frmDoiMatKhau(TaiKhoan_DTO loginAcc)
        {
            InitializeComponent();
            this.currentAccount = loginAcc;
        }

        private void frmDoiMatKhau_Load(object sender, EventArgs e)
        {
            if (currentAccount == null)
            {
                MessageBox.Show("Lỗi: Không tìm thấy thông tin tài khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            txtTenDangNhap.Text = currentAccount.TenDangNhap;
            txtTenDangNhap.ReadOnly = true;
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            string mkCu = txtMatKhauCu.Text;
            string mkMoi = txtMatKhauMoi.Text;
            string xacNhan = txtXacNhanMatKhau.Text;

            if (string.IsNullOrEmpty(mkCu) || string.IsNullOrEmpty(mkMoi) || string.IsNullOrEmpty(xacNhan))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ các thông tin!");
                return;
            }

            TaiKhoan_DTO checkAcc = TaiKhoan_BUS.DangNhap(currentAccount.TenDangNhap, mkCu);
            if (checkAcc == null)
            {
                MessageBox.Show("Mật khẩu cũ không chính xác!");
                txtMatKhauCu.Focus();
                return;
            }

            if (mkMoi != xacNhan)
            {
                MessageBox.Show("Mật khẩu mới và xác nhận không trùng khớp!");
                return;
            }

            if (TaiKhoan_BUS.DoiMatKhau(currentAccount, mkMoi))
            {
                MessageBox.Show("Đổi mật khẩu thành công!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra, vui lòng thử lại sau.");
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkHienThiMK_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHienThiMK.Checked)
            {
                txtMatKhauCu.UseSystemPasswordChar = true;
                txtMatKhauMoi.UseSystemPasswordChar = true;
                txtXacNhanMatKhau.UseSystemPasswordChar = true;
            }
            else
            {
                txtMatKhauCu.UseSystemPasswordChar = false;
                txtMatKhauMoi.UseSystemPasswordChar = false;
                txtXacNhanMatKhau.UseSystemPasswordChar = false;
            }
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
