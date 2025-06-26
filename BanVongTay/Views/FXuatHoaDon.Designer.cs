namespace BanVongTay.Views
{
    partial class FXuatHoaDon
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
            this.rtbHoaDon = new System.Windows.Forms.RichTextBox();
            this.btnXuatHoaDon = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rtbHoaDon
            // 
            this.rtbHoaDon.Location = new System.Drawing.Point(-1, -1);
            this.rtbHoaDon.Name = "rtbHoaDon";
            this.rtbHoaDon.Size = new System.Drawing.Size(556, 624);
            this.rtbHoaDon.TabIndex = 0;
            this.rtbHoaDon.Text = "";
            // 
            // btnXuatHoaDon
            // 
            this.btnXuatHoaDon.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXuatHoaDon.Location = new System.Drawing.Point(186, 629);
            this.btnXuatHoaDon.Name = "btnXuatHoaDon";
            this.btnXuatHoaDon.Size = new System.Drawing.Size(165, 53);
            this.btnXuatHoaDon.TabIndex = 1;
            this.btnXuatHoaDon.Text = "XUẤT HOÁ ĐƠN";
            this.btnXuatHoaDon.UseVisualStyleBackColor = true;
            this.btnXuatHoaDon.Click += new System.EventHandler(this.btnXuatHoaDon_Click);
            // 
            // FXuatHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 692);
            this.ControlBox = false;
            this.Controls.Add(this.btnXuatHoaDon);
            this.Controls.Add(this.rtbHoaDon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FXuatHoaDon";
            this.Text = "FXuatHoaDon";
            this.Load += new System.EventHandler(this.FXuatHoaDon_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbHoaDon;
        private System.Windows.Forms.Button btnXuatHoaDon;
    }
}