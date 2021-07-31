using System.Collections.Generic;
using E_Commerce_Shop.Entity;

namespace E_Commerce_Shop.Business.Abstract
{
    public interface IProductService : IValidator<Product>
    {
        Product GetById(int id);
        List<Product> GetAll();
        bool Create(Product entity);
        bool Update(Product entity);
        void Delete(Product entity);
        Product GetProductWithCategories(string url);
        List<Product> GetProductsByCategoryUrl(string url, int page, int pageSize);
        int GetCountByCategory(string name);
        List<Product> GetHomePageProducts();
        List<Product> GetSearchResult(string searchValue);
        Product GetProductWithCategoriesByProductId(int productId);
        bool Update(Product product, int[] categoryIds);
    }
}