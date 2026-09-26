USE master;
GO

IF EXISTS (SELECT name FROM sys.databases WHERE name = N'QuanLyQuanCafe')
BEGIN
    ALTER DATABASE QuanLyQuanCafe SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE QuanLyQuanCafe;
END
GO

CREATE DATABASE QuanLyQuanCafe;
GO

USE QuanLyQuanCafe;
GO

-- CÁC BẢNG 

-- 1. Bảng Tài khoản 
CREATE TABLE TaiKhoan (
    TenDangNhap NVARCHAR(100) PRIMARY KEY,
    TenHienThi NVARCHAR(100) NOT NULL,
    MatKhau NVARCHAR(1000) NOT NULL DEFAULT N'1',
    LoaiTaiKhoan INT NOT NULL DEFAULT 0 
)

-- 2. Bảng Danh mục
CREATE TABLE DanhMuc (
    MaDanhMuc INT IDENTITY PRIMARY KEY,
    TenDanhMuc NVARCHAR(100) NOT NULL
)

-- 3. Bảng Bàn
CREATE TABLE Ban (
    MaBan INT IDENTITY PRIMARY KEY,
    TenBan NVARCHAR(100) NOT NULL,
    TrangThai NVARCHAR(100) NOT NULL DEFAULT N'Trống'
)

-- 4. Bảng Thức uống
CREATE TABLE ThucUong (
    MaThucUong INT IDENTITY PRIMARY KEY,
    TenThucUong NVARCHAR(100) NOT NULL,
    MaDanhMuc INT NOT NULL,
    DonGia FLOAT NOT NULL DEFAULT 0,
    HinhAnh NVARCHAR(500),
    TrangThai INT DEFAULT 1
	
    FOREIGN KEY (MaDanhMuc) REFERENCES DanhMuc(MaDanhMuc)
)

-- 5. Bảng Hóa đơn 
CREATE TABLE HoaDon (
    MaHD INT IDENTITY PRIMARY KEY,
    NgayVao DATETIME NOT NULL DEFAULT GETDATE(),
    NgayThanhToan DATETIME, 
    MaBan INT NOT NULL,
    TrangThai INT NOT NULL DEFAULT 0, 
    GiamGia INT DEFAULT 0,
    TongTien FLOAT DEFAULT 0,
    TenDangNhap NVARCHAR(100), 
    FOREIGN KEY (MaBan) REFERENCES Ban(MaBan),
    FOREIGN KEY (TenDangNhap) REFERENCES TaiKhoan(TenDangNhap)
)

-- 6. Bảng Chi tiết hóa đơn 
CREATE TABLE ChiTietHoaDon (
    MaCTHD INT IDENTITY PRIMARY KEY,
    MaHD INT NOT NULL,
    MaThucUong INT NOT NULL,
    SoLuong INT NOT NULL DEFAULT 0,
    GiaBan FLOAT NOT NULL DEFAULT 0, 
    GhiChu NVARCHAR(255) NULL,
    FOREIGN KEY (MaHD) REFERENCES HoaDon(MaHD),
    FOREIGN KEY (MaThucUong) REFERENCES ThucUong(MaThucUong)
)
-- 7. Bảng Nguyên liệu (Kho)
CREATE TABLE NguyenLieu (
    MaNL INT IDENTITY PRIMARY KEY,
    TenNL NVARCHAR(100) NOT NULL,
    SoLuongTon FLOAT NOT NULL DEFAULT 0, 
    DonViTinh NVARCHAR(50) NOT NULL      
)

-- 8. Bảng Định mức (Công thức món ăn)
CREATE TABLE DinhMuc (
    MaThucUong INT NOT NULL,
    MaNL INT NOT NULL,
    HamLuong FLOAT NOT NULL DEFAULT 0, 
    PRIMARY KEY (MaThucUong, MaNL),
    FOREIGN KEY (MaThucUong) REFERENCES ThucUong(MaThucUong),
    FOREIGN KEY (MaNL) REFERENCES NguyenLieu(MaNL)
)

GO

-- DỮ LIỆU MẪU 

