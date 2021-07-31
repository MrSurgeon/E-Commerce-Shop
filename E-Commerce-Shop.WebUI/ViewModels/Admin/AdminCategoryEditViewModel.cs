using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using E_Commerce_Shop.Entity;

namespace E_Commerce_Shop.WebUI.ViewModels.Admin
{
    public class AdminCategoryEditViewModel
    {
        public int CategoryId { get; set; }

        [Display(Name = "İsim:", Prompt = "Ürün İsmi Giriniz")]
        [Required(ErrorMessage = "Name alanı girilmelidir.")]
        [StringLength(100, MinimumLength = 5,
       ErrorMessage = "Ürün İsmi 5-100 arasında karakter içermelidir.")]
        public string Name { get; set; }

        [Display(Name = "Url:", Prompt = "Url İsmi Giriniz")]
        [Required(ErrorMessage = "Url alanı girilmelidir.")]
        public string Url { get; set; }
        public List<Product> CategoryProducts { get; set; }
    }
}