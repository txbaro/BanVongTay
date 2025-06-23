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
    public partial class FHoaDon : Form
    {
        private OrderController orderController = new OrderController();
        private OrderDetailsController detailsController = new OrderDetailsController();

        public FHoaDon()
        {
            InitializeComponent();
            this.dtgvHoaDon.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvHoaDon_CellContentClick);
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
        }

        private void FHoaDon_Load(object sender, EventArgs e)
        {
            try
            {
                loadDanhSachHoaDon();
                cbTimKiem.Items.AddRange(new string[] { "Mã HD", "Tên KH", "Tên NV" });
                cbTimKiem.SelectedIndex = 0;
                dtgvHoaDon.ReadOnly = true;
                dtgvChiTietHoaDon.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}");
            }
        }

        public void loadDanhSachHoaDon()
        {
            try
            {
                List<Order> orders = orderController.GetAllOrders() ?? new List<Order>();
                DataTable dt = new DataTable();
                dt.Columns.Add("MaHD");
                dt.Columns.Add("TenKH");
                dt.Columns.Add("TenNV");
                dt.Columns.Add("TongTien");
                dt.Columns.Add("NgayTao");

                foreach (var o in orders)
                {
                    dt.Rows.Add(o.OrderID, o.CustomerName, o.UserName, o.TotalAmount, o.OrderDate);
                }
                dtgvHoaDon.AutoGenerateColumns = true;
                dtgvHoaDon.DataSource = dt;

                dtgvHoaDon.Columns["MaHD"].Width = 100;
                dtgvHoaDon.Columns["TenKH"].Width = 200;
                dtgvHoaDon.Columns["TenNV"].Width = 200;
                dtgvHoaDon.Columns["TongTien"].Width = 200;
                dtgvHoaDon.Columns["NgayTao"].Width = 300;

                dtgvHoaDon.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dtgvHoaDon.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                dtgvHoaDon.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            }
            catch (Exception ex)                
            {
                MessageBox.Show($"Lỗi khi tải danh sách hóa đơn: {ex.Message}\nStackTrace: {ex.StackTrace}");
            }
        }
            
        private void loadChiTietHoaDon(string maHD)
        {
            try
            {
                if (string.IsNullOrEmpty(maHD)) return;

                int orderId = Convert.ToInt32(maHD);
                List<OrderDetails> details = detailsController.GetOrderDetailsByOrderID(orderId) ?? new List<OrderDetails>();

                DataTable dt = new DataTable();
                dt.Columns.Add("STT");
                dt.Columns.Add("ProductName");
                dt.Columns.Add("Quantity");
                dt.Columns.Add("UnitPrice");
                dt.Columns.Add("Thành tiền");

                int stt = 1;
                decimal tongTien = 0;

                foreach (var item in details)
                {
                    decimal thanhTien = item.Quantity * item.UnitPrice;
                    dt.Rows.Add(stt++, item.ProductName, item.Quantity, item.UnitPrice, thanhTien);
                    tongTien += thanhTien;
                }

                dtgvChiTietHoaDon.DataSource = dt;
                txtTongTien.Text = tongTien.ToString("N0");

                orderController.UpdateTotalAmount(orderId, tongTien);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải chi tiết hóa đơn: {ex.Message}");
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                string keyword = txtTimKiem.Text.ToLower();
                string col = cbTimKiem.SelectedItem.ToString();

                DataTable dt = (DataTable)dtgvHoaDon.DataSource;
                DataView dv = dt.DefaultView;

                if (col == "Mã HD")
                    dv.RowFilter = $"MaHD LIKE '%{keyword}%'";
                else if (col == "Tên KH")
                    dv.RowFilter = $"TenKH LIKE '%{keyword}%'";
                else if (col == "Tên NV")
                    dv.RowFilter = $"TenNV LIKE '%{keyword}%'";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm: {ex.Message}");
            }
        }

        private void dtgvHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    string maHD = dtgvHoaDon.Rows[e.RowIndex].Cells[0].Value?.ToString();
                    txtMaHD.Text = maHD;
                    txtTenKH.Text = dtgvHoaDon.Rows[e.RowIndex].Cells[1].Value?.ToString() ?? "";
                    txtTenNV.Text = dtgvHoaDon.Rows[e.RowIndex].Cells[2].Value?.ToString() ?? "";
                    txtTongTien.Text = dtgvHoaDon.Rows[e.RowIndex].Cells[3].Value?.ToString() ?? "0";
                    dtpNgayTao.Value = Convert.ToDateTime(dtgvHoaDon.Rows[e.RowIndex].Cells[4].Value ?? DateTime.Now);

                    tabControl1.SelectedTab = tabPage2;
                    loadChiTietHoaDon(maHD);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi chọn hóa đơn: {ex.Message}");
            }
        }

        private void btnThemHoaDon_Click(object sender, EventArgs e)
        {
            try
            {
                Order newOrder = new Order
                {
                    CustomerID = 1,
                    UserID = 1,  
                    OrderDate = DateTime.Now,
                    TotalAmount = 0
                };

                int newOrderId = orderController.AddOrder(newOrder);
                if (newOrderId > 0)
                {
                    MessageBox.Show("Tạo hóa đơn thành công!");
                    loadDanhSachHoaDon();
                    txtMaHD.Text = newOrderId.ToString();

                    tabControl1.SelectedTab = tabPage2;
                    loadChiTietHoaDon(newOrderId.ToString());
                }
                else
                {
                    MessageBox.Show("Tạo hóa đơn thất bại!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm hóa đơn: {ex.Message}");
            }
        }

        private void btnThemSP_Click(object sender, EventArgs e)
        {
        }

        private void dtgvHoaDon_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnLuuHoaDon_Click(object sender, EventArgs e)
        {
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage1)
            {
                loadDanhSachHoaDon();
            }
            else if (tabControl1.SelectedTab == tabPage2 && !string.IsNullOrEmpty(txtMaHD.Text))
            {
                loadChiTietHoaDon(txtMaHD.Text);
            }
        }
    }
}