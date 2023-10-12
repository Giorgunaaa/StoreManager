using StoreManager.DTO;
using StoreManager.Facade.Interfaces.Repositories;
using StoreManager.Facade.Interfaces.Services;

namespace StoreManager.Services;

public sealed class CustomerQueryService : QueryServiceBase<Customer, ICustomerRepository>, ICustomerQueryService
{
    private readonly IUnitOfWork _unitOfWork;

    public CustomerQueryService(IUnitOfWork unitOfWork) : base(unitOfWork.CustomerRepository)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public IEnumerable<Customer> Search(string text)
    {
        throw new NotImplementedException();
    }
}
