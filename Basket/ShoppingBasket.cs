using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dataaccess.supermarket;

namespace Basket
{
    public class ShoppingBasket
    {
        public List<BasketItem> BasketItems { get; set; }
        public decimal BasketTotal => BasketItems.Sum(basketItem => basketItem.LatestPrice * basketItem.Quantity);

        /// <summary>
        /// The constructor for the shopping basket. It will initialize a collection of basket items.
        /// </summary>
        public ShoppingBasket()
        {
            BasketItems = new List<BasketItem>();
        }

        /// <summary>
        /// Adds a product to the basket
        /// </summary>
        /// <param name="productName">The string name of the product (Should be distinct)</param>
        /// <param name="productValue">The current value of the product added.</param>
        /// <param name="quantity">The quantity of hte product to be added.</param>
        /// <param name="offer">The offer that is on the product.</param>
        public void AddProduct(string productName, decimal productValue, int quantity, Offer offer)
        {
            BasketItem _item = BasketItems.SingleOrDefault(b => b.ProductName == productName);
            if (_item != null)
            {
                _item.Quantity += quantity;
                if (productValue < _item.LatestPrice) _item.LatestPrice = productValue;
                return;
            }

            BasketItems.Add(new BasketItem
            {
                ProductName = productName,
                LatestPrice = productValue,
                Quantity = quantity,
                Offer = offer
            });
        }

        /// <summary>
        /// Removes a product from the basket.
        /// </summary>
        /// <param name="productName">The name of the product to remove.</param>
        public void RemoveProduct(string productName)
        {
            BasketItems.RemoveAll(b => b.ProductName == productName);
        }

        /// <summary>
        /// This method will clear the basket contents entirely.
        /// </summary>
        public void ClearBasket()
        {
            BasketItems.Clear();
        }
    }
}
