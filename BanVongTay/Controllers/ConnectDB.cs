using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BanVongTay.Controllers
{
    internal class ConnectDB
    {
        private readonly string connectionString = "Server=TB7;Database=LaeliaDB;Trusted_Connection=True;";
        private SqlConnection connection;

        public ConnectDB()
        {
            connection = new SqlConnection(connectionString);
        }

        public void OpenConnection()
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();
        }

        public void CloseConnection()
        {
            if (connection.State == ConnectionState.Open)
                connection.Close();
        }


        public DataTable ExecuteQuery(string query)
        {
            DataTable dt = new DataTable();
            try
            {
                OpenConnection();
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            finally
            {
                CloseConnection();
            }
            return dt;
        }

        public int ExecuteNonQuery(string query)
        {
            int result = 0;
            try
            {
                OpenConnection();
                SqlCommand cmd = new SqlCommand(query, connection);
                result = cmd.ExecuteNonQuery();
            }
            finally
            {
                CloseConnection();
            }
            return result;
        }

        public int ExecuteNonQuery(string query, Dictionary<string, object> parameters)
        {
            int result = 0;
            try
            {
                OpenConnection();
                SqlCommand cmd = new SqlCommand(query, connection);
                foreach (var param in parameters)
                {
                    cmd.Parameters.AddWithValue(param.Key, param.Value);
                }
                result = cmd.ExecuteNonQuery();
            }
            finally
            {
                CloseConnection();
            }
            return result;
        }
    }
}
