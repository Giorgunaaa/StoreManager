using StoreManager.DTO;
using StoreManager.Facade.Interfaces.Repositories;
using StoreManager.Facade.Interfaces.Services;

namespace StoreManager.Services;

public class OrderCommandService : CommandServiceBase<Order, IOrderRepository>, IOrderCommandService
{
    public OrderCommandService(IUnitOfWork unitOfWork) : base(unitOfWork, unitOfWork.OrderRepository)
    {

    }
}
