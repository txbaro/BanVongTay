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
        private User currentUser;

        public FMain()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

        }

        public FMain(User user)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            currentUser = user;
            LoadUserInfo();
        }

        private void LoadUserInfo()
        {
            lblName.Text = currentUser.LastName;
            lblRole.Text = currentUser.Role;
        }

        private void LoadFormIntoPanel(Form form)
        {
            if (panelContainer.Controls.Count > 0)
                panelContainer.Controls[0].Dispose();

            form.TopLevel = false; 
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill; 

            panelContainer.Controls.Add(form); 
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
            FSanPham form = new FSanPham();
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
            FKhachHang form = new FKhachHang(); // Gọi form mấy ông muốn nhảy qua 
            LoadFormIntoPanel(form);
            lblTrangChu.Text = "KHÁCH HÀNG";
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            FThongKe form = new FThongKe(); // Gọi form mấy ông muốn nhảy qua
            lblTrangChu.Text = "THỐNG KÊ";
            LoadFormIntoPanel(form);
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
