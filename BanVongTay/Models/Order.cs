using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanVongTay.Models
{
    public class Order
    {
        public string OrderID { get; set; }
        public string CustomerID { get; set; }
        public string CustomerName { get; set; }  // Optional: For displaying
        public string UserID { get; set; }
        public string UserName { get; set; }      // Optional: For displaying
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }

        public Order() { }

        public Order(string orderId, string customerId, string userId, DateTime orderDate, decimal totalAmount)
        {
            OrderID = orderId;
            CustomerID = customerId;
            UserID = userId;
            OrderDate = orderDate;
            TotalAmount = totalAmount;

        }
    }
}
