using System.Collections.Generic;
using E_Commerce_Shop.WebUI.Models;

namespace E_Commerce_Shop.WebUI.ViewModels
{
    public class ProductViewModel
    {
        public Category Category { get; set; }
        public List<Product> Products { get; set; }
    }
}