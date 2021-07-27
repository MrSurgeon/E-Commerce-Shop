using System.Collections.Generic;
using System.Linq;
using E_Commerce_Shop.WebUI.Data;
using E_Commerce_Shop.WebUI.Models;
using E_Commerce_Shop.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace E_Commerce_Shop.WebUI.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        //localhost/product/list => Tüm Ürünler Listele
        //Localhost/product/list/1 => 1 nolu kategoriye ait olan ürünleri listele
        public IActionResult List(int? id, string q)
        {
            var productViewModel = new ProductViewModel()
            {
                Products = id != null ? q != null ?
                ProductRepository.Products.Where(w => w.Name.ToLower().Contains(q.ToLower()) || w.Description.ToLower().Contains(q.ToLower())).ToList()
                : ProductRepository.Products.Where(w => w.CategoryId == id).ToList() : ProductRepository.Products
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
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(CategoryRepository.Categories, "CategoryId", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                ProductRepository.AddProduct(product);
                return RedirectToAction("List");
            }
            ViewBag.Categories = new SelectList(CategoryRepository.Categories, "CategoryId", "Name");
            return View("Create", product);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Categories = new SelectList(CategoryRepository.Categories, "CategoryId", "Name");
            return View(ProductRepository.GetProductById(id));
        }
        [HttpPost]
        public IActionResult Edit(Product product)
        {

            ProductRepository.AddProduct(product);
            return RedirectToAction("List");
        }
        public IActionResult Delete(int productId)
        {
            ProductRepository.DeleteProduct(productId);
            return RedirectToAction("List");
        }



    }
}