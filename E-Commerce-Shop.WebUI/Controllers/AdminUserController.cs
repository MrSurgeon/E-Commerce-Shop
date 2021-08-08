using E_Commerce_Shop.WebUI.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_Shop.WebUI.Controllers
{
    public class AdminUserController : Controller
    {
        private readonly UserManager<User> _userManager;
        public AdminUserController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult UserList()
        {
            return View(_userManager.Users);
        }

    }
}