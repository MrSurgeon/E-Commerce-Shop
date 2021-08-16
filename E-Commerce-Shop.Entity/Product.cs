using System;
using System.Collections.Generic;

namespace E_Commerce_Shop.Entity
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public double? Price { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public bool IsApproved { get; set; } = false;
        public bool IsHome { get; set; }
        public DateTime DateOfAdd { get; set; }

        public List<ProductCategory> ProductCategories { get; set; }
        public List<CardItem> CardItems { get; set; }
    }
}