using DTO;
using DAO;
using System;
using System.Collections.Generic;

namespace BUS
{
    public class ThucUong_BUS
    {
        public static List<ThucUong_DTO> LayDSThucUong()
        {
            return ThucUong_DAO.LayDanhSachThucUong() ?? new List<ThucUong_DTO>();
        }
        public static List<ThucUong_DTO> LayDSThucUongDeBan()
        {
            return ThucUong_DAO.LayDSThucUongDeBan();
        }
        public static List<ThucUong_DTO> LayDanhSachThucUongTheoDanhMuc(int maDanhMuc)
        {
            if (maDanhMuc <= 0) return new List<ThucUong_DTO>();
            return ThucUong_DAO.LayDanhSachThucUongTheoDanhMuc(maDanhMuc) ?? new List<ThucUong_DTO>();
        }

        public static bool ThemThucUong(ThucUong_DTO thucUong)
        {
            if (thucUong == null || string.IsNullOrWhiteSpace(thucUong.STenThucUong))
                return false;

            if (thucUong.FDonGia < 0)
                return false;

            return ThucUong_DAO.ThemThucUong(thucUong);
        }

        public static bool SuaThucUong(ThucUong_DTO thucUong)
        {
            if (thucUong == null || thucUong.IMaThucUong <= 0 || string.IsNullOrWhiteSpace(thucUong.STenThucUong))
                return false;

            return ThucUong_DAO.SuaThucUong(thucUong);
        }

        public static bool XoaThucUong(int maThucUong)
        {
            if (maThucUong <= 0)
                return false;

            return ThucUong_DAO.XoaThucUong(maThucUong);
        }
        public static bool DieuChinhGiaHangLoat(int maDM, bool laTang, bool laPhanTram, float giaTri)
        {
            if (giaTri < 0) return false;

            return DAO.ThucUong_DAO.CapNhatGiaHangLoat(maDM, laTang, laPhanTram, giaTri);
        }
        public static List<ThucUong_DTO> LayDSThucUongNgungKinhDoanh()
        {
            return ThucUong_DAO.LayDSThucUongNgungKinhDoanh() ?? new List<ThucUong_DTO>();
        }

        public static bool KhoiPhucThucUong(int maThucUong)
        {
            return ThucUong_DAO.KhoiPhucThucUong(maThucUong);
        }
    }
}