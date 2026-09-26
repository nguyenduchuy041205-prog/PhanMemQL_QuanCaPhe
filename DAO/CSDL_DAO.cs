using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class CSDL_DAO
    {
        static SqlConnection con;
        public static bool SaoLuuDuLieu(string sDuongDan)
        {
            string sTen = "\\QuanLyQuanCafe(" + DateTime.Now.Day.ToString() + "_" +
            DateTime.Now.Month.ToString() + "_" +
            DateTime.Now.Year.ToString() + "_" +
            DateTime.Now.Hour.ToString() + "_" +
            DateTime.Now.Minute.ToString() + ").bak";
            string sql = "BACKUP DATABASE QuanLyQuanCafe TO DISK = N'" + sDuongDan +
           sTen + "'";
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sql, con);
            return kq;
        }
        public static bool PhucHoiDuLieu(string sDuongDan)
        {
            string connMaster = @"Data Source=.\SQLEXPRESS;Initial Catalog=master;Integrated Security=True";

            try
            {
                SqlConnection.ClearAllPools();

                using (SqlConnection kn = new SqlConnection(connMaster))
                {
                    kn.Open();
                    string sql = $@"
                        ALTER DATABASE QuanLyQuanCafe SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
                        RESTORE DATABASE QuanLyQuanCafe FROM DISK = N'{sDuongDan}' WITH REPLACE;
                        ALTER DATABASE QuanLyQuanCafe SET MULTI_USER;";

                    SqlCommand cmd = new SqlCommand(sql, kn);
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
