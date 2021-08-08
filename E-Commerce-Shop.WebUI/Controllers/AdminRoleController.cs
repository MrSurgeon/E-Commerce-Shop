using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_Commerce_Shop.WebUI.Extensions;
using E_Commerce_Shop.WebUI.Helpers;
using E_Commerce_Shop.WebUI.Identity;
using E_Commerce_Shop.WebUI.ViewModels.AdminRole;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_Shop.WebUI.Controllers
{
    public class AdminRoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;

        public AdminRoleController(RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public IActionResult RoleList()
        {
            return View(_roleManager.Roles.ToList());
        }

        [HttpGet]
        public IActionResult RoleCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RoleCreate(RoleCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await _roleManager.CreateAsync(new IdentityRole()
            {
                Name = model.Name
            });
            if (result.Succeeded)
            {
                TempData.Put<AlertMessage>("message", new AlertMessage()
                {
                    Title = "Kayıt Bilgisi",
                    AlertType = "success",
                    Message = "Yeni rol sisteme eklendi."
                });
                return RedirectToAction("RoleList");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> RoleEdit(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                TempData.Put<AlertMessage>("message", new AlertMessage()
                {
                    Title = "Hata Mesajı",
                    AlertType = "danger",
                    Message = "İlgili role detay sayfasına ulaşılamadı"
                });
                return RedirectToAction("RoleList");
            }
            var role = await _roleManager.FindByIdAsync(id);
            if (role != null)
            {
                var members = new List<User>();
                var nonMembers = new List<User>();

                foreach (var user in _userManager.Users.ToList())
                {
                    var list = (await _userManager.IsInRoleAsync(user, role.Name)) ? members : nonMembers;
                    list.Add(user);
                }
                var model = new RoleEditViewModel()
                {
                    RoleId = role.Id,
                    RoleName = role.Name,
                    Members = members,
                    NonMembers = nonMembers
                };
                return View(model);
            }
            TempData.Put<AlertMessage>("message", new AlertMessage()
            {
                Title = "Hata Mesajı",
                AlertType = "danger",
                Message = "İlgili rol server tarafında bulunamadı. Tekrar deneyiniz."
            });
            return RedirectToAction("RoleList");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RoleEdit(RoleEditViewModel model)
        {
            if (string.IsNullOrEmpty(model.RoleName) && string.IsNullOrEmpty(model.RoleId))
            {
                TempData.Put<AlertMessage>("message", new AlertMessage()
                {
                    Title = "Hata Mesajı",
                    AlertType = "danger",
                    Message = "İlgili role bilgilerinin eksik olduğu farkedildi. Tekrar işlemleri gerçekleştiriniz."
                });
                return RedirectToAction("RoleList");
            }
            if (model.IdsToAdd != null)
            {
                foreach (var userId in model.IdsToAdd)
                {
                    var user = await _userManager.FindByIdAsync(userId);
                    if (user != null)
                    {
                        var result = await _userManager.AddToRoleAsync(user, model.RoleName);
                        if (!result.Succeeded)
                        {
                            foreach (var error in result.Errors)
                            {
                                ModelState.AddModelError("", error.Description);
                            }
                        }
                    }
                }
            }
            if (model.IdsToDelete != null)
            {
                foreach (var userId in model.IdsToDelete)
                {
                    var user = await _userManager.FindByIdAsync(userId);
                    if (user != null)
                    {
                        var result = await _userManager.RemoveFromRoleAsync(user, model.RoleName);
                        if (!result.Succeeded)
                        {
                            foreach (var error in result.Errors)
                            {
                                ModelState.AddModelError("", error.Description);
                            }
                        }
                    }
                }
            }
            return Redirect("/adminrole/roles/" + model.RoleId);
        }

    }
}