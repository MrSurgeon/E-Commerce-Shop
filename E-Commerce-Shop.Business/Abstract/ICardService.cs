using E_Commerce_Shop.Entity;

namespace E_Commerce_Shop.Business.Abstract
{
    public interface ICardService
    {
        void DeleteFromCart(string userId, int productId);
        void Create(string userId);
        Card GetCardWithItemsAndProductByUserId(string userId);
        void AddToCard(string userId, int productId, int quantity);


    }
}