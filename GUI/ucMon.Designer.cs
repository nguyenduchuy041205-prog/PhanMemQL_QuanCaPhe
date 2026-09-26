namespace GUI
{
    partial class ucMon
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.picMon = new System.Windows.Forms.PictureBox();
            this.lblTenMon = new System.Windows.Forms.Label();
            this.lblGia = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picMon)).BeginInit();
            this.SuspendLayout();
            // 
            // picMon
            // 
            this.picMon.Dock = System.Windows.Forms.DockStyle.Top;
            this.picMon.Location = new System.Drawing.Point(0, 0);
            this.picMon.Margin = new System.Windows.Forms.Padding(2);
            this.picMon.Name = "picMon";
            this.picMon.Size = new System.Drawing.Size(107, 79);
            this.picMon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picMon.TabIndex = 0;
            this.picMon.TabStop = false;
            // 
            // lblTenMon
            // 
            this.lblTenMon.AutoSize = true;
            this.lblTenMon.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenMon.Location = new System.Drawing.Point(3, 82);
            this.lblTenMon.Name = "lblTenMon";
            this.lblTenMon.Size = new System.Drawing.Size(45, 17);
            this.lblTenMon.TabIndex = 1;
            this.lblTenMon.Text = "label1";
            // 
            // lblGia
            // 
            this.lblGia.AutoSize = true;
            this.lblGia.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGia.ForeColor = System.Drawing.Color.Crimson;
            this.lblGia.Location = new System.Drawing.Point(3, 99);
            this.lblGia.Name = "lblGia";
            this.lblGia.Size = new System.Drawing.Size(45, 17);
            this.lblGia.TabIndex = 1;
            this.lblGia.Text = "label1";
            // 
            // ucMon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblGia);
            this.Controls.Add(this.lblTenMon);
            this.Controls.Add(this.picMon);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ucMon";
            this.Size = new System.Drawing.Size(107, 138);
            ((System.ComponentModel.ISupportInitialize)(this.picMon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picMon;
        private System.Windows.Forms.Label lblTenMon;
        private System.Windows.Forms.Label lblGia;
    }
}
