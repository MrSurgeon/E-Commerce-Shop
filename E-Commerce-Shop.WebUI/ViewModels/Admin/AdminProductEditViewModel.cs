using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using E_Commerce_Shop.Entity;

namespace E_Commerce_Shop.WebUI.ViewModels.Admin
{
    public class AdminProductEditViewModel
    {
        public int ProductId { get; set; }

        [Display(Name = "Ürün İsmi:", Prompt = "Ürün İsmi Giriniz")]
        [Required(ErrorMessage = "Name alanı girilmelidir.")]
        [StringLength(100, MinimumLength = 5,
        ErrorMessage = "Ürün İsmi 5-100 arasında karakter içermelidir.")]
        public string Name { get; set; }

        [Display(Name = "Ürün Url'i:", Prompt = "Url Yolunu Giriniz")]
        [Required(ErrorMessage = "Url alanı girilmelidir.")]
        public string Url { get; set; }

        [Range(0, 10000, ErrorMessage = "Fiyat değeri 0-10000 arasında girilebilir.")]
        [Required(ErrorMessage = "Price alanı girilmelidir.")]
        public double? Price { get; set; }

        [Required(ErrorMessage = "Description alanı girilmelidir.")]
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public List<Category> SelectedCategories { get; set; }
        public List<Category> AllCategories { get; set; }
        public bool IsApproved { get; set; }
        public bool IsHome { get; set; }


    }
}