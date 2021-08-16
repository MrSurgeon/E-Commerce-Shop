using E_Commerce_Shop.Business.Abstract;
using E_Commerce_Shop.DataAccess.Abstract;
using E_Commerce_Shop.Entity;

namespace E_Commerce_Shop.Business.Concrete
{
    public class CardManager : ICardService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CardManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool AddToCard(string userId, int? productId, int? quantity)
        {
            var card = _unitOfWork.Cards.GetCardWithItemsAndProductByUserId(userId);

            if (IsValidation(card))
            {
                if (productId == null)
                {
                    ErrorMessage += "Satın alınmak istenen ürün hakkında sorun oluştu. Tekrar deneyiniz";
                    return false;
                }
                if (_unitOfWork.Products.GetById((int)productId) == null)
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
            _unitOfWork.Cards.Update(card);
            _unitOfWork.Save();

            return true;
        }

        public void Create(string userId)
        {
            //İş kuralları veya Validator işlemlerini bu kısımda ekleyebilirsin. 
            _unitOfWork.Cards.Create(new Card()
            {
                UserId = userId
            });
            _unitOfWork.Save();
        }

        public void DeleteFromCart(string userId, int productId)
        {
            var card = _unitOfWork.Cards.GetCardWithItemsAndProductByUserId(userId);
            _unitOfWork.Cards.DeleteFromCart(card.Id, productId);

            _unitOfWork.Save();
        }

        public Card GetCardWithItemsAndProductByUserId(string userId)
        {
            //İş kuralları
            return _unitOfWork.Cards.GetCardWithItemsAndProductByUserId(userId);
        }

        public string ErrorMessage { get; set; }
        public bool IsValidation(Card entity)
        {
            bool isValid = true;

            return isValid;
        }

        public void ClearCard(int cartId)
        {
            _unitOfWork.Cards.ClearCart(cartId);
            _unitOfWork.Save();
        }
    }
}