using BanVongTay.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace BanVongTay.Controllers
{
    public class OrderController
    {
        private ConnectDB db;

        public OrderController()
        {
            db = new ConnectDB();
        }

        public string GenerateNewOrderID()
        {
            string prefix = "HD";
            int maxNumber = 0;

            string query = @"
                SELECT MAX(CAST(SUBSTRING(OrderID, 3, LEN(OrderID) - 2) AS INT))
                FROM Orders
                WHERE OrderID LIKE 'HD%'";

            object result = db.ExecuteScalar(query);

            if (result != null && result != DBNull.Value)
            {
                maxNumber = Convert.ToInt32(result);
            }

            maxNumber++;
            return prefix + maxNumber.ToString("D3");
        }

        public List<Order> GetAllOrders()
        {
            List<Order> list = new List<Order>();
            try
            {
                string query = @"
    SELECT o.OrderID, o.CustomerID, o.UserID, o.OrderDate, o.TotalAmount,
           c.Name AS CustomerName,
           (u.FirstName + ' ' + u.LastName) AS UserName
    FROM Orders o
    JOIN Customers c ON o.CustomerID = c.CustomerID
    JOIN Users u ON o.UserID = u.UserID";

                DataTable dt = db.ExecuteQuery(query);

                foreach (DataRow row in dt.Rows)
                {
                    Order o = new Order
                    {
                        OrderID = row["OrderID"].ToString(),
                        CustomerID = row["CustomerID"].ToString(),
                        UserID = row["UserID"].ToString(),
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
                throw new Exception($"Lỗi khi lấy danh sách hóa đơn: {ex.Message}");
            }

            return list;
        }

        public Order GetOrderById(string orderId)
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
                    OrderID = row["OrderID"].ToString(),
                    CustomerID = row["CustomerID"].ToString(),
                    UserID = row["UserID"].ToString(),
                    OrderDate = Convert.ToDateTime(row["OrderDate"]),
                    TotalAmount = Convert.ToDecimal(row["TotalAmount"])
                };
            }

            return null;
        }

        public string AddOrder(Order order)
        {
            string newOrderID = GenerateNewOrderID();

            string query = "INSERT INTO Orders (OrderID, CustomerID, UserID, OrderDate, TotalAmount) " +
                           "VALUES (@id, @customer, @user, @date, @total)";

            var parameters = new Dictionary<string, object>
            {
                { "@id", newOrderID },
                { "@customer", order.CustomerID },
                { "@user", order.UserID },
                { "@date", order.OrderDate },
                { "@total", order.TotalAmount }
            };

            bool success = db.ExecuteNonQuery(query, parameters) > 0;
            return success ? newOrderID : null;
        }

        public bool UpdateTotalAmount(string orderId, decimal totalAmount)
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
