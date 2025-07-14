using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BanVongTay.Views
{
    public partial class FKhachHang : Form
    {
        public FKhachHang()
        {
            InitializeComponent();
        }

        private void lblNTNS_Click(object sender, EventArgs e)
        {

        }
        SqlConnection connec = null;
        string strconnec = @"Data Source=MSI\SQLEXPRESS;Initial Catalog=BraceletShop;Integrated Security=True";
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaKH.Text) || string.IsNullOrEmpty(txtTenKH.Text) || string.IsNullOrEmpty(txtDiaChi.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ các thông tin bắt buộc: Mã KH, Tên KH và Địa chỉ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string sql = "INSERT INTO Customers (CustomerID, Name, Phone, Address, Email) VALUES (@CustomerID, @Name, @Phone, @Address, @Email)";

            try
            {
                using (SqlConnection connec = new SqlConnection(strconnec))
                {
                    connec.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, connec))
                    {
                        cmd.Parameters.AddWithValue("@CustomerID", txtMaKH.Text.Trim());
                        cmd.Parameters.AddWithValue("@Name", txtTenKH.Text.Trim());
                        cmd.Parameters.AddWithValue("@Phone", txtSoDT.Text.Trim());
                        cmd.Parameters.AddWithValue("@Address", txtDiaChi.Text.Trim());
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Thêm khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        HienThiDuLieuLenListView();

                        txtMaKH.Clear();
                        txtTenKH.Clear();
                        txtSoDT.Clear();
                        txtDiaChi.Clear();
                        txtEmail.Clear();
                        txtMaKH.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi thêm khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HienThiDuLieuLenListView(string searchTerm = "")
        {
            lvKH.Items.Clear();

            string strconnec = @"Data Source=.\SQLEXPRESS;Initial Catalog=BraceletShop;Integrated Security=True";
            string sql = "SELECT CustomerID, Name, Phone, Address, Email FROM Customers";

            if (!string.IsNullOrEmpty(searchTerm))
            {
                sql += " WHERE Name LIKE @SearchTerm OR Phone LIKE @SearchTerm";
            }

            try
            {
                using (SqlConnection connec = new SqlConnection(strconnec))
                {
                    connec.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, connec))
                    {
                        if (!string.IsNullOrEmpty(searchTerm))
                        {
                            cmd.Parameters.AddWithValue("@SearchTerm", "%" + searchTerm + "%");
                        }

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ListViewItem item = new ListViewItem(reader["CustomerID"].ToString());
                                item.SubItems.Add(reader["Name"].ToString());
                                item.SubItems.Add(reader["Phone"].ToString());
                                item.SubItems.Add(reader["Address"].ToString());
                                item.SubItems.Add(reader["Email"].ToString());
                                lvKH.Items.Add(item);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }

        private void FKhachHang_Load(object sender, EventArgs e)
        {
            HienThiDuLieuLenListView();
        }

        


        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lvKH.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một khách hàng để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string customerIDToDelete = lvKH.SelectedItems[0].Text;

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa khách hàng có mã '" + customerIDToDelete + "' không?",
                                                  "Xác nhận xóa",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                return;
            }

            string sql = "DELETE FROM Customers WHERE CustomerID = @CustomerID";

            try
            {
                using (SqlConnection connec = new SqlConnection(strconnec))
                {
                    connec.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, connec))
                    {
                        cmd.Parameters.AddWithValue("@CustomerID", customerIDToDelete);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Xóa khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            HienThiDuLieuLenListView(txtTimKiem.Text);
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy khách hàng để xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi xóa khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (lvKH.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một khách hàng để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ListViewItem selectedItem = lvKH.SelectedItems[0];

            txtMaKH.Text = selectedItem.SubItems[0].Text;
            txtTenKH.Text = selectedItem.SubItems[1].Text;
            txtSoDT.Text = selectedItem.SubItems[2].Text;
            txtDiaChi.Text = selectedItem.SubItems[3].Text;
            txtEmail.Text = selectedItem.SubItems[4].Text;

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
                MessageBox.Show("Vui lòng không để trống Tên và Địa chỉ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string sql = "UPDATE Customers SET Name = @Name, Phone = @Phone, Address = @Address, Email = @Email WHERE CustomerID = @CustomerID";

            try
            {
                using (SqlConnection connec = new SqlConnection(strconnec))
                {
                    connec.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, connec))
                    {
                        cmd.Parameters.AddWithValue("@Name", txtTenKH.Text.Trim());
                        cmd.Parameters.AddWithValue("@Phone", txtSoDT.Text.Trim());
                        cmd.Parameters.AddWithValue("@Address", txtDiaChi.Text.Trim());
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@CustomerID", txtMaKH.Text);

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Cập nhật thông tin khách hàng thành công!", "Thông báo");

                        HienThiDuLieuLenListView(txtTimKiem.Text);

                        QuayVeCheDoThem();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi cập nhật: " + ex.Message, "Lỗi");
            }
        }
        private void QuayVeCheDoThem()
        {
            txtMaKH.Clear();
            txtTenKH.Clear();
            txtSoDT.Clear();
            txtDiaChi.Clear();
            txtEmail.Clear();

            txtMaKH.ReadOnly = false;

            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;

            btnLuu.Visible = false;
            btnHuy.Visible = false;

            txtMaKH.Focus();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            QuayVeCheDoThem();
        }

        private void lvKH_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = txtTimKiem.Text;

            // Gọi lại hàm hiển thị dữ liệu với từ khóa tìm kiếm
            HienThiDuLieuLenListView(searchTerm);
        }
    }
}