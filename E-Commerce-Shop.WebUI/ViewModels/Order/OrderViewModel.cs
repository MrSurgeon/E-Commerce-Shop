using System;
using System.Collections.Generic;
using System.Linq;
using E_Commerce_Shop.Entity;

namespace E_Commerce_Shop.WebUI.ViewModels.Order
{
    public class OrderViewModel
    {
        public OrderViewModel()
        {
            OrderItems = new List<OrderItemsViewModel>();
        }
        public int OrderId { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public string Address { get; set; }
        public string PaymentId { get; set; }
        public string ConversationId { get; set; }
        public EnumPaymentType PaymentType { get; set; }
        public string City { get; set; }
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Note { get; set; }

        public int TotalPrice()
        {
            return OrderItems.Sum(i => (int)(i.Price * i.Quantity));
        }
        public EnumOrderState OrderStatus { get; set; }
        public List<OrderItemsViewModel> OrderItems { get; set; }

    }
}