using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dataaccess.supermarket.Entities
{
    public class SupermarketEntities : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<ProductOffer> ProductOffers { get; set; }
    }
}
