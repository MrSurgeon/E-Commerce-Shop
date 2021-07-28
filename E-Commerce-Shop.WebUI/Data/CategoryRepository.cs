using System.Collections.Generic;
using System.Linq;
using E_Commerce_Shop.Entity;

namespace E_Commerce_Shop.WebUI.Data
{
    public static class CategoryRepository
    {
        static CategoryRepository()
        {
            _categories = new List<Category>()
                {
                    new Category(){CategoryId=1, Name = "Telefonlar"},
                    new Category(){CategoryId=2,Name = "Bilgisayarlar"},
                    new Category(){CategoryId=3,Name = "Elektronik"},
                    new Category(){CategoryId=4,Name = "Beyaz Eşya"},

                 };
        }
        private static List<Category> _categories;

        public static List<Category> Categories
        {
            get
            {
                return _categories;
            }
        }
        public static void AddCategory(Category category)
        {
            _categories.Add(category);
        }
        public static Category GetCategoryById(int categoryId)
        {
            var result = _categories.FirstOrDefault(p => p.CategoryId == categoryId);
            return result;
        }
    }
}