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
    public partial class frmNguyenLieu : Form
    {
        public frmNguyenLieu()
        {
            InitializeComponent();
        }

        private void frmNguyenLieu_Load(object sender, EventArgs e)
        {
            LoadDanhSachNguyenLieu();
        }
        private void LoadDanhSachNguyenLieu()
        {
            List<NguyenLieu_DTO> lst = NguyenLieu_BUS.LayDanhSachNguyenLieu();
            dgvNguyenLieu.DataSource = lst;

            if (lst != null)
            {
                lblTongNL.Text = "Tổng số nguyên liệu: " + lst.Count;
                int sapHet = lst.Count(x => x.SoLuongTon1 < 1000);

                lblNLSapHet.Text = "Sắp hết (< 1000): " + sapHet + " mục";
                if (sapHet > 0) lblNLSapHet.ForeColor = Color.Crimson;
                else lblNLSapHet.ForeColor = Color.MediumSeaGreen;
            }
        }

        private void dgvNguyenLieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvNguyenLieu.Rows[e.RowIndex];
                txtMaNguyenLieu.Text = row.Cells["MaNL"].Value.ToString();
                txtTenNguyenLieu.Text = row.Cells["TenNL"].Value.ToString();
                txtSoLuongTon.Text = row.Cells["SoLuongTon"].Value.ToString();
                cboDonViTinh.Text = row.Cells["DonViTinh"].Value.ToString();

                numSLNhap.Value = 0;
            }
        }

        private void dgvNguyenLieu_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvNguyenLieu.Columns[e.ColumnIndex].Name == "SoLuongTon" && e.Value != null)
            {
                float soLuong = float.Parse(e.Value.ToString());
                if (soLuong < 1000)
                {
                    e.CellStyle.ForeColor = Color.Crimson;
                    e.CellStyle.Font = new Font(dgvNguyenLieu.Font, FontStyle.Bold);
                }
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiem.Text.ToLower();
            List<NguyenLieu_DTO> lst = NguyenLieu_BUS.LayDanhSachNguyenLieu();

            if (lst != null)
            {
                List<NguyenLieu_DTO> lstLoc = lst.Where(x => x.TenNL1.ToLower().Contains(tuKhoa)).ToList();
                dgvNguyenLieu.DataSource = lstLoc;
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaNguyenLieu.Clear();
            txtTenNguyenLieu.Clear();
            txtSoLuongTon.Clear();
            cboDonViTinh.SelectedIndex = -1;
            cboDonViTinh.Text = "";
            numSLNhap.Value = 0;
            txtTenNguyenLieu.Focus();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            float slNhap = (float)numSLNhap.Value;

            if (!string.IsNullOrEmpty(txtMaNguyenLieu.Text))
            {
                if (slNhap <= 0)
                {
                    MessageBox.Show("Vui lòng nhập số lượng nhập kho lớn hơn 0!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int maNL = int.Parse(txtMaNguyenLieu.Text);
                float tonHienTai = string.IsNullOrEmpty(txtSoLuongTon.Text) ? 0 : float.Parse(txtSoLuongTon.Text);

                NguyenLieu_DTO nlUpdate = new NguyenLieu_DTO();
                nlUpdate.MaNL1 = maNL;
                nlUpdate.TenNL1 = txtTenNguyenLieu.Text;
                nlUpdate.DonViTinh1 = cboDonViTinh.Text;
                nlUpdate.SoLuongTon1 = tonHienTai + slNhap; 

                if (NguyenLieu_BUS.SuaNguyenLieu(nlUpdate))
                {
                    MessageBox.Show($"Đã nhập thêm [{slNhap}] vào kho cho món [{nlUpdate.TenNL1}].\nSố lượng tồn mới là: {nlUpdate.SoLuongTon1}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSachNguyenLieu();
                    btnLamMoi_Click(sender, e); 
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra khi nhập kho!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                string tenNL = txtTenNguyenLieu.Text.Trim();
                string dvt = cboDonViTinh.Text.Trim();

                if (string.IsNullOrEmpty(tenNL) || string.IsNullOrEmpty(dvt))
                {
                    MessageBox.Show("Vui lòng nhập Tên và Đơn vị tính cho nguyên liệu mới!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                List<NguyenLieu_DTO> lstKho = NguyenLieu_BUS.LayDanhSachNguyenLieu();
                NguyenLieu_DTO nlTonTai = lstKho.FirstOrDefault(x => x.TenNL1.ToLower() == tenNL.ToLower());

                if (nlTonTai != null)
                {
                    nlTonTai.SoLuongTon1 += slNhap;
                    if (NguyenLieu_BUS.SuaNguyenLieu(nlTonTai))
                    {
                        MessageBox.Show($"Nguyên liệu '{tenNL}' đã có sẵn. Hệ thống tự động cộng dồn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDanhSachNguyenLieu();
                        btnLamMoi_Click(sender, e);
                    }
                }
                else
                {
                    NguyenLieu_DTO nlMoi = new NguyenLieu_DTO();
                    nlMoi.TenNL1 = tenNL;
                    nlMoi.DonViTinh1 = dvt;
                    nlMoi.SoLuongTon1 = slNhap;

                    if (NguyenLieu_BUS.ThemNguyenLieu(nlMoi))
                    {
                        MessageBox.Show("Tạo nguyên liệu mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDanhSachNguyenLieu();
                        btnLamMoi_Click(sender, e);
                    }
                }
            }
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaNguyenLieu.Text))
            {
                MessageBox.Show("Vui lòng chọn một nguyên liệu từ danh sách để thao tác!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            NguyenLieu_DTO nl = new NguyenLieu_DTO();
            nl.MaNL1 = int.Parse(txtMaNguyenLieu.Text);
            nl.TenNL1 = txtTenNguyenLieu.Text;
            nl.DonViTinh1 = cboDonViTinh.Text;

            float tonKhoHienTai = float.Parse(txtSoLuongTon.Text);
            float slNhap = (float)numSLNhap.Value;
            nl.SoLuongTon1 = tonKhoHienTai + slNhap;

            if (nl.SoLuongTon1 < 0)
            {
                MessageBox.Show("Số lượng tồn kho không thể nhỏ hơn 0. Vui lòng kiểm tra lại số lượng xuất!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (NguyenLieu_BUS.SuaNguyenLieu(nl))
            {
                MessageBox.Show("Cập nhật kho thành công!\nSố lượng mới: " + nl.SoLuongTon1, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDanhSachNguyenLieu();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaNguyenLieu.Text))
            {
                MessageBox.Show("Vui lòng chọn nguyên liệu cần xóa!", "Cảnh báo");
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa nguyên liệu này? Các món ăn đang sử dụng nguyên liệu này có thể bị lỗi định mức!", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                int maNL = int.Parse(txtMaNguyenLieu.Text);
                if (NguyenLieu_BUS.XoaNguyenLieu(maNL))
                {
                    MessageBox.Show("Đã xóa nguyên liệu!", "Thông báo");
                    LoadDanhSachNguyenLieu();
                    btnLamMoi_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Xóa thất bại! Nguyên liệu này đang nằm trong công thức của một số món.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
