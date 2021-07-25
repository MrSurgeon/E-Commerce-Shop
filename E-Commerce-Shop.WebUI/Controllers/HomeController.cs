

using System;
using System.Collections.Generic;
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
                Products = new List<Product>()
                {
                    new Product(){Name="Samsung S3",Price=1000,Description="Smart Phone"},
                    new Product(){Name="Samsung S4",Price=2000,Description="Smart Phone",IsApproved=true},
                    new Product(){Name="Samsung S5",Price=3000,Description="Smart Phone"},
                    new Product(){Name="Samsung S6",Price=4000,Description="Smart Phone",IsApproved=true},
                    new Product(){Name="Samsung S7",Price=5000,Description="Smart Phone"},
                    new Product(){Name="Samsung S8",Price=6000,Description="Smart Phone",IsApproved=true},
                }
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