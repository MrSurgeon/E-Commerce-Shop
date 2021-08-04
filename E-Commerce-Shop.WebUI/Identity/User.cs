using Microsoft.AspNetCore.Identity;

namespace E_Commerce_Shop.WebUI.Identity
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}