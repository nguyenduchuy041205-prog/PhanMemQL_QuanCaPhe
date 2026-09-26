using BUS;
using DTO;
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
    public partial class frmDieuChinhGia : Form
    {
        public frmDieuChinhGia()
        {
            InitializeComponent();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            int maDM = (int)cboDanhMuc.SelectedValue; 
            bool laTang = radTangGia.Checked;
            bool laPhanTram = radPhanTram.Checked;
            float giaTri = (float)numGiaTri.Value;
            string thongBao = string.Format("Hệ thống sẽ {0} giá cho {1} với mức {2}{3}.\nBạn có chắc chắn không?",
                                laTang ? "TĂNG" : "GIẢM",
                                cboDanhMuc.Text,
                                giaTri,
                                laPhanTram ? "%" : "đ");

            if (MessageBox.Show(thongBao, "Cảnh báo quan trọng", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (ThucUong_BUS.DieuChinhGiaHangLoat(maDM, laTang, laPhanTram, giaTri))
                {
                    MessageBox.Show("Cập nhật giá thành công! (Đã tự động làm tròn đến hàng nghìn)");
                    this.DialogResult = DialogResult.OK; 
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại. Vui lòng kiểm tra lại kết nối Database.");
                }
            }
        }

        private void frmDieuChinhGia_Load(object sender, EventArgs e)
        {
            LoadDanhMuc();
            radTangGia.Checked = true;
            radPhanTram.Checked = true;
            numGiaTri.Value = 0;
        }
        private void LoadDanhMuc()
        {
            List<DanhMuc_DTO> ds = DanhMuc_BUS.LayDanhSachDanhMuc();
            if (ds == null) ds = new List<DanhMuc_DTO>();
            DanhMuc_DTO tatCa = new DanhMuc_DTO();
            tatCa.IMaDanhMuc = -1; 
            tatCa.STenDanhMuc = "--- TẤT CẢ CÁC MÓN ---";
            ds.Insert(0, tatCa);

            cboDanhMuc.DataSource = ds;
            cboDanhMuc.DisplayMember = "STenDanhMuc"; 
            cboDanhMuc.ValueMember = "IMaDanhMuc";    

            cboDanhMuc.SelectedIndex = 0; 
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
