using StoreManager.DTO;
using StoreManager.Facade.Interfaces.Repositories;
using StoreManager.Facade.Interfaces.Services;

namespace StoreManager.Services;

public class OrderQueryService : QueryServiceBase<Order, IOrderRepository>, IOrderQueryService
{
    public OrderQueryService(IUnitOfWork unitOfWork) : base(unitOfWork.OrderRepository)
    {

    }

    public IEnumerable<Order> Set(DateTime fromDate, DateTime toDate) =>
        Set(x => x.OrderDate >= fromDate && x.OrderDate <= toDate);
}
