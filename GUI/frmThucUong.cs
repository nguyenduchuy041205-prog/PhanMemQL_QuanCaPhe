using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace GUI
{
    public partial class frmThucUong : Form
    {
        List<ThucUong_DTO> dsThucUongGoc = new List<ThucUong_DTO>();
        bool isAdding = false;
        string duongDanAnhMoi = "";

        public frmThucUong()
        {
            InitializeComponent();
            dgvThucUong.AutoGenerateColumns = false;
        }

        private void frmThucUong_Load(object sender, EventArgs e)
        {
            LoadComboBox();
            LoadData();
            SetState(false);
        }

        private void LoadData()
        {
            dsThucUongGoc = ThucUong_BUS.LayDSThucUong() ?? new List<ThucUong_DTO>();
            dgvThucUong.DataSource = dsThucUongGoc;
            lblTongCong.Text = "Tổng cộng : " + dsThucUongGoc.Count;
        }

        private void LoadComboBox()
        {
            cboDanhMuc.DataSource = DanhMuc_BUS.LayDanhSachDanhMuc();
            cboDanhMuc.DisplayMember = "STenDanhMuc";
            cboDanhMuc.ValueMember = "IMaDanhMuc";
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim().ToLower();
            var ketQua = dsThucUongGoc.Where(x =>
                (x.STenThucUong != null && x.STenThucUong.ToLower().Contains(keyword)) ||
                x.IMaThucUong.ToString().Contains(keyword)
            ).ToList();

            dgvThucUong.DataSource = ketQua;
            lblTongCong.Text = "Tìm thấy: " + ketQua.Count + " món";
        }

        private void SetState(bool editing)
        {
            txtTenMon.Enabled = editing;
            cboDanhMuc.Enabled = editing;
            numDonGia.Enabled = editing;
            btnChonAnh.Enabled = editing;
            btnLuu.Enabled = editing;
            btnHuy.Enabled = editing;
            btnThem.Enabled = !editing;
            btnSua.Enabled = !editing;
            btnXoa.Enabled = !editing;
            dgvThucUong.Enabled = !editing;
        }

        private void dgvThucUong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && !btnLuu.Enabled)
            {
                if (dgvThucUong.Rows[e.RowIndex].DataBoundItem is ThucUong_DTO item)
                {
                    txtMaMon.Text = item.IMaThucUong.ToString();
                    txtTenMon.Text = item.STenThucUong;
                    cboDanhMuc.Text = item.STenDanhMuc;
                    numDonGia.Value = (decimal)item.FDonGia;

                    if (picHinhAnh.Image != null) picHinhAnh.Image.Dispose();

                    if (!string.IsNullOrEmpty(item.SHinhAnh))
                    {
                        string path = Path.Combine(Application.StartupPath, "Images", item.SHinhAnh);
                        if (File.Exists(path))
                        {
                            try
                            {
                                using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
                                {
                                    using (var imgTemp = Image.FromStream(stream))
                                    {
                                        picHinhAnh.Image = new Bitmap(imgTemp, new Size(150, 150));
                                    }
                                }
                                picHinhAnh.Tag = item.SHinhAnh;
                            }
                            catch { picHinhAnh.Image = null; }
                        }
                        else picHinhAnh.Image = null;
                    }
                    else
                    {
                        picHinhAnh.Image = null;
                        picHinhAnh.Tag = null;
                    }
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            isAdding = true;
            txtMaMon.Text = "Tự động tăng";
            txtTenMon.Clear();
            numDonGia.Value = numDonGia.Minimum;
            if (picHinhAnh.Image != null) picHinhAnh.Image.Dispose();
            picHinhAnh.Image = null;
            picHinhAnh.Tag = null;
            SetState(true);
            txtTenMon.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaMon.Text) || txtMaMon.Text == "Tự động tăng") return;
            isAdding = false;
            SetState(true);
            txtTenMon.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenMon.Text))
            {
                MessageBox.Show("Vui lòng nhập tên món!");
                return;
            }

            ThucUong_DTO obj = new ThucUong_DTO();
            obj.STenThucUong = txtTenMon.Text;
            obj.IMaDanhMuc = (int)cboDanhMuc.SelectedValue;
            obj.FDonGia = (float)numDonGia.Value;
            obj.SHinhAnh = picHinhAnh.Tag != null ? picHinhAnh.Tag.ToString() : "";


            if (isAdding)
            {
                if (ThucUong_BUS.ThemThucUong(obj)) MessageBox.Show("Thêm thành công!");
            }
            else
            {
                obj.IMaThucUong = int.Parse(txtMaMon.Text);
                if (ThucUong_BUS.SuaThucUong(obj)) MessageBox.Show("Sửa thành công!");
            }

            LoadData();
            SetState(false);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            SetState(false);
            if (dgvThucUong.CurrentRow != null)
                dgvThucUong_CellClick(dgvThucUong, new DataGridViewCellEventArgs(0, dgvThucUong.CurrentRow.Index));
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvThucUong.CurrentRow == null) return;
            ThucUong_DTO item = dgvThucUong.CurrentRow.DataBoundItem as ThucUong_DTO;

            if (item != null)
            {
                if (MessageBox.Show($"Bạn có chắc muốn ngừng bán món [{item.STenThucUong}]?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (ThucUong_BUS.XoaThucUong(item.IMaThucUong))
                    {
                        MessageBox.Show("Đã chuyển trạng thái món sang ngừng bán!");
                        LoadData(); 
                    }
                }
            }
        }

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        if (picHinhAnh.Image != null) picHinhAnh.Image.Dispose();

                        using (var imgTemp = Image.FromFile(ofd.FileName))
                        {
                            picHinhAnh.Image = new Bitmap(imgTemp, new Size(150, 150));
                            picHinhAnh.Tag = Path.GetFileName(ofd.FileName);
                            duongDanAnhMoi = ofd.FileName;
                        }
                    }
                    catch { MessageBox.Show("Ảnh không hợp lệ!"); }
                }
            }
        }

        private void dgvThucUong_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvThucUong.Columns[e.ColumnIndex].Name == "HinhAnh" && e.RowIndex >= 0)
            {
                var item = dgvThucUong.Rows[e.RowIndex].DataBoundItem as ThucUong_DTO;
                if (item != null && !string.IsNullOrEmpty(item.SHinhAnh))
                {
                    string path = Path.Combine(Application.StartupPath, "Images", item.SHinhAnh);

                    if (File.Exists(path))
                    {
                        try
                        {
                            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
                            {
                                e.Value = new Bitmap(Image.FromStream(fs), new Size(60, 60));
                            }
                        }
                        catch { e.Value = null; }
                    }
                }
            }
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnThungRac_Click(object sender, EventArgs e)
        {
            frmMonNgungBan f = new frmMonNgungBan();
            f.ShowDialog(); 
            LoadData();
        }
    }
}