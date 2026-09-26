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
    public partial class frmMonNgungBan : Form
    {
        public frmMonNgungBan()
        {
            InitializeComponent();
            dgvThungRac.AutoGenerateColumns = false;
        }

        private void btnBanLai_Click(object sender, EventArgs e)
        {
            if (dgvThungRac.CurrentRow == null) return;

            ThucUong_DTO item = dgvThungRac.CurrentRow.DataBoundItem as ThucUong_DTO;

            if (item != null)
            {
                DialogResult dr = MessageBox.Show($"Bạn có muốn bắt đầu kinh doanh lại món [{item.STenThucUong}] không?",
                                                 "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    if (ThucUong_BUS.KhoiPhucThucUong(item.IMaThucUong))
                    {
                        MessageBox.Show("Món ăn đã được khôi phục thành công!");
                        LoadDataThungRac();
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi xảy ra khi khôi phục món ăn.");
                    }
                }
            }
        }
        private void LoadDataThungRac()
        {
            dgvThungRac.DataSource = ThucUong_BUS.LayDSThucUongNgungKinhDoanh();
        }
        private void frmMonNgungBan_Load(object sender, EventArgs e)
        {
            LoadDataThungRac();
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
