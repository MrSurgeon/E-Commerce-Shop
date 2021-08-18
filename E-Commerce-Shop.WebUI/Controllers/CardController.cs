using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_Commerce_Shop.Business.Abstract;
using E_Commerce_Shop.Entity;
using E_Commerce_Shop.WebUI.Extensions;
using E_Commerce_Shop.WebUI.Helpers;
using E_Commerce_Shop.WebUI.Identity;
using E_Commerce_Shop.WebUI.ViewModels.Card;
using Iyzipay;
using Iyzipay.Model;
using Iyzipay.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_Shop.WebUI.Controllers
{
    [Authorize]
    public class CardController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly SignInManager<User> _signInManager;
        private readonly ICardService _cardService;
        private readonly UserManager<User> _userManager;
        public CardController(ICardService cardService, UserManager<User> userManager, SignInManager<User> signInManager, IOrderService orderService)
        {
            _cardService = cardService;
            _userManager = userManager;
            _signInManager = signInManager;
            _orderService = orderService;
        }

        [HttpGet]
        public IActionResult SuccessPayment()
        {
            return View();
        }
        [HttpGet]
        public IActionResult CardList()
        {
            var card = _cardService.GetCardWithItemsAndProductByUserId(_userManager.GetUserId(User));


            return View(new CardViewModel()
            {
                CardId = card.Id,
                CardItems = card.CardItems.Select(i => new CardItemModel()
                {
                    ImageUrl = i.Product.ImageUrl,
                    ProductId = i.ProductId,
                    Price = (double)i.Product.Price,
                    Quantity = i.Quantity,
                    ProductName = i.Product.Name
                }).ToList()
            });
        }

        [HttpPost]
        public async Task<IActionResult> AddToCard(int? productId, int? quantity)
        {
            var userId = _userManager.GetUserId(User);
            if (userId != null)
            {
                if (await _cardService.AddToCardAsync(userId, productId, quantity))
                {
                    return Redirect("/cardList");
                }
                TempData.Put<AlertMessage>("message", new AlertMessage()
                {
                    Title = "Hata Mesajı",
                    AlertType = "danger",
                    Message = _cardService.ErrorMessage
                });
            }
            return Redirect("/");
        }

        [HttpPost]
        public IActionResult DeleteFromCard(int productId)
        {

            _cardService.DeleteFromCart(_userManager.GetUserId(User), productId);
            return RedirectToAction("CardList");
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            var card = _cardService.GetCardWithItemsAndProductByUserId(_userManager.GetUserId(User));
            return View(new OrderModel()
            {
                CardModel = new CardViewModel()
                {
                    CardId = card.Id,
                    CardItems = card.CardItems.Select(i => new CardItemModel()
                    {
                        ImageUrl = i.Product.ImageUrl,
                        ProductId = i.ProductId,
                        Price = (double)i.Product.Price,
                        Quantity = i.Quantity,
                        ProductName = i.Product.Name
                    }).ToList()
                }
            });

        }

        private CardViewModel BringCardInfo()
        {
            if (User.Identity.IsAuthenticated)
            {
                var card = _cardService.GetCardWithItemsAndProductByUserId(_userManager.GetUserId(User));
                return new CardViewModel()
                {
                    CardId = card.Id,
                    CardItems = card.CardItems.Select(i => new CardItemModel()
                    {
                        ImageUrl = i.Product.ImageUrl,
                        ProductId = i.ProductId,
                        Price = (double)i.Product.Price,
                        Quantity = i.Quantity,
                        ProductName = i.Product.Name
                    }).ToList()
                };
            }
            return new CardViewModel();
        }
        [HttpPost]
        public async Task<IActionResult> Checkout(OrderModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = _userManager.GetUserId(User);
                var user = await _userManager.FindByIdAsync(userId);
                model.CardModel = BringCardInfo();

                var payment = PaymentProcess(model, user);
                if (payment.Status == "success")
                {
                    SaveOrder(model, payment, userId);
                    ClearCard(model.CardModel.CardId);

                    TempData.Put<AlertMessage>("message", new AlertMessage()
                    {
                        Title = "Ödeme Başarılı",
                        AlertType = "danger",
                        Message = "Ödemeniz başarılı bir şekilde gerçekleştirildi."
                    });
                    return RedirectToAction("SuccessPayment");
                }
                else
                {
                    TempData.Put<AlertMessage>("message", new AlertMessage()
                    {
                        Title = "Hata Mesajı",
                        AlertType = "danger",
                        Message = payment.ErrorMessage
                    });
                }
            }
            model.CardModel = BringCardInfo();
            return View(model);
        }

        private void ClearCard(int cartId)
        {
            _cardService.ClearCard(cartId);
        }

        private void SaveOrder(OrderModel model, Payment payment, string userId)
        {
            var order = new Order()
            {
                PaymentType = EnumPaymentType.CreditCard,
                PaymentId = payment.PaymentId,
                ConversationId = payment.ConversationId,
                OrderDate = DateTime.Now,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Address = model.Address,
                City = model.City,
                UserId = userId,
                Phone = model.Phone,
                Email = model.Email,
                Note = model.Note,
                OrderNumber = Guid.NewGuid().ToString(),
                OrderItems = model.CardModel.CardItems.Select(i => new E_Commerce_Shop.Entity.OrderItem()
                {
                    ProductId = i.ProductId,
                    Price = (double)i.Price,
                    Quantity = i.Quantity,

                }).ToList()
            };

            _orderService.Create(order);
        }

        private Payment PaymentProcess(OrderModel model, User user)
        {
            Options options = new Options();
            options.ApiKey = "sandbox-ezyJHWoEcwcs3ay3gp8zRtANtJ8A9Sn5";
            options.SecretKey = "sandbox-0tTLWiYkULkaThozKO3ZU7HmPhzALfWL";
            options.BaseUrl = "https://sandbox-api.iyzipay.com";

            CreatePaymentRequest request = new CreatePaymentRequest();
            request.Locale = Locale.TR.ToString();
            request.ConversationId = new Random().Next(111111111, 999999999).ToString();
            request.Price = model.CardModel.TotalPrice().ToString();

            Console.WriteLine("Total Price:" + model.CardModel.TotalPrice());
            request.PaidPrice = model.CardModel.TotalPrice().ToString();
            request.Currency = Currency.TRY.ToString();
            request.Installment = 1;
            request.BasketId = "B67832";
            request.PaymentChannel = PaymentChannel.WEB.ToString();
            request.PaymentGroup = PaymentGroup.PRODUCT.ToString();

            PaymentCard paymentCard = new PaymentCard();
            paymentCard.CardHolderName = model.CardName;
            paymentCard.CardNumber = model.CardNumber;
            paymentCard.ExpireMonth = model.ExpirationMonth;
            paymentCard.ExpireYear = model.ExpirationYear;
            paymentCard.Cvc = model.Cvc;
            paymentCard.RegisterCard = 0;
            request.PaymentCard = paymentCard;

            // paymentCard.CardNumber = "5528790000000008";
            // paymentCard.ExpireMonth = "12";
            // paymentCard.ExpireYear = "2030";
            // paymentCard.Cvc = "123";

            Buyer buyer = new Buyer();
            buyer.Id = user.Id;
            buyer.Name = user.FirstName;
            buyer.Surname = user.LastName;
            buyer.GsmNumber = "+905350000000";
            buyer.Email = model.Email;
            buyer.IdentityNumber = "74300864791";
            buyer.LastLoginDate = "2015-10-05 12:43:35";
            buyer.RegistrationDate = "2013-04-21 15:12:09";
            buyer.RegistrationAddress = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
            buyer.Ip = "85.34.78.112";
            buyer.City = "Istanbul";
            buyer.Country = "Turkey";
            buyer.ZipCode = "34732";
            request.Buyer = buyer;

            Address shippingAddress = new Address();
            shippingAddress.ContactName = "Jane Doe";
            shippingAddress.City = "Istanbul";
            shippingAddress.Country = "Turkey";
            shippingAddress.Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
            shippingAddress.ZipCode = "34742";
            request.ShippingAddress = shippingAddress;

            Address billingAddress = new Address();
            billingAddress.ContactName = "Jane Doe";
            billingAddress.City = "Istanbul";
            billingAddress.Country = "Turkey";
            billingAddress.Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
            billingAddress.ZipCode = "34742";
            request.BillingAddress = billingAddress;

            List<BasketItem> basketItems = new List<BasketItem>();
            BasketItem basketItem;

            double para = 0;
            foreach (var item in model.CardModel.CardItems)
            {
                int a = item.Quantity;
                do
                {
                    basketItem = new BasketItem()
                    {
                        Id = item.ProductId.ToString(),
                        Name = item.ProductName,
                        Category1 = "Phone",
                        ItemType = BasketItemType.PHYSICAL.ToString(),
                        Price = item.Price.ToString()
                    };
                    a--;
                    basketItems.Add(basketItem);
                    para += item.Price;
                } while (a != 0);

            }

            Console.WriteLine("Toplam Basket değeri" + para);

            request.BasketItems = basketItems;


            return Payment.Create(request, options);
        }
    }
}