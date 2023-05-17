using InvoiceManager.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvoiceManager.Models.Repositorys
{
    public class ProductRepository
    {
        public List<Product> GetProducts()
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Products.ToList();
            }
        }

        public Product GetProduct(int productId)
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Products.Single(p => p.Id == productId);
            }
        }
    }
}