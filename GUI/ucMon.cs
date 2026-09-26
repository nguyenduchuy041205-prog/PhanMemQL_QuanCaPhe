using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class ucMon : UserControl
    {
        public ucMon()
        {
            InitializeComponent();
            foreach (Control c in this.Controls)
            {
                c.Click += (s, e) => { this.OnClick(e); };
            }
        }
        public string TenMon
        {
            get { return lblTenMon.Text; }
            set { lblTenMon.Text = value; }
        }

        public string Gia
        {
            get { return lblGia.Text; }
            set { lblGia.Text = value; }
        }

        public Image Anh
        {
            get { return picMon.Image; }
            set { picMon.Image = value; }
        }

        public int MaMon { get; set; }

        public void LoadData(string ten, float gia, string hinh)
        {
            lblTenMon.Text = ten; // Giả sử label tên món là lblTenMon
            lblGia.Text = gia.ToString("N0") + "đ"; // Giả sử label giá là lblGia

            // Code load ảnh (như mình đã hướng dẫn ở các bước trước)
            if (!string.IsNullOrEmpty(hinh))
            {
                string path = System.IO.Path.Combine(Application.StartupPath, "Images", hinh);
                if (System.IO.File.Exists(path))
                {
                    picMon.Image = Image.FromFile(path); // Giả sử PictureBox là picHinh
                }
            }
        }
    }
}
