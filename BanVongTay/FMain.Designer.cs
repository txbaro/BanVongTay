namespace BanVongTay
{
    partial class FMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FMain));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.btnKhachHang = new System.Windows.Forms.Button();
            this.btnHoaDon = new System.Windows.Forms.Button();
            this.btnSanPham = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblTrangChu = new System.Windows.Forms.Label();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.pbClose = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel1.Controls.Add(this.btnThongKe);
            this.panel1.Controls.Add(this.btnKhachHang);
            this.panel1.Controls.Add(this.btnHoaDon);
            this.panel1.Controls.Add(this.btnSanPham);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(168, 540);
            this.panel1.TabIndex = 0;
            // 
            // btnThongKe
            // 
            this.btnThongKe.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThongKe.Location = new System.Drawing.Point(3, 425);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(162, 59);
            this.btnThongKe.TabIndex = 3;
            this.btnThongKe.Text = "THỐNG KÊ";
            this.btnThongKe.UseVisualStyleBackColor = true;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // btnKhachHang
            // 
            this.btnKhachHang.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKhachHang.Location = new System.Drawing.Point(3, 134);
            this.btnKhachHang.Name = "btnKhachHang";
            this.btnKhachHang.Size = new System.Drawing.Size(162, 59);
            this.btnKhachHang.TabIndex = 2;
            this.btnKhachHang.Text = "KHÁCH HÀNG";
            this.btnKhachHang.UseVisualStyleBackColor = true;
            this.btnKhachHang.Click += new System.EventHandler(this.btnKhachHang_Click);
            // 
            // btnHoaDon
            // 
            this.btnHoaDon.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHoaDon.Location = new System.Drawing.Point(3, 331);
            this.btnHoaDon.Name = "btnHoaDon";
            this.btnHoaDon.Size = new System.Drawing.Size(162, 59);
            this.btnHoaDon.TabIndex = 1;
            this.btnHoaDon.Text = "HOÁ ĐƠN";
            this.btnHoaDon.UseVisualStyleBackColor = true;
            this.btnHoaDon.Click += new System.EventHandler(this.btnHoaDon_Click_1);
            // 
            // btnSanPham
            // 
            this.btnSanPham.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSanPham.Location = new System.Drawing.Point(3, 233);
            this.btnSanPham.Name = "btnSanPham";
            this.btnSanPham.Size = new System.Drawing.Size(162, 59);
            this.btnSanPham.TabIndex = 0;
            this.btnSanPham.Text = "SẢN PHẨM";
            this.btnSanPham.UseVisualStyleBackColor = true;
            this.btnSanPham.Click += new System.EventHandler(this.btnSanPham_Click_1);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.pbClose);
            this.panel2.Controls.Add(this.lblTrangChu);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(168, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(792, 63);
            this.panel2.TabIndex = 1;
            // 
            // lblTrangChu
            // 
            this.lblTrangChu.AutoSize = true;
            this.lblTrangChu.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrangChu.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblTrangChu.Location = new System.Drawing.Point(6, 21);
            this.lblTrangChu.Name = "lblTrangChu";
            this.lblTrangChu.Size = new System.Drawing.Size(194, 41);
            this.lblTrangChu.TabIndex = 0;
            this.lblTrangChu.Text = "TRANG CHỦ";
            // 
            // panelContainer
            // 
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(168, 63);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(792, 477);
            this.panelContainer.TabIndex = 2;
            this.panelContainer.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // pbClose
            // 
            this.pbClose.ErrorImage = null;
            this.pbClose.Image = ((System.Drawing.Image)(resources.GetObject("pbClose.Image")));
            this.pbClose.InitialImage = null;
            this.pbClose.Location = new System.Drawing.Point(740, 12);
            this.pbClose.Name = "pbClose";
            this.pbClose.Size = new System.Drawing.Size(40, 45);
            this.pbClose.TabIndex = 1;
            this.pbClose.TabStop = false;
            this.pbClose.Click += new System.EventHandler(this.pbClose_Click);
            // 
            // FMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(960, 540);
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FMain";
            this.Load += new System.EventHandler(this.FMain_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnKhachHang;
        private System.Windows.Forms.Button btnHoaDon;
        private System.Windows.Forms.Button btnSanPham;
        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.Label lblTrangChu;
        private System.Windows.Forms.PictureBox pbClose;
    }
}

