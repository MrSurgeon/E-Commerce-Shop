using E_Commerce_Shop.Entity;

namespace E_Commerce_Shop.DataAccess.Abstract
{
    public interface ICardRepository : IRepository<Card>
    {
        void DeleteFromCart(int cardId, int productId);
        Card GetCardWithItemsAndProductByUserId(string userId);
        void ClearCart(int cartId);
    }
}