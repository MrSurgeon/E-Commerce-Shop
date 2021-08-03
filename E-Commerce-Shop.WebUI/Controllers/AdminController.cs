using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using E_Commerce_Shop.Business.Abstract;
using E_Commerce_Shop.Entity;
using E_Commerce_Shop.WebUI.Helpers;
using E_Commerce_Shop.WebUI.ViewModels;
using E_Commerce_Shop.WebUI.ViewModels.Admin;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace E_Commerce_Shop.WebUI.Controllers
{
    public class AdminController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        public AdminController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }
        public IActionResult ProductList()
        {
            return View(new ProductListViewModel()
            {
                Products = _productService.GetAll()
            });
        }

        [HttpGet]
        public IActionResult CreateProduct()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(AdminProductViewModel adminProductViewModel, IFormFile file)
        {
            if (!ModelState.IsValid)
            {
                return View(adminProductViewModel);
            }
            var entity = new Product()
            {
                Name = adminProductViewModel.Name,
                Price = adminProductViewModel.Price,
                Url = adminProductViewModel.Url,
                Description = adminProductViewModel.Description
            };

            if (file == null)
            {
                _productService.ErrorMessage += "Resim seçilmedi veya yanlış format yüklenmeye çalışıldı !";
            }
            entity.ImageUrl = await ImageToDepo(file);

            if (_productService.Create(entity))
            {
                TemplateOfMessage($"{entity.Name} isimli ürün eklendi", "success");
                return RedirectToAction("ProductList");
            }
            TemplateOfMessage(_productService.ErrorMessage, "danger");
            return View(adminProductViewModel);
        }

        [HttpGet]
        public IActionResult EditProduct(int? id)
        {
            if (id != null)
            {
                var result = _productService.GetProductWithCategoriesByProductId((int)id);
                var selectedCategories = result.ProductCategories.Select(sC => sC.Category).ToList();

                if (result != null) return View(new AdminProductEditViewModel()
                {
                    ProductId = result.ProductId,
                    Name = result.Name,
                    Price = result.Price,
                    Description = result.Description,
                    Url = result.Url,
                    ImageUrl = result.ImageUrl,
                    SelectedCategories = selectedCategories,
                    AllCategories = _categoryService.GetAll(),
                    IsApproved = result.IsApproved,
                    IsHome = result.IsHome
                });

            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> EditProduct(AdminProductEditViewModel adminEditViewModel, int[] categoryIds, IFormFile file)
        {
            if (!ModelState.IsValid)
            {

                return View(adminEditViewModel);
            }
            if (_productService.GetById(adminEditViewModel.ProductId) == null)
            {
                return NotFound();
            }
            if (file == null)
            {
                _productService.ErrorMessage += "Resim seçilmedi veya yanlış format yüklenmeye çalışıldı !";
            }

            if (_productService.Update(new Product()
            {
                ProductId = adminEditViewModel.ProductId,
                Name = adminEditViewModel.Name,
                Price = adminEditViewModel.Price,
                Description = adminEditViewModel.Description,
                Url = adminEditViewModel.Url,
                ImageUrl = await ImageToDepo(file),
                IsApproved = adminEditViewModel.IsApproved,
                IsHome = adminEditViewModel.IsHome
            }, categoryIds))
            {
                TemplateOfMessage($"{adminEditViewModel.Name} isimli ürünümüz güncellendi.", "secondary");
                return RedirectToAction("ProductList");
            }
            TemplateOfMessage(_productService.ErrorMessage, "danger");
            return View(adminEditViewModel);
        }
        [HttpPost]
        public IActionResult DeleteProduct(int? productId)
        {
            if (productId != null)
            {
                var result = _productService.GetById((int)productId);
                if (result != null)
                {
                    _productService.Delete(result);

                    //Alert Message Tanımlaması
                    var message = new AlertMessage()
                    {
                        Message = $"{result.Name} isimli ürünümüz silindi.",
                        AlertType = "danger"
                    };
                    TempData["Message"] = JsonConvert.SerializeObject(message);
                    return RedirectToAction("ProductList");
                }
            }
            return NotFound();
        }

        public IActionResult CategoryList()
        {
            return View(new AdminCategoryViewModel()
            {
                Categories = _categoryService.GetAll()
            });
        }

        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCategory(AdminCreateCategoryViewModel adminCreateCategoryViewModel)
        {
            if (!ModelState.IsValid) return View(adminCreateCategoryViewModel);
            _categoryService.Create(new Category()
            {
                Name = adminCreateCategoryViewModel.Name,
                Url = adminCreateCategoryViewModel.Url
            });
            var message = new AlertMessage()
            {
                Message = $"{adminCreateCategoryViewModel.Name} isimli kategori sisteme eklendi.",
                AlertType = "success"
            };
            TempData["Message"] = JsonConvert.SerializeObject(message);
            return RedirectToAction("CategoryList");
        }

        [HttpGet]
        public IActionResult EditCategory(int? categoryId)
        {
            if (categoryId != null)
            {
                var result = _categoryService.GetByIdWithProducts((int)categoryId);
                if (result != null) return View(new AdminCategoryEditViewModel()
                {
                    CategoryId = result.CategoryId,
                    Name = result.Name,
                    Url = result.Url,
                    CategoryProducts = result.ProductCategories.Select(pC => pC.Product).ToList()
                });
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult EditCategory(AdminCategoryEditViewModel adminCategoryEditViewModel)
        {
            if (!ModelState.IsValid)
            {
                var productWithCategories = _categoryService.GetByIdWithProducts((int)adminCategoryEditViewModel.CategoryId);
                adminCategoryEditViewModel.CategoryProducts = productWithCategories
                                                            .ProductCategories
                                                            .Select(s => s.Product)
                                                            .ToList();

                return View(adminCategoryEditViewModel);
            }
            var result = _categoryService.GetByIdWithProducts(adminCategoryEditViewModel.CategoryId);
            if (result != null)
            {
                _categoryService.Update(new Category()
                {
                    CategoryId = result.CategoryId,
                    Name = adminCategoryEditViewModel.Name,
                    Url = adminCategoryEditViewModel.Url
                });
                var message = new AlertMessage()
                {
                    Message = $"{adminCategoryEditViewModel.Name} isimli kategori güncellendi.",
                    AlertType = "warning"
                };
                TempData["Message"] = JsonConvert.SerializeObject(message);
                return RedirectToAction("CategoryList");
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult DeleteCategory(int? id)
        {
            var result = _categoryService.GetById((int)id);
            if (result != null)
            {
                _categoryService.Delete(result);
                var message = new AlertMessage()
                {
                    Message = $"{result.Name} isimli kategori silindi.",
                    AlertType = "danger"
                };
                TempData["Message"] = JsonConvert.SerializeObject(message);
                return RedirectToAction("CategoryList");
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult DeleteProductFromCategory(int? productId, int? categoryId)
        {
            if (productId != null || categoryId != null)
            {
                var productResult = _productService.GetById((int)productId);
                var categoryResult = _categoryService.GetById((int)categoryId);
                if (productResult != null && categoryResult != null)
                {
                    _categoryService.DeleteProductFromCategory((int)productId, (int)categoryId);
                    return Redirect("/Admin/Categories/" + (int)categoryId);
                }
            }
            return NotFound();
        }

        private void TemplateOfMessage(string message, string alertType)
        {
            var messagePackage = new AlertMessage()
            {
                Message = message,
                AlertType = alertType
            };
            TempData["Message"] = JsonConvert.SerializeObject(messagePackage);
        }

        private async Task<string> ImageToDepo(IFormFile file)
        {
            var extension = Path.GetExtension(file.FileName);
            var randomName = string.Format($"{Guid.NewGuid()}{extension}");
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", randomName);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return randomName;
        }
    }
}