using System.Collections.Generic;
using E_Commerce_Shop.WebUI.Identity;

namespace E_Commerce_Shop.WebUI.ViewModels.AdminRole
{
    public class RoleEditViewModel
    {
        public string RoleName { get; set; }
        public string RoleId { get; set; }
        public List<User> Members { get; set; }
        public List<User> NonMembers { get; set; }

        public string[] IdsToAdd { get; set; }
        public string[] IdsToDelete { get; set; }

    }
}