-- Thêm 2 tài khoản mẫu
INSERT INTO TaiKhoan (TenDangNhap, TenHienThi, MatKhau, LoaiTaiKhoan) 
VALUES (N'admin', N'Đức Huy (Admin)', 'c4ca4238a0b923820dcc509a6f75849b', 1);
GO

-- Thêm 1 tài khoản nhân viên mẫu mật khẩu cũng là '1'
INSERT INTO TaiKhoan (TenDangNhap, TenHienThi, MatKhau, LoaiTaiKhoan) 
VALUES (N'staff', N'Nhân viên bán hàng', 'c4ca4238a0b923820dcc509a6f75849b', 0);
GO

-- Thêm 15 Bàn bằng vòng lặp
DECLARE @i INT = 1
WHILE @i <= 15
BEGIN
    INSERT INTO Ban (TenBan, TrangThai) VALUES (N'Bàn ' + CAST(@i AS NVARCHAR(10)), N'Trống')
    SET @i = @i + 1
END
GO

-- Thêm 3 Danh mục
INSERT INTO DanhMuc (TenDanhMuc) VALUES (N'Cà phê'), (N'Trà'), (N'Sinh tố')
GO

-- Thêm Thức uống mẫu
INSERT INTO ThucUong (TenThucUong, MaDanhMuc, DonGia, HinhAnh)
VALUES (N'Cà phê đen đá', 1, 25000, N'cf_den.jpg'),
       (N'Cà phê sữa đá', 1, 29000, N'1-ca-phe-sua-1586320543.jpg'),
       (N'Bạc xỉu', 1, 32000, N'bacxiu.jpg')

INSERT INTO ThucUong (TenThucUong, MaDanhMuc, DonGia, HinhAnh)
VALUES (N'Trà đào cam sả', 2, 45000, N'tradaocamsa.jpg'),
       (N'Trà vải', 2, 40000, N'travai.jpg')

INSERT INTO ThucUong (TenThucUong, MaDanhMuc, DonGia, HinhAnh)
VALUES (N'Sinh tố bơ', 3, 50000, N'stbo.jpg'),
       (N'Nước ép dưa hấu', 3, 35000, N'epduahau.jpg')
GO
INSERT INTO HoaDon (MaBan, TrangThai) VALUES (1, 0);
UPDATE HoaDon SET TrangThai = 1
INSERT INTO ChiTietHoaDon (MaHD, MaThucUong, SoLuong) VALUES (1, 1, 2);

UPDATE Ban SET TrangThai = N'Có người' WHERE MaBan = 1;
PRINT N'Tạo Database QuanLyQuanCafe thành công!'

DELETE FROM ChiTietHoaDon;
DELETE FROM HoaDon;
GO

INSERT INTO HoaDon (NgayVao, NgayThanhToan, MaBan, TrangThai, TongTien, TenDangNhap) 
VALUES (GETDATE(), GETDATE(), 1, 1, 50000, N'admin');

INSERT INTO ChiTietHoaDon (MaHD, MaThucUong, SoLuong, GiaBan) VALUES (SCOPE_IDENTITY(), 1, 2, 25000);

INSERT INTO HoaDon (NgayVao, NgayThanhToan, MaBan, TrangThai, TongTien, TenDangNhap) 
VALUES (GETDATE(), GETDATE(), 2, 1, 45000, N'staff');

INSERT INTO ChiTietHoaDon (MaHD, MaThucUong, SoLuong, GiaBan) VALUES (SCOPE_IDENTITY(), 4, 1, 45000);
GO

INSERT INTO NguyenLieu (TenNL, SoLuongTon, DonViTinh)
VALUES 
-- 1. Nhóm Cà phê & Sữa
(N'Cà phê hạt Robusta', 5500, N'gam'),
(N'Sữa đặc Ngôi Sao', 800, N'ml'),          
(N'Sữa tươi không đường', 3000, N'ml'),
(N'Đường cát trắng', 4200, N'gam'),
(N'Kem béo thực vật', 2500, N'ml'),

-- 2. Nhóm Trà & Siro 
(N'Trà đen túi lọc', 150, N'gói'),           
(N'Siro Đào', 900, N'ml'),                  
(N'Siro Vải', 1000, N'ml'),
(N'Đào miếng (lon)', 20, N'miếng'),          
(N'Vải trái (lon)', 30, N'quả'),             
(N'Sả tươi', 500, N'gam'),                   
(N'Cam vàng', 10, N'quả'),                    

