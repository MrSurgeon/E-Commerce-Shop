using E_Commerce_Shop.Entity;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_Shop.DataAccess.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void SeedData(this ModelBuilder builder)
        {
            builder.Entity<Category>()
                    .HasData(new Category() { CategoryId = 1, Name = "Akıllı Telefon", Url = "telefon" },
                             new Category() { CategoryId = 2, Name = "Elektronik", Url = "elektronik" },
                             new Category() { CategoryId = 3, Name = "Bilgisayar", Url = "bilgisayar" },
                             new Category() { CategoryId = 4, Name = "Beyaz Eşya", Url = "beyaz-esya" }
                             );

            builder.Entity<Product>()
                    .HasData(new Product() { ProductId = 1, Name = "Samsung S4", Url = "samsung-s4", Price = 2000, Description = "İyi Telefon", ImageUrl = "1.jfif", IsApproved = true },
                             new Product() { ProductId = 2, Name = "Samsung S5", Url = "samsung-s5", Price = 3000, Description = "İyi Telefon", ImageUrl = "2.jfif", IsApproved = true },
                             new Product() { ProductId = 3, Name = "Samsung S6", Url = "samsung-s6", Price = 4000, Description = "İyi Telefon", ImageUrl = "3.jfif", IsApproved = false },
                             new Product() { ProductId = 4, Name = "Samsung S7", Url = "samsung-s7", Price = 5000, Description = "İyi Telefon", ImageUrl = "4.jfif", IsApproved = false },
                             new Product() { ProductId = 5, Name = "Samsung S8", Url = "samsung-s8", Price = 6000, Description = "İyi Telefon", ImageUrl = "5.jfif", IsApproved = true },
                             new Product() { ProductId = 6, Name = "Samsung S9", Url = "samsung-s9", Price = 7000, Description = "İyi Telefon", ImageUrl = "6.jfif", IsApproved = true }
                    );
            builder.Entity<ProductCategory>()
                    .HasData(
                        new ProductCategory() { ProductId = 1, CategoryId = 1 },
                        new ProductCategory() { ProductId = 1, CategoryId = 2 },
                        new ProductCategory() { ProductId = 1, CategoryId = 3 },
                        new ProductCategory() { ProductId = 1, CategoryId = 4 },
                        new ProductCategory() { ProductId = 2, CategoryId = 1 },
                        new ProductCategory() { ProductId = 2, CategoryId = 2 },
                        new ProductCategory() { ProductId = 2, CategoryId = 3 },
                        new ProductCategory() { ProductId = 3, CategoryId = 1 },
                        new ProductCategory() { ProductId = 3, CategoryId = 2 },
                        new ProductCategory() { ProductId = 4, CategoryId = 1 },
                        new ProductCategory() { ProductId = 4, CategoryId = 3 },
                        new ProductCategory() { ProductId = 5, CategoryId = 2 },
                        new ProductCategory() { ProductId = 5, CategoryId = 3 },
                        new ProductCategory() { ProductId = 5, CategoryId = 4 },
                        new ProductCategory() { ProductId = 6, CategoryId = 4 }
                    );
        }
    }
}