using System.Threading.Tasks;
using E_Commerce_Shop.Business.Abstract;
using E_Commerce_Shop.Services.EmailService;
using E_Commerce_Shop.WebUI.Extensions;
using E_Commerce_Shop.WebUI.Helpers;
using E_Commerce_Shop.WebUI.Identity;
using E_Commerce_Shop.WebUI.ViewModels.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_Shop.WebUI.Controllers
{

    public class AccountController : Controller
    {
        private readonly ICardService _cardService;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IEmailSender _emailSender;
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, IEmailSender emailSender, ICardService cardService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _cardService = cardService;
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
            if(User.Identity.IsAuthenticated)
            {
                return Redirect("/");
            }
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
            TempData.Put<AlertMessage>("message", new AlertMessage()
            {
                Title = "Bilgi Mesajı",
                AlertType = "warning",
                Message = "Hesabınızın oturumu güvenli bir şekilde kapatıldı."
            });
            return Redirect("~/");
        }


        public async Task<IActionResult> ConfirmEmail(string token, string email)
        {
            if (token == null || email == null)
            {
                TempData.Put<AlertMessage>("message", new AlertMessage()
                {
                    Title = "Hata Mesajı",
                    AlertType = "danger",
                    Message = "Email veya token bilgisi hasarlıdır."
                });
                return View();
            }
            var user = await _userManager.FindByEmailAsync(email);

            if (user != null)
            {
                var result = await _userManager.ConfirmEmailAsync(user, token);
                if (result.Succeeded)
                {
                    //Card Objesini Oluştur
                    _cardService.Create(user.Id);
                    
                    TempData.Put<AlertMessage>("message", new AlertMessage()
                    {
                        Title = "Başarı",
                        AlertType = "success",
                        Message = "Hesabınız onaylandı. Bu sayfayı kapatabilirsiniz."
                    });
                    return View();
                }
            }
            TempData.Put<AlertMessage>("message", new AlertMessage()
            {
                Title = "Hata Mesajı",
                AlertType = "warning",
                Message = "Hesabınız onaylanırken sorun oluştu. Tekrar onaylanma başvurusunda bulununuz."
            });
            return View();
        }

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            if (string.IsNullOrEmpty(email))
                return RedirectToAction("Index", "Home");

            var user = await _userManager.FindByEmailAsync(email);
            if (user != null)
            {
                var resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
                var confirmationLink = Url.Action(nameof(ResetPassword), "Account", new { token = resetToken, email = email }, Request.Scheme);
                var message = new Message(new string[] { email }, "Change The Password Link", $"Lütfen şifrenizi değiştirebilmek için gönderilen linke <a href=\"{confirmationLink}\">tıklayınız.</a>");
                await _emailSender.SendEmailAsync(message);
                return RedirectToAction("Login");
            }
            return View();
        }

        [HttpGet]
        public IActionResult ResetPassword(string token, string email)
        {
            if (token == null || email == null)
                return RedirectToAction("ForgotPassword");

            var model = new ResetPasswordViewModel()
            {
                Email = email,
                Token = token
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user != null)
            {
                var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("ResetPasswordConfirmation");
                }
            }
            return Redirect("~/");
        }
        public IActionResult AccessDenied()
        {
            return View();
        }

        public IActionResult ResetPasswordConfirmation()
        {
            return View();
        }

    }
}