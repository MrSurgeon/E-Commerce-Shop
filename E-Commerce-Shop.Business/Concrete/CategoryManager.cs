using System.Collections.Generic;
using E_Commerce_Shop.Business.Abstract;
using E_Commerce_Shop.DataAccess.Abstract;
using E_Commerce_Shop.Entity;

namespace E_Commerce_Shop.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryManager(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public string ErrorMessage { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public void Create(Category entity)
        {
            //İş Kuralları
            _categoryRepository.Create(entity);
        }

        public void Delete(Category entity)
        {
            //İş Kuralları
            _categoryRepository.Delete(entity);
        }

        public void DeleteProductFromCategory(int productId, int categoryId)
        {
            _categoryRepository.DeleteProductFromCategory(productId, categoryId);
        }

        public List<Category> GetAll()
        {
            //İş Kuralları
            return _categoryRepository.GetAll();
        }

        public Category GetById(int id)
        {
            //İş Kuralları
            return _categoryRepository.GetById(id);
        }

        public Category GetByIdWithProducts(int id)
        {
            return _categoryRepository.GetByIdWithProducts(id);
        }

        public void Update(Category entity)
        {
            //İş Kuralları
            _categoryRepository.Update(entity);
        }

        public bool IsValidation(Category entity)
        {
            throw new System.NotImplementedException();
        }
    }
}