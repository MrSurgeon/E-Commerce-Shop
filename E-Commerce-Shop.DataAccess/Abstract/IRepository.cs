using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_Commerce_Shop.DataAccess.Abstract
{
    public interface IRepository<T>
    {
        Task<T> GetByIdAsync(int id);
        Task<List<T>> GetAllAsync();
        void Create(T entity);
        Task CreateAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}