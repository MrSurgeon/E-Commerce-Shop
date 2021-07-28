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

        public void Create(Category entity)
        {
            //İş Kuralları
            _categoryRepository.Create(entity);
        }

        public void Delete(int id)
        {
            //İş Kuralları
            _categoryRepository.Delete(_categoryRepository.GetById(id));
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

        public void Update(Category entity)
        {
            //İş Kuralları
            _categoryRepository.Update(entity);
        }
    }
}