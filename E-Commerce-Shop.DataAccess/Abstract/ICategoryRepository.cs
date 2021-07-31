using System.Collections.Generic;
using E_Commerce_Shop.Entity;

namespace E_Commerce_Shop.DataAccess.Abstract
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Category GetByIdWithProducts(int id);
        void DeleteProductFromCategory(int productId, int categoryId);
    }
}