using E_Commerce_Shop.Entity;
using System.Collections.Generic;

namespace E_Commerce_Shop.DataAccess.Abstract
{
    public interface IProductRepository : IRepository<Product>
    {
        Product GetProductWithCategories(int id);
        List<Product> GetProductsByCategoryUrl(string name);
    }
}