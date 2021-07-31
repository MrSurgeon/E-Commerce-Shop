using E_Commerce_Shop.Business.Abstract;
using E_Commerce_Shop.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_Shop.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;

        public HomeController(IProductService productService)
        {
            _productService = productService;
        }
        public IActionResult Index()
        {
            var productViewModel = new ProductListViewModel()
            {
                Products = _productService.GetHomePageProducts()
            };
            return View(productViewModel);
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View("myView");
        }
    }
}