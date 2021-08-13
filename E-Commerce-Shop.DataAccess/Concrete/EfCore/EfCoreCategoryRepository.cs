using System.Linq;
using E_Commerce_Shop.DataAccess.Abstract;
using E_Commerce_Shop.Entity;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_Shop.DataAccess.Concrete.EfCore
{
    public class EfCoreCategoryRepository : EfCoreGenericRepository<Category>, ICategoryRepository
    {
        public EfCoreCategoryRepository(ShopContext context) : base(context)
        {
        }
        private ShopContext ShopContext
        {
            get
            {
                return _context as ShopContext;
            }
        }
        public void DeleteProductFromCategory(int productId, int categoryId)
        {

            var cmd = "Delete From productcategories Where ProductId=@p0 And CategoryId=@p1";
            ShopContext.Database.ExecuteSqlRaw(cmd, productId, categoryId);

        }

        public Category GetByIdWithProducts(int id)
        {
            return ShopContext.Categories
                     .Where(w => w.CategoryId == id)
                     .Include(c => c.ProductCategories)
                     .ThenInclude(cP => cP.Product)
                     .FirstOrDefault();
        }
    }
}