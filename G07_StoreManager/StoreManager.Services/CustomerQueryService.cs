using StoreManager.DTO;
using StoreManager.Facade.Interfaces.Repositories;
using StoreManager.Facade.Interfaces.Services;
using System.Linq.Expressions;

namespace StoreManager.Services;

public sealed class CustomerQueryService : ICustomerQueryService
{
    private readonly IUnitOfWork _unitOfWork;

    public CustomerQueryService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public Customer Get(params object[] id) => _unitOfWork.CustomerRepository.Set().Single(x => x.Id == Convert.ToInt32(id) && !x.IsDeleted);

    public IEnumerable<Customer> Set(Expression<Func<Customer, bool>> predicate) => _unitOfWork.CustomerRepository.Set(predicate);

    public IEnumerable<Customer> Set() => _unitOfWork.CustomerRepository.Set();
}

