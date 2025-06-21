using BanVongTay.Controllers;
using BanVongTay.Models;
using BanVongTay.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace BanVongTay
{
    public partial class FMain : Form
    {
        public FMain()
        {
            InitializeComponent();
            this.Size = new System.Drawing.Size(1280, 720);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Normal;
        }

        private void LoadFormIntoPanel(Form form) 
        {
            if (panelDisplayForm.Controls.Count > 0)
                panelDisplayForm.Controls[0].Dispose(); 

            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;

            panelDisplayForm.Controls.Add(form);
            panelDisplayForm.Tag = form;
            form.Show();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panelDisplayForm_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBoxMaximize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void picMaximize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {
            FSanPham form = new FSanPham();
            LoadFormIntoPanel(form); // Thiếu dòng này nên form không hiển thị
            lblThongTinTrang.Text = "SẢN PHẨM";
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            FHoaDon form = new FHoaDon();
            LoadFormIntoPanel(form);
            form.loadDanhSachHoaDon();   
            lblThongTinTrang.Text = "HOÁ ĐƠN";
        }
    }
}
