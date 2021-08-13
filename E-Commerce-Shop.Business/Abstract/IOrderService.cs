using System.Collections.Generic;
using E_Commerce_Shop.Entity;

namespace E_Commerce_Shop.Business.Abstract
{
    public interface IOrderService
    {
        void Create(Order entity);
        List<Order> GetOrderWithItemsByUserId(string userId);
    }
}