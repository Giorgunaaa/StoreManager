using Microsoft.EntityFrameworkCore;
using StoreManager.Facade.Interfaces;

namespace StoreManager.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository CategoryRepository { get; }

        int SaveChanges();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreManagerDbContext _context;
        private readonly ICategoryRepository _categoryRepository;

        protected UnitOfWork(StoreManagerDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _categoryRepository = new CategoryRepository(_context);
        }

        //todo: we need to implement lazy loading for such properties.
        public ICategoryRepository CategoryRepository => _categoryRepository;

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public void Dispose() => _context.Dispose();
    }
}
