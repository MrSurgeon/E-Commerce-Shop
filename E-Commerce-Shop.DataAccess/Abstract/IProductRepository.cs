using E_Commerce_Shop.Entity;
using System.Collections.Generic;

namespace E_Commerce_Shop.DataAccess.Abstract
{
    public interface IProductRepository : IRepository<Product>
    {
        Product GetProductWithCategories(string url);
        Product GetProductWithCategoriesByProductId(int productId);
        List<Product> GetSearchResult(string searchValue);
        List<Product> GetProductsByCategoryUrl(string url, int page, int pageSize);
        int GetCountByCategory(string name);
        List<Product> GetHomePageProducts();
        void Update(Product product, int[] categoryIds);

    }
}