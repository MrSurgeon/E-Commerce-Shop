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
        public int GetCountByCategory(string name)
        {
            using (var context = new ShopContext())
            {
                var products = context
                .Products
                .Where(w => w.IsApproved)
                .AsQueryable();

                if (!string.IsNullOrEmpty(name))
                {
                    products = products
                                    .Include(p => p.ProductCategories)
                                    .ThenInclude(pc => pc.Category)
                                    .Where(w => w.ProductCategories.Any(c => c.Category.Url == name));
                }
                return products.ToList().Count();
            }
        }

        public List<Product> GetHomePageProducts()
        {
            using (var context = new ShopContext())
            {
                return context.Products.Where(w => w.IsApproved && w.IsHome).ToList();
            }
        }

        public List<Product> GetProductsByCategoryUrl(string url, int page, int pageSize)
        {
            using (var context = new ShopContext())
            {
                var products = context
                .Products
                .Where(w => w.IsApproved)
                .AsQueryable();

                if (!string.IsNullOrEmpty(url))
                {
                    products = products
                                    .Include(p => p.ProductCategories)
                                    .ThenInclude(pc => pc.Category)
                                    .Where(w => w.ProductCategories.Any(c => c.Category.Url == url));
                }
                return products.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
        }
        public Product GetProductWithCategories(string url)
        {
            using (var context = new ShopContext())
            {
                var product = context.Products
                                .Include(p => p.ProductCategories)
                                .ThenInclude(pc => pc.Category)
                                .FirstOrDefault(fD => fD.Url == url);
                Console.WriteLine(product);
                return product;
            }
        }

        public List<Product> GetSearchResult(string searchValue)
        {
            using (var context = new ShopContext())
            {
                var products = context
                   .Products
                   .Where(w => w.IsApproved &&
                   (w.Name.ToLower().Contains(searchValue.ToLower()) ||
                   w.Description.ToLower().Contains(searchValue.ToLower())))
                   .AsQueryable();

                return products.ToList();
            }
        }
    }
}