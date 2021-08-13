using System.Linq;
using E_Commerce_Shop.DataAccess.Abstract;
using E_Commerce_Shop.Entity;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_Shop.DataAccess.Concrete.EfCore
{
    public class EfCoreCardRepository : EfCoreGenericRepository<Card, ShopContext>, ICardRepository
    {
        public void ClearCart(int cartId)
        {
            using (var db = new ShopContext())
            {
                var cmd = @"Delete From CardItems Where CardId=@p0";
                db.Database.ExecuteSqlRaw(cmd, cartId);
            }
        }

        public void DeleteFromCart(int cardId, int productId)
        {
            using (var db = new ShopContext())
            {
                var cmd = @"Delete From CardItems Where CardId=@p0 And ProductId=@p1";
                db.Database.ExecuteSqlRaw(cmd, cardId, productId);
            }
        }

        public Card GetCardWithItemsAndProductByUserId(string userId)
        {
            using (var db = new ShopContext())
            {
                return db.Cards
                        .Include(c => c.CardItems)
                        .ThenInclude(cI => cI.Product)
                        .FirstOrDefault(f => f.UserId == userId);
            }
        }

        public override void Update(Card entity)
        {
            using (var context = new ShopContext())
            {
                context.Cards.Update(entity);
                context.SaveChanges();
            }
        }


    }
}