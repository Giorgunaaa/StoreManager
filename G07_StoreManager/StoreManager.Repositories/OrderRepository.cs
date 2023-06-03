using StoreManager.DTO;

namespace StoreManager.Repositories;

public sealed class OrderRepository : RepositoryBase<Order>
{
    public OrderRepository(StoreManagerDbContext context) : base(context) { }
}