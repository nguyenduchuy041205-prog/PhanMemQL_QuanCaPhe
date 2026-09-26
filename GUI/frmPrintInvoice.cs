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
    public partial class frmPrintInvoice : Form
    {
        private int _maHD;
        public frmPrintInvoice(int maHD)
        {
            InitializeComponent(); 
            this._maHD = maHD;     
        }

        private void frmPrintInvoice_Load(object sender, EventArgs e)
        {
            try
            {
                var data = ChiTietHoaDon_BUS.LayDSChiTietChoReport(_maHD);
                reportViewer1.LocalReport.DataSources.Clear();
                ReportDataSource rds = new ReportDataSource("DataSet1", data);
                reportViewer1.LocalReport.DataSources.Add(rds);
                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiện Report: " + ex.Message + "\n" + ex.InnerException?.Message);
            }
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}