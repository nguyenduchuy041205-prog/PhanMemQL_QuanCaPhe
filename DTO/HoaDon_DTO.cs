using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HoaDon_DTO
    {
        private int maHD;
        private DateTime thoiGian;
        private string banPhucVu;
        private string nhanVien;
        private float tongTien;

        public int MaHD { get => maHD; set => maHD = value; }
        public DateTime ThoiGian { get => thoiGian; set => thoiGian = value; }
        public string BanPhucVu { get => banPhucVu; set => banPhucVu = value; }
        public string NhanVien { get => nhanVien; set => nhanVien = value; }
        public float TongTien { get => tongTien; set => tongTien = value; }
    }
}
