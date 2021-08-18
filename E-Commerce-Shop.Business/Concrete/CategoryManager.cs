using System.Collections.Generic;
using System.Threading.Tasks;
using E_Commerce_Shop.Business.Abstract;
using E_Commerce_Shop.DataAccess.Abstract;
using E_Commerce_Shop.Entity;

namespace E_Commerce_Shop.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public string ErrorMessage { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public void Create(Category entity)
        {
            //İş Kuralları
            _unitOfWork.Categories.Create(entity);
            _unitOfWork.Save();
        }

        public void Delete(Category entity)
        {
            //İş Kuralları
            _unitOfWork.Categories.Delete(entity);
            _unitOfWork.Save();
        }

        public void DeleteProductFromCategory(int productId, int categoryId)
        {
            _unitOfWork.Categories.DeleteProductFromCategory(productId, categoryId);
        }

        public async Task<List<Category>> GetAllAsync()
        {
            //İş Kuralları
            return await _unitOfWork.Categories.GetAllAsync();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            //İş Kuralları
            return await _unitOfWork.Categories.GetByIdAsync(id);
        }

        public Category GetByIdWithProducts(int id)
        {
            return _unitOfWork.Categories.GetByIdWithProducts(id);
        }

        public void Update(Category entity)
        {
            //İş Kuralları
            _unitOfWork.Categories.Update(entity);
            _unitOfWork.Save();
        }

        public bool IsValidation(Category entity)
        {
            bool isValid = true;
            return isValid;
        }
    }
}