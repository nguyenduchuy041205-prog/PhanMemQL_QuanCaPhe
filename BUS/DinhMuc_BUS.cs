using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace BUS
{
    public class DinhMuc_BUS
    {
        public static List<DinhMuc_DTO> LayDinhMucTheoMon(int maThucUong)
        {
            if (maThucUong <= 0) return new List<DinhMuc_DTO>();
            return DinhMuc_DAO.LayDinhMucTheoMon(maThucUong);
        }

        public static bool ThemDinhMuc(DinhMuc_DTO dm)
        {
            if (dm == null || dm.HamLuong1 <= 0) return false;
            return DinhMuc_DAO.ThemDinhMuc(dm);
        }

        public static bool SuaDinhMuc(DinhMuc_DTO dm)
        {
            if (dm == null || dm.HamLuong1 <= 0) return false;
            return DinhMuc_DAO.SuaDinhMuc(dm);
        }

        public static bool XoaDinhMuc(int maMon, int maNL)
        {
            return DinhMuc_DAO.XoaDinhMuc(maMon, maNL);
        }

        public static bool KiemTraMonDaCoCongThuc(int maThucUong)
        {
            List<DinhMuc_DTO> ds = DinhMuc_DAO.LayDinhMucTheoMon(maThucUong);
            return ds != null && ds.Count > 0;
        }
        public static DataTable LayDSDinhMucTheoDanhMuc(int maDM)
        {
            return DinhMuc_DAO.LayDSDinhMucTheoDanhMuc(maDM);
        }

        public static List<DanhMuc_DTO> LayDSDanhMucBaoCao()
        {
            List<DanhMuc_DTO> ds = DanhMuc_DAO.LayDanhSachDanhMuc();

            DanhMuc_DTO tatCa = new DanhMuc_DTO();
            tatCa.IMaDanhMuc = 0;          
            tatCa.STenDanhMuc = "--- Tất cả danh mục ---";

            ds.Insert(0, tatCa);
            return ds;
        }
    }
}