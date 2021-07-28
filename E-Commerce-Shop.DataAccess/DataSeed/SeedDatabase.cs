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
            using (var context = new ShopContext())
            {
                if (context.Database.GetPendingMigrations().Count() == 0)
                {
                    if (context.Categories.Count() == 0)
                    {
                        context.Categories.AddRange(Categories());
                    }
                    if (context.Products.Count() == 0)
                    {
                        context.Products.AddRange(Products());
                    }
                }
                context.SaveChanges();
            }
        }
        private static Category[] Categories()
        {
            return new Category[]{
                new Category(){Name="Akıllı Telefon"},
                new Category(){Name="Elektronik Eşya"},
                new Category(){Name="Bilgisayar"},
            };
        }
        private static Product[] Products()
        {
            return new Product[]{
                new Product(){Name="Samsung S4",Price=2000,Description="İyi Telefon",ImageUrl="1.jfif",IsApproved=true},
                new Product(){Name="Samsung S5",Price=3000,Description="İyi Telefon",ImageUrl="2.jfif",IsApproved=true},
                new Product(){Name="Samsung S6",Price=4000,Description="İyi Telefon",ImageUrl="3.jfif",IsApproved=false},
                new Product(){Name="Samsung S7",Price=5000,Description="İyi Telefon",ImageUrl="4.jfif",IsApproved=false},
                new Product(){Name="Samsung S8",Price=6000,Description="İyi Telefon",ImageUrl="5.jfif",IsApproved=true},
                new Product(){Name="Samsung S9",Price=7000,Description="İyi Telefon",ImageUrl="6.jfif",IsApproved=true},
            };
        }
    }
}