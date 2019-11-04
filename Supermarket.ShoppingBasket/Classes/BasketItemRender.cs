using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.ShoppingBasket.Classes
{
    public class BasketItemRender
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public string OfferDescription { get; set; }
        public decimal InitialPrice { get; set; }
        public decimal Savings { get; set; }
        public decimal FinalPrice { get; set; }
        public string OffersApplied { get; set; }
    }
}
