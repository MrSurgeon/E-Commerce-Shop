using System.Threading.Tasks;
using E_Commerce_Shop.WebUI.Identity;
using E_Commerce_Shop.WebUI.ViewModels.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_Shop.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterAddViewModel registerAddViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(registerAddViewModel);
            }

            var result = await _userManager.CreateAsync(new User()
            {
                Email = registerAddViewModel.EMail,
                FirstName = registerAddViewModel.FirstName,
                LastName = registerAddViewModel.LastName,
                UserName = registerAddViewModel.UserName
            }, registerAddViewModel.Password);

            if (result.Succeeded)
            {
                //Generate Token
                //Email Confirm
                return RedirectToAction("Login", "Account");
            }
            ModelState.AddModelError("", "Bilinmeyen bir hata ouştu tekrar deneyiniz");
            return View(registerAddViewModel);
        }
    }
}