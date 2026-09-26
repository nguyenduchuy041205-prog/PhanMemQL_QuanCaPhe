using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ThucUong_DTO
    {
        private int iMaThucUong;
        public int IMaThucUong { get { return iMaThucUong; } set { iMaThucUong = value; } }

        private string sTenThucUong;
        public string STenThucUong { get { return sTenThucUong; } set { sTenThucUong = value; } }

        private int iMaDanhMuc;
        public int IMaDanhMuc { get { return iMaDanhMuc; } set { iMaDanhMuc = value; } }

        private float fDonGia;
        public float FDonGia { get { return fDonGia; } set { fDonGia = value; } }

        private string sHinhAnh;
        public string SHinhAnh { get { return sHinhAnh; } set { sHinhAnh = value; } }
        private string sTenDanhMuc;
        public string STenDanhMuc { get { return sTenDanhMuc; } set { sTenDanhMuc = value; } }
        private int iTrangThai;
        public int ITrangThai { get => iTrangThai; set => iTrangThai = value; }
    }
}
