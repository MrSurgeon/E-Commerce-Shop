using System.Threading.Tasks;
using E_Commerce_Shop.Services.EmailService;
using E_Commerce_Shop.WebUI.Helpers;
using E_Commerce_Shop.WebUI.Identity;
using E_Commerce_Shop.WebUI.ViewModels.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace E_Commerce_Shop.WebUI.Controllers
{

    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IEmailSender _emailSender;
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
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
        [ValidateAntiForgeryToken]
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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel registerAddViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(registerAddViewModel);
            }
            var user = new User()
            {
                Email = registerAddViewModel.EMail,
                FirstName = registerAddViewModel.FirstName,
                LastName = registerAddViewModel.LastName,
                UserName = registerAddViewModel.UserName
            };

            var result = await _userManager.CreateAsync(user, registerAddViewModel.Password);

            if (result.Succeeded)
            {
                //Generate Token
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var confirmationLink = Url.Action(nameof(ConfirmEmail), "Account", new { token, email = user.Email }, Request.Scheme);
                var message = new Message(new string[] { user.Email }, "Confirmation email link", $"Lütfen emailinizi onaylamak için gönderilen linke <a href=\"{confirmationLink}\">tıklayınız.</a>");
                await _emailSender.SendEmailAsync(message);
                return RedirectToAction("Login", "Account");
            }
            ModelState.AddModelError("", "Bilinmeyen bir hata oluştu tekrar deneyiniz");
            return View(registerAddViewModel);
        }
        public async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return Redirect("~/");
        }


        public async Task<IActionResult> ConfirmEmail(string token, string email)
        {

            var user = await _userManager.FindByIdAsync(email);
            if (user != null)
            {
                var result = await _userManager.ConfirmEmailAsync(user, token);
                if (result.Succeeded)
                {
                    TemplateOfMessage("Hesabınız onaylandı. Bu sayfayı kapatabilirsiniz.", "success");
                    return View();
                }   
            }

            TemplateOfMessage("Hesabınız onaylanırken sorun oluştu. Tekrar onaylanma başvurusunda bulununuz.", "warning");
            return View();
        }

        private void TemplateOfMessage(string message, string alertType)
        {
            var messagePackage = new AlertMessage()
            {
                Message = message,
                AlertType = alertType
            };
            TempData["Message"] = JsonConvert.SerializeObject(messagePackage);
        }
    }
}