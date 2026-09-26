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
    public partial class frmQLTaiKhoan : Form
    {
        List<TaiKhoan_DTO> dsTaiKhoanGoc = new List<TaiKhoan_DTO>();
        public frmQLTaiKhoan()
        {
            InitializeComponent();
            dgvTaiKhoan.AutoGenerateColumns = false;
        }

        private void QLTaiKhoan_Load(object sender, EventArgs e)
        {
            LoadCombobox();
            LoadData();
        }
        private void LoadCombobox()
        {
            cboLoaiTaiKhoan.Items.Clear();
            cboLoaiTaiKhoan.Items.Add("Nhân viên (Staff)");   
            cboLoaiTaiKhoan.Items.Add("Quản trị viên (Admin)"); 
            cboLoaiTaiKhoan.SelectedIndex = 0;
        }

        private void LoadData()
        {
            dsTaiKhoanGoc = TaiKhoan_BUS.LayDSTaiKhoan();
            HienThiLenGrid(dsTaiKhoanGoc);
        }

        private void HienThiLenGrid(List<TaiKhoan_DTO> ds)
        {
            dgvTaiKhoan.DataSource = null;
            dgvTaiKhoan.DataSource = ds;
            lblTong.Text = "Tổng số tài khoản: " + ds.Count;
        }

        private void dgvTaiKhoan_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTaiKhoan.CurrentRow != null)
            {
                var tk = dgvTaiKhoan.CurrentRow.DataBoundItem as TaiKhoan_DTO;
                if (tk != null)
                {
                    txtTenDangNhap.Text = tk.TenDangNhap;
                    txtTenHienThi.Text = tk.TenHienThi;
                    cboLoaiTaiKhoan.SelectedIndex = tk.LoaiTaiKhoan;

                    txtTenDangNhap.ReadOnly = true;
                    txtTenDangNhap.BackColor = Color.LightGray;
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenDangNhap.Text) || string.IsNullOrWhiteSpace(txtTenHienThi.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Tên đăng nhập và Tên hiển thị!");
                return;
            }

            if (dsTaiKhoanGoc.Any(x => x.TenDangNhap == txtTenDangNhap.Text.Trim()))
            {
                MessageBox.Show("Tên đăng nhập này đã tồn tại, vui lòng chọn tên khác!");
                return;
            }

            TaiKhoan_DTO tk = new TaiKhoan_DTO();
            tk.TenDangNhap = txtTenDangNhap.Text.Trim();
            tk.TenHienThi = txtTenHienThi.Text.Trim();
            tk.LoaiTaiKhoan = cboLoaiTaiKhoan.SelectedIndex;

            if (TaiKhoan_BUS.ThemTaiKhoan(tk))
            {
                MessageBox.Show("Thêm tài khoản thành công! Mật khẩu mặc định là '1'.");
                LoadData();
                btnReset_Click(null, null);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenDangNhap.Text)) return;

            TaiKhoan_DTO tk = new TaiKhoan_DTO();
            tk.TenDangNhap = txtTenDangNhap.Text.Trim();
            tk.TenHienThi = txtTenHienThi.Text.Trim();
            tk.LoaiTaiKhoan = cboLoaiTaiKhoan.SelectedIndex;

            if (TaiKhoan_BUS.SuaTaiKhoan(tk))
            {
                MessageBox.Show("Cập nhật thông tin tài khoản thành công!");
                LoadData();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string username = txtTenDangNhap.Text.Trim();
            if (string.IsNullOrEmpty(username)) return;

            if (username.ToLower() == "admin")
            {
                MessageBox.Show("Không thể xóa tài khoản Quản trị hệ thống!");
                return;
            }

            DialogResult dr = MessageBox.Show($"Xác nhận xóa tài khoản [{username}]?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                if (TaiKhoan_BUS.XoaTaiKhoan(username))
                {
                    MessageBox.Show("Đã xóa tài khoản!");
                    LoadData();
                    btnReset_Click(null, null);
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtTenDangNhap.ReadOnly = false;
            txtTenDangNhap.BackColor = Color.White;
            txtTenDangNhap.Clear();
            txtTenHienThi.Clear();
            cboLoaiTaiKhoan.SelectedIndex = 0;
            txtTenDangNhap.Focus();
        }

        private void btnDatLaiMatKhau_Click(object sender, EventArgs e)
        {
            string username = txtTenDangNhap.Text.Trim();
            if (string.IsNullOrEmpty(username)) return;

            if (MessageBox.Show($"Đặt lại mật khẩu cho tài khoản [{username}] về mặc định là '1'?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (TaiKhoan_BUS.ResetMatKhau(username))
                {
                    MessageBox.Show("Đã đặt lại mật khẩu thành công!");
                }
            }
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
