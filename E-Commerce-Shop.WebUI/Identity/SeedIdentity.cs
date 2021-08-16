using System;
using System.Linq;
using System.Threading.Tasks;
using E_Commerce_Shop.Business.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace E_Commerce_Shop.WebUI.Identity
{
    public static class SeedIdentity
    {

        public static async Task Seed(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, ICardService cardService, IConfiguration configuration)
        {

            var roles = configuration.GetSection("Data:Roles").GetChildren().Select(x => x.Value).ToArray();

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole()
                    {
                        Name = role
                    });
                }
            }

            var users = configuration.GetSection("Data:Users").GetChildren();

            foreach (var user in users)
            {
                var email = user.GetValue<string>("email");
                if (await userManager.FindByEmailAsync(email) == null)
                {
                    var username = user.GetValue<string>("username");
                    var password = user.GetValue<string>("password");
                    var firstname = user.GetValue<string>("firstname");
                    var lastname = user.GetValue<string>("lastname");
                    var role = user.GetValue<string>("role");

                    var person = new User()
                    {
                        UserName = username,
                        FirstName = firstname,
                        LastName = lastname,
                        EmailConfirmed = true,
                        Email = email
                    };
                    var result = await userManager.CreateAsync(person, password);
                    if (result.Succeeded)
                    {
                        Console.WriteLine("user kaydedildi");
                        var roleResult = await userManager.AddToRoleAsync(person, role);
                        if (!roleResult.Succeeded)
                        {
                            foreach (var error in result.Errors)
                            {
                                Console.WriteLine(error);
                            }
                        }
                        cardService.Create(person.Id);
                    }
                    else
                    {
                        Console.WriteLine("user kaydedilemedi");
                    }


                }
            }
        }
    }
}