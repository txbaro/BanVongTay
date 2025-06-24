using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanVongTay.Models
{
    public class OrderDetails
    {
        public string OrderDetailID { get; set; }
        public string OrderID { get; set; }
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public decimal Total => Quantity * UnitPrice;
    }
}
