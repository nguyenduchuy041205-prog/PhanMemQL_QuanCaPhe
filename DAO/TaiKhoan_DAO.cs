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
    public class TaiKhoan_DAO
    {
        static SqlConnection con;
        public static TaiKhoan_DTO LayTaiKhoan(string ten, string matkhau)
        {
            string sTruyVan = string.Format(@"SELECT * FROM TaiKhoan WHERE TenDangNhap=N'{0}' AND MatKhau='{1}'", ten, matkhau);
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);

            if (dt == null || dt.Rows.Count == 0) return null;

            DataRow dr = dt.Rows[0];
            return new TaiKhoan_DTO
            {
                TenDangNhap = dr["TenDangNhap"].ToString(),
                TenHienThi = dr["TenHienThi"].ToString(),
                LoaiTaiKhoan = int.Parse(dr["LoaiTaiKhoan"].ToString())
            };
        }

        public static bool CapNhatTaiKhoan(TaiKhoan_DTO tk)
        {
            string sql = string.Format(@"UPDATE TaiKhoan SET MatKhau='{0}' WHERE TenDangNhap='{1}'", tk.MatKhau, tk.TenDangNhap);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sql, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
        public static List<TaiKhoan_DTO> LayDanhSachTaiKhoan()
        {
            string sTruyVan = "SELECT TenDangNhap, TenHienThi, LoaiTaiKhoan FROM TaiKhoan";
            SqlConnection con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);

            List<TaiKhoan_DTO> ds = new List<TaiKhoan_DTO>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    ds.Add(new TaiKhoan_DTO
                    {
                        TenDangNhap = dr["TenDangNhap"].ToString(),
                        TenHienThi = dr["TenHienThi"].ToString(),
                        LoaiTaiKhoan = int.Parse(dr["LoaiTaiKhoan"].ToString())
                    });
                }
            }
            return ds;
        }

        public static bool ThemTaiKhoan(TaiKhoan_DTO tk)
        {
            string sql = string.Format(@"INSERT INTO TaiKhoan (TenDangNhap, TenHienThi, LoaiTaiKhoan, MatKhau) 
                                 VALUES (N'{0}', N'{1}', {2}, '{3}')",tk.TenDangNhap, tk.TenHienThi, tk.LoaiTaiKhoan, tk.MatKhau);

            SqlConnection con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sql, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }

        public static bool SuaTaiKhoan(TaiKhoan_DTO tk)
        {
            string sql = string.Format(@"UPDATE TaiKhoan SET TenHienThi = N'{0}', LoaiTaiKhoan = {1} WHERE TenDangNhap = N'{2}'",
                                         tk.TenHienThi, tk.LoaiTaiKhoan, tk.TenDangNhap);
            SqlConnection con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sql, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }

        public static bool XoaTaiKhoan(string ten)
        {
            string sql = string.Format("DELETE FROM TaiKhoan WHERE TenDangNhap = N'{0}'", ten);
            SqlConnection con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sql, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }

        public static bool ResetMatKhau(string ten, string matKhauMaoHoa)
        {
            string sql = string.Format("UPDATE TaiKhoan SET MatKhau = '{0}' WHERE TenDangNhap = N'{1}'", matKhauMaoHoa, ten);

            SqlConnection con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sql, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
    }
}
