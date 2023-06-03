using StoreManager.DTO;

namespace StoreManager.Repositories;

public sealed class CustomerRepository : RepositoryBase<Customer>
{
    public CustomerRepository(StoreManagerDbContext context) : base(context) { }
}