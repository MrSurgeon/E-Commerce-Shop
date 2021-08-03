using System.IO;
using E_Commerce_Shop.Business.Abstract;
using E_Commerce_Shop.Business.Concrete;
using E_Commerce_Shop.DataAccess.Abstract;
using E_Commerce_Shop.DataAccess.Concrete.EfCore;
using E_Commerce_Shop.DataAccess.DataSeed;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;

namespace E_Commerce_Shop.WebUI
{
    public class Startup
    {

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ICategoryRepository, EfCoreCategoryRepository>();
            services.AddScoped<IProductRepository, EfCoreProductRepository>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<IProductService, ProductManager>();
            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
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
        }
    }
}
