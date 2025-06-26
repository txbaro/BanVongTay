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
            this.StartPosition = FormStartPosition.CenterScreen;

        }

        private void LoadFormIntoPanel(Form form) //Load Form Ở đây
        {
            if (panelContainer.Controls.Count > 0)
                panelContainer.Controls[0].Dispose();

            form.TopLevel = false; // Quan trọng: để form chạy như control
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill; // Cho vừa khít panel

            panelContainer.Controls.Add(form);  // tham chiếu
            panelContainer.Tag = form;
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
        }

        private void pictureBoxMaximize_Click(object sender, EventArgs e)
        {
        }

        private void picClose_Click(object sender, EventArgs e)
        {
   
        }

        private void picMaximize_Click(object sender, EventArgs e)
        {
        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {

        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void FMain_Load(object sender, EventArgs e)
        {
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSanPham_Click_1(object sender, EventArgs e)
        {
            FSanPham form = new FSanPham(); // Gọi form mấy ông muốn nhảy qua 
            LoadFormIntoPanel(form);
            lblTrangChu.Text = "SẢN PHẨM";
        }

        private void btnHoaDon_Click_1(object sender, EventArgs e)
        {
            FHoaDon form = new FHoaDon(); // Gọi form mấy ông muốn nhảy qua 
            LoadFormIntoPanel(form);
            lblTrangChu.Text = "HOÁ ĐƠN"; // Cập nhật tiêu đề
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            lblTrangChu.Text = "KHÁCH HÀNG";
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            lblTrangChu.Text = "THỐNG KÊ";
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
