using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BanVongTay.Controllers
{
    public class ConnectDB
    {
        //đổi cái (localdb)\\MSSQLLocalDB thành cái server name trong mssql trên máy m
        private readonly string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=BraceletShop;Trusted_Connection=True;";
        private SqlConnection connection;

        public ConnectDB()
        {
            connection = new SqlConnection(connectionString);
        }

        public void OpenConnection()
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
            }
            catch (SqlException ex)
            {
                throw new Exception($"Lỗi kết nối cơ sở dữ liệu: {ex.Message}");
            }
        }

        public void CloseConnection()
        {
            if (connection.State == ConnectionState.Open)
                connection.Close();
        }

        public DataTable ExecuteQuery(string query, Dictionary<string, object> parameters)
        {
            DataTable dt = new DataTable();
            try
            {
                OpenConnection();
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    foreach (var param in parameters)
                    {
                        cmd.Parameters.AddWithValue(param.Key, param.Value ?? (object)DBNull.Value);
                    }
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi thực thi truy vấn: {ex.Message}");
            }
            finally
            {
                CloseConnection();
            }
            return dt;
        }

        public DataTable ExecuteQuery(string query)
        {
            return ExecuteQuery(query, new Dictionary<string, object>());
        }

        public int ExecuteNonQuery(string query, Dictionary<string, object> parameters)
        {
            int result = 0;
            try
            {
                OpenConnection();
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    foreach (var param in parameters)
                    {
                        cmd.Parameters.AddWithValue(param.Key, param.Value ?? (object)DBNull.Value);
                    }
                    result = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi thực thi NonQuery: {ex.Message}");
            }
            finally
            {
                CloseConnection();
            }
            return result;
        }

        public object ExecuteScalar(string query, Dictionary<string, object> parameters)
        {
            object result = null;
            try
            {
                OpenConnection();
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    foreach (var param in parameters)
                    {
                        cmd.Parameters.AddWithValue(param.Key, param.Value ?? (object)DBNull.Value);
                    }
                    result = cmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi thực thi Scalar: {ex.Message}");
            }
            finally
            {
                CloseConnection();
            }
            return result;
        }

        public object ExecuteScalar(string query)
        {
            return ExecuteScalar(query, new Dictionary<string, object>());
        }
    }
}
