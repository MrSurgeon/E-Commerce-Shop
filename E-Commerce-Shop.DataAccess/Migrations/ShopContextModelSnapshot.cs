﻿// <auto-generated />
using System;
using E_Commerce_Shop.DataAccess.Concrete.EfCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace E_Commerce_Shop.DataAccess.Migrations
{
    [DbContext(typeof(ShopContext))]
    partial class ShopContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.17")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("E_Commerce_Shop.Entity.Card", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("E_Commerce_Shop.Entity.CardItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CardId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CardId");

                    b.HasIndex("ProductId");

                    b.ToTable("CardItems");
                });

            modelBuilder.Entity("E_Commerce_Shop.Entity.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Url")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            Name = "Akıllı Telefon",
                            Url = "telefon"
                        },
                        new
                        {
                            CategoryId = 2,
                            Name = "Elektronik",
                            Url = "elektronik"
                        },
                        new
                        {
                            CategoryId = 3,
                            Name = "Bilgisayar",
                            Url = "bilgisayar"
                        },
                        new
                        {
                            CategoryId = 4,
                            Name = "Beyaz Eşya",
                            Url = "beyaz-esya"
                        });
                });

            modelBuilder.Entity("E_Commerce_Shop.Entity.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("City")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("ConversationId")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Email")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Note")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("OrderNumber")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("OrderState")
                        .HasColumnType("int");

                    b.Property<string>("PaymentId")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("PaymentType")
                        .HasColumnType("int");

                    b.Property<string>("Phone")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("UserId")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("E_Commerce_Shop.Entity.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("double");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("E_Commerce_Shop.Entity.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfAdd")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TIMESTAMP")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Description")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsHome")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(200) CHARACTER SET utf8mb4")
                        .HasMaxLength(200);

                    b.Property<double?>("Price")
                        .HasColumnType("double");

                    b.Property<string>("Url")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("ProductId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            DateOfAdd = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "İyi Telefon",
                            ImageUrl = "1.jfif",
                            IsApproved = true,
                            IsHome = false,
                            Name = "Samsung S4",
                            Price = 2000.0,
                            Url = "samsung-s4"
                        },
                        new
                        {
                            ProductId = 2,
                            DateOfAdd = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "İyi Telefon",
                            ImageUrl = "2.jfif",
                            IsApproved = true,
                            IsHome = false,
                            Name = "Samsung S5",
                            Price = 3000.0,
                            Url = "samsung-s5"
                        },
                        new
                        {
                            ProductId = 3,
                            DateOfAdd = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "İyi Telefon",
                            ImageUrl = "3.jfif",
                            IsApproved = false,
                            IsHome = false,
                            Name = "Samsung S6",
                            Price = 4000.0,
                            Url = "samsung-s6"
                        },
                        new
                        {
                            ProductId = 4,
                            DateOfAdd = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "İyi Telefon",
                            ImageUrl = "4.jfif",
                            IsApproved = false,
                            IsHome = false,
                            Name = "Samsung S7",
                            Price = 5000.0,
                            Url = "samsung-s7"
                        },
                        new
                        {
                            ProductId = 5,
                            DateOfAdd = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "İyi Telefon",
                            ImageUrl = "5.jfif",
                            IsApproved = true,
                            IsHome = false,
                            Name = "Samsung S8",
                            Price = 6000.0,
                            Url = "samsung-s8"
                        },
                        new
                        {
                            ProductId = 6,
                            DateOfAdd = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "İyi Telefon",
                            ImageUrl = "6.jfif",
                            IsApproved = true,
                            IsHome = false,
                            Name = "Samsung S9",
                            Price = 7000.0,
                            Url = "samsung-s9"
                        });
                });

            modelBuilder.Entity("E_Commerce_Shop.Entity.ProductCategory", b =>
                {
                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("CategoryId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductCategories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            ProductId = 1
                        },
                        new
                        {
                            CategoryId = 2,
                            ProductId = 1
                        },
                        new
                        {
                            CategoryId = 3,
                            ProductId = 1
                        },
                        new
                        {
                            CategoryId = 4,
                            ProductId = 1
                        },
                        new
                        {
                            CategoryId = 1,
                            ProductId = 2
                        },
                        new
                        {
                            CategoryId = 2,
                            ProductId = 2
                        },
                        new
                        {
                            CategoryId = 3,
                            ProductId = 2
                        },
                        new
                        {
                            CategoryId = 1,
                            ProductId = 3
                        },
                        new
                        {
                            CategoryId = 2,
                            ProductId = 3
                        },
                        new
                        {
                            CategoryId = 1,
                            ProductId = 4
                        },
                        new
                        {
                            CategoryId = 3,
                            ProductId = 4
                        },
                        new
                        {
                            CategoryId = 2,
                            ProductId = 5
                        },
                        new
                        {
                            CategoryId = 3,
                            ProductId = 5
                        },
                        new
                        {
                            CategoryId = 4,
                            ProductId = 5
                        },
                        new
                        {
                            CategoryId = 4,
                            ProductId = 6
                        });
                });

            modelBuilder.Entity("E_Commerce_Shop.Entity.CardItem", b =>
                {
                    b.HasOne("E_Commerce_Shop.Entity.Card", "Card")
                        .WithMany("CardItems")
                        .HasForeignKey("CardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("E_Commerce_Shop.Entity.Product", "Product")
                        .WithMany("CardItems")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("E_Commerce_Shop.Entity.OrderItem", b =>
                {
                    b.HasOne("E_Commerce_Shop.Entity.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("E_Commerce_Shop.Entity.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("E_Commerce_Shop.Entity.ProductCategory", b =>
                {
                    b.HasOne("E_Commerce_Shop.Entity.Category", "Category")
                        .WithMany("ProductCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("E_Commerce_Shop.Entity.Product", "Product")
                        .WithMany("ProductCategories")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
