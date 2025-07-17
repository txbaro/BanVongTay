namespace BanVongTay.Views
{
    partial class FKhachHang
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
            this.grpbTTCT = new System.Windows.Forms.GroupBox();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.lblTimKiem = new System.Windows.Forms.Label();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.txtSoDT = new System.Windows.Forms.TextBox();
            this.txtTenKH = new System.Windows.Forms.TextBox();
            this.txtMaKH = new System.Windows.Forms.TextBox();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.lblSDT = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblDiaChi = new System.Windows.Forms.Label();
            this.lblTenKH = new System.Windows.Forms.Label();
            this.lblMaKH = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.grpbTTKH = new System.Windows.Forms.GroupBox();
            this.lvKH = new System.Windows.Forms.ListView();
            this.clMaKH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clTenKH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clSoDT = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clEmail = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clDiaChi = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1.SuspendLayout();
            this.grpbTTCT.SuspendLayout();
            this.panel2.SuspendLayout();
            this.grpbTTKH.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.grpbTTCT);
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1051, 289);
            this.panel1.TabIndex = 1;
            // 
            // grpbTTCT
            // 
            this.grpbTTCT.Controls.Add(this.txtTimKiem);
            this.grpbTTCT.Controls.Add(this.lblTimKiem);
            this.grpbTTCT.Controls.Add(this.btnHuy);
            this.grpbTTCT.Controls.Add(this.btnLuu);
            this.grpbTTCT.Controls.Add(this.btnSua);
            this.grpbTTCT.Controls.Add(this.txtEmail);
            this.grpbTTCT.Controls.Add(this.txtDiaChi);
            this.grpbTTCT.Controls.Add(this.txtSoDT);
            this.grpbTTCT.Controls.Add(this.txtTenKH);
            this.grpbTTCT.Controls.Add(this.txtMaKH);
            this.grpbTTCT.Controls.Add(this.btnXoa);
            this.grpbTTCT.Controls.Add(this.btnThem);
            this.grpbTTCT.Controls.Add(this.lblSDT);
            this.grpbTTCT.Controls.Add(this.lblEmail);
            this.grpbTTCT.Controls.Add(this.lblDiaChi);
            this.grpbTTCT.Controls.Add(this.lblTenKH);
            this.grpbTTCT.Controls.Add(this.lblMaKH);
            this.grpbTTCT.Font = new System.Drawing.Font("Segoe Fluent Icons", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpbTTCT.Location = new System.Drawing.Point(0, 0);
            this.grpbTTCT.Name = "grpbTTCT";
            this.grpbTTCT.Size = new System.Drawing.Size(1051, 605);
            this.grpbTTCT.TabIndex = 1;
            this.grpbTTCT.TabStop = false;
            this.grpbTTCT.Text = " ";
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(563, 155);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(227, 30);
            this.txtTimKiem.TabIndex = 21;
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);
            // 
            // lblTimKiem
            // 
            this.lblTimKiem.AutoSize = true;
            this.lblTimKiem.Font = new System.Drawing.Font("Segoe Fluent Icons", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimKiem.Location = new System.Drawing.Point(481, 161);
            this.lblTimKiem.Name = "lblTimKiem";
            this.lblTimKiem.Size = new System.Drawing.Size(76, 20);
            this.lblTimKiem.TabIndex = 20;
            this.lblTimKiem.Text = "Tìm kiếm:";
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(831, 132);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(161, 44);
            this.btnHuy.TabIndex = 19;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Visible = false;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(831, 61);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(161, 44);
            this.btnLuu.TabIndex = 18;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Visible = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(629, 209);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(161, 44);
            this.btnSua.TabIndex = 17;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(229, 155);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(227, 30);
            this.txtEmail.TabIndex = 16;
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(563, 102);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(227, 30);
            this.txtDiaChi.TabIndex = 13;
            // 
            // txtSoDT
            // 
            this.txtSoDT.Location = new System.Drawing.Point(229, 96);
            this.txtSoDT.Name = "txtSoDT";
            this.txtSoDT.Size = new System.Drawing.Size(227, 30);
            this.txtSoDT.TabIndex = 12;
            // 
            // txtTenKH
            // 
            this.txtTenKH.Location = new System.Drawing.Point(563, 40);
            this.txtTenKH.Name = "txtTenKH";
            this.txtTenKH.Size = new System.Drawing.Size(227, 30);
            this.txtTenKH.TabIndex = 10;
            // 
            // txtMaKH
            // 
            this.txtMaKH.Enabled = false;
            this.txtMaKH.Location = new System.Drawing.Point(229, 40);
            this.txtMaKH.Name = "txtMaKH";
            this.txtMaKH.Size = new System.Drawing.Size(227, 30);
            this.txtMaKH.TabIndex = 9;
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(405, 209);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(161, 44);
            this.btnXoa.TabIndex = 7;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThem
            // 
            this.btnThem.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnThem.Location = new System.Drawing.Point(165, 209);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(161, 44);
            this.btnThem.TabIndex = 6;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // lblSDT
            // 
            this.lblSDT.AutoSize = true;
            this.lblSDT.Font = new System.Drawing.Font("Segoe Fluent Icons", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSDT.Location = new System.Drawing.Point(164, 102);
            this.lblSDT.Name = "lblSDT";
            this.lblSDT.Size = new System.Drawing.Size(58, 20);
            this.lblSDT.TabIndex = 5;
            this.lblSDT.Text = "Số ĐT:";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Segoe Fluent Icons", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(164, 161);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(50, 20);
            this.lblEmail.TabIndex = 4;
            this.lblEmail.Text = "Email:";
            // 
            // lblDiaChi
            // 
            this.lblDiaChi.AutoSize = true;
            this.lblDiaChi.Font = new System.Drawing.Font("Segoe Fluent Icons", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiaChi.Location = new System.Drawing.Point(496, 102);
            this.lblDiaChi.Name = "lblDiaChi";
            this.lblDiaChi.Size = new System.Drawing.Size(60, 20);
            this.lblDiaChi.TabIndex = 3;
            this.lblDiaChi.Text = "Địa chỉ:";
            // 
            // lblTenKH
            // 
            this.lblTenKH.AutoSize = true;
            this.lblTenKH.Font = new System.Drawing.Font("Segoe Fluent Icons", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenKH.Location = new System.Drawing.Point(495, 40);
            this.lblTenKH.Name = "lblTenKH";
            this.lblTenKH.Size = new System.Drawing.Size(71, 20);
            this.lblTenKH.TabIndex = 1;
            this.lblTenKH.Text = "Tên KH: ";
            // 
            // lblMaKH
            // 
            this.lblMaKH.AutoSize = true;
            this.lblMaKH.Font = new System.Drawing.Font("Segoe Fluent Icons", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaKH.Location = new System.Drawing.Point(161, 40);
            this.lblMaKH.Name = "lblMaKH";
            this.lblMaKH.Size = new System.Drawing.Size(61, 20);
            this.lblMaKH.TabIndex = 0;
            this.lblMaKH.Text = "Mã KH:";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(183, 219);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(8, 8);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.grpbTTKH);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 295);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1051, 271);
            this.panel2.TabIndex = 2;
            // 
            // grpbTTKH
            // 
            this.grpbTTKH.Controls.Add(this.lvKH);
            this.grpbTTKH.Font = new System.Drawing.Font("Segoe Fluent Icons", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpbTTKH.Location = new System.Drawing.Point(12, 18);
            this.grpbTTKH.Name = "grpbTTKH";
            this.grpbTTKH.Size = new System.Drawing.Size(1027, 188);
            this.grpbTTKH.TabIndex = 0;
            this.grpbTTKH.TabStop = false;
            this.grpbTTKH.Text = "Thông tin khách hàng";
            // 
            // lvKH
            // 
            this.lvKH.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clMaKH,
            this.clTenKH,
            this.clSoDT,
            this.clEmail,
            this.clDiaChi});
            this.lvKH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvKH.FullRowSelect = true;
            this.lvKH.GridLines = true;
            this.lvKH.HideSelection = false;
            this.lvKH.Location = new System.Drawing.Point(3, 26);
            this.lvKH.Name = "lvKH";
            this.lvKH.Size = new System.Drawing.Size(1021, 159);
            this.lvKH.TabIndex = 0;
            this.lvKH.UseCompatibleStateImageBehavior = false;
            this.lvKH.View = System.Windows.Forms.View.Details;
            // 
            // clMaKH
            // 
            this.clMaKH.Text = "Mã KH";
            this.clMaKH.Width = 101;
            // 
            // clTenKH
            // 
            this.clTenKH.Text = "Tên KH";
            this.clTenKH.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.clTenKH.Width = 301;
            // 
            // clSoDT
            // 
            this.clSoDT.Text = "Số ĐT";
            this.clSoDT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.clSoDT.Width = 150;
            // 
            // clEmail
            // 
            this.clEmail.Text = "Email";
            this.clEmail.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.clEmail.Width = 164;
            // 
            // clDiaChi
            // 
            this.clDiaChi.Text = "Địa chỉ";
            this.clDiaChi.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.clDiaChi.Width = 301;
            // 
            // FKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1051, 566);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FKhachHang";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.Load += new System.EventHandler(this.FKhachHang_Load);
            this.panel1.ResumeLayout(false);
            this.grpbTTCT.ResumeLayout(false);
            this.grpbTTCT.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.grpbTTKH.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox grpbTTCT;
        private System.Windows.Forms.Label lblSDT;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblDiaChi;
        private System.Windows.Forms.Label lblTenKH;
        private System.Windows.Forms.Label lblMaKH;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TextBox txtMaKH;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.TextBox txtTenKH;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.TextBox txtSoDT;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox grpbTTKH;
        private System.Windows.Forms.ListView lvKH;
        private System.Windows.Forms.ColumnHeader clMaKH;
        private System.Windows.Forms.ColumnHeader clTenKH;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.ColumnHeader clSoDT;
        private System.Windows.Forms.ColumnHeader clEmail;
        private System.Windows.Forms.ColumnHeader clDiaChi;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Label lblTimKiem;
    }
}