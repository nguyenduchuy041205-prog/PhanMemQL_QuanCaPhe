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
    public partial class frmQLHoaDon : Form
    {
        List<HoaDon_DTO> dsGoc = new List<HoaDon_DTO>();
        public frmQLHoaDon()
        {
            InitializeComponent();
            dgvHoaDon.AutoGenerateColumns = false;
        }

       
        private void LoadLichSu()
        {
            DateTime tuNgay = dtpTuNgay.Value;
            DateTime denNgay = dtpDenNgay.Value;
            dsGoc = HoaDon_BUS.LayLichSuHoaDon(tuNgay, denNgay);
            HienThiLenGrid(dsGoc);
        }

 

        private void QLHoaDon_Load(object sender, EventArgs e)
        {
            dtpTuNgay.Value = DateTime.Now;
            dtpDenNgay.Value = DateTime.Now;
            LoadLichSu();
        }

        private void btnMoFile_Click(object sender, EventArgs e)
        {
            if (dgvHoaDon.CurrentRow == null) return;
            var hd = dgvHoaDon.CurrentRow.DataBoundItem as HoaDon_DTO;
            if (hd == null) return;
            string soBan = System.Text.RegularExpressions.Regex.Match(hd.BanPhucVu, @"\d+").Value;
            string folderPath = System.IO.Path.Combine(Application.StartupPath, "HoaDon");
            if (!System.IO.Directory.Exists(folderPath))
            {
                MessageBox.Show("Thư mục chứa hóa đơn không tồn tại!");
                return;
            }
            string pattern = string.Format("HD_Ban{0}_{1}*.txt", soBan, hd.ThoiGian.ToString("yyyyMMdd_HHmm"));
            try
            {
                string[] files = System.IO.Directory.GetFiles(folderPath, pattern);

                if (files.Length > 0)
                {
                    var newestFile = files.OrderByDescending(f => f).First();
                    System.Diagnostics.Process.Start("notepad.exe", newestFile);
                }
                else
                {
                    MessageBox.Show($"Không tìm thấy hóa đơn của Bàn {soBan} lúc {hd.ThoiGian:HH:mm}\n(Vui lòng kiểm tra thư mục: {folderPath})");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnTraCuu_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            LoadLichSu();
        }

        private void btnXoaHD_Click(object sender, EventArgs e)
        {
            if (dgvHoaDon.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một hóa đơn trong danh sách để xóa!", "Thông báo");
                return;
            }

            var hd = dgvHoaDon.CurrentRow.DataBoundItem as HoaDon_DTO;
            if (hd == null) return;

            DialogResult dr = MessageBox.Show($"Bạn có chắc chắn muốn xóa hóa đơn mã {hd.MaHD} không?\nLưu ý: Thao tác này sẽ xóa vĩnh viễn dữ liệu doanh thu!",
                                              "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
            {
              
                if (HoaDon_BUS.XoaHoaDon(hd.MaHD, -1))
                {
                    MessageBox.Show("Đã xóa hóa đơn thành công!");
                    LoadLichSu(); 
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra khi xóa hóa đơn!");
                }
            }
        }

       
        private void HienThiLenGrid(List<HoaDon_DTO> danhSach)
        {
            dgvHoaDon.DataSource = null;
            dgvHoaDon.DataSource = danhSach;

            if (danhSach != null)
            {
                lblTongHD.Text = danhSach.Count.ToString();
                lblDoanhThu.Text = danhSach.Sum(x => x.TongTien).ToString("N0") + "đ";
            }
            else
            {
                lblTongHD.Text = "0";
                lblDoanhThu.Text = "0đ";
            }
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                if (dsGoc == null || dsGoc.Count == 0) return;
                string tuKhoa = txtTimKiem.Text.ToLower().Trim();
                if (string.IsNullOrEmpty(tuKhoa))
                {
                    HienThiLenGrid(dsGoc);
                }
                else
                {
                    var dsLoc = dsGoc.Where(x =>
                        x.MaHD.ToString().Contains(tuKhoa) ||
                        (x.BanPhucVu != null && x.BanPhucVu.ToLower().Contains(tuKhoa)) ||
                        (x.NhanVien != null && x.NhanVien.ToLower().Contains(tuKhoa))
                    ).ToList();

                    HienThiLenGrid(dsLoc);
                }
            }
        }
    }
}
