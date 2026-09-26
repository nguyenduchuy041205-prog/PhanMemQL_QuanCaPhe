namespace GUI
{
    partial class frmMonNgungBan
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvThungRac = new System.Windows.Forms.DataGridView();
            this.btnBanLai = new System.Windows.Forms.Button();
            this.btnOut = new System.Windows.Forms.Button();
            this.MaMon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenMon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Loai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThungRac)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnOut);
            this.panel1.Controls.Add(this.btnBanLai);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(377, 61);
            this.panel1.TabIndex = 0;
            // 
            // dgvThungRac
            // 
            this.dgvThungRac.AllowUserToAddRows = false;
            this.dgvThungRac.AllowUserToDeleteRows = false;
            this.dgvThungRac.AllowUserToResizeColumns = false;
            this.dgvThungRac.AllowUserToResizeRows = false;
            this.dgvThungRac.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvThungRac.BackgroundColor = System.Drawing.Color.White;
            this.dgvThungRac.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThungRac.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaMon,
            this.TenMon,
            this.Loai});
            this.dgvThungRac.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvThungRac.Location = new System.Drawing.Point(0, 61);
            this.dgvThungRac.Name = "dgvThungRac";
            this.dgvThungRac.ReadOnly = true;
            this.dgvThungRac.RowHeadersVisible = false;
            this.dgvThungRac.RowHeadersWidth = 51;
            this.dgvThungRac.RowTemplate.Height = 24;
            this.dgvThungRac.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvThungRac.Size = new System.Drawing.Size(377, 310);
            this.dgvThungRac.TabIndex = 1;
            // 
            // btnBanLai
            // 
            this.btnBanLai.BackColor = System.Drawing.Color.OrangeRed;
            this.btnBanLai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBanLai.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBanLai.ForeColor = System.Drawing.Color.Black;
            this.btnBanLai.Location = new System.Drawing.Point(12, 12);
            this.btnBanLai.Name = "btnBanLai";
            this.btnBanLai.Size = new System.Drawing.Size(91, 42);
            this.btnBanLai.TabIndex = 0;
            this.btnBanLai.Text = "Bán lại";
            this.btnBanLai.UseVisualStyleBackColor = false;
            this.btnBanLai.Click += new System.EventHandler(this.btnBanLai_Click);
            // 
            // btnOut
            // 
            this.btnOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOut.AutoSize = true;
            this.btnOut.BackColor = System.Drawing.Color.Transparent;
            this.btnOut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnOut.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Maroon;
            this.btnOut.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOut.ForeColor = System.Drawing.Color.Black;
            this.btnOut.Location = new System.Drawing.Point(347, 3);
            this.btnOut.Name = "btnOut";
            this.btnOut.Size = new System.Drawing.Size(27, 28);
            this.btnOut.TabIndex = 6;
            this.btnOut.Text = "X";
            this.btnOut.UseVisualStyleBackColor = false;
            this.btnOut.Click += new System.EventHandler(this.btnOut_Click);
            // 
            // MaMon
            // 
            this.MaMon.DataPropertyName = "IMaThucUong";
            this.MaMon.HeaderText = "Mã món";
            this.MaMon.MinimumWidth = 6;
            this.MaMon.Name = "MaMon";
            this.MaMon.ReadOnly = true;
            // 
            // TenMon
            // 
            this.TenMon.DataPropertyName = "STenThucUong";
            this.TenMon.HeaderText = "Tên món";
            this.TenMon.MinimumWidth = 6;
            this.TenMon.Name = "TenMon";
            this.TenMon.ReadOnly = true;
            // 
            // Loai
            // 
            this.Loai.DataPropertyName = "STenDanhMuc";
            this.Loai.HeaderText = "Loại";
            this.Loai.MinimumWidth = 6;
            this.Loai.Name = "Loai";
            this.Loai.ReadOnly = true;
            // 
            // frmMonNgungBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 371);
            this.Controls.Add(this.dgvThungRac);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMonNgungBan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMonNgungBan";
            this.Load += new System.EventHandler(this.frmMonNgungBan_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThungRac)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvThungRac;
        private System.Windows.Forms.Button btnBanLai;
        private System.Windows.Forms.Button btnOut;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaMon;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenMon;
        private System.Windows.Forms.DataGridViewTextBoxColumn Loai;
    }
}