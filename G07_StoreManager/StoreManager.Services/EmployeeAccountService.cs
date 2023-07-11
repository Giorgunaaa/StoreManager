using StoreManager.DTO;
using StoreManager.Facade.Exceptions;
using StoreManager.Facade.HelpExtentions;
using StoreManager.Facade.Interfaces.Repositories;
using StoreManager.Facade.Interfaces.Services;
using StoreManager.Models;
using System.Linq.Expressions;

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
        if (string.IsNullOrEmpty(username)) throw new ArgumentException($"{nameof(username)} cannot be null or empty.", nameof(username));
        if (string.IsNullOrEmpty(password)) throw new ArgumentException($"{nameof(password)} cannot be null or empty.", nameof(password));

        Employee? employee = _unitOfWork.EmployeeRepository
            .Set()
            .SingleOrDefault(x => x.AccountDetails != null &&
                                  x.AccountDetails.Username == username &&
                                  x.AccountDetails.Password == password.GetHash() &&
                                  !x.IsDeleted);

        return employee == null
            ? throw new LoginException(username)
            : new AuthorizedUserModel(employee.Id, employee.AccountDetails!.Username);
    }

    public void Register(Employee employee)
    {
        if (employee == null) throw new ArgumentNullException(nameof(employee));
        if (employee.AccountDetails == null) throw new ArgumentNullException(nameof(employee.AccountDetails));

        employee.AccountDetails.Password = employee.AccountDetails.Password.GetHash();
        _unitOfWork.EmployeeRepository.Insert(employee);
        _unitOfWork.SaveChanges();
    }

    public void Update(Employee employee)
    {
        if (employee == null) throw new ArgumentNullException(nameof(employee));

        Employee? originalEmployee = _unitOfWork.EmployeeRepository
            .Set()
            .SingleOrDefault(x => x.Id == employee.Id &&
                                  !x.IsDeleted);
        if (originalEmployee == null) throw new NullReferenceException(nameof(originalEmployee));

        employee.AccountDetails = originalEmployee.AccountDetails;

        _unitOfWork.EmployeeRepository.Update(employee);
        _unitOfWork.SaveChanges();
    }

    public void Deactivate(int employeeId)
    {
        Employee? employee = _unitOfWork.EmployeeRepository
            .Set()
            .SingleOrDefault(x => x.Id == employeeId && !x.IsDeleted);
        if (employee == null) throw new NullReferenceException(nameof(employee));

        employee.IsDeleted = true;
        _unitOfWork.EmployeeRepository.Update(employee);
        _unitOfWork.SaveChanges();
    }

    Employee IQueryService<Employee>.Get(params object[] id)
    {
        throw new NotImplementedException();
    }

    IEnumerable<Employee> IQueryService<Employee>.Set(Expression<Func<Employee, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    IEnumerable<Employee> IQueryService<Employee>.Set()
    {
        throw new NotImplementedException();
    }
}
