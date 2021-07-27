using System.Collections.Generic;
using E_Commerce_Shop.WebUI.Data;
using E_Commerce_Shop.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_Shop.WebUI.ViewComponents
{
    public class CategoriesViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData.Values["id"];
            return View(CategoryRepository.Categories);
        }
    }
}