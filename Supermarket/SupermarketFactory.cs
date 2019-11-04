using System.Collections.Generic;
using System.Runtime.Remoting.Channels;
using Basket;
using dataaccess.supermarket;
using dataaccess.supermarket.Repositories;

namespace Supermarket
{
    public class SupermarketFactory
    {
        public List<Product> Products { get; private set; }

        private readonly ProductsRepository productsRepository = new ProductsRepository();
        private readonly OffersRepository offersRepository = new OffersRepository();

        public ShoppingBasket shoppingBasket = new ShoppingBasket();

        public SupermarketFactory()
        {
            Products = productsRepository.GetProducts();
        }

        public List<Offer> GetOffersByProduct(Product product)
        {

            return offersRepository.OffersByProduct(product);
        }

        public void AddItemToBasket(Product product, int quantity, Offer offer)
        {
            shoppingBasket.AddProduct(product.ProductName, product.UnitPrice, quantity, offer);
        }

        public List<BasketItemRender> BuildBasketRender()
        {
            List<BasketItem> _itemsProcessed = new List<BasketItem>();
            List<BasketItemRender> _itemRenders = new List<BasketItemRender>();
            foreach (BasketItem _basketItem in shoppingBasket.BasketItems)
            {
                BasketItemRender _item = new BasketItemRender
                {
                    InitialPrice = _basketItem.LatestPrice,
                    OfferDescription = _basketItem.Offer.OfferDescription,
                    ProductName = _basketItem.ProductName,
                    Quantity = _basketItem.Quantity
                };

                if (_basketItem.Offer.BOGOF)
                {
                    if (!IsOdd(_basketItem.Quantity))
                    {
                        _item.FinalPrice = _item.InitialPrice*_item.Quantity / 2;
                    }
                    else
                    {
                        _item.Quantity -= 1;
                        _item.FinalPrice = _item.InitialPrice * _item.Quantity / 2;
                        _item.Quantity += 1;
                        _item.FinalPrice += _item.InitialPrice;
                    }
                }
                else if (_basketItem.Offer.DISCOUNT)
                {
                    _item.FinalPrice = _basketItem.Offer.DiscountPercentage/_item.InitialPrice*100*_item.Quantity ?? _item.InitialPrice*_item.Quantity;
                }
                else if (_basketItem.Offer.TFTPOT)
                {
                    
                }
                
                _itemRenders.Add(_item);
            }

            return _itemRenders;
        }

        public static bool IsOdd(int value)
        {
            return value % 2 != 0;
        }
    }
}
