using InvoiceManager.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvoiceManager.Models.Repositorys
{
    public class ProductRepository
    {
        public List<Product> GetProducts(string userId)
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Products.Where(p => p.UserId == userId).ToList();
            }
        }

        public Product GetProduct(int id, string userId)
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Products.Single(p => p.Id == id && p.UserId == userId);
            }
        }

        public void Add(Product product)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Products.Add(product);
                context.SaveChanges();
            }
        }

        public void Update(Product product)
        {
            using (var context = new ApplicationDbContext())
            {
                var productToUpdate = context.Products
                    .Single(p => p.Id == product.Id && p.UserId == product.UserId);

                productToUpdate.Name = product.Name;
                productToUpdate.Value = product.Value;

                context.SaveChanges();
            }
        }

        public void Delete(int id, string userId)
        {
            using (var context = new ApplicationDbContext())
            {
                var productToDelete = context.Products
                    .Single(c => c.Id == id && c.UserId == userId);
                context.Products.Remove(productToDelete);
                context.SaveChanges();
            }
        }
    }
}