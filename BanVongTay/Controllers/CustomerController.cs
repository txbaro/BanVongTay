using System;
using BanVongTay.Controllers;

namespace BanVongTay.Controllers
{
    internal class CustomerController
    {
        private readonly ConnectDB db = new ConnectDB();

        public string GenerateNewCustomerID()
        {
            string prefix = "KH";
            int maxNumber = 0;

            string query = "SELECT MAX(CustomerID) FROM Customers WHERE CustomerID LIKE 'KH%'";

            object result = db.ExecuteScalar(query);

            if (result != null && result != DBNull.Value)
            {
                string currentMax = result.ToString();
                if (currentMax.Length > prefix.Length)
                {
                    string numberPart = currentMax.Substring(prefix.Length);
                    if (int.TryParse(numberPart, out int number))
                    {
                        maxNumber = number;
                    }
                }
            }

            maxNumber++;
            return prefix + maxNumber.ToString("D3");
        }
    }
}
