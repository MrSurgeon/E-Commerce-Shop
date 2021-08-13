using System.Linq;
using E_Commerce_Shop.Business.Abstract;
using E_Commerce_Shop.WebUI.Identity;
using E_Commerce_Shop.WebUI.ViewModels.Order;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_Shop.WebUI.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly UserManager<User> _userManager;
        public OrderController(IOrderService orderService, UserManager<User> userManager)
        {
            _orderService = orderService;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult OrderList()
        {
            var userId = _userManager.GetUserId(User);
            var orderList = _orderService.GetOrderWithItemsByUserId(userId);

            var orderListModel = new OrderListViewModel()
            {
                Orders = orderList.Select(s => new OrderViewModel()
                {
                    OrderId = s.Id,
                    OrderNumber = s.OrderNumber,
                    OrderDate = s.OrderDate,
                    Address = s.Address,
                    PaymentType = s.PaymentType,
                    City = s.City,
                    UserId = s.UserId,
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    Phone = s.Phone,
                    Email = s.Email,
                    Note = s.Note,
                    OrderStatus = s.OrderState,
                    OrderItems = s.OrderItems.Select(ot => new OrderItemsViewModel()
                    {
                        ImageUrl = ot.Product.ImageUrl,
                        ProductName = ot.Product.Name,
                        Price = ot.Price,
                        Quantity = ot.Quantity
                    }).ToList()
                }).ToList()
            };

            return View("Orders", orderListModel);
        }
    }
}