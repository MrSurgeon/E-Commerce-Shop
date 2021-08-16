using System;
using System.Collections.Generic;
using System.Linq;
using E_Commerce_Shop.DataAccess.Abstract;
using E_Commerce_Shop.Entity;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_Shop.DataAccess.Concrete.EfCore
{
    public class EfCoreProductRepository : EfCoreGenericRepository<Product>, IProductRepository
    {
        public EfCoreProductRepository(ShopContext context) : base(context)
        {
        }
        private ShopContext ShopContext
        {
            get
            {
                return _context as ShopContext;
            }
        }

        public int GetCountByCategory(string name)
        {

            var products = ShopContext
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

        public List<Product> GetHomePageProducts()
        {
            return ShopContext.Products.Where(w => w.IsApproved && w.IsHome).ToList();
        }

        public List<Product> GetProductsByCategoryUrl(string url, int page, int pageSize)
        {
            var products = ShopContext
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
        public Product GetProductWithCategories(string url)
        {
            var product = ShopContext.Products
                            .Include(p => p.ProductCategories)
                            .ThenInclude(pc => pc.Category)
                            .FirstOrDefault(fD => fD.Url == url);
            Console.WriteLine(product);
            return product;
        }

        public Product GetProductWithCategoriesByProductId(int productId)
        {
            return ShopContext.Products
                            .Include(p => p.ProductCategories)
                            .ThenInclude(pc => pc.Category)
                            .FirstOrDefault(p => p.ProductId == productId);
        }

        public List<Product> GetSearchResult(string searchValue)
        {
            var products = ShopContext
               .Products
               .Where(w => w.IsApproved &&
               (w.Name.ToLower().Contains(searchValue.ToLower()) ||
               w.Description.ToLower().Contains(searchValue.ToLower())))
               .AsQueryable();

            return products.ToList();
        }

        public void Update(Product product, int[] categoryIds)
        {
            var result = ShopContext.Products
                                .Include(c => c.ProductCategories)
                                .FirstOrDefault(w => w.ProductId == product.ProductId);
            if (result != null)
            {
                result.Name = product.Name;
                result.Price = product.Price;
                result.Url = product.Url;
                result.Description = product.Description;
                result.ImageUrl = product.ImageUrl;
                result.IsApproved = product.IsApproved;
                result.IsHome = product.IsHome;
                result.ProductCategories = categoryIds.Select(cakid => new ProductCategory()
                {
                    ProductId = result.ProductId,
                    CategoryId = cakid
                }).ToList();
            }
        }
    }
}