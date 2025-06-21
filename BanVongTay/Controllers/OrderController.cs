using BanVongTay.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BanVongTay.Controllers
{
    public class OrderController
    {
        private ConnectDB db;

        public OrderController()
        {
            db = new ConnectDB();
        }

        public List<Order> GetAllOrders()
        {
            List<Order> list = new List<Order>();
            try
            {
                string query = @"
    SELECT o.OrderID, o.CustomerID, o.UserID, o.OrderDate, o.TotalAmount,
           (c.FirstName + ' ' + c.LastName) AS CustomerName,
           (u.FirstName + ' ' + u.LastName) AS UserName
    FROM Orders o
    JOIN Customers c ON o.CustomerID = c.CustomerID
    JOIN Users u ON o.UserID = u.UserID";

                DataTable dt = db.ExecuteQuery(query);
                if (dt.Rows.Count == 0)
                {
                    Console.WriteLine("Không có dữ liệu trong Orders hoặc bảng liên quan.");
                }

                foreach (DataRow row in dt.Rows)
                {
                    Order o = new Order
                    {
                        OrderID = Convert.ToInt32(row["OrderID"]),
                        CustomerID = Convert.ToInt32(row["CustomerID"]),
                        UserID = Convert.ToInt32(row["UserID"]),
                        OrderDate = Convert.ToDateTime(row["OrderDate"]),
                        TotalAmount = Convert.ToDecimal(row["TotalAmount"]),
                        CustomerName = row["CustomerName"].ToString(),
                        UserName = row["UserName"].ToString()
                    };
                    list.Add(o);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lấy danh sách hóa đơn: {ex.Message}");
                throw;
            }
            return list;
        }

        public Order GetOrderById(int orderId)
        {
            string query = "SELECT * FROM Orders WHERE OrderID = @id";
            var parameters = new Dictionary<string, object>
            {
                { "@id", orderId }
            };

            DataTable dt = db.ExecuteQuery(query, parameters);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                return new Order
                {
                    OrderID = Convert.ToInt32(row["OrderID"]),
                    CustomerID = Convert.ToInt32(row["CustomerID"]),
                    UserID = Convert.ToInt32(row["UserID"]),
                    OrderDate = Convert.ToDateTime(row["OrderDate"]),
                    TotalAmount = Convert.ToDecimal(row["TotalAmount"])
                };
            }

            return null;
        }

        public int AddOrder(Order order)
        {
            string query = "INSERT INTO Orders (CustomerID, UserID, OrderDate, TotalAmount) " +
                   "VALUES (@customer, @user, @date, @total); SELECT SCOPE_IDENTITY();";

            var parameters = new Dictionary<string, object>
    {
        { "@customer", order.CustomerID },
        { "@user", order.UserID },
        { "@date", order.OrderDate },
        { "@total", order.TotalAmount }
    };

            object result = db.ExecuteScalar(query, parameters);
            return result != null ? Convert.ToInt32(result) : -1;
        }

        public bool UpdateTotalAmount(int orderId, decimal totalAmount)
        {
            string query = "UPDATE Orders SET TotalAmount = @total WHERE OrderID = @id";

            var parameters = new Dictionary<string, object>
            {
                { "@id", orderId },
                { "@total", totalAmount }
            };

            return db.ExecuteNonQuery(query, parameters) > 0;
        }
    }
}
