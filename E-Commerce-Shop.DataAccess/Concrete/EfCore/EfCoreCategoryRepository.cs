using System.Linq;
using E_Commerce_Shop.DataAccess.Abstract;
using E_Commerce_Shop.Entity;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_Shop.DataAccess.Concrete.EfCore
{
    public class EfCoreCategoryRepository : EfCoreGenericRepository<Category, ShopContext>, ICategoryRepository
    {
        public void DeleteProductFromCategory(int productId, int categoryId)
        {
            using (var db = new ShopContext())
            {
                var cmd = "Delete From productcategories Where ProductId=@p0 And CategoryId=@p1";
                db.Database.ExecuteSqlRaw(cmd, productId, categoryId);
            }
        }

        public Category GetByIdWithProducts(int id)
        {
            using (var db = new ShopContext())
            {
                return db.Categories
                         .Where(w => w.CategoryId == id)
                         .Include(c => c.ProductCategories)
                         .ThenInclude(cP => cP.Product)
                         .FirstOrDefault();
            }
        }
    }
}