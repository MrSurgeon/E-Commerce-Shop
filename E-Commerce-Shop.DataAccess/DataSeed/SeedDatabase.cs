using System.Linq;
using E_Commerce_Shop.DataAccess.Concrete.EfCore;
using E_Commerce_Shop.Entity;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_Shop.DataAccess.DataSeed
{
    public static class SeedDatabase
    {
        public static void Seed()
        {
            // using (var context = new ShopContext())
            // {
            //     if (context.Database.GetPendingMigrations().Count() == 0)
            //     {
            //         if (context.Categories.Count() == 0)
            //         {
            //             context.Categories.AddRange(Categories);

            //         }
            //         if (context.Products.Count() == 0)
            //         {
            //             context.Products.AddRange(Products);
            //             context.AddRange(ProductsCategories);
            //         }
            //     }
            //     context.SaveChanges();
            // }
        }
        private static Category[] Categories =
        {
            new Category(){Name="Akıllı Telefon",Url="telefon"},
            new Category(){Name="Elektronik",Url="elektronik"},
            new Category(){Name="Bilgisayar",Url="bilgisayar"},
        };
        private static Product[] Products =
        {
            new Product(){Name="Samsung S4",Url="samsung-s4",Price=2000,Description="İyi Telefon",ImageUrl="1.jfif",IsApproved=true},
            new Product(){Name="Samsung S5",Url="samsung-s5",Price=3000,Description="İyi Telefon",ImageUrl="2.jfif",IsApproved=true},
            new Product(){Name="Samsung S6",Url="samsung-s6",Price=4000,Description="İyi Telefon",ImageUrl="3.jfif",IsApproved=false},
            new Product(){Name="Samsung S7",Url="samsung-s7",Price=5000,Description="İyi Telefon",ImageUrl="4.jfif",IsApproved=false},
            new Product(){Name="Samsung S8",Url="samsung-s8",Price=6000,Description="İyi Telefon",ImageUrl="5.jfif",IsApproved=true},
            new Product(){Name="Samsung S9",Url="samsung-s9",Price=7000,Description="İyi Telefon",ImageUrl="6.jfif",IsApproved=true},

        };
        private static ProductCategory[] ProductsCategories =
        {
            new ProductCategory() { Product = Products[0],Category = Categories[0]},
            new ProductCategory() { Product = Products[0],Category = Categories[1]},
            new ProductCategory() { Product = Products[1],Category = Categories[0]},
            new ProductCategory() { Product = Products[1],Category = Categories[1]},
            new ProductCategory() { Product = Products[2],Category = Categories[0]},
            new ProductCategory() { Product = Products[2],Category = Categories[1]},
            new ProductCategory() { Product = Products[3],Category = Categories[0]},
            new ProductCategory() { Product = Products[3],Category = Categories[2]},
            new ProductCategory() { Product = Products[4],Category = Categories[0]},
            new ProductCategory() { Product = Products[5],Category = Categories[0]},

        };
    }
}