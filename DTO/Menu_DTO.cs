using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Menu_DTO
    {
        private int iMaThucUong;
        public int IMaThucUong { get { return iMaThucUong; } set { iMaThucUong = value; } }
        private string sTenThucUong;
        public string STenThucUong { get { return sTenThucUong; } set { sTenThucUong = value; } }

        private int iSoLuong;
        public int ISoLuong { get { return iSoLuong; } set { iSoLuong = value; } }

        private float fDonGia;
        public float FDonGia { get { return fDonGia; } set { fDonGia = value; } }

        private float fThanhTien;
        public float FThanhTien { get { return fThanhTien; } set { fThanhTien = value; } }
        private string sGhiChu;
        public string SGhiChu { get => sGhiChu; set => sGhiChu = value; }
    }
}
