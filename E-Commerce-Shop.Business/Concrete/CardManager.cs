using E_Commerce_Shop.Business.Abstract;
using E_Commerce_Shop.DataAccess.Abstract;
using E_Commerce_Shop.Entity;

namespace E_Commerce_Shop.Business.Concrete
{
    public class CardManager : ICardService
    {
        private readonly ICardRepository _cardRepository;
        private readonly IProductRepository _productRepository;

        public CardManager(ICardRepository cardRepository, IProductRepository productRepository)
        {
            _cardRepository = cardRepository;
            _productRepository = productRepository;
        }
        public bool AddToCard(string userId, int? productId, int? quantity)
        {
            var card = _cardRepository.GetCardWithItemsAndProductByUserId(userId);

            if (IsValidation(card))
            {
                if (productId == null)
                {
                    ErrorMessage += "Satın alınmak istenen ürün hakkında sorun oluştu. Tekrar deneyiniz";
                    return false;
                }
                if (_productRepository.GetById((int)productId) == null)
                {
                    ErrorMessage += "Satın alınmak istenen ürün bulunamadı. Tekrar deneyiniz";
                    return false;
                }
                if (quantity == null && quantity < 0 && quantity > 5)
                {
                    ErrorMessage += "Girilen adet bilgisi satın alma gücüne göre çok fazla belirtilmiştir. Ürün adetini azaltınız.";
                    return false;
                }
            }
            //Yeni eklenen ürün daha önceden sepete eklenmiş miydi?
            //Yeni eklenen ürünü sepete ekle()
            var index = card.CardItems.FindIndex(i => i.ProductId == (int)productId);
            if (index >= 0)
            {
                card.CardItems[index].Quantity += (int)quantity;
            }
            else
            {
                card.CardItems.Add(new CardItem()
                {
                    CardId = card.Id,
                    ProductId = (int)productId,
                    Quantity = (int)quantity
                });
            }
            _cardRepository.Update(card);

            return true;
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

        public string ErrorMessage { get; set; }
        public bool IsValidation(Card entity)
        {
            bool isValid = true;

            return isValid;
        }

        public void ClearCard(int cartId)
        {
            _cardRepository.ClearCart(cartId);
        }
    }
}