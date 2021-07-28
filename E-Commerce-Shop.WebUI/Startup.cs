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
            services.AddScoped<IProductRepository, EfCoreProductRepository>();
            services.AddScoped<IProductService, ProductManager>();
            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(env.ContentRootPath, "node_modules")),
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
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                );
            });
        }
    }
}
