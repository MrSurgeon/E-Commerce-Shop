using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Shop.WebUI.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required]
        [StringLength(300, MinimumLength = 10, ErrorMessage = "Ürün İsmi 10-300 arasında karakter sayısı girilebilir.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Ürün Fiyatı Girilmelidir.")]
        public double? Price { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "Resim Url'i eklenmelidir.")]
        public string ImageUrl { get; set; }
        public bool IsApproved { get; set; } = false;
        [Required(ErrorMessage = "Kategori bilgisi girilmelidir.")]
        public int? CategoryId { get; set; }
    }
}