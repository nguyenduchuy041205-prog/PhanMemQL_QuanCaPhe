using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmBan : Form
    {
        List<Ban_DTO> dsBan = new List<Ban_DTO>();
        bool isAdding = false;
        public frmBan()
        {
            InitializeComponent();
            dgvBan.AutoGenerateColumns = false;
        }

        private void frmBan_Load(object sender, EventArgs e)
        {
            LoadTrangThaiCBO();
            LoadData();
            SetState(false);
        }
        private void LoadTrangThaiCBO()
        {
            txtTrangThai.Items.Clear();
            txtTrangThai.Items.Add("Trống");
            txtTrangThai.Items.Add("Có người");
            txtTrangThai.SelectedIndex = 0;
        }

        private void LoadData()
        {
            dsBan = Ban_BUS.LayDanhSachBan() ?? new List<Ban_DTO>();
            dgvBan.DataSource = dsBan;

            int trong = dsBan.Count(x => x.STrangThai == "Trống");
            int coNguoi = dsBan.Count - trong;

            lblBanTrong.Text = trong.ToString();
            lblCoNguoi.Text = coNguoi.ToString();
        }

        private void SetState(bool editing)
        {
            txtTebBan.Enabled = editing;
            txtTrangThai.Enabled = editing;

            btnLuu.Enabled = editing;
            btnHuy.Enabled = editing;

            btnThem.Enabled = !editing;
            btnSua.Enabled = !editing;
            btnXoa.Enabled = !editing;
            dgvBan.Enabled = !editing;
        }

        private void dgvBan_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvBan.CurrentRow != null && !btnLuu.Enabled)
            {
                Ban_DTO ban = dgvBan.CurrentRow.DataBoundItem as Ban_DTO;
                if (ban != null)
                {
                    txtMaBan.Text = ban.IMaBan.ToString();
                    txtTebBan.Text = ban.STenBan;
                    txtTrangThai.Text = ban.STrangThai;
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

            isAdding = true;
            txtMaBan.Text = "Tự động";
            txtTebBan.Clear();
            txtTrangThai.SelectedIndex = 0;
            SetState(true);
            txtTebBan.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvBan.CurrentRow == null) return;
            isAdding = false;
            SetState(true);
            txtTebBan.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtTebBan.Text))
            {
                MessageBox.Show("Vui lòng nhập tên bàn!");
                return;
            }

            Ban_DTO ban = new Ban_DTO();
            ban.STenBan = txtTebBan.Text;
            ban.STrangThai = txtTrangThai.Text;

            if (isAdding)
            {
                if (Ban_BUS.ThemBan(ban)) MessageBox.Show("Thêm bàn thành công!");
            }
            else
            {
                ban.IMaBan = int.Parse(txtMaBan.Text);
                if (Ban_BUS.SuaBan(ban)) MessageBox.Show("Cập nhật thành công!");
            }

            LoadData();
            SetState(false);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            if (dgvBan.CurrentRow == null) return;
            Ban_DTO ban = dgvBan.CurrentRow.DataBoundItem as Ban_DTO;

            if (ban.STrangThai == "Có người")
            {
                MessageBox.Show("Bàn đang có người, không thể xóa!");
                return;
            }

            if (MessageBox.Show($"Xác nhận xóa {ban.STenBan}?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (Ban_BUS.XoaBan(ban.IMaBan))
                {
                    MessageBox.Show("Đã xóa!");
                    LoadData();
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            SetState(false);
            dgvBan_SelectionChanged(null, null);
        }

        private void dgvBan_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvBan.Columns[e.ColumnIndex].Name == "TrangThai") 
            {
                if (e.Value != null && e.Value.ToString() == "Có người")
                {
                    e.CellStyle.ForeColor = Color.Red;
                    e.CellStyle.Font = new Font(dgvBan.Font, FontStyle.Bold);
                }
                else
                {
                    e.CellStyle.ForeColor = Color.Green;
                }
            }
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
