namespace GUI
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTrangThai = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnOut = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuHeThong = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDangNhap = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDangXuat = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDoiMatKhau = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDuLieu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSaoLuu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPhucHoi = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuThoat = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuQuanly = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDanhMuc = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDoUong = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBan = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDieuChinhGia = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHoaDon = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTaiKhoan = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBanHang = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuKho = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNguyenLieu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCongThuc = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBaoCao = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDoanhThu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDinhMucNL = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTroGiup = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuThongTin = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHuongDan = new System.Windows.Forms.ToolStripMenuItem();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(151, 20);
            this.lblTrangThai.Text = "toolStripStatusLabel1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.White;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblTrangThai});
            this.statusStrip1.Location = new System.Drawing.Point(179, 685);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1372, 26);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnOut);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(179, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1372, 93);
            this.panel1.TabIndex = 5;
            // 
            // btnOut
            // 
            this.btnOut.AutoSize = true;
            this.btnOut.BackColor = System.Drawing.Color.Red;
            this.btnOut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnOut.FlatAppearance.BorderSize = 0;
            this.btnOut.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Maroon;
            this.btnOut.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOut.ForeColor = System.Drawing.Color.White;
            this.btnOut.Image = global::GUI.Properties.Resources.power1;
            this.btnOut.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOut.Location = new System.Drawing.Point(1250, 12);
            this.btnOut.Name = "btnOut";
            this.btnOut.Size = new System.Drawing.Size(97, 38);
            this.btnOut.TabIndex = 5;
            this.btnOut.Text = "THOÁT";
            this.btnOut.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOut.UseVisualStyleBackColor = false;
            this.btnOut.Click += new System.EventHandler(this.btnOut_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.AllowMerge = false;
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackColor = System.Drawing.Color.AliceBlue;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHeThong,
            this.mnuQuanly,
            this.mnuBanHang,
            this.mnuKho,
            this.mnuBaoCao,
            this.mnuTroGiup});
            this.menuStrip1.Location = new System.Drawing.Point(0, 93);
            this.menuStrip1.Margin = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(191, 618);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuHeThong
            // 
            this.mnuHeThong.AutoSize = false;
            this.mnuHeThong.BackColor = System.Drawing.Color.AliceBlue;
            this.mnuHeThong.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDangNhap,
            this.mnuDangXuat,
            this.mnuDoiMatKhau,
            this.mnuDuLieu,
            this.toolStripSeparator1,
            this.mnuThoat});
            this.mnuHeThong.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuHeThong.Image = global::GUI.Properties.Resources.content_management_system;
            this.mnuHeThong.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mnuHeThong.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuHeThong.Margin = new System.Windows.Forms.Padding(50, 0, 0, 0);
            this.mnuHeThong.Name = "mnuHeThong";
            this.mnuHeThong.Padding = new System.Windows.Forms.Padding(10, 0, 1, 0);
            this.mnuHeThong.Size = new System.Drawing.Size(160, 90);
            this.mnuHeThong.Text = "      &Hệ thống";
            this.mnuHeThong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.mnuHeThong.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            // 
            // mnuDangNhap
            // 
            this.mnuDangNhap.Image = global::GUI.Properties.Resources.login;
            this.mnuDangNhap.Name = "mnuDangNhap";
            this.mnuDangNhap.Size = new System.Drawing.Size(224, 26);
            this.mnuDangNhap.Text = "Đăng nhập";
            this.mnuDangNhap.Click += new System.EventHandler(this.mnuDangNhap_Click);
            // 
            // mnuDangXuat
            // 
            this.mnuDangXuat.Image = global::GUI.Properties.Resources.logout;
            this.mnuDangXuat.Name = "mnuDangXuat";
            this.mnuDangXuat.Size = new System.Drawing.Size(224, 26);
            this.mnuDangXuat.Text = "Đăng &xuất";
            this.mnuDangXuat.Click += new System.EventHandler(this.mnuDangXuat_Click);
            // 
            // mnuDoiMatKhau
            // 
            this.mnuDoiMatKhau.Image = global::GUI.Properties.Resources.key;
            this.mnuDoiMatKhau.Name = "mnuDoiMatKhau";
            this.mnuDoiMatKhau.Size = new System.Drawing.Size(224, 26);
            this.mnuDoiMatKhau.Text = "Đổi mật khẩu";
            this.mnuDoiMatKhau.Click += new System.EventHandler(this.mnuDoiMatKhau_Click);
            // 
            // mnuDuLieu
            // 
            this.mnuDuLieu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSaoLuu,
            this.mnuPhucHoi});
            this.mnuDuLieu.Image = global::GUI.Properties.Resources.folder;
            this.mnuDuLieu.Name = "mnuDuLieu";
            this.mnuDuLieu.Size = new System.Drawing.Size(224, 26);
            this.mnuDuLieu.Text = "Dữ liệu";
            // 
            // mnuSaoLuu
            // 
            this.mnuSaoLuu.Image = global::GUI.Properties.Resources.backup_file;
            this.mnuSaoLuu.Name = "mnuSaoLuu";
            this.mnuSaoLuu.Size = new System.Drawing.Size(224, 26);
            this.mnuSaoLuu.Text = "Sao lưu";
            this.mnuSaoLuu.Click += new System.EventHandler(this.mnuSaoLuu_Click);
            // 
            // mnuPhucHoi
            // 
            this.mnuPhucHoi.Image = global::GUI.Properties.Resources.file;
            this.mnuPhucHoi.Name = "mnuPhucHoi";
            this.mnuPhucHoi.Size = new System.Drawing.Size(224, 26);
            this.mnuPhucHoi.Text = "Phục hồi";
            this.mnuPhucHoi.Click += new System.EventHandler(this.mnuPhucHoi_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(221, 6);
            // 
            // mnuThoat
            // 
            this.mnuThoat.Image = global::GUI.Properties.Resources.exit1;
            this.mnuThoat.Name = "mnuThoat";
            this.mnuThoat.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.mnuThoat.Size = new System.Drawing.Size(224, 26);
            this.mnuThoat.Text = "&Thoát";
            this.mnuThoat.Click += new System.EventHandler(this.mnuThoat_Click);
            // 
            // mnuQuanly
            // 
            this.mnuQuanly.AutoSize = false;
            this.mnuQuanly.BackColor = System.Drawing.Color.AliceBlue;
            this.mnuQuanly.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDanhMuc,
            this.mnuDoUong,
            this.mnuBan,
            this.mnuDieuChinhGia,
            this.mnuHoaDon,
            this.mnuTaiKhoan});
            this.mnuQuanly.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuQuanly.Image = global::GUI.Properties.Resources.time;
            this.mnuQuanly.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mnuQuanly.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuQuanly.Name = "mnuQuanly";
            this.mnuQuanly.Padding = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.mnuQuanly.Size = new System.Drawing.Size(160, 90);
            this.mnuQuanly.Text = "      &Quản lý";
            this.mnuQuanly.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mnuDanhMuc
            // 
            this.mnuDanhMuc.Image = global::GUI.Properties.Resources.list;
            this.mnuDanhMuc.Name = "mnuDanhMuc";
            this.mnuDanhMuc.Size = new System.Drawing.Size(195, 26);
            this.mnuDanhMuc.Text = "Danh mục";
            this.mnuDanhMuc.Click += new System.EventHandler(this.mnuDanhMuc_Click);
            // 
            // mnuDoUong
            // 
            this.mnuDoUong.Image = global::GUI.Properties.Resources.coffee_cup;
            this.mnuDoUong.Name = "mnuDoUong";
            this.mnuDoUong.Size = new System.Drawing.Size(195, 26);
            this.mnuDoUong.Text = "Đồ &uống";
            this.mnuDoUong.Click += new System.EventHandler(this.mnuDoUong_Click);
            // 
            // mnuBan
            // 
            this.mnuBan.Image = global::GUI.Properties.Resources.chair_and_table;
            this.mnuBan.Name = "mnuBan";
            this.mnuBan.Size = new System.Drawing.Size(195, 26);
            this.mnuBan.Text = "&Bàn";
            this.mnuBan.Click += new System.EventHandler(this.mnuBan_Click);
            // 
            // mnuDieuChinhGia
            // 
            this.mnuDieuChinhGia.Image = global::GUI.Properties.Resources.best_price;
            this.mnuDieuChinhGia.Name = "mnuDieuChinhGia";
            this.mnuDieuChinhGia.Size = new System.Drawing.Size(195, 26);
            this.mnuDieuChinhGia.Text = "Điều chỉnh giá";
            this.mnuDieuChinhGia.Click += new System.EventHandler(this.mnuDieuChinhGia_Click);
            // 
            // mnuHoaDon
            // 
            this.mnuHoaDon.Image = global::GUI.Properties.Resources.transaction;
            this.mnuHoaDon.Name = "mnuHoaDon";
            this.mnuHoaDon.Size = new System.Drawing.Size(195, 26);
            this.mnuHoaDon.Text = "Hóa đơn";
            this.mnuHoaDon.Click += new System.EventHandler(this.mnuHoaDon_Click);
            // 
            // mnuTaiKhoan
            // 
            this.mnuTaiKhoan.Image = global::GUI.Properties.Resources.settings;
            this.mnuTaiKhoan.Name = "mnuTaiKhoan";
            this.mnuTaiKhoan.Size = new System.Drawing.Size(195, 26);
            this.mnuTaiKhoan.Text = "Tài khoản";
            this.mnuTaiKhoan.Click += new System.EventHandler(this.mnuTaiKhoan_Click);
            // 
            // mnuBanHang
            // 
            this.mnuBanHang.AutoSize = false;
            this.mnuBanHang.BackColor = System.Drawing.Color.AliceBlue;
            this.mnuBanHang.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuBanHang.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.mnuBanHang.Image = global::GUI.Properties.Resources.sell;
            this.mnuBanHang.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mnuBanHang.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuBanHang.Name = "mnuBanHang";
            this.mnuBanHang.Padding = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.mnuBanHang.Size = new System.Drawing.Size(160, 90);
            this.mnuBanHang.Text = "      Bá&n Hàng";
            this.mnuBanHang.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.mnuBanHang.Click += new System.EventHandler(this.mnuBanHang_Click);
            // 
            // mnuKho
            // 
            this.mnuKho.AutoSize = false;
            this.mnuKho.BackColor = System.Drawing.Color.AliceBlue;
            this.mnuKho.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNguyenLieu,
            this.mnuCongThuc});
            this.mnuKho.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuKho.Image = global::GUI.Properties.Resources.warehouse;
            this.mnuKho.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mnuKho.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuKho.Name = "mnuKho";
            this.mnuKho.Padding = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.mnuKho.Size = new System.Drawing.Size(160, 90);
            this.mnuKho.Text = "       Kho";
            this.mnuKho.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mnuNguyenLieu
            // 
            this.mnuNguyenLieu.Image = global::GUI.Properties.Resources.milk;
            this.mnuNguyenLieu.Name = "mnuNguyenLieu";
            this.mnuNguyenLieu.Size = new System.Drawing.Size(262, 26);
            this.mnuNguyenLieu.Text = "Nguyên liệu";
            this.mnuNguyenLieu.Click += new System.EventHandler(this.mnuNguyenLieu_Click);
            // 
            // mnuCongThuc
            // 
            this.mnuCongThuc.Image = global::GUI.Properties.Resources.recipe;
            this.mnuCongThuc.Name = "mnuCongThuc";
            this.mnuCongThuc.Size = new System.Drawing.Size(262, 26);
            this.mnuCongThuc.Text = "Công thức và Định mức";
            this.mnuCongThuc.Click += new System.EventHandler(this.mnuCongThuc_Click);
            // 
            // mnuBaoCao
            // 
            this.mnuBaoCao.AutoSize = false;
            this.mnuBaoCao.BackColor = System.Drawing.Color.AliceBlue;
            this.mnuBaoCao.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDoanhThu,
            this.mnuDinhMucNL});
            this.mnuBaoCao.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuBaoCao.Image = global::GUI.Properties.Resources.report;
            this.mnuBaoCao.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mnuBaoCao.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuBaoCao.Name = "mnuBaoCao";
            this.mnuBaoCao.Padding = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.mnuBaoCao.Size = new System.Drawing.Size(160, 90);
            this.mnuBaoCao.Text = "      Báo cáo";
            this.mnuBaoCao.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mnuDoanhThu
            // 
            this.mnuDoanhThu.Image = global::GUI.Properties.Resources.inflation;
            this.mnuDoanhThu.Name = "mnuDoanhThu";
            this.mnuDoanhThu.Size = new System.Drawing.Size(251, 26);
            this.mnuDoanhThu.Text = "Doanh thu";
            this.mnuDoanhThu.Click += new System.EventHandler(this.mnuDoanhThu_Click);
            // 
            // mnuDinhMucNL
            // 
            this.mnuDinhMucNL.Image = global::GUI.Properties.Resources.quantitative;
            this.mnuDinhMucNL.Name = "mnuDinhMucNL";
            this.mnuDinhMucNL.Size = new System.Drawing.Size(251, 26);
            this.mnuDinhMucNL.Text = "Định mức nguyên liệu";
            this.mnuDinhMucNL.Click += new System.EventHandler(this.mnuDinhMucNL_Click);
            // 
            // mnuTroGiup
            // 
            this.mnuTroGiup.AutoSize = false;
            this.mnuTroGiup.BackColor = System.Drawing.Color.AliceBlue;
            this.mnuTroGiup.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuThongTin,
            this.mnuHuongDan});
            this.mnuTroGiup.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuTroGiup.Image = global::GUI.Properties.Resources.customer_service;
            this.mnuTroGiup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mnuTroGiup.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuTroGiup.Name = "mnuTroGiup";
            this.mnuTroGiup.Padding = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.mnuTroGiup.Size = new System.Drawing.Size(160, 90);
            this.mnuTroGiup.Text = "      Trợ &giúp";
            this.mnuTroGiup.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mnuThongTin
            // 
            this.mnuThongTin.Image = global::GUI.Properties.Resources.information;
            this.mnuThongTin.Name = "mnuThongTin";
            this.mnuThongTin.Size = new System.Drawing.Size(244, 26);
            this.mnuThongTin.Text = "Thông tin phần mềm";
            this.mnuThongTin.Click += new System.EventHandler(this.mnuThongTin_Click);
            // 
            // mnuHuongDan
            // 
            this.mnuHuongDan.Image = global::GUI.Properties.Resources.question;
            this.mnuHuongDan.Name = "mnuHuongDan";
            this.mnuHuongDan.Size = new System.Drawing.Size(244, 26);
            this.mnuHuongDan.Text = "Hướng dẫn";
            this.mnuHuongDan.Click += new System.EventHandler(this.mnuHuongDan_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.menuStrip1);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(179, 711);
            this.panel3.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BackgroundImage = global::GUI.Properties.Resources.logo_cafe_19;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(179, 93);
            this.panel2.TabIndex = 6;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1551, 711);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Font = new System.Drawing.Font("Segoe UI Black", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMain";
            this.Text = "Hệ thống quản lý quán cà phê";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripStatusLabel lblTrangThai;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Button btnOut;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem mnuHeThong;
        private System.Windows.Forms.ToolStripMenuItem mnuDangNhap;
        private System.Windows.Forms.ToolStripMenuItem mnuDangXuat;
        private System.Windows.Forms.ToolStripMenuItem mnuDoiMatKhau;
        private System.Windows.Forms.ToolStripMenuItem mnuDuLieu;
        private System.Windows.Forms.ToolStripMenuItem mnuSaoLuu;
        private System.Windows.Forms.ToolStripMenuItem mnuPhucHoi;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuThoat;
        private System.Windows.Forms.ToolStripMenuItem mnuQuanly;
        private System.Windows.Forms.ToolStripMenuItem mnuDanhMuc;
        private System.Windows.Forms.ToolStripMenuItem mnuDoUong;
        private System.Windows.Forms.ToolStripMenuItem mnuBan;
        private System.Windows.Forms.ToolStripMenuItem mnuDieuChinhGia;
        private System.Windows.Forms.ToolStripMenuItem mnuHoaDon;
        private System.Windows.Forms.ToolStripMenuItem mnuTaiKhoan;
        private System.Windows.Forms.ToolStripMenuItem mnuBanHang;
        private System.Windows.Forms.ToolStripMenuItem mnuKho;
        private System.Windows.Forms.ToolStripMenuItem mnuNguyenLieu;
        private System.Windows.Forms.ToolStripMenuItem mnuCongThuc;
        private System.Windows.Forms.ToolStripMenuItem mnuBaoCao;
        private System.Windows.Forms.ToolStripMenuItem mnuDoanhThu;
        private System.Windows.Forms.ToolStripMenuItem mnuDinhMucNL;
        private System.Windows.Forms.ToolStripMenuItem mnuTroGiup;
        private System.Windows.Forms.ToolStripMenuItem mnuThongTin;
        private System.Windows.Forms.ToolStripMenuItem mnuHuongDan;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Panel panel3;
    }
}