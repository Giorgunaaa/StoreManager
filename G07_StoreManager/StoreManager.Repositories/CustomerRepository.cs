using StoreManager.DTO;
using StoreManager.Facade.Interfaces;

namespace StoreManager.Repositories;

public sealed class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
{
    public CustomerRepository(StoreManagerDbContext context) : base(context) { }
}