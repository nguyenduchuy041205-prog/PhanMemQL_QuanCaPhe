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
    public class DanhMuc_DAO
    {
        public static List<DanhMuc_DTO> LayDanhSachDanhMuc()
        {
            string sTruyVan = "SELECT * FROM DanhMuc";
            SqlConnection con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);

            List<DanhMuc_DTO> lst = new List<DanhMuc_DTO>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DanhMuc_DTO dm = new DanhMuc_DTO();
                    dm.IMaDanhMuc = int.Parse(dt.Rows[i]["MaDanhMuc"].ToString());
                    dm.STenDanhMuc = dt.Rows[i]["TenDanhMuc"].ToString();
                    lst.Add(dm);
                }
            }
            DataProvider.DongKetNoi(con);
            return lst;
        }

        public static bool ThemDanhMuc(string tenDanhMuc)
        {
            string sTruyVan = string.Format("INSERT INTO DanhMuc (TenDanhMuc) VALUES (N'{0}')", tenDanhMuc);
            SqlConnection con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }

        public static bool SuaDanhMuc(int maDanhMuc, string tenDanhMuc)
        {
            string sTruyVan = string.Format("UPDATE DanhMuc SET TenDanhMuc = N'{0}' WHERE MaDanhMuc = {1}", tenDanhMuc, maDanhMuc);
            SqlConnection con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }

        public static bool XoaDanhMuc(int maDanhMuc)
        {
            string sTruyVan = string.Format("DELETE FROM DanhMuc WHERE MaDanhMuc = {0}", maDanhMuc);
            SqlConnection con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
    }
}