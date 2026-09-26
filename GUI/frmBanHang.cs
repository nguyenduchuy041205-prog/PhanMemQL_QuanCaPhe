using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace GUI
{
    public partial class frmBanHang : Form
    {
        private int maBanHienTai = -1;
        private float tongTienHienTai = 0;
        private bool dangLoadDuLieu = false;

        public frmBanHang()
        {
            InitializeComponent();
            LoadDanhSachBan();
            LoadDanhMuc();
            LoadThucUong();
            LoadComboBoxBanDich();

            btnChuyenMon.Enabled = false;
        }

        #region Xử lý Sơ đồ bàn
        private void LoadDanhSachBan()
        {
            flpBan.Controls.Clear();
            List<Ban_DTO> lstBan = Ban_BUS.LayDanhSachBan();
            if (lstBan == null) return;

            foreach (Ban_DTO ban in lstBan)
            {
                Button btn = new Button();
                btn.Width = 90;
                btn.Height = 90;
                btn.Text = ban.STenBan + Environment.NewLine + ban.STrangThai;
                btn.Tag = ban;

                if (ban.STrangThai == "Trống")
                    btn.BackColor = Color.LightGreen;
                else
                    btn.BackColor = Color.LightCoral;

                btn.Click += BtnBan_Click;
                flpBan.Controls.Add(btn);
              
            }
        }
       
        
        private void BtnBan_Click(object sender, EventArgs e)
        {
            Button btnClick = sender as Button;
            Ban_DTO banDuocChon = btnClick.Tag as Ban_DTO;

            maBanHienTai = banDuocChon.IMaBan;
            lblHoaDon.Text = "Hóa đơn - " + banDuocChon.STenBan;

            HienThiHoaDon(banDuocChon.IMaBan);
        }
        #endregion

        #region Xử lý Thực đơn
        private void LoadDanhMuc()
        {
            List<DanhMuc_DTO> lstDanhMuc = DanhMuc_BUS.LayDanhSachDanhMuc();
            DanhMuc_DTO tatCa = new DanhMuc_DTO { IMaDanhMuc = 0, STenDanhMuc = "Tất cả" };
            lstDanhMuc.Insert(0, tatCa);

            cboDanhMuc.DataSource = lstDanhMuc;
            cboDanhMuc.DisplayMember = "STenDanhMuc";
            cboDanhMuc.ValueMember = "IMaDanhMuc";
        }

        private void LoadThucUong()
        {
            flpThucDon.Controls.Clear();
            List<ThucUong_DTO> lstThucUong = ThucUong_BUS.LayDSThucUongDeBan(); 
            if (lstThucUong == null) return;
            RenderThucDon(lstThucUong);
        }

        private void LoadThucUongTheoDanhMuc(int id)
        {
            flpThucDon.Controls.Clear();
            List<ThucUong_DTO> lstThucUong = ThucUong_BUS.LayDanhSachThucUongTheoDanhMuc(id);
            if (lstThucUong == null) return;
            RenderThucDon(lstThucUong);
        }

        private void RenderThucDon(List<ThucUong_DTO> list)
        {
            foreach (ThucUong_DTO thucuong in list)
            {
                ucMon item = new ucMon();
                item.Margin = new Padding(4);
                item.LoadData(thucuong.STenThucUong, thucuong.FDonGia, thucuong.SHinhAnh);
                item.Click += (s, ev) => { XuLyChonMon(thucuong); };
                flpThucDon.Controls.Add(item);
            }
        }

        private void cboDanhMuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDanhMuc.SelectedItem == null) return;
            DanhMuc_DTO selected = cboDanhMuc.SelectedItem as DanhMuc_DTO;
            if (selected.IMaDanhMuc == 0) LoadThucUong();
            else LoadThucUongTheoDanhMuc(selected.IMaDanhMuc);
        }
        private void LamMoiOThongTin()
        {
            txtTenMon.Text = "";
            txtGhiChu.Text = "";
            numSL.Value = 1;
            txtTenMon.Tag = null;
        }
        private void XuLyChonMon(ThucUong_DTO thucuong)
        {
            if (!DinhMuc_BUS.KiemTraMonDaCoCongThuc(thucuong.IMaThucUong))
            {
                MessageBox.Show("Món này chưa được thiết lập công thức pha chế!", "Thông báo");
                return;
            }
            if (maBanHienTai == -1)
            {
                MessageBox.Show("Vui lòng chọn bàn trước khi gọi món!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!NguyenLieu_BUS.KiemTraDuNguyenLieu(thucuong.IMaThucUong))
            {
                MessageBox.Show($"Món [{thucuong.STenThucUong}] đã hết nguyên liệu pha chế!", "Hết hàng", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            int maHD = HoaDon_BUS.LayMaHDTheoBan(maBanHienTai);
            if (maHD == -1)
            {
                if (HoaDon_BUS.ThemHoaDonMoi(maBanHienTai))
                {
                    maHD = HoaDon_BUS.LayMaHDTheoBan(maBanHienTai);
                    LoadDanhSachBan(); 
                }
                else
                {
                    MessageBox.Show("Không thể tạo hóa đơn mới!", "Lỗi");
                    return;
                }
            }

            if (ChiTietHoaDon_BUS.ThemChiTietHoaDon(maHD, thucuong.IMaThucUong, 1, ""))
            {
                LamMoiOThongTin();
                HienThiHoaDon(maBanHienTai);
            }
            else
            {
                MessageBox.Show("Thêm món thất bại!", "Lỗi");
            }
        }
        #endregion

        #region Xử lý Hóa đơn
        private void HienThiHoaDon(int maBan)
        {
            dgvHoaDon_Ban.Rows.Clear();
            List<Menu_DTO> lstMenu = Menu_BUS.LayDanhSachMenuTheoBan(maBan);
            tongTienHienTai = 0;

            if (lstMenu != null)
            {
                foreach (Menu_DTO item in lstMenu)
                {
                    int rowIndex = dgvHoaDon_Ban.Rows.Add(
                        item.IMaThucUong,    
                        item.STenThucUong,  
                        item.ISoLuong,       
                        item.SGhiChu,        
                        item.FThanhTien.ToString("N0") 
                    );

                    dgvHoaDon_Ban.Rows[rowIndex].Tag = item.IMaThucUong;
                    tongTienHienTai += item.FThanhTien;
                }
            }
            lblTong.Text = "Tổng cộng: " + tongTienHienTai.ToString("N0") + " đ";
        }



        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (maBanHienTai == -1)
            {
                MessageBox.Show("Vui lòng chọn một Bàn để thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maHD = HoaDon_BUS.LayMaHDTheoBan(maBanHienTai);
            if (maHD == -1)
            {
                MessageBox.Show("Bàn này đang trống, không có hóa đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult rs = MessageBox.Show("Xác nhận thanh toán cho " + lblHoaDon.Text + "\nTổng tiền: " + tongTienHienTai.ToString("N0") + " đ?",
                                              "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (rs == DialogResult.Yes)
            {
                try
                {
                    string tenDangNhap = (frmMain.CurrentUser != null) ? frmMain.CurrentUser.TenDangNhap : "admin";
                    string folderPath = Application.StartupPath + @"\HoaDon";
                    if (!System.IO.Directory.Exists(folderPath)) System.IO.Directory.CreateDirectory(folderPath);

                    string fileName = string.Format("HD_Ban{0}_{1}.txt", maBanHienTai, DateTime.Now.ToString("yyyyMMdd_HHmmss"));
                    string filePath = System.IO.Path.Combine(folderPath, fileName);

                    using (System.IO.StreamWriter sw = new System.IO.StreamWriter(filePath))
                    {
                        sw.WriteLine("          QUÁN CÀ PHÊ ĐỨC HUY          ");
                        sw.WriteLine("   Địa chỉ: 123 Lai Vung, Đồng Tháp    ");
                        sw.WriteLine("          SĐT: 0123.456.789            ");
                        sw.WriteLine("=======================================");
                        sw.WriteLine(string.Format("Hóa đơn: Bàn số {0}", maBanHienTai));
                        sw.WriteLine(string.Format("Ngày: {0}", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")));
                        sw.WriteLine("---------------------------------------");
                        sw.WriteLine(string.Format("{0,-18} | {1,-3} | {2,-10}", "Tên món", "SL", "Thành tiền"));
                        sw.WriteLine("---------------------------------------");

                        foreach (DataGridViewRow row in dgvHoaDon_Ban.Rows)
                        {
                            if (row.Cells[0].Value != null)
                            {
                                string tenMon = row.Cells["TenMon"].Value.ToString();
                                string sl = row.Cells["SL"].Value.ToString();
                                string thanhTien = row.Cells["ThanhTien"].Value.ToString();
                                if (tenMon.Length > 18) tenMon = tenMon.Substring(0, 15) + "...";
                                sw.WriteLine(string.Format("{0,-18} | {1,-3} | {2,-10}", tenMon, sl, thanhTien));
                            }
                        }

                        sw.WriteLine("---------------------------------------");
                        sw.WriteLine(string.Format("TỔNG CỘNG:          {0,15} đ", tongTienHienTai.ToString("N0")));
                        sw.WriteLine("=======================================");
                        sw.WriteLine("      CẢM ƠN QUÝ KHÁCH - HẸN GẶP LẠI    ");
                    }

                    
                    if (HoaDon_BUS.ThanhToan(maHD, maBanHienTai, (float)tongTienHienTai, tenDangNhap))
                    {
                        NguyenLieu_BUS.TruKhoKhiThanhToan(maHD);
                        MessageBox.Show("Thanh toán thành công!\nHóa đơn đã được lưu và kho đã được cập nhật.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frmPrintInvoice fReport = new frmPrintInvoice(maHD); // in hóa đơn report
                        fReport.ShowDialog();

                        LoadDanhSachBan();      
                        HienThiHoaDon(-1);      
                        LamMoiOThongTin();     
                    }
                    else
                    {
                        MessageBox.Show("Lỗi cập nhật trạng thái hóa đơn trên Database!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xử lý thanh toán: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



       

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtTenMon.Tag == null || maBanHienTai == -1) return;

            int maThucUong = (int)txtTenMon.Tag;
            int maHD = HoaDon_BUS.LayMaHDTheoBan(maBanHienTai);
            if (ChiTietHoaDon_BUS.CapNhatMon(maHD, maThucUong, (int)numSL.Value, txtGhiChu.Text))
            {
                HienThiHoaDon(maBanHienTai);
                txtTenMon.Clear(); txtTenMon.Tag = null; txtGhiChu.Clear(); numSL.Value = 1;
            }
        }


        private void numSL_ValueChanged(object sender, EventArgs e)
        {
            if (dangLoadDuLieu) return;
            if (txtTenMon.Tag == null || maBanHienTai == -1) return;
            int maThucUong = (int)txtTenMon.Tag;
            int maHD = HoaDon_BUS.LayMaHDTheoBan(maBanHienTai);
            int soLuongMoi = (int)numSL.Value;
            string ghiChuHienTai = txtGhiChu.Text;

            if (maHD != -1)
            {
                if (soLuongMoi == 0)
                {
                    DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa món này khỏi hóa đơn không?",
                                                    "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        ChiTietHoaDon_BUS.XoaMon(maHD, maThucUong, ghiChuHienTai);
                        HoaDon_BUS.KiemTraVaXoaHoaDonRong(maHD, maBanHienTai);

                        LoadDanhSachBan();
                        HienThiHoaDon(maBanHienTai);
                        LamMoiOThongTin();
                        return; 
                    }
                    else
                    {
                        dangLoadDuLieu = true;
                        numSL.Value = 1;
                        dangLoadDuLieu = false;
                        return;
                    }
                }
                else
                {
                    ChiTietHoaDon_BUS.CapNhatMon(maHD, maThucUong, soLuongMoi, ghiChuHienTai);
                }

                HienThiHoaDon(maBanHienTai);
            }
        }
        private void LoadComboBoxBanDich()
        {
            List<Ban_DTO> dsBan = Ban_BUS.LayDanhSachBan();
            cboBanDich.DataSource = dsBan;
            cboBanDich.DisplayMember = "STenBan";
            cboBanDich.ValueMember = "IMaBan";
        }
        private void btnDoiBan_Click(object sender, EventArgs e)
        {
            if (maBanHienTai == -1) return;

            int maBanDich = Convert.ToInt32(cboBanDich.SelectedValue);
            if (maBanHienTai == maBanDich) return;

            if (MessageBox.Show($"Bạn có chắc chắn muốn ĐỔI từ bàn {maBanHienTai} sang bàn {maBanDich} không?\n(Hành động này không thể hoàn tác!)","CẢNH BÁO XÁC NHẬN",MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.Yes)
            { 
                if (HoaDon_BUS.DoiBan(maBanHienTai, maBanDich))
                {
                    MessageBox.Show("Đổi bàn thành công!");
                    maBanHienTai = maBanDich;
                    LoadDanhSachBan();
                    HienThiHoaDon(maBanHienTai);
                    lblHoaDon.Text = "Hóa đơn - Bàn " + maBanDich;
                }
                else
                {
                    MessageBox.Show("Lỗi database khi đổi bàn!");
                }
            }
        }
        

        private void btnGopBan_Click(object sender, EventArgs e)
        {
            if (maBanHienTai == -1) return;
            int maBanDich = Convert.ToInt32(cboBanDich.SelectedValue);
            if (maBanHienTai == maBanDich) return;
            if (HoaDon_BUS.LayMaHDTheoBan(maBanDich) == -1)
            {
                MessageBox.Show("Bàn đích đang trống, không thể gộp! Hãy dùng chức năng Đổi bàn.", "Thông báo");
                return;
            }

            string msg = $"Bạn có chắc muốn gộp tất cả món từ bàn {maBanHienTai} vào bàn {maBanDich}?\n(Bàn {maBanHienTai} sẽ trở thành bàn trống)";

            if (MessageBox.Show(msg, "Xác nhận gộp bàn", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (HoaDon_BUS.GopBan(maBanHienTai, maBanDich))
                {
                    MessageBox.Show("Gộp bàn thành công!", "Thông báo");

                    LoadDanhSachBan();
                    maBanHienTai = maBanDich; 
                    HienThiHoaDon(maBanHienTai);
                }
                else
                {
                    MessageBox.Show("Gộp bàn thất bại! Có thể do trùng món ăn giữa hai bàn.", "Lỗi");
                }
            }
        }

        private void btnChuyenMon_Click(object sender, EventArgs e)
        {
            if (dgvHoaDon_Ban.CurrentRow == null) return;
            int maThucUong = (int)dgvHoaDon_Ban.CurrentRow.Cells["MaThucUong"].Value;            
            int soLuongGoc = (int)dgvHoaDon_Ban.CurrentRow.Cells["SL"].Value;
            int soLuongMuonChuyen = (int)nmSoLuongChuyen.Value;
            string tenMon = dgvHoaDon_Ban.CurrentRow.Cells["TenMon"].Value.ToString();
            int maBanDich = (int)cboBanDich.SelectedValue;
            string tenBanDich = cboBanDich.Text;
            int maHDCu = HoaDon_BUS.LayMaHDTheoBan(maBanHienTai);
            int maHDMoi = HoaDon_BUS.LayMaHDTheoBan(maBanDich);
            string thongBao = $"Bạn có chắc chắn muốn chuyển {soLuongMuonChuyen} món {tenMon} sang {tenBanDich} không?";
            DialogResult rs = MessageBox.Show(thongBao, "CẢNH BÁO CHUYỂN MÓN", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (rs == DialogResult.No) return; 
            if (maHDMoi == -1)
            {
                HoaDon_BUS.ThemHoaDonMoi(maBanDich);
                maHDMoi = HoaDon_BUS.LayMaHDTheoBan(maBanDich);
            }
            if (soLuongMuonChuyen > soLuongGoc)
            {
                MessageBox.Show("Số lượng chuyển không được lớn hơn số lượng đang có!", "Thông báo");
                return;
            }
            if (HoaDon_BUS.ChuyenMon(maHDCu, maHDMoi, maThucUong, soLuongMuonChuyen, maBanHienTai))
            {
                MessageBox.Show($"Đã chuyển {soLuongMuonChuyen} món sang bàn mới thành công!");
                LoadDanhSachBan();
                HienThiHoaDon(maBanHienTai);
            }
            else
            {
                MessageBox.Show("Chuyển món thất bại!", "Lỗi");
            }
        }

       
        private void dgvHoaDon_Ban_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    dangLoadDuLieu = true;
                    DataGridViewRow row = dgvHoaDon_Ban.Rows[e.RowIndex];
                    txtTenMon.Text = row.Cells["TenMon"].Value?.ToString();
                    txtTenMon.Tag = row.Cells["MaThucUong"].Value;
                    if (row.Cells["SL"].Value != null)
                    {
                        numSL.Value = Convert.ToDecimal(row.Cells["SL"].Value);
                    }
                    txtGhiChu.Text = row.Cells["GhiChu"].Value?.ToString() ?? "";

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tại CellClick: " + ex.Message);
                }
                finally
                {
                    dangLoadDuLieu = false;
                }
            }

        }

        private void chkChuyenMon_CheckedChanged(object sender, EventArgs e)
        {
            if(chkChuyenMon.Checked == false)
            {
                btnChuyenMon.Enabled = false;
            }
            else
            {
                btnChuyenMon.Enabled = true;
            }
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    #endregion
}