using E_Commerce_Shop.Business.Abstract;
using E_Commerce_Shop.WebUI.Helpers;
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
        // products/telefon?page=1
        //products?page=1
        public IActionResult List(string category, int page = 1)
        {
            const int pageSize = 2;
            var productListViewModel = new ProductListViewModel()
            {
                Products = _productService.GetProductsByCategoryUrl(category, page, pageSize),
                PageInfo = new PageInfo()
                {
                    TotalItems = _productService.GetCountByCategory(category),
                    CurrentCategory = category,
                    CurrentPage = page,
                    ItemsPerPage = pageSize
                }
            };
            return View(productListViewModel);
        }

        public IActionResult Details(string productUrl)
        {
            if (productUrl != null)
            {
                var product = _productService.GetProductWithCategories(productUrl);
                if (product != null) return View(product);
            }
            return NotFound();
        }

        public IActionResult Search(string q)
        {
            var searchViewModel = new SearchViewModel()
            {
                Products = _productService.GetSearchResult(q)
            };
            return View(searchViewModel);
        }
    }
}