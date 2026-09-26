using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class NguyenLieu_BUS
    {
        public static List<NguyenLieu_DTO> LayDanhSachNguyenLieu()
        {
            return NguyenLieu_DAO.LayDanhSachNguyenLieu();
        }


        public static bool TruKhoKhiThanhToan(int maHD)
        {
            try
            {
                return NguyenLieu_DAO.TruKhoKhiThanhToan(maHD);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool KiemTraTonKhoChoHoaDon(int maHD)
        {
            return true;
        }
        public static bool KiemTraDuNguyenLieu(int maThucUong)
        {
            List<DinhMuc_DTO> dsDinhMuc = DinhMuc_DAO.LayDinhMucTheoMon(maThucUong);
            if (dsDinhMuc == null || dsDinhMuc.Count == 0) return true;

            List<NguyenLieu_DTO> dsKho = NguyenLieu_DAO.LayDanhSachNguyenLieu();

            foreach (DinhMuc_DTO congThuc in dsDinhMuc)
            {
                NguyenLieu_DTO nlTrongKho = dsKho.Find(x => x.MaNL1 == congThuc.MaNL1);
                if (nlTrongKho == null) return false;
                if (nlTrongKho.SoLuongTon1 < congThuc.HamLuong1) return false;
            }
            return true;
        }
        public static bool ThemNguyenLieu(NguyenLieu_DTO nl)
        {
            return NguyenLieu_DAO.ThemNguyenLieu(nl);
        }

        public static bool SuaNguyenLieu(NguyenLieu_DTO nl)
        {
            return NguyenLieu_DAO.SuaNguyenLieu(nl);
        }

        public static bool XoaNguyenLieu(int maNL)
        {
            return NguyenLieu_DAO.XoaNguyenLieu(maNL);
        }
    }
}
