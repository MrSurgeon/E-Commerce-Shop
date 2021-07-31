using System.Collections.Generic;
using E_Commerce_Shop.Entity;

namespace E_Commerce_Shop.Business.Abstract
{
    public interface ICategoryService : IValidator<Category>
    {
        Category GetById(int id);
        List<Category> GetAll();
        void Create(Category entity);
        void Update(Category entity);
        void Delete(Category entity);
        Category GetByIdWithProducts(int id);
        void DeleteProductFromCategory(int productId, int categoryId);
    }
}