using BanVongTay.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BanVongTay.Views
{
    public partial class FLogin : Form
    {
        public FLogin()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            AuthController auth = new AuthController();
            var user = auth.Login(txtUsername.Text.Trim(), txtPassword.Text.Trim());

            if (user != null)
            {
                this.Hide();
                var mainForm = new FMain(user);
                mainForm.Show();
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!");
            }
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
