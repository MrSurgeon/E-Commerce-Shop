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
        Product GetProductWithCategories(string url);
        List<Product> GetProductsByCategoryUrl(string url, int page, int pageSize);
        int GetCountByCategory(string name);
        List<Product> GetHomePageProducts();
        List<Product> GetSearchResult(string searchValue);
    }
}