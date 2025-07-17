using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using BanVongTay.Controllers;

namespace BanVongTay.Views
{
    public partial class FKhachHang : Form
    {
        private ConnectDB db = new ConnectDB();

        public FKhachHang()
        {
            InitializeComponent();  

        }

        private void FKhachHang_Load(object sender, EventArgs e)
        {
            HienThiDuLieuLenListView();
        }

        private void HienThiDuLieuLenListView(string searchTerm = "")
        {
            lvKH.Items.Clear();
            lvKH.Columns.Clear();

            lvKH.View = View.Details;
            lvKH.FullRowSelect = true;
            lvKH.GridLines = true;

            if (lvKH.Columns.Count == 0)
            {
                lvKH.View = View.Details;          
                lvKH.FullRowSelect = true;         
                lvKH.GridLines = true;             

                lvKH.Columns.Add("Mã KH", 70);     
                lvKH.Columns.Add("Tên KH", 170);   
                lvKH.Columns.Add("SĐT", 100);
                lvKH.Columns.Add("Email", 180);
                lvKH.Columns.Add("Địa chỉ", 200);     
            }

            string sql = "SELECT CustomerID, Name, Phone, Address, Email FROM Customers";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                sql += " WHERE Name LIKE @SearchTerm OR Phone LIKE @SearchTerm";
                parameters["@SearchTerm"] = "%" + searchTerm + "%";
            }

            try
            {
                DataTable dt = db.ExecuteQuery(sql, parameters);
                foreach (DataRow row in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(row["CustomerID"].ToString());
                    item.SubItems.Add(row["Name"].ToString());
                    item.SubItems.Add(row["Phone"].ToString());
                    item.SubItems.Add(row["Address"].ToString());
                    item.SubItems.Add(row["Email"].ToString());
                    lvKH.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenKH.Text) || string.IsNullOrEmpty(txtDiaChi.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ các thông tin bắt buộc.", "Thông báo");
                return;
            }

            CustomerController controller = new CustomerController();
            string newCustomerID = controller.GenerateNewCustomerID();

            string sql = "INSERT INTO Customers (CustomerID, Name, Phone, Address, Email) VALUES (@CustomerID, @Name, @Phone, @Address, @Email)";
            var parameters = new Dictionary<string, object>
            {
                ["@CustomerID"] = newCustomerID,
                ["@Name"] = txtTenKH.Text.Trim(),
                ["@Phone"] = txtSoDT.Text.Trim(),
                ["@Address"] = txtDiaChi.Text.Trim(),
                ["@Email"] = txtEmail.Text.Trim()
            };

            try
            {
                db.ExecuteNonQuery(sql, parameters);
                MessageBox.Show("Thêm khách hàng thành công!");
                HienThiDuLieuLenListView();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm khách hàng: " + ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lvKH.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần xóa.");
                return;
            }

            string id = lvKH.SelectedItems[0].Text;
            var confirm = MessageBox.Show($"Bạn có chắc muốn xoá khách hàng '{id}'?", "Xác nhận", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.No) return;

            string sql = "DELETE FROM Customers WHERE CustomerID = @CustomerID";
            var parameters = new Dictionary<string, object> { ["@CustomerID"] = id };

            try
            {
                int rows = db.ExecuteNonQuery(sql, parameters);
                if (rows > 0)
                {
                    MessageBox.Show("Xóa thành công!");
                    HienThiDuLieuLenListView(txtTimKiem.Text);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy khách hàng.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xoá khách hàng: " + ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (lvKH.SelectedItems.Count == 0)
            {
                MessageBox.Show("Chọn khách hàng để sửa.");
                return;
            }

            var selected = lvKH.SelectedItems[0];
            txtMaKH.Text = selected.SubItems[0].Text;
            txtTenKH.Text = selected.SubItems[1].Text;
            txtSoDT.Text = selected.SubItems[2].Text;
            txtDiaChi.Text = selected.SubItems[3].Text;
            txtEmail.Text = selected.SubItems[4].Text;

            txtMaKH.ReadOnly = true;
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Visible = true;
            btnHuy.Visible = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenKH.Text) || string.IsNullOrEmpty(txtDiaChi.Text))
            {
                MessageBox.Show("Tên và địa chỉ không được để trống.");
                return;
            }

            string sql = "UPDATE Customers SET Name = @Name, Phone = @Phone, Address = @Address, Email = @Email WHERE CustomerID = @CustomerID";
            var parameters = new Dictionary<string, object>
            {
                ["@CustomerID"] = txtMaKH.Text,
                ["@Name"] = txtTenKH.Text.Trim(),
                ["@Phone"] = txtSoDT.Text.Trim(),
                ["@Address"] = txtDiaChi.Text.Trim(),
                ["@Email"] = txtEmail.Text.Trim()
            };

            try
            {
                db.ExecuteNonQuery(sql, parameters);
                MessageBox.Show("Cập nhật thành công!");
                HienThiDuLieuLenListView(txtTimKiem.Text);
                QuayVeCheDoThem();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật: " + ex.Message);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            QuayVeCheDoThem();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            HienThiDuLieuLenListView(txtTimKiem.Text);
        }

        private void ClearForm()
        {
            txtMaKH.Clear();
            txtTenKH.Clear();
            txtSoDT.Clear();
            txtDiaChi.Clear();
            txtEmail.Clear();
            txtMaKH.Focus();
        }

        private void QuayVeCheDoThem()
        {
            ClearForm();
            txtMaKH.ReadOnly = false;

            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLuu.Visible = false;
            btnHuy.Visible = false;
        }
    }
}
