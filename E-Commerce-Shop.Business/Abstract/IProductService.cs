using System.Collections.Generic;
using System.Threading.Tasks;
using E_Commerce_Shop.Entity;

namespace E_Commerce_Shop.Business.Abstract
{
    public interface IProductService : IValidator<Product>
    {
        Task DeleteAsync(Product product);
        Task<Product> CreateAsync(Product entity);
        Task<Product> GetByIdAsync(int id);
        Task<List<Product>> GetAllAsync();
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
        Task UpdateAsync(Product current, Product updated);
    }
}