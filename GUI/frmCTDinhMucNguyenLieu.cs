using BUS;
using DTO;
using Microsoft.Reporting.WinForms;
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
    public partial class frmCTDinhMucNguyenLieu : Form
    {
        public frmCTDinhMucNguyenLieu()
        {
            InitializeComponent();
        }

        private void frmCTDinhMucNguyenLieu_Load(object sender, EventArgs e)
        {

            LoadComboDanhMuc();
            btnThongKe_Click(sender, e);
        }
        private void LoadComboDanhMuc()
        {
            List<DanhMuc_DTO> ds = DinhMuc_BUS.LayDSDanhMucBaoCao();
            cboDanhMuc.DataSource = ds;
            cboDanhMuc.DisplayMember = "STenDanhMuc";
            cboDanhMuc.ValueMember = "IMaDanhMuc";
        }
        private void btnThongKe_Click(object sender, EventArgs e)
        {
            int maDM = (int)cboDanhMuc.SelectedValue;
            DataTable dt = DinhMuc_BUS.LayDSDinhMucTheoDanhMuc(maDM);
            ReportDataSource rds = new ReportDataSource("dsDinhMuc", dt);
            this.rpCTDM.LocalReport.DataSources.Clear();
            this.rpCTDM.LocalReport.DataSources.Add(rds);
            this.rpCTDM.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            this.rpCTDM.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;

            this.rpCTDM.RefreshReport();
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
