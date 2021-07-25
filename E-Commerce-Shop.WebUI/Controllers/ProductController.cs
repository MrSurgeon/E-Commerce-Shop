using System.Collections.Generic;
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
                Category = new Category() { Name = "Telefonlar" },
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
        public IActionResult Details(int? id)
        {
            var p = new Product()
            {
                Name = "Samsung S4",
                Price = 2200,
                Description = "New and Clean Smart Phone"
            };
            return View(p);
        }
    }
}