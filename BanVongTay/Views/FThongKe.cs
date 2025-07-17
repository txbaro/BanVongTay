using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using BanVongTay.Controllers;

namespace BanVongTay
{
    public partial class FThongKe : Form
    {
        private readonly ConnectDB db = new ConnectDB();

        public FThongKe()
        {
            InitializeComponent();
            InitUI();
        }

        private void FThongKe_Load(object sender, EventArgs e)
        {
            LoadYearsToComboBox();
            if (cboNam.Items.Count > 0 && int.TryParse(cboNam.SelectedItem.ToString(), out int selectedYear))
            {
                LoadRevenueData(selectedYear);
            }
            cboNam.SelectedIndexChanged += cboNam_SelectedIndexChanged;
        }

        private void InitUI()
        {
            Text = "Thống Kê Doanh Thu Bán Hàng";
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            Font = new Font("Segoe UI", 10F);

            InitChart();
        }

        private void InitChart()
        {
            chartDoanhThu.Series.Clear();
            chartDoanhThu.ChartAreas.Clear();

            ChartArea area = new ChartArea("ChartArea")
            {
                AxisX = { Title = "Tháng", Interval = 1 },
                AxisY = { Title = "Doanh thu (VNĐ)" }
            };
            area.AxisY.LabelStyle.Format = "#,##0";
            chartDoanhThu.ChartAreas.Add(area);

            chartDoanhThu.Titles.Clear();
            chartDoanhThu.Titles.Add("Biểu đồ doanh thu theo tháng");
        }

        private void LoadYearOptions()
        {
            const string query = "SELECT DISTINCT YEAR(OrderDate) AS Nam FROM Orders ORDER BY Nam DESC";
            try
            {
                DataTable dt = db.ExecuteQuery(query);
                cboNam.Items.Clear();

                foreach (DataRow row in dt.Rows)
                    cboNam.Items.Add(row["Nam"].ToString());

                if (cboNam.Items.Count > 0)
                    cboNam.SelectedIndex = 0;
                else
                    MessageBox.Show("Không có dữ liệu thống kê!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                ShowError("Lỗi khi tải danh sách năm", ex);
            }
        }

        private void LoadRevenueData(int year, int? month = null)
        {
            string query = @"
        SELECT 
            MONTH(OrderDate) AS Thang, 
            SUM(TotalAmount) AS DoanhThu
        FROM Orders
        WHERE YEAR(OrderDate) = @Nam";

            var parameters = new Dictionary<string, object> { { "@Nam", year } };

            if (month.HasValue)
            {
                query += " AND MONTH(OrderDate) = @Thang";
                parameters.Add("@Thang", month.Value);
            }

            query += " GROUP BY MONTH(OrderDate) ORDER BY Thang";

            try
            {
                DataTable dt = db.ExecuteQuery(query, parameters);

                if (dt.Rows.Count == 0)
                {
                    chartDoanhThu.Series.Clear();
                    lblTongDoanhThu.Text = "Tổng doanh thu: 0 VNĐ";
                    MessageBox.Show("Không có doanh thu trong khoảng đã chọn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    RenderChart(dt);

                    decimal total = 0;
                    foreach (DataRow row in dt.Rows)
                    {
                        total += Convert.ToDecimal(row["DoanhThu"]);
                    }
                    lblTongDoanhThu.Text = "Tổng doanh thu: " + total.ToString("N0") + " VNĐ";
                }
            }
            catch (Exception ex)
            {
                ShowError("Lỗi khi thống kê doanh thu", ex);
            }
        }

        private void RenderChart(DataTable data)
        {
            chartDoanhThu.Series.Clear();

            Series series = new Series("DoanhThu")
            {
                ChartType = SeriesChartType.Column,
                IsValueShownAsLabel = true,
                Color = Color.SteelBlue
            };

            foreach (DataRow row in data.Rows)
            {
                int month = Convert.ToInt32(row["Thang"]);
                decimal revenue = Convert.ToDecimal(row["DoanhThu"]);
                series.Points.AddXY($"Tháng {month}", revenue);
            }

            chartDoanhThu.Series.Add(series);
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            if (cboNam.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn năm để thống kê!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (int.TryParse(cboNam.SelectedItem.ToString(), out int selectedYear))
            {
                LoadRevenueData(selectedYear);
            }
        }

        private void cboNam_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (int.TryParse(cboNam.SelectedItem?.ToString(), out int selectedYear))
            {
                LoadRevenueData(selectedYear);
            }
        }

        private void LoadYearsToComboBox()
        {
            string query = "SELECT DISTINCT YEAR(OrderDate) AS Nam FROM Orders ORDER BY Nam DESC";
            try
            {
                DataTable dt = db.ExecuteQuery(query);
                cboNam.Items.Clear();

                foreach (DataRow row in dt.Rows)
                    cboNam.Items.Add(row["Nam"].ToString());

                if (cboNam.Items.Count > 0)
                {
                    cboNam.SelectedIndexChanged += cboNam_SelectedIndexChanged; 
                    cboNam.SelectedIndex = 0; 
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu thống kê!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                ShowError("Lỗi khi tải danh sách năm", ex);
            }
        }

        private void ShowError(string title, Exception ex)
        {
            MessageBox.Show($"{title}:\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
