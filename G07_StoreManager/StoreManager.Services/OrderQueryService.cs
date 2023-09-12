using StoreManager.DTO;
using StoreManager.Facade.Interfaces.Repositories;

namespace StoreManager.Services;

public class OrderQueryService : QueryServiceBase<Order, IOrderRepository>
{
	public OrderQueryService(IUnitOfWork unitOfWork) : base(unitOfWork.OrderRepository)
	{

	}

	public IEnumerable<Order> Set(DateTime fromDate, DateTime toDate) =>
		Set(x => x.OrderDate >= fromDate && x.OrderDate <= toDate);
}
