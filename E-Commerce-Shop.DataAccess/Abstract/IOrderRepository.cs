using System.Collections.Generic;
using E_Commerce_Shop.Entity;

namespace E_Commerce_Shop.DataAccess.Abstract
{
    public interface IOrderRepository : IRepository<Order>
    {
        List<Order> GetOrderWithItemsByUserId(string userId);
    }
}