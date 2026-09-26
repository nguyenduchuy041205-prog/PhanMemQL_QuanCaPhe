using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class DinhMuc_DAO
    {
        public static List<DinhMuc_DTO> LayDinhMucTheoMon(int maThucUong)
        {
            string sql = "SELECT * FROM DinhMuc WHERE MaThucUong = " + maThucUong;
            SqlConnection con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sql, con);
            DataProvider.DongKetNoi(con);

            List<DinhMuc_DTO> ds = new List<DinhMuc_DTO>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    ds.Add(new DinhMuc_DTO
                    {
                        MaThucUong1 = int.Parse(dr["MaThucUong"].ToString()),
                        MaNL1 = int.Parse(dr["MaNL"].ToString()),
                        HamLuong1 = float.Parse(dr["HamLuong"].ToString())
                    });
                }
            }
            return ds;
        }

        public static bool ThemDinhMuc(DinhMuc_DTO dm)
        {
            string sql = string.Format("INSERT INTO DinhMuc VALUES ({0}, {1}, {2})",
                                        dm.MaThucUong1, dm.MaNL1, dm.HamLuong1);
            SqlConnection con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sql, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }

        public static bool SuaDinhMuc(DinhMuc_DTO dm)
        {
            string sql = string.Format("UPDATE DinhMuc SET HamLuong = {0} WHERE MaThucUong = {1} AND MaNL = {2}",
                                        dm.HamLuong1, dm.MaThucUong1, dm.MaNL1);
            SqlConnection con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sql, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }

        public static bool XoaDinhMuc(int maMon, int maNL)
        {
            string sql = string.Format("DELETE FROM DinhMuc WHERE MaThucUong = {0} AND MaNL = {1}", maMon, maNL);
            SqlConnection con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sql, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
        public static DataTable LayDSDinhMucTheoDanhMuc(int maDM)
        {
            string sql = @"SELECT DM.TenDanhMuc, TU.TenThucUong, NL.TenNL, D.HamLuong, NL.DonViTinh
                   FROM DanhMuc DM
                   JOIN ThucUong TU ON DM.MaDanhMuc = TU.MaDanhMuc
                   JOIN DinhMuc D ON TU.MaThucUong = D.MaThucUong
                   JOIN NguyenLieu NL ON D.MaNL = NL.MaNL
                   WHERE (@ma = 0 OR DM.MaDanhMuc = @ma)";

            SqlConnection con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sql.Replace("@ma", maDM.ToString()), con);
            DataProvider.DongKetNoi(con);
            return dt;
        }
    }
}