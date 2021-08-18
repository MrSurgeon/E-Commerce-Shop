using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using E_Commerce_Shop.Business.Abstract;
using E_Commerce_Shop.Entity;
using E_Commerce_Shop.WebUI.Extensions;
using E_Commerce_Shop.WebUI.Helpers;
using E_Commerce_Shop.WebUI.ViewModels;
using E_Commerce_Shop.WebUI.ViewModels.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace E_Commerce_Shop.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        public AdminController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }
        public async Task<IActionResult> ProductList()
        {
            return View(new ProductListViewModel()
            {
                Products = await _productService.GetAllAsync()
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
                TempData.Put<AlertMessage>("message", new AlertMessage()
                {
                    Title = "Bilgi Mesajı",
                    AlertType = "success",
                    Message = $"{entity.Name} isimli ürün eklendi"
                });
                return RedirectToAction("ProductList");
            }
            TempData.Put<AlertMessage>("message", new AlertMessage()
            {
                Title = "Hata Mesajı",
                AlertType = "danger",
                Message = _productService.ErrorMessage
            });
            return View(adminProductViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> EditProduct(int? id)
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
                    AllCategories = await _categoryService.GetAllAsync(),
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
            if (await _productService.GetByIdAsync(adminEditViewModel.ProductId) == null)
            {
                return NotFound();
            }
            if (_productService.Update(new Product()
            {
                ProductId = adminEditViewModel.ProductId,
                Name = adminEditViewModel.Name,
                Price = adminEditViewModel.Price,
                Description = adminEditViewModel.Description,
                Url = adminEditViewModel.Url,
                ImageUrl = (file != null) ? await ImageToDepo(file) : adminEditViewModel.ImageUrl,
                IsApproved = adminEditViewModel.IsApproved,
                IsHome = adminEditViewModel.IsHome
            }, categoryIds))
            {
                TempData.Put<AlertMessage>("message", new AlertMessage()
                {
                    Title = "Bilgi Mesajı",
                    AlertType = "secondary",
                    Message = $"{adminEditViewModel.Name} isimli ürünümüz güncellendi."
                });
                return RedirectToAction("ProductList");
            }
            TempData.Put<AlertMessage>("message", new AlertMessage()
            {
                Title = "Hata Mesajı",
                AlertType = "danger",
                Message = _productService.ErrorMessage
            });
            adminEditViewModel.SelectedCategories = new List<Category>();
            return View(adminEditViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteProduct(int? productId)
        {
            if (productId != null)
            {
                var result = await _productService.GetByIdAsync((int)productId);
                if (result != null)
                {
                    _productService.Delete(result);
                    //Alert Message Tanımlaması
                    TempData.Put<AlertMessage>("message", new AlertMessage()
                    {
                        Title = "Bilgi Mesajı",
                        Message = $"{result.Name} isimli ürünümüz silindi.",
                        AlertType = "danger"
                    });
                    return RedirectToAction("ProductList");
                }
            }
            return NotFound();
        }

        public async Task<IActionResult> CategoryList()
        {
            return View(new AdminCategoryViewModel()
            {
                Categories = await _categoryService.GetAllAsync()
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
            TempData.Put<AlertMessage>("message", new AlertMessage()
            {
                Title = "Bilgi Mesajı",
                Message = $"{adminCreateCategoryViewModel.Name} isimli kategori sisteme eklendi.",
                AlertType = "success"
            });
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


                TempData.Put<AlertMessage>("message", new AlertMessage()
                {
                    Title = "Bilgi Mesajı",
                    Message = $"{adminCategoryEditViewModel.Name} isimli kategori güncellendi.",
                    AlertType = "warning"
                });
                return RedirectToAction("CategoryList");
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCategory(int? id)
        {
            var result = await _categoryService.GetByIdAsync((int)id);
            if (result != null)
            {
                _categoryService.Delete(result);
                TempData.Put<AlertMessage>("message", new AlertMessage()
                {
                    Title = "Bilgi Mesajı",
                    Message = $"{result.Name} isimli kategori silindi.",
                    AlertType = "danger"
                });
                return RedirectToAction("CategoryList");
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProductFromCategory(int? productId, int? categoryId)
        {
            if (productId != null || categoryId != null)
            {
                var productResult = await _productService.GetByIdAsync((int)productId);
                var categoryResult =await _categoryService.GetByIdAsync((int)categoryId);
                if (productResult != null && categoryResult != null)
                {
                    _categoryService.DeleteProductFromCategory((int)productId, (int)categoryId);
                    return Redirect("/Admin/Categories/" + (int)categoryId);
                }
            }
            return NotFound();
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