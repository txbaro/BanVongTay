using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace BanVongTay
{
    public partial class FThongKe : Form
    {
        private readonly string strconnec = @"Data Source=(local)\SQLEXPRESS;Initial Catalog=BraceletShop;Integrated Security=True";

        public FThongKe()
        {
            InitializeComponent();
        }

        private void FThongKe_Load(object sender, EventArgs e)
        {
            SetupFormAppearance();
            SetupListView();
            LoadNamComboBox();
        }

        #region Cài đặt giao diện

        private void SetupFormAppearance()
        {
            this.Text = "Thống Kê Doanh Thu Bán Hàng";
            this.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None;
            this.MaximizeBox = false;
        }

        private void SetupListView()
        {
            lvDoanhThu.View = View.Details;
            lvDoanhThu.GridLines = true;
            lvDoanhThu.FullRowSelect = true;
            lvDoanhThu.Font = new Font("Segoe UI", 11F, FontStyle.Regular);

            lvDoanhThu.OwnerDraw = true;

            lvDoanhThu.Columns.Clear();
            lvDoanhThu.Columns.Add("Tháng", 150, HorizontalAlignment.Left);
            lvDoanhThu.Columns.Add("Tổng Doanh Thu (VNĐ)", -2, HorizontalAlignment.Left);
        }

        #endregion

        #region Xử lý dữ liệu

        private void LoadNamComboBox()
        {
            string query = "SELECT DISTINCT YEAR(NgayBan) AS Nam FROM HoaDon_ThongKe ORDER BY Nam DESC;";
            using (SqlConnection connection = new SqlConnection(strconnec))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        cboNam.Items.Clear();
                        while (reader.Read())
                        {
                            cboNam.Items.Add(reader["Nam"].ToString());
                        }
                        if (cboNam.Items.Count > 0)
                        {
                            cboNam.SelectedIndex = 0;
                            btnThongKe_Click(null, null);
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy dữ liệu thống kê.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnThongKe.Enabled = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi tải dữ liệu năm:\n" + ex.Message, "Lỗi Cơ Sở Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            if (cboNam.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn một năm để thực hiện thống kê.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int selectedYear = int.Parse(cboNam.SelectedItem.ToString());
            LoadAndDisplayRevenueData(selectedYear);
        }

        private void LoadAndDisplayRevenueData(int year)
        {
            DataTable revenueData = new DataTable();
            string query = @"
                SELECT 
                    MONTH(NgayBan) AS Thang, 
                    SUM(TongTien) AS DoanhThu
                FROM HoaDon_ThongKe
                WHERE YEAR(NgayBan) = @Nam
                GROUP BY MONTH(NgayBan)
                ORDER BY Thang;";
            using (SqlConnection connection = new SqlConnection(strconnec))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nam", year);
                    try
                    {
                        connection.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.Fill(revenueData);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi tải dữ liệu doanh thu:\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            DisplayDataOnListView(revenueData);
        }

        private void DisplayDataOnListView(DataTable data)
        {
            lvDoanhThu.Items.Clear();
            foreach (DataRow row in data.Rows)
            {
                string thang = $"Tháng {row["Thang"]}";
                ListViewItem item = new ListViewItem(thang);
                decimal doanhThu = Convert.ToDecimal(row["DoanhThu"]);
                item.SubItems.Add(doanhThu.ToString("N0"));
                lvDoanhThu.Items.Add(item);
            }
        }

        #endregion

        #region Xử lý vẽ lại ListView để căn giữa

        // SỬA ĐỔI: Thêm sự kiện DrawItem để xử lý cột đầu tiên
        // Hàm này được gọi để vẽ từng dòng (bao gồm cột đầu tiên)
        private void LvDoanhThu_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            // Yêu cầu hệ thống tự vẽ dòng này theo kiểu mặc định trước.
            // Thao tác này sẽ vẽ nền và nội dung căn trái cho cả dòng.
            e.DrawDefault = true;
        }

        // SỬA ĐỔI: Sửa lại DrawSubItem để xử lý tất cả các cột
        private void LvDoanhThu_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            // Định dạng căn lề: Căn giữa theo chiều ngang và chiều dọc
            TextFormatFlags flags = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter;

            // Vẽ lại nội dung của ô với định dạng đã chọn
            // Ghi đè lên nội dung được vẽ mặc định bởi DrawItem
            e.DrawText(flags);
        }

        private void LvDoanhThu_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.DrawDefault = true;
        }

        #endregion
    }
}
