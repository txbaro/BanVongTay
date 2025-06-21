using BanVongTay.Controllers;
using BanVongTay.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace BanVongTay.Views
{
    public partial class FSanPham : Form
    {
        private Products currentProduct = new Products();
        private ProductController productController = new ProductController();
        private bool isEditing = false;
        private bool isAdding = false;

        public FSanPham()
        {
            InitializeComponent();
        }

        private void FSanPham_Load(object sender, EventArgs e)
        {
            loadProductList();
            loadSearchOption();
            LoadCategoryToComboBox();
            setInputEnabled(false);
            btnThem.Text = "THÊM";
            isAdding = false;
            isEditing = false;
            dtgvDSSP.ReadOnly = true;
        }

        private void loadProductList()
        {
            ConnectDB db = new ConnectDB();
            string query = @"
        SELECT 
            p.ProductID,
            p.ProductName,
            p.Price,
            p.CategoryName,
            ISNULL(s.Quantity, 0) AS Quantity,
            p.ImageURL
                FROM Products p
                LEFT JOIN Storage s ON p.ProductID = s.ProductID";

            dtgvDSSP.DataSource = db.ExecuteQuery(query);

            dtgvDSSP.Columns["ProductID"].Width = 80;
            dtgvDSSP.Columns["ProductName"].Width = 200;
            dtgvDSSP.Columns["Price"].Width = 90;
            dtgvDSSP.Columns["Quantity"].Width = 80;
        }

        private void loadSearchOption()
        {
            cbTimKiem.Items.Clear();
            cbTimKiem.Items.Add("Mã");  
            cbTimKiem.Items.Add("Tên");    
            cbTimKiem.Items.Add("Loại");   
            cbTimKiem.SelectedIndex = 0;
        }

        private void setInputEnabled(bool enabled)
        {
            txtProductName.Enabled = enabled;
            txtUnitPrice.Enabled = enabled;
            txtQuantity.Enabled = enabled;
            btnUploadImage.Enabled = enabled;
            cbCategories.Enabled = enabled;
        }

        private void clearInput()
        {
            txtProductID.Clear();
            txtProductName.Clear();
            txtUnitPrice.Clear();
            txtQuantity.Clear();
            pbProductImg.Image = null;
            currentProduct = new Products();
        }

        private bool isTextOnly(string input)
        {
            foreach (char c in input)
            {
                if (!char.IsLetter(c) && !char.IsWhiteSpace(c))
                    return false;
            }
            return true;
        }

        private void dtgvDSSP_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtgvDSSP.Rows[e.RowIndex];
                txtProductID.Text = row.Cells["ProductID"].Value.ToString();
                txtProductName.Text = row.Cells["ProductName"].Value.ToString();
                txtUnitPrice.Text = row.Cells["Price"].Value.ToString();
                txtQuantity.Text = row.Cells["Quantity"].Value.ToString();
                cbCategories.Text = row.Cells["CategoryName"].Value.ToString();

                pbProductImg.Image = null;

                currentProduct.CategoryName = cbCategories.Text;
                currentProduct.ProductName = row.Cells["ProductName"].Value.ToString();
                currentProduct.Price = Convert.ToDecimal(row.Cells["Price"].Value);
                currentProduct.Quantity = Convert.ToInt32(row.Cells["Quantity"].Value);
                currentProduct.ImageURL = row.Cells["ImageURL"].Value?.ToString() ?? string.Empty;

                if (!string.IsNullOrEmpty(currentProduct.ImageURL) && System.IO.File.Exists(currentProduct.ImageURL))
                {
                    pbProductImg.ImageLocation = currentProduct.ImageURL;
                    pbProductImg.SizeMode = PictureBoxSizeMode.Zoom;
                }
                else
                {
                    pbProductImg.Image = null;
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (btnThem.Text == "THÊM")
            {
                isAdding = true;
                isEditing = false;
                setInputEnabled(true);
                clearInput();
                btnThem.Text = "LƯU";
            }
            else if (btnThem.Text == "LƯU")
            {
                if (string.IsNullOrWhiteSpace(txtProductName.Text) ||
                    string.IsNullOrWhiteSpace(txtUnitPrice.Text) ||
                    string.IsNullOrWhiteSpace(txtQuantity.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                    return;
                }

                if (!decimal.TryParse(txtUnitPrice.Text, out decimal price))
                {
                    MessageBox.Show("Giá không hợp lệ!");
                    return;
                }

                if (!int.TryParse(txtQuantity.Text, out int quantity))
                {
                    MessageBox.Show("Số lượng không hợp lệ!");
                    return;
                }

                if (!isTextOnly(txtProductName.Text))
                {
                    MessageBox.Show("Tên sản phẩm chỉ được chứa chữ cái và khoảng trắng.");
                    return;
                }

                if (!isTextOnly(cbCategories.Text))
                {
                    MessageBox.Show("Loại vòng chỉ được chứa chữ cái.");
                    return;
                }

                if (!decimal.TryParse(txtUnitPrice.Text, out price))
                {
                    MessageBox.Show("Giá không hợp lệ! Chỉ được nhập số.");
                    return;
                }

                if (!int.TryParse(txtQuantity.Text, out quantity))
                {
                    MessageBox.Show("Số lượng không hợp lệ! Chỉ được nhập số nguyên.");
                    return;
                }

                currentProduct.ProductName = txtProductName.Text;
                currentProduct.Price = price;
                currentProduct.Quantity = quantity;
                currentProduct.ImageURL = pbProductImg.ImageLocation;
                currentProduct.CategoryName = cbCategories.Text;


                bool result = false;

                if (isAdding)
                {
                    result = productController.AddProduct(currentProduct);
                    MessageBox.Show(result ? "Thêm sản phẩm thành công!" : "Thêm thất bại.");
                }
                else if (isEditing)
                {
                    currentProduct.ProductID = int.Parse(txtProductID.Text);
                    result = productController.UpdateProduct(currentProduct);
                    MessageBox.Show(result ? "Cập nhật thành công!" : "Cập nhật thất bại.");
                }

                isAdding = false;
                isEditing = false;
                btnThem.Text = "THÊM";
                setInputEnabled(false);
                loadProductList();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtProductID.Text))
            {
                MessageBox.Show("Vui lòng chọn sản phẩm để sửa.");
                return;
            }

            isEditing = true;
            isAdding = false;
            setInputEnabled(true);
            btnThem.Text = "LƯU";
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtProductID.Text))
            {
                MessageBox.Show("Vui lòng chọn sản phẩm để xoá.");
                return;
            }

            int id = int.Parse(txtProductID.Text);
            DialogResult dialog = MessageBox.Show("Bạn có chắc muốn xoá?", "Xác nhận", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                bool result = productController.DeleteProduct(id);
                MessageBox.Show(result ? "Xoá thành công!" : "Xoá thất bại.");
                loadProductList();
            }
        }

        private void btnUploadImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    pbProductImg.ImageLocation = ofd.FileName;
                    pbProductImg.SizeMode = PictureBoxSizeMode.Zoom;
                    currentProduct.ImageURL = ofd.FileName;
                }
            }
        }

        private void LoadCategoryToComboBox()
        {
            cbCategories.Items.Clear();
            cbCategories.Items.Add("Vòng chuỗi");
            cbCategories.Items.Add("Vòng chỉ");
            cbCategories.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void pbProductImg_Click(object sender, EventArgs e) { }

        private void label3_Click(object sender, EventArgs e) { }

        private void txtProductType_TextChanged(object sender, EventArgs e) { }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();
            string selectedOption = cbTimKiem.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(keyword))
            {
                loadProductList(); 
                return;
            }

            string whereClause = "";

            switch (selectedOption)
            {
                case "Mã sản phẩm":
                    whereClause = $"p.ProductID LIKE N'%{keyword}%'";
                    break;
                case "Tên sản phẩm":
                    whereClause = $"p.ProductName LIKE N'%{keyword}%'";
                    break;
                case "Loại sản phẩm":
                    whereClause = $"p.CategoryName LIKE N'%{keyword}%'";
                    break;
                default:
                    // Tìm tất cả các cột
                    whereClause = $@"
                p.ProductID LIKE N'%{keyword}%' OR
                p.ProductName LIKE N'%{keyword}%' OR
                p.CategoryName LIKE N'%{keyword}%'";
                    break;
            }

            string query = $@"
        SELECT 
            p.ProductID,
            p.ProductName,
            p.Price,
            p.CategoryName,
            ISNULL(s.Quantity, 0) AS Quantity
        FROM Products p
        LEFT JOIN Storage s ON p.ProductID = s.ProductID
        WHERE {whereClause}";

            ConnectDB db = new ConnectDB();
            dtgvDSSP.DataSource = db.ExecuteQuery(query);
        }

        private void txtImagePath_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
