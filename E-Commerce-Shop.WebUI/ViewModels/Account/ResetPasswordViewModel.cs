using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Shop.WebUI.ViewModels.Account
{
    public class ResetPasswordViewModel
    {
        [Required]
        [Display(Name ="Şifre:")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name ="Tekrar Şifre:")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        public string Token { get; set; }
        public string Email { get; set; }
    }
}