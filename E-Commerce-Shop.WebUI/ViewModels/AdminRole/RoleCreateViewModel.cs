using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Shop.WebUI.ViewModels.AdminRole
{
    public class RoleCreateViewModel
    {
        [Required(ErrorMessage ="Lütfen role ismini giriniz.")]
        public string Name { get; set; }
    }
}