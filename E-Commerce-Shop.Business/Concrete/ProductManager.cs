using System.Collections.Generic;
using E_Commerce_Shop.Business.Abstract;
using E_Commerce_Shop.DataAccess.Abstract;
using E_Commerce_Shop.Entity;

namespace E_Commerce_Shop.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductRepository _productRepository;


        public ProductManager(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public Product GetById(int id)
        {
            //İş Kurallarını Oluştur
            return _productRepository.GetById(id);
        }
        public List<Product> GetAll()
        {
            //İş Kurallarını Oluştur
            return _productRepository.GetAll();
        }
        public bool Create(Product entity)
        {
            if (IsValidation(entity))
            {
                _productRepository.Create(entity);
                return true;
            }
            return false;
        }
        public bool Update(Product entity)
        {
            if (IsValidation(entity))
            {

                _productRepository.Update(entity);
                return true;
            }
            return false;

        }
        public void Delete(Product entity)
        {
            //İş Kurallarını Oluştur
            _productRepository.Delete(entity);
        }

        public List<Product> GetProductsByCategoryUrl(string url, int page, int pageSize)
        {
            //İş Kurallarını Oluştur
            if (page <= 0)
            {
                page = 1;
            }
            if (pageSize <= 0)
            {
                pageSize = 3;
            }
            return _productRepository.GetProductsByCategoryUrl(url, page, pageSize);
        }

        public Product GetProductWithCategories(string url)
        {
            //İş Kurallarını Oluştur
            return _productRepository.GetProductWithCategories(url);
        }

        public int GetCountByCategory(string name)
        {
            return _productRepository.GetCountByCategory(name);
        }

        public List<Product> GetHomePageProducts()
        {
            //İş Kuralları
            return _productRepository.GetHomePageProducts();
        }

        public List<Product> GetSearchResult(string searchValue)
        {
            return _productRepository.GetSearchResult(searchValue);
        }

        public Product GetProductWithCategoriesByProductId(int productId)
        {

            return _productRepository.GetProductWithCategoriesByProductId(productId);
        }

        public bool Update(Product product, int[] categoryIds)
        {
            if (IsValidation(product))
            {
                if (categoryIds.Length == 0)
                {
                    ErrorMessage += "En az bir kategori alanı seçmelisiniz!";
                    return false;
                }
                _productRepository.Update(product, categoryIds);
                return true;
            }
            return false;
        }

        public string ErrorMessage { get; set; }
        public bool IsValidation(Product entity)
        {
            bool isValid = true;
            if (string.IsNullOrEmpty(entity.Name))
            {
                ErrorMessage += "Ürün ismi doldurulmalıdır.";
                isValid = false;
            }
            if (string.IsNullOrEmpty(entity.Url))
            {
                ErrorMessage += "Url alanı doldurulmalıdır.";
                isValid = false;
            }
            if (entity.Price == null)
            {
                ErrorMessage += "Fiyat alanı boş geçilemez !";
                isValid = false;
            }
            if (entity.Price < 0)
            {
                ErrorMessage += "Fiyat alanı 0'dan küçük olamaz !";
                isValid = false;
            }
            return isValid;
        }
    }
}