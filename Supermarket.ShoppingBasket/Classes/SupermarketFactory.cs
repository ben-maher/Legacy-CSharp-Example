using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Deployment.Application;
using System.Linq;
using Basket;
using dataaccess.supermarket;
using dataaccess.supermarket.Repositories;

namespace Supermarket.ShoppingBasket.Classes
{
    public class SupermarketFactory
    {
        public List<Product> Products { get; private set; }

        private readonly ProductsRepository productsRepository = new ProductsRepository();
        private readonly OffersRepository offersRepository = new OffersRepository();

        public Basket.ShoppingBasket shoppingBasket = new Basket.ShoppingBasket();

        /// <summary>
        /// Constructor for the Supermarket factory will get a collection of Products and cache them inside the app to reduce calls to databse.
        /// </summary>
        public SupermarketFactory()
        {
            Products = productsRepository.GetProducts();
        }

        /// <summary>
        /// Gets the offers that are assigned to a given product.
        /// </summary>
        /// <param name="product">A Product object</param>
        /// <returns>Returns a collection of offers that a product has.</returns>
        public List<Offer> GetOffersByProduct(Product product)
        {

            return offersRepository.OffersByProduct(product);
        }

        /// <summary>
        /// Adds an item to the ShoppingBasket using the AddProduct function
        /// </summary>
        /// <param name="product">The product to add</param>
        /// <param name="quantity">The quantity of said product</param>
        /// <param name="offer">The offer (if any) appended to the product.</param>
        public void AddItemToBasket(Product product, int quantity, Offer offer)
        {
            shoppingBasket.AddProduct(product.ProductName, product.UnitPrice, quantity, offer);
        }

