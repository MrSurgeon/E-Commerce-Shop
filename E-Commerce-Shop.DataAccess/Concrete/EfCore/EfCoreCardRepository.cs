using System.Linq;
using E_Commerce_Shop.DataAccess.Abstract;
using E_Commerce_Shop.Entity;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_Shop.DataAccess.Concrete.EfCore
{
    public class EfCoreCardRepository : EfCoreGenericRepository<Card>, ICardRepository
    {
        public EfCoreCardRepository(ShopContext context) : base(context)
        {
        }
        private ShopContext ShopContext
        {
            get
            {
                return _context as ShopContext;
            }
        }
        public void ClearCart(int cartId)
        {
            var cmd = @"Delete From CardItems Where CardId=@p0";
            ShopContext.Database.ExecuteSqlRaw(cmd, cartId);
        }

        public void DeleteFromCart(int cardId, int productId)
        {
            var cmd = @"Delete From CardItems Where CardId=@p0 And ProductId=@p1";
            ShopContext.Database.ExecuteSqlRaw(cmd, cardId, productId);
        }

        public Card GetCardWithItemsAndProductByUserId(string userId)
        {
            return ShopContext.Cards
                    .Include(c => c.CardItems)
                    .ThenInclude(cI => cI.Product)
                    .FirstOrDefault(f => f.UserId == userId);
        }

        public override void Update(Card entity)
        {
            ShopContext.Cards.Update(entity);
            ShopContext.SaveChanges();
        }


    }
}