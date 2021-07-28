using System.Collections.Generic;
using System.Linq;
using E_Commerce_Shop.WebUI.Data;
using E_Commerce_Shop.Entity;
using E_Commerce_Shop.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using E_Commerce_Shop.DataAccess.Abstract;

namespace E_Commerce_Shop.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
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
                Products = _productRepository.GetAll()
            };
            return View(productViewModel);
        }
        public IActionResult Details(int id)
        {

            var p = _productRepository.GetById(id);
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
                _productRepository.Create(product);
                return RedirectToAction("List");
            }
            ViewBag.Categories = new SelectList(CategoryRepository.Categories, "CategoryId", "Name");
            return View("Create", product);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Categories = new SelectList(CategoryRepository.Categories, "CategoryId", "Name");
            return View(_productRepository.GetById(id));
        }
        [HttpPost]
        public IActionResult Edit(Product product)
        {

            _productRepository.Update(product);
            return RedirectToAction("List");
        }
        public IActionResult Delete(int productId)
        {
            _productRepository.Delete(_productRepository.GetById(productId));
            return RedirectToAction("List");
        }
    }
}