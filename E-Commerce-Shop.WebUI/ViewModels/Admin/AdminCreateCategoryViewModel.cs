using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Shop.WebUI.ViewModels.Admin
{
    public class AdminCreateCategoryViewModel
    {
        [Display(Name = "Kategori İsmi:", Prompt = "Kategori İsmi Giriniz")]
        [Required(ErrorMessage = "Name alanı girilmelidir.")]
        [StringLength(100, MinimumLength = 5,
        ErrorMessage = "Kategori İsmi 5-100 arasında karakter içermelidir.")]
        public string Name { get; set; }

        [Display(Name = "Kategori Url:", Prompt = "Url İsmi Giriniz")]
        [Required(ErrorMessage = "Url alanı girilmelidir.")]
        public string Url { get; set; }
    }
}