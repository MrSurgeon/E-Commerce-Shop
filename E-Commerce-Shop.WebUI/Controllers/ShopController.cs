using E_Commerce_Shop.DataAccess.Abstract;
using E_Commerce_Shop.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_Shop.WebUI.Controllers
{
    public class ShopController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ShopController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public IActionResult Index()
        {
            var productListViewModel = new ProductListViewModel()
            {
                Products = _productRepository.GetAll()
            };
            return View(productListViewModel);
        }
    }
}