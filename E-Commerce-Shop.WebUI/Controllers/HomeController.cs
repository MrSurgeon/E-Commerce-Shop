

using System;
using System.Collections.Generic;
using E_Commerce_Shop.WebUI.Data;
using E_Commerce_Shop.WebUI.Models;
using E_Commerce_Shop.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_Shop.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

            var productViewModel = new ProductViewModel()
            {
                Products = ProductRepository.Products
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