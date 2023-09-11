using StoreManager.DTO;
using StoreManager.Facade.Interfaces.Repositories;

namespace StoreManager.Services;

public class OrderQueryService : QueryServiceBase<Order, IOrderRepository>
{
    private readonly IUnitOfWork _unitOfWork;

    public OrderQueryService(IUnitOfWork unitOfWork) : base(unitOfWork.OrderRepository)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
}
