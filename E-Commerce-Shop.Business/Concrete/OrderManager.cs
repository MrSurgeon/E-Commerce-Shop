using System.Collections.Generic;
using E_Commerce_Shop.Business.Abstract;
using E_Commerce_Shop.DataAccess.Abstract;
using E_Commerce_Shop.Entity;

namespace E_Commerce_Shop.Business.Concrete
{
    public class OrderManager : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Create(Order entity)
        {
            _unitOfWork.Orders.Create(entity);
            _unitOfWork.Save();
        }

        public List<Order> GetOrderWithItemsByUserId(string userId)
        {
            return _unitOfWork.Orders.GetOrderWithItemsByUserId(userId);
        }
    }
}