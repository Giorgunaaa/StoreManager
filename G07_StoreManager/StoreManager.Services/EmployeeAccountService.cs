using System.Linq.Expressions;
using StoreManager.DTO;
using StoreManager.Facade.Interfaces.Repositories;
using StoreManager.Facade.Interfaces.Services;
using StoreManager.Models;

namespace StoreManager.Services;

public sealed class EmployeeAccountService : IEmployeeAccountService
{
    private readonly IUnitOfWork _unitOfWork;

    public EmployeeAccountService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public AuthorizedUserModel Login(string username, string password)
    {
        return _unitOfWork
            .EmployeeRepository
            .Set()
            .Select(x => new AuthorizedUserModel(x.Id, x.Username))
            .Single();
    }

    public Employee Get(params object[] id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Employee> Set(Expression<Func<Employee, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Employee> Set()
    {
        throw new NotImplementedException();
    }
}
