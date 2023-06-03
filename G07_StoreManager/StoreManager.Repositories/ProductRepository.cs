using StoreManager.DTO;

namespace StoreManager.Repositories;

public sealed class ProductRepository : RepositoryBase<Product>
{
    public ProductRepository(StoreManagerDbContext context) : base(context) { }
}