namespace GUI
{
    partial class frmCTDinhMucNguyenLieu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.dataTable1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.quanLyQuanCafeDataSet = new GUI.QuanLyQuanCafeDataSet();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.cboDanhMuc = new System.Windows.Forms.ComboBox();
            this.rpCTDM = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dataTable1TableAdapter = new GUI.QuanLyQuanCafeDataSetTableAdapters.DataTable1TableAdapter();
            this.btnOut = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyQuanCafeDataSet)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataTable1BindingSource
            // 
            this.dataTable1BindingSource.DataMember = "DataTable1";
            this.dataTable1BindingSource.DataSource = this.quanLyQuanCafeDataSet;
            // 
            // quanLyQuanCafeDataSet
            // 
            this.quanLyQuanCafeDataSet.DataSetName = "QuanLyQuanCafeDataSet";
            this.quanLyQuanCafeDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnOut);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnThongKe);
            this.panel1.Controls.Add(this.cboDanhMuc);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 58);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(34, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chọn danh mục";
            // 
            // btnThongKe
            // 
            this.btnThongKe.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnThongKe.BackColor = System.Drawing.Color.Yellow;
            this.btnThongKe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThongKe.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThongKe.Location = new System.Drawing.Point(596, 12);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(91, 34);
            this.btnThongKe.TabIndex = 2;
            this.btnThongKe.Text = "Thống kê";
            this.btnThongKe.UseVisualStyleBackColor = false;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // cboDanhMuc
            // 
            this.cboDanhMuc.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cboDanhMuc.FormattingEnabled = true;
            this.cboDanhMuc.Location = new System.Drawing.Point(175, 18);
            this.cboDanhMuc.Name = "cboDanhMuc";
            this.cboDanhMuc.Size = new System.Drawing.Size(170, 24);
            this.cboDanhMuc.TabIndex = 1;
            // 
            // rpCTDM
            // 
            this.rpCTDM.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "dsDinhMuc";
            reportDataSource2.Value = this.dataTable1BindingSource;
            this.rpCTDM.LocalReport.DataSources.Add(reportDataSource2);
            this.rpCTDM.LocalReport.ReportEmbeddedResource = "GUI.rpCTDM.rdlc";
            this.rpCTDM.Location = new System.Drawing.Point(0, 58);
            this.rpCTDM.Name = "rpCTDM";
            this.rpCTDM.ServerReport.BearerToken = null;
            this.rpCTDM.Size = new System.Drawing.Size(800, 392);
            this.rpCTDM.TabIndex = 1;
            // 
            // dataTable1TableAdapter
            // 
            this.dataTable1TableAdapter.ClearBeforeFill = true;
            // 
            // btnOut
            // 
            this.btnOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOut.BackColor = System.Drawing.Color.Transparent;
            this.btnOut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnOut.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Maroon;
            this.btnOut.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOut.ForeColor = System.Drawing.Color.Black;
            this.btnOut.Location = new System.Drawing.Point(761, 0);
            this.btnOut.Name = "btnOut";
            this.btnOut.Size = new System.Drawing.Size(39, 30);
            this.btnOut.TabIndex = 3;
            this.btnOut.Text = "X";
            this.btnOut.UseVisualStyleBackColor = false;
            this.btnOut.Click += new System.EventHandler(this.btnOut_Click);
            // 
            // frmCTDinhMucNguyenLieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rpCTDM);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmCTDinhMucNguyenLieu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chi tiết định mức";
            this.Load += new System.EventHandler(this.frmCTDinhMucNguyenLieu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyQuanCafeDataSet)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Microsoft.Reporting.WinForms.ReportViewer rpCTDM;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.ComboBox cboDanhMuc;
        private System.Windows.Forms.BindingSource dataTable1BindingSource;
        private QuanLyQuanCafeDataSet quanLyQuanCafeDataSet;
        private QuanLyQuanCafeDataSetTableAdapters.DataTable1TableAdapter dataTable1TableAdapter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOut;
    }
}