        /// <summary>
        /// This function will convert the in-class collection of basketitems into a collection of basket item renders ready for a control to consume.
        /// </summary>
        /// <returns>A collection of BasketItemRender</returns>
        public List<BasketItemRender> BuildBasketRenders()
        {
            List<BasketItemRender> _basketItemRenders = new List<BasketItemRender>();


            //Iterate the collection of items that dont have any offers and create the render items.
            foreach (BasketItem _basketItem in shoppingBasket.BasketItems.Where(b=> b.Offer == null))
            {
                _basketItemRenders.Add(new BasketItemRender
                {
                    ProductName = _basketItem.ProductName,
                    InitialPrice = _basketItem.LatestPrice,
                    FinalPrice = _basketItem.LatestPrice * _basketItem.Quantity,
                    Savings = 0.00m,
                    OfferDescription = "",
                    OffersApplied = "",
                    Quantity = _basketItem.Quantity
                });
            }


            //BOGOF is a relatively simple calculation. I'm going to do it dependant on if the items are odd or even because bigger challenges are awaiting ahead.
            foreach (BasketItem _basketItem in shoppingBasket.BasketItems.Where(b => b.Offer != null && b.Offer.Bogof))
            {
                BasketItemRender _basketItemRender = new BasketItemRender
                {
                    ProductName = _basketItem.ProductName,
                    Quantity = _basketItem.Quantity,
                    InitialPrice = _basketItem.LatestPrice,
                    OfferDescription = _basketItem.Offer.OfferDescription,
                    OffersApplied = ""
                };
                //The item is perfectly divisible by 2 so the math is now a straight divide.
                if (_basketItem.Quantity % 2 == 0)
                {
                    _basketItemRender.FinalPrice = _basketItem.LatestPrice * _basketItem.Quantity / 2;
                    _basketItemRender.Savings = _basketItemRender.FinalPrice;
                    _basketItemRender.OffersApplied = $"{_basketItem.Quantity / 2} items free on buy one get one free offer!";
                }
                //The item isn't perfectly divisible so we're going to ignore one item do the same process as before then re-add that item.
                else
                {
                    _basketItem.Quantity--;
                    _basketItemRender.FinalPrice = _basketItem.LatestPrice * _basketItem.Quantity / 2;
                    _basketItemRender.Savings = _basketItemRender.FinalPrice;
                    _basketItemRender.OffersApplied = $"{_basketItem.Quantity / 2} items free on buy one get one free offer!";
                    _basketItemRender.FinalPrice += _basketItem.LatestPrice;
                    _basketItem.Quantity++;
                }

                _basketItemRenders.Add(_basketItemRender);
            }

            //For a percentage discount we're going to simply iterate the collcetion and subtract the discount (Price * (1-DiscountPercentage / 100) * quantity) to get our discount.
            foreach (BasketItem _basketItem in shoppingBasket.BasketItems.Where(b => b.Offer != null && b.Offer.Discount))
            {
                //A safety check to ensure that the discount percentage isn't null
                if (!_basketItem.Offer.DiscountPercentage.HasValue) continue;

                BasketItemRender _basketItemRender = new BasketItemRender
                {
                    ProductName = _basketItem.ProductName,
                    OfferDescription = _basketItem.Offer.OfferDescription,
                    FinalPrice = _basketItem.LatestPrice * _basketItem.Quantity - _basketItem.LatestPrice * _basketItem.Quantity / 100 * _basketItem.Offer.DiscountPercentage.Value,
                    InitialPrice = _basketItem.LatestPrice,
                    OffersApplied = "",
                    Quantity = _basketItem.Quantity,
                };

                _basketItemRender.Savings = _basketItem.TotalOrder - _basketItemRender.FinalPrice;
                _basketItemRender.OffersApplied = $"£{_basketItemRender.Savings.ToString("#0.00")} saved on {_basketItem.Offer.DiscountPercentage}% offer!";
                _basketItemRenders.Add(_basketItemRender);
            }


            //For TFPOT we're going to start the iteration with the distinct group id from the existing collection of basket items.
            foreach (int? _tfpotGroup in shoppingBasket.BasketItems.Where(b=> b.Offer != null).Select(b=> b.Offer.TftpotGroup).Distinct())
            {
                //as it's a nullable type we will get an occourance where the group is null. (Could handle this with where in linq)
                if (_tfpotGroup == null) continue;

                List<BasketItem> _explodedCollectionOfTfpot = new List<BasketItem>();
                //To make the logic a thousand times simpler we're going to 'explode' the collection duplicating the rows per basket item.
                foreach (BasketItem _basketItem in shoppingBasket.BasketItems.Where(b=> b.Offer.TftpotGroup == _tfpotGroup.Value))
                {
                    for (int _i = 0; _i < _basketItem.Quantity; _i++)
                    {
                        _explodedCollectionOfTfpot.Add(_basketItem);
                    }
                }

                List<BasketItemRender> _renders = new List<BasketItemRender>();
                //Working out the free items is now easy, we just get the total quantity divide that by 3 which will give us a nice rounded int of free items.
                IEnumerable<BasketItem> _freeBasketItems = _explodedCollectionOfTfpot.OrderBy(b => b.LatestPrice).Take(_explodedCollectionOfTfpot.Count / 3).ToList();

                //let's iterate the free items first and remove them from the collection so that we don't need linq to iterate the non-free items.
                foreach (BasketItem _basketItem in _freeBasketItems)
                {
                    BasketItemRender _render = _renders.SingleOrDefault(b => b.ProductName == _basketItem.ProductName);
                    if (_render != null)
                    {
                        _render.Quantity++;
                        _render.Savings += _basketItem.LatestPrice;
                    }
                    else
                    {
                        _render = new BasketItemRender
                        {
                            ProductName = _basketItem.ProductName,
                            FinalPrice = 0,
                            InitialPrice = _basketItem.LatestPrice,
                            OffersApplied = "",
                            OfferDescription = _basketItem.Offer.OfferDescription,
                            Quantity = 1,
                            Savings = _basketItem.LatestPrice
                        };

                        _renders.Add(_render);

                        
                    }

                    _explodedCollectionOfTfpot.Remove(_basketItem);
                }

                //lastly, let's add the non-free items to our collection of basketItemRenders. 
                foreach (BasketItem _basketItem in _explodedCollectionOfTfpot)
                {
                    BasketItemRender _render = _renders.SingleOrDefault(r => r.ProductName == _basketItem.ProductName);

                    if (_render != null)
                    {
                        _render.Quantity++;
                        _render.FinalPrice += _basketItem.LatestPrice;
                    }
                    else
                    {
                        _render = new BasketItemRender
                        {
                            ProductName = _basketItem.ProductName,
                            FinalPrice = _basketItem.LatestPrice,
                            InitialPrice = _basketItem.LatestPrice,
                            OffersApplied = "",
                            OfferDescription = _basketItem.Offer.OfferDescription,
                            Quantity = 1,
                            Savings = 0
                        };

                        _renders.Add(_render);
                    }
                }


                //One final iteration to render some pretty stats.
                foreach (BasketItemRender _basketItemRender in _renders)
                {
                    int _quantityFree = _freeBasketItems.Count(b => b.ProductName == _basketItemRender.ProductName);
                    _basketItemRender.OffersApplied = $"{_quantityFree} free items in 3 for 2 offer!";
                }

                //Add the items to the master collection ready for rendering.
                _basketItemRenders.AddRange(_renders);
            }

            return _basketItemRenders;
        }

    }
}
