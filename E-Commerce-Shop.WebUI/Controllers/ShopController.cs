using E_Commerce_Shop.Business.Abstract;

using E_Commerce_Shop.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_Shop.WebUI.Controllers
{
    public class ShopController : Controller
    {
        private readonly IProductService _productService;

        public ShopController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult List(string category)
        {
            var productListViewModel = new ProductListViewModel()
            {
                Products = _productService.GetProductsByCategoryUrl(category)
            };
            return View(productListViewModel);
        }

        public IActionResult Details(int? id)
        {
            if (id != null)
            {
                var product = _productService.GetProductWithCategories((int)id);
                if (product != null) return View(product);
            }
            return NotFound();
        }
    }
}