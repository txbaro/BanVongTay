using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanVongTay.Models
{
    public class Products
    {

        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public decimal Price { get; set; }
        public string ImageURL { get; set; }
        public int Quantity { get; set; }

    }
}
