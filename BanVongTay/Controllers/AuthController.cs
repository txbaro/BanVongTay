using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BanVongTay.Models;

namespace BanVongTay.Controllers
{
    public class AuthController
    {
        private ConnectDB db = new ConnectDB();

        public User Login(string username, string password)
        {
            string query = @"
                SELECT * FROM Users 
                WHERE Username = @username AND Password = @password";

            var parameters = new Dictionary<string, object>
            {
                { "@username", username },
                { "@password", password }
            };

            DataTable dt = db.ExecuteQuery(query, parameters);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                return new User
                {
                    UserID = row["UserID"].ToString(),
                    Username = row["Username"].ToString(),
                    FirstName = row["FirstName"].ToString(),
                    LastName = row["LastName"].ToString(),
                    Role = row["Role"].ToString()
                };
            }

            return null;
        }
    }
}