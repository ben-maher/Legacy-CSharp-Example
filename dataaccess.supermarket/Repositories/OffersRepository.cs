using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dataaccess.supermarket.Entities;

namespace dataaccess.supermarket.Repositories
{
    public class OffersRepository
    {
        private readonly SupermarketEntities supermarketDb = new SupermarketEntities();

        public List<Offer> OffersByProduct(Product product)
        {
            //We can't assume a product is only in one offer. So this query gets all offers that a product belongs to.
            List<ProductOffer> _productOffers = supermarketDb.ProductOffers.Where(po => po.ProductId == product.ProductId).ToList();

            //Return a list of the offers that the product belongs to.
            return _productOffers.Select(productOffer => supermarketDb.Offers.SingleOrDefault(o => o.OfferId == productOffer.OfferId)).ToList();
        }
    }
}
