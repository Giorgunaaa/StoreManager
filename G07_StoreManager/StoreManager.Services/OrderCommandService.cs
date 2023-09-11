using StoreManager.DTO;
using StoreManager.Facade.Interfaces.Repositories;

namespace StoreManager.Services;

public class OrderCommandService : CommandServiceBase<Order, IOrderRepository>
{
    private readonly IUnitOfWork _unitOfWork;

    public OrderCommandService(IUnitOfWork unitOfWork) : base(unitOfWork, unitOfWork.OrderRepository)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
}
