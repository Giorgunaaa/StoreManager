using StoreManager.DTO;
using StoreManager.Facade.Interfaces.Repositories;
using StoreManager.Models;
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

    [Theory]
    [InlineData("FirstName 1", "LastName 1", "User 1", "Password 1")]
    [InlineData("FirstName 2", "LastName 2", "User 2", "Password 2")]
    [InlineData("FirstName 3", "LastName 3", "User 3", "Password 3")]
    [InlineData("FirstName 4", "LastName 4", "User 4", "Password 4")]
    public void Login(string firstName, string lastName, string username, string password)
    {
        Employee employee = new Employee()
        {
            FirstName = firstName,
            LastName = lastName,
            AccountDetails = new()
            {
                Password = password,
                Username = username
            }
        };

        _employeeAccountService.Register(employee);
        AuthorizedUserModel model = _employeeAccountService.Login(username, password);

        Assert.NotNull(model);
        Assert.Equal(model.Username, username);
    }

    [Theory]
    [InlineData("FirstName 5", "LastName 5", "User 5", "Password 5")]
    [InlineData("FirstName 6", "LastName 6", "User 6", "Password 6")]
    [InlineData("FirstName 7", "LastName 7", "User 7", "Password 7")]
    [InlineData("FirstName 8", "LastName 8", "User 8", "Password 8")]
    public void Register(string firstName, string lastName, string username, string password)
    {
        Employee employee = new Employee()
        {
            FirstName = firstName,
            LastName = lastName,
            AccountDetails = new()
            {
                Password = password,
                Username = username
            }
        };

        _employeeAccountService.Register(employee);

        Employee? expectedEmployee = _unitOfWork.EmployeeRepository
            .Set()
            .SingleOrDefault(x => x.Id == employee.Id);

        Assert.NotNull(expectedEmployee);
    }

    [Theory]
    [InlineData("FirstName 9", "LastName 9", "User 9", "Password 9")]
    [InlineData("FirstName 10", "LastName 10", "User 10", "Password 10")]
    [InlineData("FirstName 11", "LastName 11", "User 11", "Password 11")]
    [InlineData("FirstName 12", "LastName 12", "User 12", "Password 12")]
    public void Update(string firstName, string lastName, string username, string password)
    {
        Employee employee = new Employee()
        {
            FirstName = firstName,
            LastName = lastName,
            AccountDetails = new()
            {
                Password = password,
                Username = username
            }
        };

        _employeeAccountService.Register(employee);

        employee.FirstName = $"New {firstName}";
        employee.LastName = $"New {lastName}";

        _employeeAccountService.Update(employee);

        Assert.True(employee.FirstName == $"New {firstName}" && employee.LastName == $"New {lastName}");
    }

    [Theory]
    [InlineData("FirstName 13", "LastName 13", "User 13", "Password 13")]
    [InlineData("FirstName 14", "LastName 14", "User 14", "Password 14")]
    [InlineData("FirstName 15", "LastName 15", "User 15", "Password 15")]
    [InlineData("FirstName 16", "LastName 16", "User 16", "Password 16")]
    public void Deactivate(string firstName, string lastName, string username, string password)
    {
        Employee employee = new Employee()
        {
            FirstName = firstName,
            LastName = lastName,
            AccountDetails = new()
            {
                Password = password,
                Username = username
            }
        };

        _employeeAccountService.Register(employee);
        _employeeAccountService.Unregister(employee.Id);

        Assert.True(employee.IsDeleted);
    }
}