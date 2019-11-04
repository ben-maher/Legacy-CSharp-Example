using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dataaccess.supermarket;

namespace Basket
{
    public class BasketItem
    {
        public string ProductName { get; set; }
        public decimal LatestPrice { get; set; }
        public int Quantity { get; set; }
        public decimal TotalOrder => LatestPrice*Quantity;
        public Offer Offer { get; set; }
    }
}
