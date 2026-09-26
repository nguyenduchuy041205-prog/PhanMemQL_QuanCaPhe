using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DinhMuc_DTO
    {
        private int MaThucUong;
        private int MaNL;
        private float HamLuong;
        private string sTenDanhMuc;
        private string tenThucUong;
        private string tenNguyenLieu;
        private string donViTinh;
        public int MaThucUong1 { get => MaThucUong; set => MaThucUong = value; }
        public int MaNL1 { get => MaNL; set => MaNL = value; }
        public float HamLuong1 { get => HamLuong; set => HamLuong = value; }
        public string STenDanhMuc1 { get => sTenDanhMuc; set => sTenDanhMuc = value; }
        public string TenThucUong1 { get => tenThucUong; set => tenThucUong = value; }
        public string TenNguyenLieu1 { get => tenNguyenLieu; set => tenNguyenLieu = value; }
        public string DonViTinh1 { get => donViTinh; set => donViTinh = value; }
    }
}
