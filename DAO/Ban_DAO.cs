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
    public class Ban_DAO
    {
        static SqlConnection con;

        public static List<Ban_DTO> LayDanhSachBan()
        {
            string sTruyVan = "select * from Ban";
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);

            if (dt.Rows.Count == 0)
            {
                return null;
            }

            List<Ban_DTO> lstBan = new List<Ban_DTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Ban_DTO ban = new Ban_DTO();
                ban.IMaBan = int.Parse(dt.Rows[i]["MaBan"].ToString());
                ban.STenBan = dt.Rows[i]["TenBan"].ToString();
                ban.STrangThai = dt.Rows[i]["TrangThai"].ToString();
                lstBan.Add(ban);
            }
            DataProvider.DongKetNoi(con);
            return lstBan;
        }

        public static string LayTrangThaiBanTheoMa(int maBan)
        {
            string sTruyVan = string.Format(@"select TrangThai from Ban where MaBan='{0}'", maBan);
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);

            if (dt.Rows.Count == 0)
            {
                DataProvider.DongKetNoi(con);
                return null;
            }

            DataProvider.DongKetNoi(con);
            return dt.Rows[0]["TrangThai"].ToString();
        }
        public static bool ThemBan(Ban_DTO ban)
        {
            string sTruyVan = string.Format(@"insert into Ban(TenBan, TrangThai) values (N'{0}', N'Trống')", ban.STenBan);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }

        public static bool SuaBan(Ban_DTO ban)
        {
            string sTruyVan = string.Format(@"update Ban set TenBan=N'{0}', TrangThai=N'{1}' where MaBan={2}",
                                            ban.STenBan, ban.STrangThai, ban.IMaBan);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }

        public static bool XoaBan(int maBan)
        {
            string sTruyVan = string.Format(@"delete from Ban where MaBan={0}", maBan);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
    }
}
