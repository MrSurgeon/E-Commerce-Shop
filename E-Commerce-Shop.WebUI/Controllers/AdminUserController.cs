using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_Commerce_Shop.WebUI.Extensions;
using E_Commerce_Shop.WebUI.Helpers;
using E_Commerce_Shop.WebUI.Identity;
using E_Commerce_Shop.WebUI.ViewModels.AdminUser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_Shop.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminUserController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;

        public AdminUserController(RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public IActionResult UserList()
        {
            return View(_userManager.Users);
        }

        [HttpGet]
        public async Task<IActionResult> UserEdit(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return RedirectToAction("UserList");
            }
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {

                var model = new UserEditViewModel()
                {
                    Id = user.Id,
                    SelectedRoles = await _userManager.GetRolesAsync(user) as List<string>,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    EmailConfirmed = user.EmailConfirmed,
                    UserName = user.UserName
                };
                ViewBag.Roles = _roleManager.Roles.Select(s => s.Name);
                return View(model);
            }
            return RedirectToAction("UserList");
        }

        [HttpPost]
        public async Task<IActionResult> UserEdit(UserEditViewModel model, string[] selectedRoles)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Role = _roleManager.Roles.Select(s => s.Name);
                return View(model);
            }
            var user = await _userManager.FindByIdAsync(model.Id);
            if (user != null)
            {
                user.LastName = model.LastName;
                user.FirstName = model.FirstName;
                user.Email = model.Email;
                user.UserName = model.UserName;
                user.EmailConfirmed = model.EmailConfirmed;


                if ((await _userManager.UpdateAsync(user)).Succeeded)
                {
                    var currentRoles = await _userManager.GetRolesAsync(user) as List<string>;
                    selectedRoles = selectedRoles ?? new string[] { };
                    await _userManager.AddToRolesAsync(user, selectedRoles.Except(currentRoles));
                    await _userManager.RemoveFromRolesAsync(user, currentRoles.Except(selectedRoles));
                    return RedirectToAction("UserList");
                }
            }
            TempData.Put<AlertMessage>("message", new AlertMessage()
            {
                Title = "Hata Mesajı",
                AlertType = "danger",
                Message = "Güncelleme yapılırken bir hata oluştu."
            });
            return View(model);

        }
    }
}