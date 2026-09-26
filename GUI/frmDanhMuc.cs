using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmDanhMuc : Form
    {
        bool isAdding = false;
        public frmDanhMuc()
        {
            InitializeComponent();
            dgvDanhMuc.AutoGenerateColumns = false;
        }

        private void frmDanhMuc_Load(object sender, EventArgs e)
        {
            LoadData();
            SetState(false);
        }
        private void LoadData()
        {
            List<DanhMuc_DTO> ds = DanhMuc_BUS.LayDanhSachDanhMuc();
            dgvDanhMuc.DataSource = ds; 
            dgvDanhMuc.Columns["MaDanhMuc"].DataPropertyName = "IMaDanhMuc";
            dgvDanhMuc.Columns["TenDanhMuc"].DataPropertyName = "STenDanhMuc";
            lblTongSL.Text = "Tổng cộng : " + ds.Count;
        }

        private void SetState(bool editing)
        {
            txtTenDanhMuc.Enabled = editing;
            btnLuu.Enabled = editing;
            btnHuy.Enabled = editing;

            btnThem.Enabled = !editing;
            btnSua.Enabled = !editing;
            btnXoa.Enabled = !editing;
            dgvDanhMuc.Enabled = !editing;
        }

 
        private void dgvDanhMuc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDanhMuc.CurrentRow != null)
            {
                txtMaDanhMuc.Text = dgvDanhMuc.CurrentRow.Cells["MaDanhMuc"].Value.ToString();
                txtTenDanhMuc.Text = dgvDanhMuc.CurrentRow.Cells["TenDanhMuc"].Value.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            isAdding = true;
            txtMaDanhMuc.Clear();
            txtTenDanhMuc.Clear();
            SetState(true);
            txtTenDanhMuc.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtMaDanhMuc.Text))
            {
                MessageBox.Show("Vui lòng chọn danh mục cần sửa!", "Thông báo");
                return;
            }
            isAdding = false;
            SetState(true);
            txtTenDanhMuc.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaDanhMuc.Text)) return;

            DialogResult dr = MessageBox.Show("Xác nhận xóa danh mục này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                int id = int.Parse(txtMaDanhMuc.Text);
                if (DanhMuc_BUS.XoaDanhMuc(id))
                {
                    LoadData();
                    txtMaDanhMuc.Clear();
                    txtTenDanhMuc.Clear();
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string ten = txtTenDanhMuc.Text.Trim();
            if (string.IsNullOrEmpty(ten))
            {
                MessageBox.Show("Tên danh mục không được để trống!", "Thông báo");
                return;
            }

            if (isAdding)
            {
                if (DanhMuc_BUS.ThemDanhMuc(ten))
                {
                    MessageBox.Show("Thêm danh mục mới thành công!");
                }
            }
            else
            {
                int id = int.Parse(txtMaDanhMuc.Text);
                if (DanhMuc_BUS.SuaDanhMuc(id, ten))
                {
                    MessageBox.Show("Cập nhật danh mục thành công!");
                }
            }

            SetState(false);
            LoadData();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {

            SetState(false);
            dgvDanhMuc_CellClick(null, null);
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
