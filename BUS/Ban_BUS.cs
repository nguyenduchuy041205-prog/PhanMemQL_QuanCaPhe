using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class Ban_BUS
    {
        public static List<Ban_DTO> LayDanhSachBan()
        {
            return Ban_DAO.LayDanhSachBan();
        }

        public static string LayTrangThaiBanTheoMa(int maBan)
        {
            return Ban_DAO.LayTrangThaiBanTheoMa(maBan);
        }
        public static bool ThemBan(Ban_DTO ban)
        {
            return Ban_DAO.ThemBan(ban);
        }

        public static bool SuaBan(Ban_DTO ban)
        {
            return Ban_DAO.SuaBan(ban);
        }

        public static bool XoaBan(int maBan)
        {
            return Ban_DAO.XoaBan(maBan);
        }
    }
}
