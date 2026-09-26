using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class DanhMuc_BUS
    {
        public static List<DanhMuc_DTO> LayDanhSachDanhMuc()
        {
            return DanhMuc_DAO.LayDanhSachDanhMuc();
        }
        public static bool ThemDanhMuc(string tenDanhMuc)
        {
            return DanhMuc_DAO.ThemDanhMuc(tenDanhMuc);
        }

        public static bool SuaDanhMuc(int maDanhMuc, string tenDanhMuc)
        {
            return DanhMuc_DAO.SuaDanhMuc(maDanhMuc, tenDanhMuc);
        }

        public static bool XoaDanhMuc(int maDanhMuc)
        {
            return DanhMuc_DAO.XoaDanhMuc(maDanhMuc);
        }
    }
}
