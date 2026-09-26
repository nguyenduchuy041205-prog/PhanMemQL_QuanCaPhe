using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Ban_DTO
    {
        private int iMaBan;
        public int IMaBan
        {
            get { return iMaBan; }
            set { iMaBan = value; }
        }

        private string sTenBan;
        public string STenBan
        {
            get { return sTenBan; }
            set { sTenBan = value; }
        }

        private string sTrangThai;
        public string STrangThai
        {
            get { return sTrangThai; }
            set { sTrangThai = value; }
        }
    }
}