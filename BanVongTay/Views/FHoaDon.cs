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
        public FHoaDon()
        {
            InitializeComponent();
            dtgvHoaDonPart1.RowHeadersVisible = false;
            dtgvHoaDonPart2.RowHeadersVisible = false;
        }

        private void loadHoaDon()
        {
            OrderController orderController = new OrderController();
            List<Order> orders = orderController.GetAllOrders();

            dtgvHoaDonPart1.DataSource = orders;
            dtgvHoaDonPart2.DataSource = orders;

            dtgvHoaDonPart1.Font = new Font("Segoe UI", 10F);
            dtgvHoaDonPart2.Font = new Font("Segoe UI", 10F);
            dtgvHoaDonPart1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvHoaDonPart2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            setColumnHeaders(dtgvHoaDonPart1);
            setColumnHeaders(dtgvHoaDonPart2);

            dtgvHoaDonPart1.Columns["OrderID"].Width = 50;
            dtgvHoaDonPart1.Columns["UserName"].Width = 60;
            dtgvHoaDonPart1.Columns["OrderDate"].Width = 80;

            dtgvHoaDonPart2.Columns["CustomerID"].Width = 60;
            dtgvHoaDonPart2.Columns["CustomerName"].Width = 70;
            dtgvHoaDonPart2.Columns["TotalAmount"].Width = 70;

            // Ẩn cột ở bảng 1: chỉ để lại Mã HD, Tên NV, Ngày lập
            dtgvHoaDonPart1.Columns["CustomerID"].Visible = false;
            dtgvHoaDonPart1.Columns["CustomerName"].Visible = false;
            dtgvHoaDonPart1.Columns["TotalAmount"].Visible = false;

            // Ẩn cột ở bảng 2: chỉ để lại Mã KH, Tên KH, Thành tiền
            dtgvHoaDonPart2.Columns["OrderID"].Visible = false;
            dtgvHoaDonPart2.Columns["UserName"].Visible = false;
            dtgvHoaDonPart2.Columns["OrderDate"].Visible = false;

            // Ẩn thêm các cột phụ
            dtgvHoaDonPart1.Columns["UserID"].Visible = false;
            dtgvHoaDonPart2.Columns["UserID"].Visible = false;
        }

        private void loadChiTietHoaDon(string orderId)
        {
            OrderDetailsController controller = new OrderDetailsController();
            var details = controller.GetOrderDetailsByOrderID(orderId);

            listViewChiTietHD.Items.Clear();

            foreach (var d in details)
            {
                var item = new ListViewItem(d.ProductID);
                item.SubItems.Add(d.ProductName);
                item.SubItems.Add(d.UnitPrice.ToString("N0"));
                item.SubItems.Add(d.Quantity.ToString());
                item.SubItems.Add((d.Quantity * d.UnitPrice).ToString("N0"));
                listViewChiTietHD.Items.Add(item);
            }
        }

        private void setColumnHeaders(DataGridView dgv)
        {
            dgv.Columns["OrderID"].HeaderText = "Mã HD";
            dgv.Columns["CustomerName"].HeaderText = "Tên KH";
            dgv.Columns["CustomerID"].HeaderText = "Mã KH";
            dgv.Columns["UserName"].HeaderText = "Tên NV";
            dgv.Columns["OrderDate"].HeaderText = "Ngày lập";
            dgv.Columns["TotalAmount"].HeaderText = "Thành tiền";

            dgv.Columns["OrderDate"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgv.Columns["TotalAmount"].DefaultCellStyle.Format = "N0";
        }


        private void FHoaDon_Load(object sender, EventArgs e)
        {
            loadHoaDon();
            dtgvHoaDonPart1.CellClick += dgvHoaDon_CellClick;
            dtgvHoaDonPart2.CellClick += dgvHoaDon_CellClick;

            listViewChiTietHD.Clear();

            listViewChiTietHD.View = View.Details;
            listViewChiTietHD.FullRowSelect = true;
            listViewChiTietHD.GridLines = true;

            listViewChiTietHD.Columns.Add("Mã SP", 85);
            listViewChiTietHD.Columns.Add("Tên SP", 130);
            listViewChiTietHD.Columns.Add("Đơn giá", 105);
            listViewChiTietHD.Columns.Add("Số lượng", 60);
            listViewChiTietHD.Columns.Add("Thành tiền", 110);
        }

        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var dgv = sender as DataGridView;
                var row = dgv.Rows[e.RowIndex];

                string orderId = row.Cells["OrderID"].Value.ToString();
                string customerId = row.Cells["CustomerID"].Value.ToString();
                string customerName = row.Cells["CustomerName"].Value.ToString();
                string userName = row.Cells["UserName"].Value.ToString();
                DateTime orderDate = Convert.ToDateTime(row.Cells["OrderDate"].Value);
                decimal total = Convert.ToDecimal(row.Cells["TotalAmount"].Value);

                txtMaHD.Text = orderId;
                txtMaKH.Text = customerId;
                txtTenKH.Text = customerName;
                txtTenNV.Text = userName;
                dtpNgayLap.Value = orderDate;
                txtThanhTien.Text = total.ToString("N0");

                loadChiTietHoaDon(orderId);
            }
        }


        private void dtgvHoaDonPart1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(keyword))
            {
                loadHoaDon();
                return;
            }

            OrderController orderController = new OrderController();
            List<Order> allOrders = orderController.GetAllOrders();

            var filtered = allOrders
                .Where(o =>
                    o.OrderID.ToLower().Contains(keyword) ||
                    o.CustomerName.ToLower().Contains(keyword) ||
                    o.UserName.ToLower().Contains(keyword)) // Thêm dòng này
                .ToList();

            dtgvHoaDonPart1.DataSource = filtered;
            dtgvHoaDonPart2.DataSource = filtered;

            setColumnHeaders(dtgvHoaDonPart1);
            setColumnHeaders(dtgvHoaDonPart2);

            // Cấu hình lại các cột giống loadHoaDon()
            dtgvHoaDonPart1.Columns["OrderID"].Width = 50;
            dtgvHoaDonPart1.Columns["UserName"].Width = 60;
            dtgvHoaDonPart1.Columns["OrderDate"].Width = 80;

            dtgvHoaDonPart2.Columns["CustomerID"].Width = 60;
            dtgvHoaDonPart2.Columns["CustomerName"].Width = 70;
            dtgvHoaDonPart2.Columns["TotalAmount"].Width = 70;

            dtgvHoaDonPart1.Columns["CustomerID"].Visible = false;
            dtgvHoaDonPart1.Columns["CustomerName"].Visible = false;
            dtgvHoaDonPart1.Columns["TotalAmount"].Visible = false;

            dtgvHoaDonPart2.Columns["OrderID"].Visible = false;
            dtgvHoaDonPart2.Columns["UserName"].Visible = false;
            dtgvHoaDonPart2.Columns["OrderDate"].Visible = false;

            dtgvHoaDonPart1.Columns["UserID"].Visible = false;
            dtgvHoaDonPart2.Columns["UserID"].Visible = false;
        }

        private void btnXuatHoaDon_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("                         BraceletStore");
            sb.AppendLine("                    *** HÓA ĐƠN BÁN HÀNG ***");
            sb.AppendLine();
            sb.AppendLine($"Mã HĐ      : {txtMaHD.Text}");
            sb.AppendLine($"Khách hàng : {txtTenKH.Text}");
            sb.AppendLine($"Nhân viên  : {txtTenNV.Text}");
            sb.AppendLine($"Ngày lập   : {dtpNgayLap.Value:dd/MM/yyyy}");
            sb.AppendLine(new string('-', 63));
            sb.AppendLine("Mã SP  | Tên sản phẩm        | Đơn giá | SL | Thành tiền");
            sb.AppendLine(new string('-', 63));

            foreach (ListViewItem item in listViewChiTietHD.Items)
            {
                string maSP = item.SubItems[0].Text;
                string tenSP = item.SubItems[1].Text;
                string donGia = item.SubItems[2].Text;
                string soLuong = item.SubItems[3].Text;
                string thanhTien = item.SubItems[4].Text;

                string tenSPShort = tenSP.Length > 18 ? tenSP.Substring(0, 17) + "…" : tenSP;

                sb.AppendLine(string.Format("{0,-6} | {1,-20} | {2,8}đ | {3,2} | {4,11}đ",
                    maSP,
                    tenSPShort,
                    donGia,
                    soLuong,
                    thanhTien));
            }

            sb.AppendLine(new string('-', 63));
            sb.AppendLine($"TỔNG TIỀN: {txtThanhTien.Text} đ");
            sb.AppendLine(new string('=', 63));
            sb.AppendLine("                     Cảm ơn quý khách và hẹn gặp lại!");

            var frm = new FXuatHoaDon(sb.ToString());
            frm.ShowDialog();
        }

    }
}
