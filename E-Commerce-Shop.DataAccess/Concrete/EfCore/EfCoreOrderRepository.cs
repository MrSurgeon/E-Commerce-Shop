using System.Collections.Generic;
using System.Linq;
using E_Commerce_Shop.DataAccess.Abstract;
using E_Commerce_Shop.Entity;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_Shop.DataAccess.Concrete.EfCore
{
    public class EfCoreOrderRepository : EfCoreGenericRepository<Order, ShopContext>, IOrderRepository
    {
        public List<Order> GetGetOrderWithItemsByUserId(string userId)
        {
            using (var db = new ShopContext())
            {
                var orders = db.Orders
                                .Include(o => o.OrderItems)
                                .ThenInclude(oT => oT.Product)
                                .AsQueryable();

                if (!string.IsNullOrEmpty("userId"))
                {
                    return orders.Where(w=>w.UserId==userId).ToList();
                }
                return orders.ToList();
            }
        }
    }
}