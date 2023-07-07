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
        if (string.IsNullOrEmpty(username))
        {
            throw new ArgumentException("Username cannot be null or empty.", nameof(username));
        }

        if (string.IsNullOrEmpty(password))
        {
            throw new ArgumentException("Password cannot be null or empty.", nameof(password));
        }

        Employee? employee = _unitOfWork.EmployeeRepository
            .Set()
            .Where(x => x.AccountDetails!.Username == username && x.AccountDetails.Password == password)
            .SingleOrDefault();

        if (employee == null)
        {
            throw new InvalidOperationException("Incorrect username or password");
        }

        return new AuthorizedUserModel(employee.Id, employee.AccountDetails!.Username);
    }

    public AuthorizedUserModel Register(Employee employee, string password)
    {
        if (employee == null)
        {
            throw new ArgumentNullException(nameof(employee));
        }

        if (string.IsNullOrEmpty(password))
        {
            throw new ArgumentException("Password cannot be null or empty.", nameof(password));
        }
        
        employee.AccountDetails!.Password = password;

        _unitOfWork.EmployeeRepository.Insert(employee);
        _unitOfWork.SaveChanges();

        return new AuthorizedUserModel(employee.Id, employee.AccountDetails!.Username);
    }

    public void Update(Employee employee)
    {
        if (employee == null)
        {
            throw new ArgumentNullException(nameof(employee));
        }

        _unitOfWork.EmployeeRepository.Update(employee);
        _unitOfWork.SaveChanges();
    }

    public void Delete(int employeeId)
    {
        _unitOfWork.EmployeeRepository.Delete(employeeId);
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
