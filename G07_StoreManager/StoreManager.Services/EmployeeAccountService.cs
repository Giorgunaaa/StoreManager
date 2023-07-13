﻿using StoreManager.DTO;
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

    public void Register(int id, string username, string password)
    {
        if (username == null) throw new ArgumentNullException(nameof(username));
        if (password == null) throw new ArgumentNullException(nameof(password));

        Employee employee = _unitOfWork.EmployeeRepository
            .Set()
            .Single(x => x.Id == id && !x.IsDeleted);

        employee.AccountDetails = new AccountDetails
        {
            Password = password.GetHash(),
            Username = username
        };
        _unitOfWork.EmployeeRepository.Insert(employee);
        _unitOfWork.SaveChanges();
    }

    public void UpdatePassword(int id, string oldPassword, string newPassword)
    {
        if (oldPassword == null) throw new ArgumentNullException(nameof(oldPassword));
        if (newPassword == null) throw new ArgumentNullException(nameof(newPassword));

        Employee employee = _unitOfWork.EmployeeRepository
            .Set()
            .Single(x => x.Id == id && x.AccountDetails!.Password == oldPassword.GetHash() && !x.IsDeleted);

        employee.AccountDetails!.Password = newPassword;

        _unitOfWork.EmployeeRepository.Update(employee);
        _unitOfWork.SaveChanges();
    }

    public void Deactivate(int employeeId)
    {
        Employee employee = _unitOfWork.EmployeeRepository
            .Set()
            .Single(x => x.Id == employeeId && !x.IsDeleted);

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
