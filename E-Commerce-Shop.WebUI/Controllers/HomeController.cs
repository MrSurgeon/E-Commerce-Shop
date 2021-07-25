

using System;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_Shop.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Greeting = (DateTime.Now.Hour) > 12 ? "İyi Günler" : "Günaydın";
            ViewBag.Name = "Enes";
            return View();
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