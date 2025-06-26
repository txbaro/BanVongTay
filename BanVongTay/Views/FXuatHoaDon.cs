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
    public partial class FXuatHoaDon : Form
    {
        public FXuatHoaDon(string hoaDonText)
        {
            InitializeComponent();
            rtbHoaDon.Font = new Font("Consolas", 10);
            rtbHoaDon.ReadOnly = true;
            rtbHoaDon.Text = hoaDonText;
        }

        private void FXuatHoaDon_Load(object sender, EventArgs e)
        {

        }

        private void btnXuatHoaDon_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
