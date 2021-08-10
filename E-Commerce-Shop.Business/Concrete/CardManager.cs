using E_Commerce_Shop.Business.Abstract;
using E_Commerce_Shop.DataAccess.Abstract;
using E_Commerce_Shop.Entity;

namespace E_Commerce_Shop.Business.Concrete
{
    public class CardManager : ICardService
    {
        private readonly ICardRepository _cardRepository;

        public CardManager(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        public void AddToCard(string userId, int productId, int quantity)
        {
            var card = _cardRepository.GetCardWithItemsAndProductByUserId(userId);
            //Yeni eklenen ürün daha önceden sepete eklenmiş miydi?
            //Yeni eklenen ürünü sepete ekle()
            var index = card.CardItems.FindIndex(i => i.ProductId == productId);
            if (index >= 0)
            {
                card.CardItems[index].Quantity += quantity;
            }
            else
            {
                card.CardItems.Add(new CardItem()
                {
                    CardId = card.Id,
                    ProductId = productId,
                    Quantity = quantity
                });
            }
            _cardRepository.Update(card);
        }

        public void Create(string userId)
        {
            //İş kuralları veya Validator işlemlerini bu kısımda ekleyebilirsin. 
            _cardRepository.Create(new Card()
            {
                UserId = userId
            });
        }

        public void DeleteFromCart(string userId, int productId)
        {
            var card = _cardRepository.GetCardWithItemsAndProductByUserId(userId);
            _cardRepository.DeleteFromCart(card.Id, productId);
        }

        public Card GetCardWithItemsAndProductByUserId(string userId)
        {
            //İş kuralları
            return _cardRepository.GetCardWithItemsAndProductByUserId(userId);
        }
    }
}