using BanVongTay.Controllers;
using BanVongTay.Models;
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
    public partial class FSanPham : Form
    {
        private Products currentProduct = new Products();
        private ProductController productController = new ProductController();

        public FSanPham()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dtgvDSSP_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtgvDSSP.Rows[e.RowIndex];

                txtProductID.Text = row.Cells["ProductID"].Value.ToString();
                txtProductName.Text = row.Cells["ProductName"].Value.ToString();
                txtUnitPrice.Text = row.Cells["UnitPrice"].Value.ToString();
                txtQuantity.Text = row.Cells["Quantity"].Value.ToString();

                currentProduct.ProductID = Convert.ToInt32(row.Cells["ProductID"].Value);
                currentProduct.ProductName = row.Cells["ProductName"].Value.ToString();
                currentProduct.UnitPrice = Convert.ToDecimal(row.Cells["UnitPrice"].Value);
                currentProduct.Quantity = Convert.ToInt32(row.Cells["Quantity"].Value);
                currentProduct.ProductImage = row.Cells["ProductImage"].Value?.ToString();

                if (!string.IsNullOrEmpty(currentProduct.ProductImage) && System.IO.File.Exists(currentProduct.ProductImage))
                {
                    pbProductImg.ImageLocation = currentProduct.ProductImage;
                }
                else
                {
                    pbProductImg.Image = null;
                }
            }
        }

        private void FSanPham_Load(object sender, EventArgs e)
        {

            ConnectDB db = new ConnectDB();
            string query = "SELECT * FROM Products";
            dtgvDSSP.DataSource = db.ExecuteQuery(query);

            dtgvDSSP.Columns["ProductID"].Width = 80;
            dtgvDSSP.Columns["ProductName"].Width = 200;
            dtgvDSSP.Columns["UnitPrice"].Width = 100;
            dtgvDSSP.Columns["Quantity"].Width = 80;
        }

        private void txtProductType_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {

        }

        private void pbProductImg_Click(object sender, EventArgs e)
        {

        }

        private void btnUploadImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    pbProductImg.ImageLocation = ofd.FileName;
                    currentProduct.ProductImage = ofd.FileName;
                }
            }
        }
    }
}
