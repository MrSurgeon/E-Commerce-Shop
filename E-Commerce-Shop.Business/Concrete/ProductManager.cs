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
    }
}