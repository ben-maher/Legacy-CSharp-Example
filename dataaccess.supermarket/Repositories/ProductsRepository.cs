using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dataaccess.supermarket.Entities;

namespace dataaccess.supermarket.Repositories
{
    public class ProductsRepository
    {
        private readonly SupermarketEntities supermarketDb = new SupermarketEntities();
        /// <summary>
        /// This function will query the Products table for a list of products
        /// </summary>
        /// <returns>All products in the database</returns>
        public List<Product> GetProducts()
        {
            return supermarketDb.Products.ToList();
        }
    }
}
