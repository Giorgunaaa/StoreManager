using StoreManager.DTO;
using StoreManager.Facade.Interfaces;

namespace StoreManager.Repositories;

public sealed class OrderDetailsRepository : RepositoryBase<OrderDetails>, IOrderDetailsRepository
{
    public OrderDetailsRepository(StoreManagerDbContext context) : base(context) { }
}