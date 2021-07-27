using System.Collections.Generic;
using System.Linq;
using E_Commerce_Shop.WebUI.Models;

namespace E_Commerce_Shop.WebUI.Data
{
    public static class ProductRepository
    {
        static ProductRepository()
        {
            _products = new List<Product>(){
            new Product(){ProductId=1,Name="Samsung S3",Price=1000,Description="Smart Phone",ImageUrl="1.jfif",CategoryId=1},
            new Product(){ProductId=2,Name="Samsung S4",Price=2000,Description="Smart Phone",IsApproved=true,ImageUrl="2.jfif",CategoryId=1},
            new Product(){ProductId=3,Name="Samsung S5",Price=3000,Description="Smart Phone",ImageUrl="3.jfif",CategoryId=1},
            new Product(){ProductId=4,Name="Samsung S6",Price=4000,Description="Smart Phone",IsApproved=true,ImageUrl="4.jfif",CategoryId=1},
            new Product(){ProductId=5,Name="Samsung S7",Price=5000,Description="Smart Phone",ImageUrl="5.jfif",CategoryId=2},
            new Product(){ProductId=6,Name="Samsung S8",Price=6000,Description="Smart Phone",IsApproved=true,ImageUrl="6.jfif",CategoryId=2},
            };
        }
        private static List<Product> _products = null;

        public static List<Product> Products
        {
            get
            {
                return _products;
            }
        }

        public static void AddProduct(Product product)
        {
            _products.Add(product);
        }
        public static Product GetProductById(int productId)
        {
            var result = _products.FirstOrDefault(p => p.ProductId == productId);
            if (result != null)
            {
                return result;
            }
            return result;
        }
        public static void EditProduct(Product product)
        {
            var p = _products.FirstOrDefault(w => w.ProductId == product.ProductId);
            p.Name = product.Name;
            p.Price = product.Price;
            p.Description = product.Description;
            p.ImageUrl = product.ImageUrl;
            p.CategoryId = product.CategoryId;
        }

        public static void DeleteProduct(int id)
        {
            var p = _products.FirstOrDefault(fD => fD.ProductId == id);
            _products.Remove(p);
        }
    }
}