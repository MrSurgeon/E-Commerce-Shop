using System.Collections.Generic;
using E_Commerce_Shop.Business.Abstract;
using E_Commerce_Shop.Entity;
using E_Commerce_Shop.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_Shop.WebUI.ViewComponents
{
    public class CategoriesViewComponent : ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public CategoriesViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IViewComponentResult Invoke()
        {
            var categoryViewModel = new CategoryViewModel()
            {
                Categories = _categoryService.GetAll()
            };
            if (RouteData.Values["action"].ToString() == "index")
            {
                ViewBag.SelectedCategory = RouteData.Values["id"];
            }
            return View(categoryViewModel);
        }
    }
}