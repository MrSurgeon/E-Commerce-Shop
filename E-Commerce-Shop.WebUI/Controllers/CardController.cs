using System.Linq;
using System.Threading.Tasks;
using E_Commerce_Shop.Business.Abstract;
using E_Commerce_Shop.WebUI.Identity;
using E_Commerce_Shop.WebUI.ViewModels.Card;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_Shop.WebUI.Controllers
{
    [Authorize]
    public class CardController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly ICardService _cardService;
        private readonly UserManager<User> _userManager;
        public CardController(ICardService cardService, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _cardService = cardService;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
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
        public async Task<IActionResult> AddToCard(int productId, int quantity)
        {
            var userId = _userManager.GetUserId(User);
            if (userId != null)
            {
                _cardService.AddToCard(userId, productId, quantity);
                return Redirect("/card");
            }
            await _signInManager.SignOutAsync();
            return Redirect("/");
        }

        [HttpPost]
        public IActionResult DeleteFromCard(int productId)
        {

            _cardService.DeleteFromCart(_userManager.GetUserId(User), productId);
            return RedirectToAction("Index");
        }
    }
}