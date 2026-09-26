using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class ThucUong_DAO
    {
        static SqlConnection con;

        public static List<ThucUong_DTO> LayDanhSachThucUong()
        {
            string sTruyVan = @"SELECT t.*, d.TenDanhMuc 
                               FROM ThucUong t 
                               INNER JOIN DanhMuc d ON t.MaDanhMuc = d.MaDanhMuc 
                               WHERE t.TrangThai = 1";

            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);

            if (dt == null || dt.Rows.Count == 0) return null;

            List<ThucUong_DTO> lstThucUong = new List<ThucUong_DTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ThucUong_DTO thucuong = new ThucUong_DTO();
                thucuong.IMaThucUong = int.Parse(dt.Rows[i]["MaThucUong"].ToString());
                thucuong.STenThucUong = dt.Rows[i]["TenThucUong"].ToString();
                thucuong.STenDanhMuc = dt.Rows[i]["TenDanhMuc"].ToString();
                thucuong.IMaDanhMuc = int.Parse(dt.Rows[i]["MaDanhMuc"].ToString());
                thucuong.FDonGia = float.Parse(dt.Rows[i]["DonGia"].ToString());
                thucuong.SHinhAnh = dt.Rows[i]["HinhAnh"] != DBNull.Value ? dt.Rows[i]["HinhAnh"].ToString() : "";

                lstThucUong.Add(thucuong);
            }
            DataProvider.DongKetNoi(con);
            return lstThucUong;
        }

        public static List<ThucUong_DTO> LayDSThucUongDeBan()
        {
            string sTruyVan = @"SELECT t.*, d.TenDanhMuc 
                               FROM ThucUong t
                               INNER JOIN DanhMuc d ON t.MaDanhMuc = d.MaDanhMuc
                               WHERE t.TrangThai = 1 
                               AND EXISTS (SELECT 1 FROM DinhMuc dm WHERE dm.MaThucUong = t.MaThucUong)";

            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);

            if (dt == null || dt.Rows.Count == 0) return null;

            List<ThucUong_DTO> lstThucUong = new List<ThucUong_DTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ThucUong_DTO thucuong = new ThucUong_DTO();
                thucuong.IMaThucUong = int.Parse(dt.Rows[i]["MaThucUong"].ToString());
                thucuong.STenThucUong = dt.Rows[i]["TenThucUong"].ToString();
                thucuong.STenDanhMuc = dt.Rows[i]["TenDanhMuc"].ToString();
                thucuong.IMaDanhMuc = int.Parse(dt.Rows[i]["MaDanhMuc"].ToString());
                thucuong.FDonGia = float.Parse(dt.Rows[i]["DonGia"].ToString());
                thucuong.SHinhAnh = dt.Rows[i]["HinhAnh"] != DBNull.Value ? dt.Rows[i]["HinhAnh"].ToString() : "";

                lstThucUong.Add(thucuong);
            }
            DataProvider.DongKetNoi(con);
            return lstThucUong;
        }

        public static List<ThucUong_DTO> LayDanhSachThucUongTheoDanhMuc(int maDanhMuc)
        {
            string sTruyVan = string.Format(@"SELECT * FROM ThucUong 
                                     WHERE MaDanhMuc = {0} AND TrangThai = 1
                                     AND EXISTS (SELECT 1 FROM DinhMuc WHERE MaThucUong = ThucUong.MaThucUong)", maDanhMuc);

            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);

            if (dt == null || dt.Rows.Count == 0) return null;

            List<ThucUong_DTO> lstThucUong = new List<ThucUong_DTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ThucUong_DTO thucuong = new ThucUong_DTO();
                thucuong.IMaThucUong = int.Parse(dt.Rows[i]["MaThucUong"].ToString());
                thucuong.STenThucUong = dt.Rows[i]["TenThucUong"].ToString();
                thucuong.IMaDanhMuc = int.Parse(dt.Rows[i]["MaDanhMuc"].ToString());
                thucuong.FDonGia = float.Parse(dt.Rows[i]["DonGia"].ToString());
                thucuong.SHinhAnh = dt.Rows[i]["HinhAnh"] != DBNull.Value ? dt.Rows[i]["HinhAnh"].ToString() : "";

                lstThucUong.Add(thucuong);
            }
            DataProvider.DongKetNoi(con);
            return lstThucUong;
        }

      
        public static bool ThemThucUong(ThucUong_DTO thucUong)
        {
            string sTruyVan = string.Format(
                "INSERT INTO ThucUong (TenThucUong, MaDanhMuc, DonGia, HinhAnh, TrangThai) VALUES (N'{0}', {1}, {2}, N'{3}', 1)",
                thucUong.STenThucUong, thucUong.IMaDanhMuc, thucUong.FDonGia, thucUong.SHinhAnh);

            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }

      
        public static bool SuaThucUong(ThucUong_DTO thucUong)
        {
            string sTruyVan = string.Format(
                "UPDATE ThucUong SET TenThucUong = N'{0}', MaDanhMuc = {1}, DonGia = {2}, HinhAnh = N'{3}' WHERE MaThucUong = {4}",
                thucUong.STenThucUong, thucUong.IMaDanhMuc, thucUong.FDonGia, thucUong.SHinhAnh, thucUong.IMaThucUong);

            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }

       
        public static bool XoaThucUong(int maThucUong)
        {
            string sTruyVan = string.Format("UPDATE ThucUong SET TrangThai = 0 WHERE MaThucUong = {0}", maThucUong);

            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }

        public static bool CapNhatGiaHangLoat(int maDM, bool laTang, bool laPhanTram, float giaTri)
        {
            string phepTinh = laTang ? "+" : "-";
            string congThuc = laPhanTram ?
                string.Format("DonGia {0} (DonGia * {1} / 100.0)", phepTinh, giaTri) :
                string.Format("DonGia {0} {1}", phepTinh, giaTri);

            string query = string.Format("UPDATE ThucUong SET DonGia = ROUND({0}, -3) WHERE TrangThai = 1", congThuc);

            if (maDM != -1)
            {
                query += " AND MaDanhMuc = " + maDM;
            }

            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(query, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
        public static List<ThucUong_DTO> LayDSThucUongNgungKinhDoanh()
        {
            string sTruyVan = @"SELECT t.*, d.TenDanhMuc 
                       FROM ThucUong t 
                       INNER JOIN DanhMuc d ON t.MaDanhMuc = d.MaDanhMuc 
                       WHERE t.TrangThai = 0";

            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);

            if (dt == null || dt.Rows.Count == 0) return null;

            List<ThucUong_DTO> lst = new List<ThucUong_DTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ThucUong_DTO item = new ThucUong_DTO();
                item.IMaThucUong = int.Parse(dt.Rows[i]["MaThucUong"].ToString());
                item.STenThucUong = dt.Rows[i]["TenThucUong"].ToString();
                item.STenDanhMuc = dt.Rows[i]["TenDanhMuc"].ToString();
                item.FDonGia = float.Parse(dt.Rows[i]["DonGia"].ToString());
                lst.Add(item);
            }
            DataProvider.DongKetNoi(con);
            return lst;
        }
        public static bool KhoiPhucThucUong(int maThucUong)
        {
            string sTruyVan = string.Format("UPDATE ThucUong SET TrangThai = 1 WHERE MaThucUong = {0}", maThucUong);
            SqlConnection con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
    }

}