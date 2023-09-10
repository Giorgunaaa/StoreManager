using StoreManager.DTO;
using StoreManager.Facade.Interfaces.Repositories;

namespace StoreManager.Repositories;

internal sealed class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
{
    public CustomerRepository(StoreManagerDbContext context) : base(context) { }
}