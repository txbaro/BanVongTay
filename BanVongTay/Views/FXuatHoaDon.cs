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
            this.ClientSize = new System.Drawing.Size(800, 550);
            InitializeComponent();
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
