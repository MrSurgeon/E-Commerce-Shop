namespace E_Commerce_Shop.WebUI.Models
{
    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public bool IsApproved { get; set; } = false;

    }
}