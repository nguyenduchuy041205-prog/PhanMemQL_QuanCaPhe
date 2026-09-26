using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class NguyenLieu_DAO
    {
        public static List<NguyenLieu_DTO> LayDanhSachNguyenLieu()
        {
            string sTruyVan = "SELECT * FROM NguyenLieu";
            SqlConnection con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);

            List<NguyenLieu_DTO> ds = new List<NguyenLieu_DTO>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    ds.Add(new NguyenLieu_DTO
                    {
                        MaNL1 = int.Parse(dr["MaNL"].ToString()),
                        TenNL1 = dr["TenNL"].ToString(),
                        SoLuongTon1 = float.Parse(dr["SoLuongTon"].ToString()),
                        DonViTinh1 = dr["DonViTinh"].ToString()
                    });
                }
            }
            return ds;
        }

        public static bool TruKhoKhiThanhToan(int maHD)
        {
            string sql = @"UPDATE NguyenLieu 
                           SET SoLuongTon = nl.SoLuongTon - (dm.HamLuong * cthd.SoLuong)
                           FROM NguyenLieu nl
                           JOIN DinhMuc dm ON nl.MaNL = dm.MaNL
                           JOIN ChiTietHoaDon cthd ON dm.MaThucUong = cthd.MaThucUong
                           WHERE cthd.MaHD = " + maHD;

            SqlConnection con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sql, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
        public static bool ThemHoaDonMoi(int maBan)
        {
            string sql = string.Format("INSERT INTO HoaDon (MaBan, TrangThai) VALUES ({0}, 0)", maBan);
            SqlConnection con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sql, con); 
            DataProvider.DongKetNoi(con);
            return kq;
        }
        public static bool ThemNguyenLieu(NguyenLieu_DTO nl)
        {
            string sql = string.Format("INSERT INTO NguyenLieu (TenNL, SoLuongTon, DonViTinh) VALUES (N'{0}', {1}, N'{2}')",
                                        nl.TenNL1, nl.SoLuongTon1, nl.DonViTinh1);
            SqlConnection con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sql, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }

        public static bool SuaNguyenLieu(NguyenLieu_DTO nl)
        {
            string sql = string.Format("UPDATE NguyenLieu SET TenNL = N'{0}', SoLuongTon = {1}, DonViTinh = N'{2}' WHERE MaNL = {3}",
                                        nl.TenNL1, nl.SoLuongTon1, nl.DonViTinh1, nl.MaNL1);
            SqlConnection con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sql, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }

        public static bool XoaNguyenLieu(int maNL)
        {
            string sql = string.Format("DELETE FROM NguyenLieu WHERE MaNL = {0}", maNL);
            SqlConnection con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sql, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
    }
}
