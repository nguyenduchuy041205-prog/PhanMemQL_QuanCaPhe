using DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class ChiTietHoaDon_BUS
    {
        public static bool ThemChiTietHoaDon(int maHD, int maThucUong, int soLuong, string ghiChu)
        {
            return ChiTietHoaDon_DAO.ThemChiTietHoaDon(maHD, maThucUong, soLuong, ghiChu);
        }

        public static bool CapNhatMon(int maHD, int maThucUong, int soLuong, string ghiChu)
        {
            return ChiTietHoaDon_DAO.CapNhatMon(maHD, maThucUong, soLuong, ghiChu);
        }

        public static void XoaMon(int maHD, int maThucUong, string ghiChu)
        {
            ChiTietHoaDon_DAO.XoaMon(maHD, maThucUong, ghiChu);
        }
        public static DataTable LayDSChiTietChoReport(int maHD)
        {
            return ChiTietHoaDon_DAO.LayDSHoaDonChoReport(maHD);
        }
    }
}