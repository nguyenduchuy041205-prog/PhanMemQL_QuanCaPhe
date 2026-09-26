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
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string user = txtTenDangNhap.Text;
            string pass = txtMatKhau.Text;
            TaiKhoan_DTO result = TaiKhoan_BUS.DangNhap(user, pass);

            if (result != null)
            {
                frmMain.CurrentUser = result;
                frmMain.bDangNhap = true;
                frmMain parent = (frmMain)this.MdiParent;
                parent.HienThiMenu();
                MessageBox.Show("Chào mừng " + result.TenHienThi + "!", "Thông báo");
                this.Close();
            }
            else
            {
                frmMain.bDangNhap = false;
                MessageBox.Show("Tài khoản hoặc mật khẩu không đúng!", "Lỗi");
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
                txtMatKhau.UseSystemPasswordChar = true;
            }
            else
            {
                txtMatKhau.UseSystemPasswordChar = false;
            }
        }

        private void txtMatKhau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnDangNhap_Click(sender, e);
            }
        }
    }
}
