using StoreManager.DTO;
using StoreManager.Facade.Interfaces.Repositories;
using StoreManager.Services;

namespace StoreManager.Tests;

public class EmployeeAccountServiceTests
{
    private readonly EmployeeAccountService _employeeAccountService;
    private readonly IUnitOfWork _unitOfWork;

    public EmployeeAccountServiceTests(IUnitOfWork unitOfWork)
    {
        _employeeAccountService = new EmployeeAccountService(unitOfWork);
        _unitOfWork = unitOfWork;
    }

    [Fact]
    public void Register()
    {
        Employee employee = new Employee()
        {
            FirstName = "name111",
            LastName = "lastname111",
            AccountDetails = new()
            {
                Password = "pass",
                Username = "user111"
            }
        };

        _employeeAccountService.Register(employee);

        Employee? expectedEmployee = _unitOfWork.EmployeeRepository
            .Set()
            .SingleOrDefault(x => x.Id == employee.Id);

        Assert.NotNull(expectedEmployee);

    }
}