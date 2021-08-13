namespace E_Commerce_Shop.WebUI.ViewModels.Card
{
    public class OrderModel
    {
        public OrderModel()
        {
            CardModel = new CardViewModel();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public string Note { get; set; }
        public string CardName { get; set; }
        public string CardNumber { get; set; }
        public string ExpirationMonth { get; set; }
        public string ExpirationYear { get; set; }
        public string Cvc { get; set; }


        public CardViewModel CardModel { get; set; }
    }

   
}