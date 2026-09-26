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
    public class Menu_DAO
    {
        static SqlConnection con;

        public static List<Menu_DTO> LayDanhSachMenuTheoBan(int maBan)
        {
            List<Menu_DTO> lstMenu = new List<Menu_DTO>();

            string sTruyVan = string.Format(@"
            SELECT tu.MaThucUong, tu.TenThucUong, ct.SoLuong, tu.DonGia, (tu.DonGia * ct.SoLuong) AS ThanhTien, ct.GhiChu
            FROM ChiTietHoaDon ct
            JOIN HoaDon hd ON ct.MaHD = hd.MaHD
            JOIN ThucUong tu ON ct.MaThucUong = tu.MaThucUong
            WHERE hd.MaBan = {0} AND hd.TrangThai = 0", maBan);

            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Menu_DTO menu = new Menu_DTO();
                    menu.IMaThucUong = int.Parse(dt.Rows[i]["MaThucUong"].ToString());
                    menu.STenThucUong = dt.Rows[i]["TenThucUong"].ToString();
                    menu.ISoLuong = int.Parse(dt.Rows[i]["SoLuong"].ToString());
                    menu.FDonGia = float.Parse(dt.Rows[i]["DonGia"].ToString());
                    menu.FThanhTien = float.Parse(dt.Rows[i]["ThanhTien"].ToString());
                    menu.SGhiChu = dt.Rows[i]["GhiChu"] != DBNull.Value ? dt.Rows[i]["GhiChu"].ToString() : "";

                    lstMenu.Add(menu);
                }
            }
            DataProvider.DongKetNoi(con);
            return lstMenu;
        }
    }
}