namespace capa_presentacion.Detalles
{
    partial class dtInicioQR
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
            this.pbQR = new System.Windows.Forms.PictureBox();
            this.pbFotoCapturada = new System.Windows.Forms.PictureBox();
            this.cmbDisp = new System.Windows.Forms.ComboBox();
            this.txtTexto = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbQR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFotoCapturada)).BeginInit();
            this.SuspendLayout();
            // 
            // pbQR
            // 
            this.pbQR.Location = new System.Drawing.Point(86, 66);
            this.pbQR.Name = "pbQR";
            this.pbQR.Size = new System.Drawing.Size(214, 197);
            this.pbQR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbQR.TabIndex = 5;
            this.pbQR.TabStop = false;
            // 
            // pbFotoCapturada
            // 
            this.pbFotoCapturada.Location = new System.Drawing.Point(86, 66);
            this.pbFotoCapturada.Name = "pbFotoCapturada";
            this.pbFotoCapturada.Size = new System.Drawing.Size(214, 197);
            this.pbFotoCapturada.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbFotoCapturada.TabIndex = 6;
            this.pbFotoCapturada.TabStop = false;
            // 
            // cmbDisp
            // 
            this.cmbDisp.FormattingEnabled = true;
            this.cmbDisp.Location = new System.Drawing.Point(54, 283);
            this.cmbDisp.Name = "cmbDisp";
            this.cmbDisp.Size = new System.Drawing.Size(121, 21);
            this.cmbDisp.TabIndex = 7;
            this.cmbDisp.Visible = false;
            // 
            // txtTexto
            // 
            this.txtTexto.Location = new System.Drawing.Point(213, 284);
            this.txtTexto.Name = "txtTexto";
            this.txtTexto.Size = new System.Drawing.Size(100, 20);
            this.txtTexto.TabIndex = 8;
            this.txtTexto.Visible = false;
            // 
            // dtInicioQR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 336);
            this.Controls.Add(this.txtTexto);
            this.Controls.Add(this.cmbDisp);
            this.Controls.Add(this.pbQR);
            this.Controls.Add(this.pbFotoCapturada);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "dtInicioQR";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "dtInicioQR";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.dtInicioQR_FormClosed);
            this.Load += new System.EventHandler(this.dtInicioQR_Load);
            this.Click += new System.EventHandler(this.dtInicioQR_Click);
            ((System.ComponentModel.ISupportInitialize)(this.pbQR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFotoCapturada)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbQR;
        private System.Windows.Forms.PictureBox pbFotoCapturada;
        private System.Windows.Forms.ComboBox cmbDisp;
        private System.Windows.Forms.TextBox txtTexto;
    }
}