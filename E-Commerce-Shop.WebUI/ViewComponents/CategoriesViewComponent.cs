using System.Collections.Generic;
using System.Threading.Tasks;
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

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categoryViewModel = new CategoryViewModel()
            {
                Categories = await _categoryService.GetAllAsync()
            };
            if (RouteData.Values["category"] != null)
            {
                ViewBag.SelectedCategory = RouteData.Values["category"];
            }
            return View(categoryViewModel);
        }
    }
}