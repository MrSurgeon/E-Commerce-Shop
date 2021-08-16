using E_Commerce_Shop.DataAccess.Abstract;

namespace E_Commerce_Shop.DataAccess.Concrete.EfCore
{
    public class UnitOfWork : IUnitOfWork
    {
        private ShopContext _context;

        public UnitOfWork(ShopContext context)
        {
            _context = context;
        }


        private EfCoreCardRepository _cardRepository;
        private EfCoreCategoryRepository _categoryRepository;
        private EfCoreOrderRepository _orderRepository;
        private EfCoreProductRepository _productRepository;

        public void Dispose()
        {
            _context.Dispose();
        }
        public void Save()
        {
            _context.SaveChanges();
        }

        public ICardRepository Cards => _cardRepository = _cardRepository ?? new EfCoreCardRepository(_context);

        public ICategoryRepository Categories => _categoryRepository = _categoryRepository ?? new EfCoreCategoryRepository(_context);

        public IOrderRepository Orders => _orderRepository = _orderRepository ?? new EfCoreOrderRepository(_context);

        public IProductRepository Products => _productRepository = _productRepository ?? new EfCoreProductRepository(_context);


    }
}