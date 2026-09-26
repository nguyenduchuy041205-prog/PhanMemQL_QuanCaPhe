using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class ChiTietHoaDon_DAO
    {
        public static List<ChiTietHoaDon_DTO> LayDSMonTheoHD(int maHD)
        {
            List<ChiTietHoaDon_DTO> ds = new List<ChiTietHoaDon_DTO>();
            string sql = "SELECT ct.MaThucUong, t.TenThucUong, ct.SoLuong, ct.GiaBan, ct.GhiChu " +
                         "FROM ChiTietHoaDon ct JOIN ThucUong t ON ct.MaThucUong = t.MaThucUong " +
                         "WHERE ct.MaHD = " + maHD;

            DataTable dt = DataProvider.TruyVanLayDuLieu(sql, DataProvider.MoKetNoi());
            if (dt == null) return ds;

            foreach (DataRow dr in dt.Rows)
            {
                ChiTietHoaDon_DTO item = new ChiTietHoaDon_DTO();
                item.MaThucUong = (int)dr["MaThucUong"];
                item.TenThucUong = dr["TenThucUong"].ToString();
                item.SoLuong = (int)dr["SoLuong"];
                item.DonGia = float.Parse(dr["GiaBan"].ToString());
                item.GhiChu = dr["GhiChu"].ToString();
                ds.Add(item);
            }
            return ds;
        }

        public static bool ThemChiTietHoaDon(int maHD, int maThucUong, int soLuong, string ghiChu)
        {
            SqlConnection con = DataProvider.MoKetNoi();
            string gc = (ghiChu ?? "").Replace("'", "''"); 
            string checkQuery = string.Format(
                "SELECT * FROM ChiTietHoaDon WHERE MaHD = {0} AND MaThucUong = {1} AND GhiChu = N'{2}'",
                maHD, maThucUong, gc);

            DataTable dt = DataProvider.TruyVanLayDuLieu(checkQuery, con);

            string query = "";
            if (dt != null && dt.Rows.Count > 0)
            {
                query = string.Format(
                    "UPDATE ChiTietHoaDon SET SoLuong = SoLuong + {0} WHERE MaHD = {1} AND MaThucUong = {2} AND GhiChu = N'{3}'",
                    soLuong, maHD, maThucUong, gc);
            }
            else
            {
                query = string.Format(
                    "INSERT INTO ChiTietHoaDon (MaHD, MaThucUong, SoLuong, GiaBan, GhiChu) " +
                    "SELECT {0}, {1}, {2}, DonGia, N'{3}' FROM ThucUong WHERE MaThucUong = {1}",
                    maHD, maThucUong, soLuong, gc);
            }

            bool kq = DataProvider.TruyVanKhongLayDuLieu(query, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }

        public static bool CapNhatMon(int maHD, int maThucUong, int sl, string ghiChuMoi)
        {
            try
            {
                string gc = (ghiChuMoi ?? "").Replace("'", "''");
                string query = string.Format(
                    "UPDATE ChiTietHoaDon SET SoLuong = {0}, GhiChu = N'{1}' " +
                    "WHERE MaHD = {2} AND MaThucUong = {3}",
                    sl, gc, maHD, maThucUong);

                using (SqlConnection con = DataProvider.MoKetNoi())
                {
                    return DataProvider.TruyVanKhongLayDuLieu(query, con);
                }
            }
            catch { return false; }
        }

        public static void XoaMon(int maHD, int maThucUong, string ghiChu)
        {
            string gc = (ghiChu ?? "").Replace("'", "''");
            string query = string.Format("DELETE FROM ChiTietHoaDon WHERE MaHD = {0} AND MaThucUong = {1} AND GhiChu = N'{2}'",
                                         maHD, maThucUong, gc);

            using (SqlConnection con = DataProvider.MoKetNoi())
            {
                DataProvider.TruyVanKhongLayDuLieu(query, con);
            }
        }
        public static DataTable LayDSHoaDonChoReport(int maHD)
        {
            string sql = string.Format(@"
                SELECT t.TenThucUong, ct.SoLuong, ct.GiaBan as DonGia, 
                       (ct.SoLuong * ct.GiaBan) as ThanhTien, b.TenBan, 
                       h.NgayVao AS NgayLap
                FROM ChiTietHoaDon ct
                JOIN ThucUong t ON ct.MaThucUong = t.MaThucUong
                JOIN HoaDon h ON ct.MaHD = h.MaHD
                JOIN Ban b ON h.MaBan = b.MaBan
                WHERE ct.MaHD = {0}", maHD);

            return DataProvider.TruyVanLayDuLieu(sql, DataProvider.MoKetNoi());
        }
    }
}