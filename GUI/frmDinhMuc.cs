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
    public partial class frmDinhMuc : Form
    {
        public frmDinhMuc()
        {
            InitializeComponent();
          
        }

        private void frmDinhMuc_Load(object sender, EventArgs e)
        {
            LoadDuLieuCombobox();
            dgvDinhMuc.AutoGenerateColumns = false;
        }

        private void LoadDuLieuCombobox()
        {
            List<ThucUong_DTO> dsMon = ThucUong_BUS.LayDSThucUong();
            cboThucUong.DataSource = ThucUong_BUS.LayDSThucUong();
            cboThucUong.DisplayMember = "STenThucUong";
            cboThucUong.ValueMember = "IMaThucUong";

            cboNguyenLieu.DataSource = NguyenLieu_BUS.LayDanhSachNguyenLieu();
            cboNguyenLieu.DisplayMember = "TenNL1";
            cboNguyenLieu.ValueMember = "MaNL1";
            if (dsMon != null && dsMon.Count > 0)
            {
                cboThucUong.SelectedIndex = 0; 
                lblTenMon.Text = dsMon[0].STenThucUong; 
                LoadCongThucLenGrid(dsMon[0].IMaThucUong); 
            }
        }

        private void cboNguyenLieu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboNguyenLieu.SelectedItem != null && cboNguyenLieu.SelectedItem is NguyenLieu_DTO)
            {
                NguyenLieu_DTO nlChon = (NguyenLieu_DTO)cboNguyenLieu.SelectedItem;
                txtDVT.Text = nlChon.DonViTinh1; 
            }
        }

        

        private void LoadCongThucLenGrid(int maMon)
        {
            List<DinhMuc_DTO> dsDinhMuc = DinhMuc_BUS.LayDinhMucTheoMon(maMon);
            List<NguyenLieu_DTO> dsKho = NguyenLieu_BUS.LayDanhSachNguyenLieu();

            if (dsDinhMuc != null && dsKho != null)
            {
                dgvDinhMuc.Columns[0].DataPropertyName = "MaNL1";
                dgvDinhMuc.Columns[1].DataPropertyName = "TenNL1";
                dgvDinhMuc.Columns[2].DataPropertyName = "HamLuong1";
                dgvDinhMuc.Columns[3].DataPropertyName = "DonViTinh1";
                var hienThi = from dm in dsDinhMuc
                              join nl in dsKho on dm.MaNL1 equals nl.MaNL1
                              select new
                              {
                                  MaNL1 = dm.MaNL1,
                                  TenNL1 = nl.TenNL1,
                                  HamLuong1 = dm.HamLuong1,
                                  DonViTinh1 = nl.DonViTinh1
                              };

                dgvDinhMuc.DataSource = hienThi.ToList();
                lblTong.Text = hienThi.Count().ToString();
            }
            else
            {
                dgvDinhMuc.DataSource = null;
                lblTong.Text = "0";
            }
        }

        private void dgvDinhMuc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDinhMuc.Rows[e.RowIndex];
                cboNguyenLieu.SelectedValue = row.Cells["MaNL"].Value;
                numHamLuong.Value = Convert.ToDecimal(row.Cells["HamLuong"].Value);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (cboThucUong.SelectedValue == null || cboNguyenLieu.SelectedValue == null) return;

            int maMon = (int)cboThucUong.SelectedValue;
            int maNL = (int)cboNguyenLieu.SelectedValue;
            float hamLuong = (float)numHamLuong.Value;

            if (hamLuong <= 0)
            {
                MessageBox.Show("Hàm lượng tiêu hao phải lớn hơn 0!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<DinhMuc_DTO> current = DinhMuc_BUS.LayDinhMucTheoMon(maMon);
            if (current != null && current.Any(x => x.MaNL1 == maNL))
            {
                MessageBox.Show("Nguyên liệu này đã có trong công thức!\nVui lòng chọn món trên lưới và bấm [Cập nhật].", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DinhMuc_DTO dm = new DinhMuc_DTO { MaThucUong1 = maMon, MaNL1 = maNL, HamLuong1 = hamLuong };
            if (DinhMuc_BUS.ThemDinhMuc(dm))
            {
                LoadCongThucLenGrid(maMon);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (cboThucUong.SelectedValue == null || cboNguyenLieu.SelectedValue == null) return;

            DinhMuc_DTO dm = new DinhMuc_DTO();
            dm.MaThucUong1 = (int)cboThucUong.SelectedValue;
            dm.MaNL1 = (int)cboNguyenLieu.SelectedValue;
            dm.HamLuong1 = (float)numHamLuong.Value;

            if (DinhMuc_BUS.SuaDinhMuc(dm))
            {
                LoadCongThucLenGrid(dm.MaThucUong1);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (cboThucUong.SelectedValue == null || cboNguyenLieu.SelectedValue == null) return;

            int maMon = (int)cboThucUong.SelectedValue;
            int maNL = (int)cboNguyenLieu.SelectedValue;

            if (MessageBox.Show("Bạn có muốn loại bỏ nguyên liệu này khỏi công thức?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (DinhMuc_BUS.XoaDinhMuc(maMon, maNL))
                {
                    LoadCongThucLenGrid(maMon);
                }
            }
        }

        private void cboThucUong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboThucUong.SelectedValue != null)
            {
                if (int.TryParse(cboThucUong.SelectedValue.ToString(), out int maMon))
                {
                    lblTenMon.Text = cboThucUong.Text;
                    LoadCongThucLenGrid(maMon);
                    numHamLuong.Value = 0;
                }
            }
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}