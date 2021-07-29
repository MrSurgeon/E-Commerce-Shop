using System;
using System.Collections.Generic;
using System.Linq;
using E_Commerce_Shop.DataAccess.Abstract;
using E_Commerce_Shop.Entity;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_Shop.DataAccess.Concrete.EfCore
{
    public class EfCoreProductRepository : EfCoreGenericRepository<Product, ShopContext>, IProductRepository
    {
        public List<Product> GetProductsByCategoryUrl(string name)
        {
            using (var context = new ShopContext())
            {
                var products = context.Products.AsQueryable();

                if (!string.IsNullOrEmpty(name))
                {
                    products = products
                                    .Include(p => p.ProductCategories)
                                    .ThenInclude(pc => pc.Category)
                                    .Where(w => w.ProductCategories.Any(c => c.Category.Url == name));
                }
                return products.ToList();
            }
        }

        public Product GetProductWithCategories(int id)
        {
            using (var context = new ShopContext())
            {
                var product = context.Products
                                .Include(p => p.ProductCategories)
                                .ThenInclude(pc => pc.Category)
                                .FirstOrDefault(fD => fD.ProductId == id);
                Console.WriteLine(product);
                return product;
            }

        }
    }
}