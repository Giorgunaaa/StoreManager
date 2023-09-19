using StoreManager.DTO;
using StoreManager.Facade.Interfaces.Repositories;
using StoreManager.Facade.Interfaces.Services;

namespace StoreManager.Services;

public class OrderCommandService : CommandServiceBase<Order, IOrderRepository>, IOrderCommandService
{
    public OrderCommandService(IUnitOfWork unitOfWork) : base(unitOfWork, unitOfWork.OrderRepository)
    {

    }

    public override int Insert(Order entity)
    {
	    if (entity.OrderDetails == null || !entity.OrderDetails.Any())
	    {
		    throw new ArgumentException("Order is empty.");
	    }
	    return base.Insert(entity);
    }

    public override void Update(Order entity) => throw new NotSupportedException();

    public override void Delete(Order entity) => throw new NotSupportedException();
}
