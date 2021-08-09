using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Shop.WebUI.ViewModels.AdminUser
{
    public class UserEditViewModel
    {
        public string Id { get; set; }
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string UserName { get; set; }

        public bool EmailConfirmed { get; set; }

        [Required]
        public string Email { get; set; }

        public List<string> SelectedRoles { get; set; }

    }
}