using System;
using System.Threading.Tasks;

namespace E_Commerce_Shop.DataAccess.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        ICardRepository Cards { get; }
        ICategoryRepository Categories { get; }
        IOrderRepository Orders { get; }
        IProductRepository Products { get; }

        void Save();
        Task<int> SaveAsync();


    }
}