namespace StoreManager.Facade.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository CategoryRepository { get; }

        int SaveChanges();
    }
}
