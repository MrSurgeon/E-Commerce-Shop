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
            new Product(){ProductId=1,Name="Samsung S3",Price=1000,Description="Smart Phone",ImageUrl="1.jfif"},
            new Product(){ProductId=2,Name="Samsung S4",Price=2000,Description="Smart Phone",IsApproved=true,ImageUrl="2.jfif"},
            new Product(){ProductId=3,Name="Samsung S5",Price=3000,Description="Smart Phone",ImageUrl="3.jfif"},
            new Product(){ProductId=4,Name="Samsung S6",Price=4000,Description="Smart Phone",IsApproved=true,ImageUrl="4.jfif"},
            new Product(){ProductId=5,Name="Samsung S7",Price=5000,Description="Smart Phone",ImageUrl="5.jfif"},
            new Product(){ProductId=6,Name="Samsung S8",Price=6000,Description="Smart Phone",IsApproved=true,ImageUrl="6.jfif"},
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

    }
}