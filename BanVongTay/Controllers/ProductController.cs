using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BanVongTay.Models;

namespace BanVongTay.Controllers
{
    internal class ProductController
    {
        private ConnectDB db;

        public ProductController()
        {
            db = new ConnectDB();
        }

        public DataTable GetAllProducts()
        {
            string query = @"SELECT p.ProductID, p.ProductName, p.CategoryName, p.Price, 
                            p.ImageURL, ISNULL(s.Quantity, 0) AS Quantity
                            FROM Products p
                            LEFT JOIN Storage s ON p.ProductID = s.ProductID";
            return db.ExecuteQuery(query);
        }



        public bool AddProduct(Products p)
        {
            try
            {
                string query1 = "INSERT INTO Products (ProductName, CategoryName, Price, ImageURL) " +
                                "VALUES (@name, @categoryName, @price, @image); SELECT SCOPE_IDENTITY();";

                var parameters1 = new Dictionary<string, object>
        {
            {"@name", p.ProductName },
            {"@categoryName", p.CategoryName },
            {"@price", p.Price },
            {"@image", p.ImageURL ?? (object)DBNull.Value }
        };

                object result = db.ExecuteScalar(query1, parameters1);
                if (result != null && int.TryParse(result.ToString(), out int newProductId))
                {
                    string query2 = "INSERT INTO Storage (ProductID, Quantity) VALUES (@id, @quantity)";
                    var parameters2 = new Dictionary<string, object>
            {
                {"@id", newProductId },
                {"@quantity", p.Quantity }
            };

                    return db.ExecuteNonQuery(query2, parameters2) > 0;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi thêm sản phẩm: {ex.Message}");
            }
        }

        public bool UpdateProduct(Products p)
        {
            string query1 = "UPDATE Products SET ProductName = @name, CategoryName = @categoryName, " +
                            "Price = @price, ImageURL = @image WHERE ProductID = @id";

            var parameters1 = new Dictionary<string, object>
    {
        {"@id", p.ProductID },
        {"@name", p.ProductName },
        {"@categoryName", p.CategoryName },
        {"@price", p.Price },
        {"@image", p.ImageURL ?? (object)DBNull.Value }
    };

            string checkQuery = "SELECT COUNT(*) FROM Storage WHERE ProductID = @id";
            var checkParams = new Dictionary<string, object> { { "@id", p.ProductID } };
            object exists = db.ExecuteScalar(checkQuery, checkParams);

            int result2 = 0;

            if (Convert.ToInt32(exists) > 0)
            {
                string query2 = "UPDATE Storage SET Quantity = @quantity WHERE ProductID = @id";
                var parameters2 = new Dictionary<string, object>
        {
            {"@id", p.ProductID },
            {"@quantity", p.Quantity }
        };
                result2 = db.ExecuteNonQuery(query2, parameters2);
            }
            else
            {
                string insertQuery = "INSERT INTO Storage (ProductID, Quantity) VALUES (@id, @quantity)";
                var insertParams = new Dictionary<string, object>
        {
            {"@id", p.ProductID },
            {"@quantity", p.Quantity }
        };
                result2 = db.ExecuteNonQuery(insertQuery, insertParams);
            }

            return db.ExecuteNonQuery(query1, parameters1) > 0 && result2 > 0;
        }

        public bool DeleteProduct(int productId)
        {
            string query = "DELETE FROM Products WHERE ProductID = @id";
            var parameters = new Dictionary<string, object>
            {
                {"@id", productId }
            };

            return db.ExecuteNonQuery(query, parameters) > 0;
        }
    }
}
