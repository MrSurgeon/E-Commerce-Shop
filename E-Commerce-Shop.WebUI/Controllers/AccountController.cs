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

        [HttpGet]
        public IActionResult Login(string ReturnUrl = null)
        {
            return View(new LoginViewModel()
            {
                ReturnUrl = ReturnUrl
            });
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
            if (result.Succeeded)
            {
                return Redirect(model.ReturnUrl ?? "~/");
            }
            ModelState.AddModelError("", "Lütfen Kullanıcı adınızı veya şifrenizi kontrol ediniz.");
            return View(model);

        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerAddViewModel)
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
            ModelState.AddModelError("", "Bilinmeyen bir hata oluştu tekrar deneyiniz");
            return View(registerAddViewModel);
        }
    }
}