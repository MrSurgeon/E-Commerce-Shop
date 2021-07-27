using System.Collections.Generic;
using System.Linq;
using E_Commerce_Shop.WebUI.Models;

namespace E_Commerce_Shop.WebUI.Data
{
    public static class CategoryRepository
    {
        static CategoryRepository()
        {
            _categories = new List<Category>()
                {
                    new Category(){CategoryId=1, Name = "Telefonlar",Description="Telefon Kategorisi" },
                    new Category(){CategoryId=2,Name = "Bilgisayarlar",Description="Bilgisayar Kategorisi" },
                    new Category(){CategoryId=3,Name = "Elektronik",Description="Elektronik Kategorisi" },
                    new Category(){CategoryId=4,Name = "Beyaz Eşya",Description="Beyaz Eşya Kategorisi" },

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