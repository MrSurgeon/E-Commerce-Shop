using System.Collections.Generic;
using System.Linq;

namespace E_Commerce_Shop.WebUI.ViewModels.Card
{
    public class CardViewModel
    {
        public CardViewModel()
        {
            CardItems = new List<CardItemModel>();
        }
        public int CardId { get; set; }

        public List<CardItemModel> CardItems { get; set; }

        public double TotalPrice()
        {
            return CardItems.Sum(i => (i.Price * i.Quantity));
        }
    }

}