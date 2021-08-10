using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace E_Commerce_Shop.WebUI.Identity
{
    public static class SeedIdentity
    {

        public static async Task Seed(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            // Oluştur (User + Role) ===> Ekle Database User + Ekle Database Role ==> Role Ekle User 
            var userName = configuration["Data:AdminUser:username"];
            var email = configuration["Data:AdminUser:email"];
            var password = configuration["Data:AdminUser:password"];
            if (await userManager.FindByNameAsync("Admin") == null)
            {
                await roleManager.CreateAsync(new IdentityRole()
                {
                    Name = "Admin"
                });
                var user = new User()
                {
                    UserName = userName,
                    FirstName = "admin",
                    LastName = "admin",
                    EmailConfirmed = true,
                    Email = email
                };
                var result = await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    Console.WriteLine("user kaydedildi");
                    await userManager.AddToRoleAsync(user, "Admin");
                }
                else
                {
                    Console.WriteLine("user kaydedilemedi");
                }
            }
        }
    }
}