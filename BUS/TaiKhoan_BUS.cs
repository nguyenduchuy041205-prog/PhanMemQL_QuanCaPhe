using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using DTO;
using DAO;

namespace BUS
{
    public class TaiKhoan_BUS
    {
        private static string MaHoa(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] data = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                    sb.Append(data[i].ToString("x2"));
                return sb.ToString();
            }
        }

        public static TaiKhoan_DTO DangNhap(string ten, string mk)
        {
            return TaiKhoan_DAO.LayTaiKhoan(ten, MaHoa(mk));
        }

        public static List<TaiKhoan_DTO> LayDSTaiKhoan()
        {
            return TaiKhoan_DAO.LayDanhSachTaiKhoan();
        }

        public static bool ThemTaiKhoan(TaiKhoan_DTO tk)
        {
            tk.MatKhau = MaHoa("1");
            return TaiKhoan_DAO.ThemTaiKhoan(tk);
        }

        public static bool SuaTaiKhoan(TaiKhoan_DTO tk)
        {
            return TaiKhoan_DAO.SuaTaiKhoan(tk);
        }

        public static bool XoaTaiKhoan(string ten)
        {
            return TaiKhoan_DAO.XoaTaiKhoan(ten);
        }

        public static bool DoiMatKhau(TaiKhoan_DTO tk, string mkMoi)
        {
            tk.MatKhau = MaHoa(mkMoi);
            return TaiKhoan_DAO.CapNhatTaiKhoan(tk);
        }

        public static bool ResetMatKhau(string ten)
        {
            return TaiKhoan_DAO.ResetMatKhau(ten, MaHoa("1"));
        }
    }
}