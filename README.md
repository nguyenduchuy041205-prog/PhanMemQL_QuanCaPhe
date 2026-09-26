# ☕ ABC Coffee - Phần mềm Quản lý Quán Cà Phê (Desktop Application)

## 📝 Giới thiệu
**ABC Coffee** là phần mềm quản lý bán hàng dành cho mô hình quán cà phê, được xây dựng trên nền tảng ứng dụng Desktop (Windows Forms). Dự án được phát triển cá nhân nhằm mục đích tin học hóa quy trình gọi món, quản lý bàn, tính tiền và theo dõi doanh thu, giúp tối ưu hóa hoạt động kinh doanh của quán.
Phần mềm sử dụng kiến trúc ADO.NET để thao tác trực tiếp và tối ưu hóa hiệu suất truy xuất dữ liệu với hệ quản trị cơ sở dữ liệu.

## 🚀 Chức năng nổi bật
* **Quản lý Bán hàng (POS):** Hiển thị danh sách bàn trực quan, gọi món, tính tiền, áp dụng giảm giá.
* **Quản lý Danh mục:** Thêm, sửa, xóa thông tin đồ uống, danh mục và trạng thái bàn.
* **Thống kê & Báo cáo:** Xem lại lịch sử hóa đơn và thống kê doanh thu theo thời gian.

## 💻 Công nghệ sử dụng
* **Ngôn ngữ lập trình:** C#
* **Framework:** .NET Framework (Windows Forms)
* **Cơ sở dữ liệu:** Microsoft SQL Server
* **Kiến trúc thao tác dữ liệu:** ADO.NET
<img width="1917" height="1078" alt="image" src="https://github.com/user-attachments/assets/28a9991b-ec3e-480a-99f1-236aac2328dd" />
<img width="1917" height="1078" alt="image" src="https://github.com/user-attachments/assets/e749129b-d9ee-496a-8ee1-7b3de77ef9ac" />

## ⚙️ Hướng dẫn cài đặt và khởi chạy

Để chạy dự án này, bạn cần cài đặt **Visual Studio** và **Microsoft SQL Server**.

**Bước 1: Tải mã nguồn**
```bash
git clone [https://github.com/nguyenduchuy041205-prog/XayDungPhanMemQL_QuanCaPhe.git](https://github.com/nguyenduchuy041205-prog/XayDungPhanMemQL_QuanCaPhe.git)
Bước 2: Cài đặt Cơ sở dữ liệu (Database)

Mở SQL Server Management Studio (SSMS).

Mở file script QLQCF.sql đính kèm trong dự án.

Nhấn Execute (F5) để thực thi script tạo cơ sở dữ liệu và dữ liệu mẫu.

Bước 3: Khôi phục thư viện (Restore NuGet Packages) - QUAN TRỌNG
Để tối ưu dung lượng source code, thư mục packages đã được loại bỏ. Bạn cần tải lại các thư viện phụ thuộc bằng cách:

Mở file QLQCP.sln bằng Visual Studio.

Nhấp chuột phải vào Solution 'QLQCP' trong cửa sổ Solution Explorer (thường ở góc phải màn hình).

Chọn Restore NuGet Packages.
(Hoặc đơn giản hơn: Bạn chỉ cần nhấn Build > Build Solution (Ctrl + Shift + B), Visual Studio sẽ tự động kết nối mạng và tải về các thư viện còn thiếu).

Bước 4: Cấu hình chuỗi kết nối (Connection String)

Tìm và mở file App.config (hoặc class chứa cấu hình kết nối của bạn).

Sửa đổi thông tin Data Source (Tên Server SQL của bạn) trong chuỗi kết nối cho phù hợp với máy cá nhân.

Bước 5: Khởi chạy phần mềm
Nhấn nút Start (F5) trong Visual Studio để chạy phần mềm.

--Tài khoản đăng nhập mẫu--
-Admin:
tk: admin
mk: 1
-Nhân viên:
tk: staff
mk:1
