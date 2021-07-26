using System.Collections.Generic;
using E_Commerce_Shop.WebUI.Data;
using E_Commerce_Shop.WebUI.Models;
using E_Commerce_Shop.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_Shop.WebUI.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult List()
        {
            var productViewModel = new ProductViewModel()
            {
                Products = ProductRepository.Products
            };
            return View(productViewModel);
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("List");
            }
            var p = ProductRepository.GetProductById((int)id);
            return View(p);
        }
    }
}