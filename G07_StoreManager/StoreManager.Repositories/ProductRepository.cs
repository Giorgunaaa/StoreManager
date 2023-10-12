using StoreManager.DTO;
using StoreManager.Facade.Interfaces.Repositories;

namespace StoreManager.Repositories;

internal sealed class ProductRepository : RepositoryBase<Customer>, IProductRepository
{
    public ProductRepository(StoreManagerDbContext context) : base(context) { }
}