using BUS;
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
    public partial class frmBCDoanhThu : Form
    {
        public frmBCDoanhThu()
        {
            InitializeComponent();
        }

        private void frmBCDoanhThu_Load(object sender, EventArgs e)
        {
            dtpTuNgay.Value = DateTime.Now;
            dtpDenNgay.Value = DateTime.Now;

            btnThongKe_Click(sender, e);
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = HoaDon_BUS.LayDuLieuBaoCaoDoanhThu(dtpTuNgay.Value, dtpDenNgay.Value);
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "GUI.rbDoanhThu.rdlc";
                ReportDataSource rds = new ReportDataSource("DataSet1", dt);
                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(rds);
                this.reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
                this.reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
