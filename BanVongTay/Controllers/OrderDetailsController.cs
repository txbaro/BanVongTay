using BanVongTay.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace BanVongTay.Controllers
{
    internal class OrderDetailsController
    {
        private ConnectDB db;

        public OrderDetailsController()
        {
            db = new ConnectDB();
        }

        public List<OrderDetails> GetOrderDetailsByOrderID(string orderId)
        {
            List<OrderDetails> list = new List<OrderDetails>();

            string query = @"
        SELECT d.OrderDetailID, d.OrderID, d.ProductID, p.ProductName, 
               d.Quantity, d.UnitPrice
        FROM OrderDetails d
        JOIN Products p ON d.ProductID = p.ProductID
        WHERE d.OrderID = @orderId";

            var parameters = new Dictionary<string, object>
    {
        { "@orderId", orderId }
    };

            DataTable dt = db.ExecuteQuery(query, parameters);

            foreach (DataRow row in dt.Rows)
            {
                OrderDetails od = new OrderDetails
                {
                    OrderDetailID = row["OrderDetailID"].ToString(),
                    OrderID = row["OrderID"].ToString(),
                    ProductID = row["ProductID"].ToString(),
                    ProductName = row["ProductName"].ToString(),
                    Quantity = Convert.ToInt32(row["Quantity"]),
                    UnitPrice = Convert.ToDecimal(row["UnitPrice"])
                };

                list.Add(od);
            }

            return list;
        }

        public bool AddOrderDetail(OrderDetails detail)
        {
            string query = "INSERT INTO OrderDetails (OrderID, ProductID, Quantity, UnitPrice) " +
                           "VALUES (@orderId, @productId, @quantity, @price)";

            var parameters = new Dictionary<string, object>
            {
                { "@orderId", detail.OrderID },
                { "@productId", detail.ProductID },
                { "@quantity", detail.Quantity },
                { "@price", detail.UnitPrice }
            };

            return db.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool DeleteOrderDetail(string orderDetailId)
        {
            string query = "DELETE FROM OrderDetails WHERE OrderDetailID = @id";
            var parameters = new Dictionary<string, object>
            {
                { "@id", orderDetailId }
            };

            return db.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool DeleteAllDetailsByOrder(string orderId)
        {
            string query = "DELETE FROM OrderDetails WHERE OrderID = @orderId";
            var parameters = new Dictionary<string, object>
            {
                { "@orderId", orderId }
            };

            return db.ExecuteNonQuery(query, parameters) > 0;
        }

        public decimal CalculateTotalByOrder(string orderId)
        {
            string query = "SELECT SUM(Quantity * UnitPrice) FROM OrderDetails WHERE OrderID = @orderId";
            var parameters = new Dictionary<string, object>
            {
                { "@orderId", orderId }
            };

            object result = db.ExecuteScalar(query, parameters);
            return result != DBNull.Value ? Convert.ToDecimal(result) : 0m;
        }
    }
}
