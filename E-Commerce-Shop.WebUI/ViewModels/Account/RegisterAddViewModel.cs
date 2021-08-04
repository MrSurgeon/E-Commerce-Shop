using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Shop.WebUI.ViewModels.Account
{
    public class RegisterAddViewModel
    {
        [Required(ErrorMessage = "Kullanıcı İsmi Boş Geçilemez")]
        public string UserName { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required(ErrorMessage = "E-mail Alanı Boş Geçilemez")]
        [DataType(DataType.EmailAddress)]
        public string EMail { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string RePassword { get; set; }

    }
}