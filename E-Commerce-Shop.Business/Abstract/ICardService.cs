using E_Commerce_Shop.Entity;

namespace E_Commerce_Shop.Business.Abstract
{
    public interface ICardService : IValidator<Card>
    {
        void DeleteFromCart(string userId, int productId);
        void Create(string userId);
        Card GetCardWithItemsAndProductByUserId(string userId);
        bool AddToCard(string userId, int? productId, int? quantity);
        void ClearCard(int cartId);
    }
}