-- 3. Nhóm Trái cây tươi 
(N'Bơ sáp tươi', 5000, N'gam'),              
(N'Dưa hấu đỏ', 10000, N'gam'),               
(N'Chanh tươi', 1500, N'gam'),

-- 4. Nhóm Topping & Bột
(N'Bột Cacao', 1200, N'gam'),
(N'Bột Matcha Nhật Bản', 1200, N'gam'),
(N'Siro Bạc hà', 850, N'ml'),                
(N'Trân châu đen', 2500, N'gam'),
(N'Trân châu trắng', 950, N'gam'),          
(N'Thạch trái cây hỗn hợp', 3000, N'gam'),
(N'Hạt sen đóng lon', 12, N'lon'),

-- 5. Nhóm Vật tư đóng gói
(N'Ly nhựa chữ U 500ml', 500, N'cái'),        
(N'Ống hút nilon', 2000, N'cái'),
(N'Túi nilon mang về (đôi)', 450, N'cái'),    
(N'Khăn giấy vuông', 5000, N'tờ'),
(N'Băng keo dán ly', 5, N'cuộn');                    

INSERT INTO DinhMuc (MaThucUong, MaNL, HamLuong)
SELECT tu.MaThucUong, nl.MaNL, src.HamLuong
FROM (
    VALUES 
    -- Cà phê đen đá
    (N'Cà phê đen đá', N'Cà phê hạt Robusta', 25),
    (N'Cà phê đen đá', N'Đường cát trắng', 15),
    (N'Cà phê đen đá', N'Ly nhựa chữ U 500ml', 1),
    (N'Cà phê đen đá', N'Ống hút nilon', 1),

    -- Cà phê sữa đá
    (N'Cà phê sữa đá', N'Cà phê hạt Robusta', 25),
    (N'Cà phê sữa đá', N'Sữa đặc Ngôi Sao', 40),
    (N'Cà phê sữa đá', N'Ly nhựa chữ U 500ml', 1),
    (N'Cà phê sữa đá', N'Ống hút nilon', 1),

    -- Bạc xỉu
    (N'Bạc xỉu', N'Cà phê hạt Robusta', 15),
    (N'Bạc xỉu', N'Sữa đặc Ngôi Sao', 50),
    (N'Bạc xỉu', N'Sữa tươi không đường', 100),
    (N'Bạc xỉu', N'Ly nhựa chữ U 500ml', 1),

    -- Trà đào cam sả
    (N'Trà đào cam sả', N'Trà đen túi lọc', 1),
    (N'Trà đào cam sả', N'Siro Đào', 25),
    (N'Trà đào cam sả', N'Đào miếng (lon)', 2),
    (N'Trà đào cam sả', N'Cam vàng', 0.25),
    (N'Trà đào cam sả', N'Sả tươi', 10),
    (N'Trà đào cam sả', N'Ly nhựa chữ U 500ml', 1),

    -- Trà vải
    (N'Trà vải', N'Trà đen túi lọc', 1),
    (N'Trà vải', N'Siro Vải', 20),
    (N'Trà vải', N'Vải trái (lon)', 3),
    (N'Trà vải', N'Ly nhựa chữ U 500ml', 1),

    -- Sinh tố bơ
    (N'Sinh tố bơ', N'Bơ sáp tươi', 200),
    (N'Sinh tố bơ', N'Sữa đặc Ngôi Sao', 45),
    (N'Sinh tố bơ', N'Sữa tươi không đường', 50),
    (N'Sinh tố bơ', N'Ly nhựa chữ U 500ml', 1),

    -- Nước ép dưa hấu
    (N'Nước ép dưa hấu', N'Dưa hấu đỏ', 350),
    (N'Nước ép dưa hấu', N'Đường cát trắng', 10),
    (N'Nước ép dưa hấu', N'Ly nhựa chữ U 500ml', 1)
) AS src(TenMon, TenNL, HamLuong)
JOIN ThucUong tu ON src.TenMon = tu.TenThucUong
JOIN NguyenLieu nl ON src.TenNL = nl.TenNL;