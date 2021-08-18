using System.Collections.Generic;
using System.Linq;
using E_Commerce_Shop.DataAccess.Abstract;
using E_Commerce_Shop.Entity;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_Shop.DataAccess.Concrete.EfCore
{
    public class EfCoreOrderRepository : EfCoreGenericRepository<Order>, IOrderRepository
    {
        public EfCoreOrderRepository(ShopContext context) : base(context)
        {
        }
        private ShopContext ShopContext => _context as ShopContext;

        public List<Order> GetOrderWithItemsByUserId(string userId)
        {

            var orders = ShopContext.Orders
                            .Include(o => o.OrderItems)
                            .ThenInclude(oT => oT.Product)
                            .AsQueryable();

            if (!string.IsNullOrEmpty("userId"))
            {
                return orders.Where(w => w.UserId == userId).ToList();
            }
            return orders.ToList();

        }
    }
}