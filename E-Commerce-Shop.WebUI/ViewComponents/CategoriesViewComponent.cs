using System.Collections.Generic;
using E_Commerce_Shop.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_Shop.WebUI.ViewComponents
{
    public class CategoriesViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var categories = new List<Category>()
                {
                    new Category(){Name = "Telefonlar",Description="Telefon Kategorisi" },
                    new Category(){Name = "Bilgisayarlar",Description="Bilgisayar Kategorisi" },
                    new Category(){Name = "elektronik",Description="Elektronik Kategorisi" },
                 };
            return View(categories);
        }
    }
}