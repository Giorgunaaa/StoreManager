using StoreManager.DTO;
using StoreManager.Facade.Interfaces.Repositories;
using StoreManager.Facade.Interfaces.Services;
using System.Linq.Expressions;

namespace StoreManager.Services;

public sealed class EmployeeQueryService : IEmployeeQueryService
{
    private readonly IUnitOfWork _unitOfWork;

    public EmployeeQueryService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public Employee Get(params object[] id) => _unitOfWork.EmployeeRepository.Set().Single(x => x.Id == Convert.ToInt32(id) && !x.IsDeleted);

    public IEnumerable<Employee> Set(Expression<Func<Employee, bool>> predicate) => _unitOfWork.EmployeeRepository.Set(predicate);

    public IEnumerable<Employee> Set() => _unitOfWork.EmployeeRepository.Set();
}
