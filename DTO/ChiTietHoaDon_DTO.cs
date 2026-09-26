using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChiTietHoaDon_DTO
    {
        private int maHD;
        private int maThucUong;
        private string tenThucUong;
        private int soLuong;
        private string ghiChu;
        private float donGia;

        public int MaHD { get => maHD; set => maHD = value; }
        public int MaThucUong { get => maThucUong; set => maThucUong = value; }
        public string TenThucUong { get => tenThucUong; set => tenThucUong = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public string GhiChu { get => ghiChu; set => ghiChu = value; }
        public float DonGia { get => donGia; set => donGia = value; }
    }
}
