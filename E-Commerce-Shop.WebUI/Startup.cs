using System;
using System.IO;
using E_Commerce_Shop.Business.Abstract;
using E_Commerce_Shop.Business.Concrete;
using E_Commerce_Shop.DataAccess.Abstract;
using E_Commerce_Shop.DataAccess.Concrete.EfCore;
using E_Commerce_Shop.DataAccess.DataSeed;
using E_Commerce_Shop.Services.EmailService;
using E_Commerce_Shop.WebUI.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;

namespace E_Commerce_Shop.WebUI
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationContext>(opt =>
            opt.UseMySql("Server = localhost; Port = 3306; Database = ShopDb; Uid = root; Pwd = root; "));
            services.AddIdentity<User, IdentityRole>()
                    .AddEntityFrameworkStores<ApplicationContext>()
                    .AddDefaultTokenProviders();
            services.Configure<IdentityOptions>(opt =>
            {
                //Password
                opt.Password.RequireDigit = true;
                opt.Password.RequiredLength = 5;
                opt.Password.RequireLowercase = true;
                opt.Password.RequireUppercase = true;
                opt.Password.RequireNonAlphanumeric = true;

                //User
                opt.User.RequireUniqueEmail = true;
                opt.SignIn.RequireConfirmedEmail = true;
                opt.SignIn.RequireConfirmedPhoneNumber = false;

                //Lockout
                opt.Lockout.AllowedForNewUsers = true;
                opt.Lockout.MaxFailedAccessAttempts = 3;
                opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(2);

            });

            services.ConfigureApplicationCookie(opt =>
            {
                opt.LoginPath = "/account/login";
                opt.LogoutPath = "/account/logout";
                opt.AccessDeniedPath = "/account/accessdenied";
                opt.SlidingExpiration = true;
                opt.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                opt.Cookie = new CookieBuilder()
                {
                    HttpOnly = true,
                    Name = ".ECommerceShopApp.Security.Cookie",
                    SameSite = SameSiteMode.Strict
                };
            });

            var emailConfig = _configuration
                .GetSection("EmailConfiguration")
                .Get<EmailConfiguration>();
            services.AddSingleton(emailConfig);

            services.AddScoped<IEmailSender, EmailSender>();

            services.AddScoped<ICardRepository, EfCoreCardRepository>();
            services.AddScoped<IProductRepository, EfCoreProductRepository>();
            services.AddScoped<ICategoryRepository, EfCoreCategoryRepository>();
            services.AddScoped<ICardService, CardManager>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<IProductService, ProductManager>();
            services.AddControllersWithViews();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                Path.Combine(env.ContentRootPath, "node_modules")
                ),
                RequestPath = "/modules"
            });
            if (env.IsDevelopment())
            {
                SeedDatabase.Seed();
                app.UseDeveloperExceptionPage();
            }


            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //card Controller
                endpoints.MapControllerRoute(
                name: "addToCard",
                pattern: "card",
                 defaults: new
                 {
                     controller = "Card",
                     action = "Index"
                 }
                );

                endpoints.MapControllerRoute(
                name: "addToCard",
                pattern: "card/addtocard",
                 defaults: new
                 {
                     controller = "Card",
                     action = "AddToCard"
                 }
                );
                //adminuser Controller
                endpoints.MapControllerRoute(
                name: "adminuserlist",
                pattern: "adminuser/users",
                 defaults: new
                 {
                     controller = "AdminUser",
                     action = "UserList"
                 }
                );
                endpoints.MapControllerRoute(
                name: "adminuseredit",
                pattern: "adminuser/users/{id?}",
                 defaults: new
                 {
                     controller = "AdminUser",
                     action = "UserEdit"
                 }
                );
                //account controller
                endpoints.MapControllerRoute(
                     name: "accountaccessdenied",
                     pattern: "account/accessdenied",
                      defaults: new
                      {
                          controller = "Account",
                          action = "AccessDenied"
                      }
                 );
                //adminrole controller
                endpoints.MapControllerRoute(
                  name: "adminrolelist",
                  pattern: "adminrole/roles",
                   defaults: new
                   {
                       controller = "AdminRole",
                       action = "RoleList"
                   }
              );

                endpoints.MapControllerRoute(
                    name: "adminrolecreate",
                    pattern: "adminrole/rolecreate",
                     defaults: new
                     {
                         controller = "AdminRole",
                         action = "RoleCreate"
                     }
                );
                //adminrole/roles/1 =>adminrole/edit/1
                endpoints.MapControllerRoute(
                    name: "adminroleedit",
                    pattern: "adminrole/roles/{id?}",
                     defaults: new
                     {
                         controller = "AdminRole",
                         action = "RoleEdit"
                     }
                );
                //admin/categories
                endpoints.MapControllerRoute(
                  name: "admincategorylist",
                  pattern: "admin/categories",
                   defaults: new
                   {
                       controller = "Admin",
                       action = "CategoryList"
                   }
              );
                //admin/categories/1 => admin/EditCategory/1
                endpoints.MapControllerRoute(
                  name: "admincategorylist",
                  pattern: "admin/categories/{categoryId?}",
                   defaults: new
                   {
                       controller = "Admin",
                       action = "EditCategory"
                   }
              );
                //admin/products
                endpoints.MapControllerRoute(
                   name: "adminproductlist",
                   pattern: "admin/products",
                    defaults: new
                    {
                        controller = "Admin",
                        action = "ProductList"
                    }
               );
                //admin/products/1 => Admin/Edit/1
                endpoints.MapControllerRoute(
                    name: "adminedit",
                    pattern: "admin/products/{id?}",
                     defaults: new
                     {
                         controller = "Admin",
                         action = "EditProduct"
                     }
                );
                //localhost/search
                endpoints.MapControllerRoute(
                    name: "search",
                    pattern: "search",
                     defaults: new
                     {
                         controller = "Shop",
                         action = "Search"
                     }
                );
                //localhost/productUrl=samsung-s5
                endpoints.MapControllerRoute(
                    name: "productdetails",
                    pattern: "{productUrl}",
                    defaults: new
                    {
                        controller = "Shop",
                        action = "Details"
                    }
                );
                //products => Shop/List
                //products/Elektronik => Shop/List/Elektronik Category Name
                endpoints.MapControllerRoute(
                    name: "products",
                    pattern: "products/{category?}",
                    defaults: new
                    {
                        controller = "Shop",
                        action = "List"
                    }
                );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                );
            });

            SeedIdentity.Seed(userManager, roleManager, configuration).Wait();

        }
    }
}
