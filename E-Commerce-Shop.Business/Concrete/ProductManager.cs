using System.Collections.Generic;
using System.Threading.Tasks;
using E_Commerce_Shop.Business.Abstract;
using E_Commerce_Shop.DataAccess.Abstract;
using E_Commerce_Shop.Entity;

namespace E_Commerce_Shop.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task DeleteAsync(Product product)
        {
            _unitOfWork.Products.Delete(product);
            await _unitOfWork.SaveAsync();
        }

        public async Task<Product> CreateAsync(Product entity)
        {
           await _unitOfWork.Products.CreateAsync(entity);
           await _unitOfWork.SaveAsync();
           return entity;
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            //İş Kurallarını Oluştur
            return await _unitOfWork.Products.GetByIdAsync(id);
        }
        public async Task<List<Product>> GetAllAsync()
        {
            //İş Kurallarını Oluştur
            return await _unitOfWork.Products.GetAllAsync();
        }
        public bool Create(Product entity)
        {
            if (IsValidation(entity))
            {
                _unitOfWork.Products.Create(entity);
                _unitOfWork.Save();
                return true;
            }
            return false;
        }
        public bool Update(Product entity)
        {
            if (IsValidation(entity))
            {
                _unitOfWork.Products.Update(entity);
                _unitOfWork.Save();
                return true;
            }
            return false;

        }
        public void Delete(Product entity)
        {
            //İş Kurallarını Oluştur
            _unitOfWork.Products.Delete(entity);
            _unitOfWork.Save();
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
            return _unitOfWork.Products.GetProductsByCategoryUrl(url, page, pageSize);
        }

        public Product GetProductWithCategories(string url)
        {
            //İş Kurallarını Oluştur
            return _unitOfWork.Products.GetProductWithCategories(url);
        }

        public int GetCountByCategory(string name)
        {
            return _unitOfWork.Products.GetCountByCategory(name);
        }

        public List<Product> GetHomePageProducts()
        {
            //İş Kuralları
            return _unitOfWork.Products.GetHomePageProducts();
        }

        public List<Product> GetSearchResult(string searchValue)
        {
            return _unitOfWork.Products.GetSearchResult(searchValue);
        }

        public Product GetProductWithCategoriesByProductId(int productId)
        {

            return _unitOfWork.Products.GetProductWithCategoriesByProductId(productId);
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
                _unitOfWork.Products.Update(product, categoryIds);
                _unitOfWork.Save();
                return true;
            }
            return false;
        }

        public async Task UpdateAsync(Product current, Product updated)
        {
            current.Url = updated.Url;
            current.Name = updated.Name;
            current.Price = updated.Price;

           await _unitOfWork.SaveAsync();
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