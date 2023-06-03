using StoreManager.DTO;

namespace StoreManager.Repositories;

public sealed class OrderDetailsRepository : RepositoryBase<OrderDetails>
{
    public OrderDetailsRepository(StoreManagerDbContext context) : base(context) { }
}