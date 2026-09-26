using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TaiKhoan_DTO
    {
        private string tenDangNhap;
        private string tenHienThi;
        private string matKhau;
        private int loaiTaiKhoan;

        public string TenDangNhap { get => tenDangNhap; set => tenDangNhap = value; }
        public string TenHienThi { get => tenHienThi; set => tenHienThi = value; }
        public string MatKhau { get => matKhau; set => matKhau = value; }
        public int LoaiTaiKhoan { get => loaiTaiKhoan; set => loaiTaiKhoan = value; }
    }
}
