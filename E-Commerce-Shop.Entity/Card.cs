using System.Collections.Generic;

namespace E_Commerce_Shop.Entity
{
    public class Card
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public List<CardItem> CardItems { get; set; }

    }
}