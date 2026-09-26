using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class HoaDon_DAO
    {
        public static int LayMaHDTheoBan(int maBan)
        {
            SqlConnection con = DataProvider.MoKetNoi();
            string query = "SELECT MaHD FROM HoaDon WHERE MaBan = " + maBan + " AND TrangThai = 0";
            DataTable dt = DataProvider.TruyVanLayDuLieu(query, con);
            DataProvider.DongKetNoi(con);

            if (dt.Rows.Count > 0)
                return int.Parse(dt.Rows[0]["MaHD"].ToString());
            return -1;
        }

        public static bool ThemHoaDonMoi(int maBan)
        {
            SqlConnection con = DataProvider.MoKetNoi();

            string query = string.Format(
                "INSERT INTO HoaDon (MaBan, TrangThai) VALUES ({0}, 0); " +
                "UPDATE Ban SET TrangThai = N'Có người' WHERE MaBan = {0}",
                maBan);

            bool kq = DataProvider.TruyVanKhongLayDuLieu(query, con);

            DataProvider.DongKetNoi(con);

            return kq;
        }
        public static bool ThanhToan(int maHD, int maBan, float tongTien, string tenDangNhap)
        {
            string query = string.Format(@"
                UPDATE HoaDon 
                SET TrangThai = 1, 
                    TongTien = {0}, 
                    TenDangNhap = N'{1}', 
                    NgayThanhToan = GETDATE() 
                WHERE MaHD = {2};
                UPDATE Ban SET TrangThai = N'Trống' WHERE MaBan = {3}",
                 tongTien, tenDangNhap, maHD, maBan);

            SqlConnection con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(query, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
        public static void KiemTraVaXoaHoaDonRong(int maHD, int maBan)
        {
            SqlConnection con = DataProvider.MoKetNoi();

            string checkQuery = "SELECT COUNT(*) FROM ChiTietHoaDon WHERE MaHD = " + maHD;
            DataTable dt = DataProvider.TruyVanLayDuLieu(checkQuery, con);

            if (dt.Rows.Count > 0)
            {
                int soMon = int.Parse(dt.Rows[0][0].ToString());

                if (soMon == 0)
                {
                    string query = string.Format("DELETE FROM HoaDon WHERE MaHD = {0}; " +
                                                 "UPDATE Ban SET TrangThai = N'Trống' WHERE MaBan = {1}", maHD, maBan);
                    DataProvider.TruyVanKhongLayDuLieu(query, con);
                }
            }
            DataProvider.DongKetNoi(con);
        }
        public static List<HoaDon_DTO> LayLichSuHoaDon(DateTime tuNgay, DateTime denNgay)
        {
            List<HoaDon_DTO> ds = new List<HoaDon_DTO>();

            string sTu = tuNgay.ToString("yyyy-MM-dd 00:00:00");
            string sDen = denNgay.ToString("yyyy-MM-dd 23:59:59");

            string sql = string.Format(@"
                                SELECT hd.MaHD, 
                                       hd.NgayThanhToan AS ThoiGian, 
                                       b.TenBan AS BanPhucVu, 
                                       ISNULL(tk.TenHienThi, N'Chưa rõ') AS NhanVien, 
                                       hd.TongTien
                                FROM HoaDon hd 
                                INNER JOIN Ban b ON hd.MaBan = b.MaBan
                                LEFT JOIN TaiKhoan tk ON hd.TenDangNhap = tk.TenDangNhap 
                                WHERE hd.TrangThai = 1 
                                AND hd.NgayThanhToan BETWEEN '{0}' AND '{1}'", sTu, sDen);

            SqlConnection con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sql, con);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    HoaDon_DTO hd = new HoaDon_DTO();
                    hd.MaHD = Convert.ToInt32(dr["MaHD"]);
                    hd.ThoiGian = dr["ThoiGian"] != DBNull.Value ? Convert.ToDateTime(dr["ThoiGian"]) : DateTime.Now;
                    hd.BanPhucVu = dr["BanPhucVu"].ToString();
                    hd.NhanVien = dr["NhanVien"].ToString();
                    hd.TongTien = Convert.ToSingle(dr["TongTien"]);
                    ds.Add(hd);
                }
            }
            DataProvider.DongKetNoi(con);
            return ds;
        }
        public static bool XoaHoaDon(int maHD, int maBan)
        {
            SqlConnection con = DataProvider.MoKetNoi();
            try
            {
                string query = string.Format("DELETE FROM ChiTietHoaDon WHERE MaHD = {0}; " +
                                             "DELETE FROM HoaDon WHERE MaHD = {0};", maHD);

                if (maBan > 0)
                {
                    query += string.Format("UPDATE Ban SET TrangThai = N'Trống' WHERE MaBan = {0}", maBan);
                }

                return DataProvider.TruyVanKhongLayDuLieu(query, con);
            }
            catch { return false; }
            finally { DataProvider.DongKetNoi(con); }
        }
        public static DataTable LayDuLieuBaoCaoDoanhThu(DateTime tuNgay, DateTime denNgay)
        {
            string sql = string.Format(@"
                SELECT 
                    MaHD, 
                    NgayThanhToan, 
                    MaBan, 
                    TongTien, 
                    TenDangNhap 
                FROM HoaDon 
                WHERE TrangThai = 1 
                  AND NgayThanhToan BETWEEN '{0}' AND '{1}'
                ORDER BY NgayThanhToan ASC",
                tuNgay.ToString("yyyy-MM-dd 00:00:00"),
                denNgay.ToString("yyyy-MM-dd 23:59:59"));

            SqlConnection con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sql, con);
            DataProvider.DongKetNoi(con);
            return dt;
        }
        public static bool DoiBan(int maBanCu, int maBanMoi)
        {
            SqlConnection con = DataProvider.MoKetNoi();
            try
            {
                string sqlUpdateHD = string.Format(
                    "UPDATE HoaDon SET MaBan = {0} WHERE MaBan = {1} AND TrangThai = 0",
                    maBanMoi, maBanCu);
                bool r1 = DataProvider.TruyVanKhongLayDuLieu(sqlUpdateHD, con);

                string sqlBanCu = string.Format("UPDATE Ban SET TrangThai = N'Trống' WHERE MaBan = {0}", maBanCu);
                bool r2 = DataProvider.TruyVanKhongLayDuLieu(sqlBanCu, con);

                string sqlBanMoi = string.Format("UPDATE Ban SET TrangThai = N'Có người' WHERE MaBan = {0}", maBanMoi);
                bool r3 = DataProvider.TruyVanKhongLayDuLieu(sqlBanMoi, con);

                DataProvider.DongKetNoi(con);
                return r1 && r2 && r3;
            }
            catch
            {
                return false;
            }
        }

        public static bool GopBan(int maBanCu, int maBanMoi)
        {
            try
            {
                int maHDCu = LayMaHDTheoBan(maBanCu);
                int maHDMoi = LayMaHDTheoBan(maBanMoi);

                string sqlGetItems = "SELECT MaThucUong, SoLuong FROM ChiTietHoaDon WHERE MaHD = " + maHDCu;
                DataTable dtMonCu = DataProvider.TruyVanLayDuLieu(sqlGetItems, DataProvider.MoKetNoi());

                foreach (DataRow row in dtMonCu.Rows)
                {
                    int maMon = (int)row["MaThucUong"];
                    int soLuong = (int)row["SoLuong"];

                    string sqlCheck = string.Format("SELECT * FROM ChiTietHoaDon WHERE MaHD = {0} AND MaThucUong = {1}", maHDMoi, maMon);
                    DataTable dtCheck = DataProvider.TruyVanLayDuLieu(sqlCheck, DataProvider.MoKetNoi());

                    if (dtCheck.Rows.Count > 0)
                    {
                        string sqlUpdate = string.Format("UPDATE ChiTietHoaDon SET SoLuong = SoLuong + {0} WHERE MaHD = {1} AND MaThucUong = {2}", soLuong, maHDMoi, maMon);
                        string sqlDel = string.Format("DELETE FROM ChiTietHoaDon WHERE MaHD = {0} AND MaThucUong = {1}", maHDCu, maMon);
                        DataProvider.TruyVanKhongLayDuLieu(sqlUpdate + ";" + sqlDel, DataProvider.MoKetNoi());
                    }
                    else
                    {
                        string sqlMove = string.Format("UPDATE ChiTietHoaDon SET MaHD = {0} WHERE MaHD = {1} AND MaThucUong = {2}", maHDMoi, maHDCu, maMon);
                        DataProvider.TruyVanKhongLayDuLieu(sqlMove, DataProvider.MoKetNoi());
                    }
                }

                string sqlFinal = string.Format("DELETE FROM HoaDon WHERE MaHD = {0}; UPDATE Ban SET TrangThai = N'Trống' WHERE MaBan = {1}", maHDCu, maBanCu);
                return DataProvider.TruyVanKhongLayDuLieu(sqlFinal, DataProvider.MoKetNoi());
            }
            catch 
            { 
                return false; 
            }
        }
        public static bool ChuyenMon(int maHDCu, int maHDMoi, int maThucUong, int soLuong, int maBanNguon)
        {
            SqlConnection con = DataProvider.MoKetNoi();
            try
            {
                string sqlMoi = string.Format(@"
            IF EXISTS (SELECT 1 FROM ChiTietHoaDon WHERE MaHD = {0} AND MaThucUong = {1})
                UPDATE ChiTietHoaDon SET SoLuong = SoLuong + {2} WHERE MaHD = {0} AND MaThucUong = {1}
            ELSE
                INSERT INTO ChiTietHoaDon (MaHD, MaThucUong, SoLuong, GiaBan) 
                SELECT {0}, {1}, {2}, DonGia FROM ThucUong WHERE MaThucUong = {1}",
                    maHDMoi, maThucUong, soLuong);

                string sqlCu = string.Format(@"
            UPDATE ChiTietHoaDon SET SoLuong = SoLuong - {2} WHERE MaHD = {0} AND MaThucUong = {1};
            DELETE FROM ChiTietHoaDon WHERE MaHD = {0} AND MaThucUong = {1} AND SoLuong <= 0",
                    maHDCu, maThucUong, soLuong);

                DataProvider.TruyVanKhongLayDuLieu(sqlMoi, con);
                DataProvider.TruyVanKhongLayDuLieu(sqlCu, con);

                KiemTraVaXoaHoaDonRong(maHDCu, maBanNguon);

                return true;
            }
            catch { return false; }
            finally { DataProvider.DongKetNoi(con); }
        }

    }
}
