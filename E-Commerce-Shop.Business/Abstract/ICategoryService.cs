using System.Collections.Generic;
using System.Threading.Tasks;
using E_Commerce_Shop.Entity;

namespace E_Commerce_Shop.Business.Abstract
{
    public interface ICategoryService : IValidator<Category>
    {
        Task<Category> GetByIdAsync(int id);
        Task<List<Category>> GetAllAsync();
        void Create(Category entity);
        void Update(Category entity);
        void Delete(Category entity);
        Category GetByIdWithProducts(int id);
        void DeleteProductFromCategory(int productId, int categoryId);
    }
}