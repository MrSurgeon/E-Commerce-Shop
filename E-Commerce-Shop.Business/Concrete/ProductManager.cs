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
        public void Create(Product entity)
        {
            //İş Kurallarını Oluştur
            _productRepository.Create(entity);
        }
        public void Update(Product entity)
        {
            //İş Kurallarını Oluştur
            _productRepository.Update(entity);
        }
        public void Delete(int id)
        {
            //İş Kurallarını Oluştur
            _productRepository.Delete(_productRepository.GetById(id));
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
    }
}