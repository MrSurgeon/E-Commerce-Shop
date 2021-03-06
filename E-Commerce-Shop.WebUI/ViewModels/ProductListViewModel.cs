using System.Collections.Generic;
using E_Commerce_Shop.Entity;
using E_Commerce_Shop.WebUI.Helpers;

namespace E_Commerce_Shop.WebUI.ViewModels
{
    public class ProductListViewModel
    {
        public PageInfo PageInfo { get; set; }
        public List<Product> Products { get; set; }
    }
}