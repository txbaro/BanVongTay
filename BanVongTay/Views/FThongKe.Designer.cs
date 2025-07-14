namespace BanVongTay
{
    partial class FThongKe
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblThongKe = new System.Windows.Forms.Label();
            this.lblChonNam = new System.Windows.Forms.Label();
            this.cboNam = new System.Windows.Forms.ComboBox();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.lvDoanhThu = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // lblThongKe
            // 
            this.lblThongKe.AutoSize = true;
            this.lblThongKe.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblThongKe.Location = new System.Drawing.Point(12, 9);
            this.lblThongKe.Name = "lblThongKe";
            this.lblThongKe.Size = new System.Drawing.Size(276, 32);
            this.lblThongKe.TabIndex = 0;
            this.lblThongKe.Text = "THỐNG KÊ DOANH THU";
            // 
            // lblChonNam
            // 
            this.lblChonNam.AutoSize = true;
            this.lblChonNam.Location = new System.Drawing.Point(14, 60);
            this.lblChonNam.Name = "lblChonNam";
            this.lblChonNam.Size = new System.Drawing.Size(80, 20);
            this.lblChonNam.TabIndex = 1;
            this.lblChonNam.Text = "Chọn năm:";
            // 
            // cboNam
            // 
            this.cboNam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNam.FormattingEnabled = true;
            this.cboNam.Location = new System.Drawing.Point(100, 57);
            this.cboNam.Name = "cboNam";
            this.cboNam.Size = new System.Drawing.Size(138, 28);
            this.cboNam.TabIndex = 2;
            // 
            // btnThongKe
            // 
            this.btnThongKe.Location = new System.Drawing.Point(244, 56);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(94, 30);
            this.btnThongKe.TabIndex = 3;
            this.btnThongKe.Text = "Thống kê";
            this.btnThongKe.UseVisualStyleBackColor = true;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // lvDoanhThu
            // 
            this.lvDoanhThu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvDoanhThu.HideSelection = false;
            this.lvDoanhThu.Location = new System.Drawing.Point(12, 100);
            this.lvDoanhThu.Name = "lvDoanhThu";
            this.lvDoanhThu.Size = new System.Drawing.Size(650, 350);
            this.lvDoanhThu.TabIndex = 4;
            this.lvDoanhThu.UseCompatibleStateImageBehavior = false;
            // 
            // **SỬA ĐỔI QUAN TRỌNG**: Thêm 2 dòng này để kết nối sự kiện vẽ
            // 
            this.lvDoanhThu.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.LvDoanhThu_DrawColumnHeader);
            this.lvDoanhThu.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.LvDoanhThu_DrawSubItem);
            // 
            // FThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 462);
            this.Controls.Add(this.lvDoanhThu);
            this.Controls.Add(this.btnThongKe);
            this.Controls.Add(this.cboNam);
            this.Controls.Add(this.lblChonNam);
            this.Controls.Add(this.lblThongKe);
            this.Name = "FThongKe";
            this.Text = "FThongKe";
            this.Load += new System.EventHandler(this.FThongKe_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblThongKe;
        private System.Windows.Forms.Label lblChonNam;
        private System.Windows.Forms.ComboBox cboNam;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.ListView lvDoanhThu;
    }
}
