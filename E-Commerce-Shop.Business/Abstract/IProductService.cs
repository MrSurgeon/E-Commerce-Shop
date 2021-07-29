using System.Collections.Generic;
using E_Commerce_Shop.Entity;

namespace E_Commerce_Shop.Business.Abstract
{
    public interface IProductService
    {
        Product GetById(int id);
        List<Product> GetAll();
        void Create(Product entity);
        void Update(Product entity);
        void Delete(int id);
        Product GetProductWithCategories(int id);
        List<Product> GetProductsByCategoryUrl(string name);
    }
}