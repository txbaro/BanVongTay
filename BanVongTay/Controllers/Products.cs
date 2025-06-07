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

        // Lấy toàn bộ sản phẩm
        public DataTable GetAllProducts()
        {
            string query = "SELECT * FROM Products";
            return db.ExecuteQuery(query);
        }

        // Thêm sản phẩm mới
        public bool AddProduct(Products p)
        {
            string query = "INSERT INTO Products (ProductName, ProductTypeID, UnitPrice, Quantity, ProductImage) " +
                           "VALUES (@name, @typeId, @price, @quantity, @image)";
            var parameters = new Dictionary<string, object>
    {
        {"@name", p.ProductName },
        {"@typeId", p.ProductTypeID },
        {"@price", p.UnitPrice },
        {"@quantity", p.Quantity },
        {"@image", p.ProductImage ?? (object)DBNull.Value }
    };

            return db.ExecuteNonQuery(query, parameters) > 0;
        }

        // Sửa sản phẩm
        public bool UpdateProduct(Products p)
        {
            string query = "UPDATE Products SET ProductName = @name, ProductTypeID = @typeId, " +
                           "UnitPrice = @price, Description = @desc WHERE ProductID = @id";
            var parameters = new Dictionary<string, object>
            {
                {"@id", p.ProductID },
                {"@name", p.ProductName },
                {"@typeId", p.ProductTypeID },
                {"@price", p.UnitPrice },
                {"@quantity", p.Quantity }
            };

            return db.ExecuteNonQuery(query, parameters) > 0;
        }

        // Xóa sản phẩm
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
