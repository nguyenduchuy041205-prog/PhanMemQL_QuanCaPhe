using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class HoaDon_BUS
    {
        public static int LayMaHDTheoBan(int maBan) { return HoaDon_DAO.LayMaHDTheoBan(maBan); }
        public static bool ThemHoaDonMoi(int maBan) { return HoaDon_DAO.ThemHoaDonMoi(maBan); }
        public static bool ThanhToan(int maHD, int maBan, float tongTien, string tenDangNhap)
        {
            return HoaDon_DAO.ThanhToan(maHD, maBan, tongTien, tenDangNhap);
        }
        public static void KiemTraVaXoaHoaDonRong(int maHD, int maBan)
        {
            HoaDon_DAO.KiemTraVaXoaHoaDonRong(maHD, maBan);
        }
        public static List<HoaDon_DTO> LayLichSuHoaDon(DateTime tuNgay, DateTime denNgay)
        {
            return DAO.HoaDon_DAO.LayLichSuHoaDon(tuNgay, denNgay);
        }
        public static bool XoaHoaDon(int maHD, int maBan)
        {
            return HoaDon_DAO.XoaHoaDon(maHD, maBan);
        }
        public static DataTable LayDuLieuBaoCaoDoanhThu(DateTime tuNgay, DateTime denNgay)
        {
            return HoaDon_DAO.LayDuLieuBaoCaoDoanhThu(tuNgay, denNgay);
        }
        public static bool DoiBan(int maBanCu, int maBanMoi)
        {
            return HoaDon_DAO.DoiBan(maBanCu, maBanMoi);
        }

        public static bool GopBan(int maBanCu, int maBanMoi) 
        { 
            return  HoaDon_DAO.GopBan(maBanCu, maBanMoi);
        }
        public static bool ChuyenMon(int maHDCu, int maHDMoi, int maThucUong, int soLuong, int maBanCu)
        {
            return HoaDon_DAO.ChuyenMon(maHDCu, maHDMoi, maThucUong, soLuong, maBanCu);
        }
    }

}
