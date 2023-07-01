﻿using Microsoft.EntityFrameworkCore;
using StoreManager.DTO;
using StoreManager.Facade.Interfaces;

namespace StoreManager.Tests;

public class CustomerRepositoryTests : RepositoryUnitTestBase
{
    public CustomerRepositoryTests(IUnitOfWork unitOfWork) : base(unitOfWork) { }

    [Theory]
    [InlineData("Firstname 1", "LastName 1", "UserName 1")]
    [InlineData("Firstname 2", "LastName 2", "UserName 2")]
    [InlineData("Firstname 3", "LastName 3", "UserName 3")]
    [InlineData("Firstname 4", "LastName 4", "UserName 4")]
    public void Insert(string firstname, string lastName, string userName)
    {
        Customer customer = GetTestRecord(firstname, lastName, userName);
        _unitOfWork.CustomerRepository.Insert(customer);
        _unitOfWork.SaveChanges();

        Assert.True(customer.Id > 0);
    }

    [Theory]
    [InlineData("Firstname 1", "LastName 1", "UserName 1")]
    [InlineData("Firstname 2", "LastName 2", "UserName 2")]
    [InlineData("Firstname 3", "LastName 3", "UserName 3")]
    [InlineData("Firstname 4", "LastName 4", "UserName 4")]
    public void NotInserted(string firstname, string lastName, string userName)
    {
        Customer customer = GetTestRecord(firstname, lastName, userName);
        customer.Id = 1;

        Assert.Throws<ArgumentException>(() =>
        {
            _unitOfWork.CustomerRepository.Insert(customer);
            _unitOfWork.SaveChanges();
        });
    }

    [Theory]
    [InlineData("Firstname 1", "LastName 1", "UserName 1")]
    [InlineData("Firstname 2", "LastName 2", "UserName 2")]
    [InlineData("Firstname 3", "LastName 3", "UserName 3")]
    [InlineData("Firstname 4", "LastName 4", "UserName 4")]
    public void Update(string firstname, string lastName, string userName)
    {
        Customer newCustomer = GetTestRecord(firstname, lastName, userName);
        _unitOfWork.CustomerRepository.Insert(newCustomer);
        _unitOfWork.SaveChanges();

        newCustomer.UserName = $"New {userName}";
        _unitOfWork.CustomerRepository.Update(newCustomer);
        _unitOfWork.SaveChanges();

        Customer updatedCustomer = _unitOfWork.CustomerRepository.Set(x => x.Id == newCustomer.Id).Single();

        Assert.True(updatedCustomer.UserName == newCustomer.UserName);
    }

    [Theory]
    [InlineData("Firstname 1", "LastName 1", "UserName 1")]
    [InlineData("Firstname 2", "LastName 2", "UserName 2")]
    [InlineData("Firstname 3", "LastName 3", "UserName 3")]
    [InlineData("Firstname 4", "LastName 4", "UserName 4")]
    public void NotUpdated(string firstname, string lastName, string userName)
    {
        Customer newCustomer = GetTestRecord(firstname, lastName, userName);

        Assert.Throws<DbUpdateConcurrencyException>(() =>
        {
            _unitOfWork.CustomerRepository.Update(newCustomer);
            _unitOfWork.SaveChanges();
        });
    }

    [Theory]
    [InlineData("Firstname 1", "LastName 1", "UserName 1")]
    [InlineData("Firstname 2", "LastName 2", "UserName 2")]
    [InlineData("Firstname 3", "LastName 3", "UserName 3")]
    [InlineData("Firstname 4", "LastName 4", "UserName 4")]
    public void DeleteByObject(string firstname, string lastName, string userName)
    {
        Customer customer = GetTestRecord(firstname, lastName, userName);
        _unitOfWork.CustomerRepository.Insert(customer);
        _unitOfWork.SaveChanges();

        _unitOfWork.CustomerRepository.Delete(customer);
        _unitOfWork.SaveChanges();

        Assert.Null(_unitOfWork.CustomerRepository.Set(x => x.Id == customer.Id).SingleOrDefault());
    }

    [Theory]
    [InlineData("Firstname 1", "LastName 1", "UserName 1")]
    [InlineData("Firstname 2", "LastName 2", "UserName 2")]
    [InlineData("Firstname 3", "LastName 3", "UserName 3")]
    [InlineData("Firstname 4", "LastName 4", "UserName 4")]
    public void DeleteById(string firstname, string lastName, string userName)
    {
        Customer customer = GetTestRecord(firstname, lastName, userName);
        _unitOfWork.CustomerRepository.Insert(customer);
        _unitOfWork.SaveChanges();

        _unitOfWork.CustomerRepository.Delete(customer.Id);
        _unitOfWork.SaveChanges();

        Assert.Null(_unitOfWork.CustomerRepository.Set(x => x.Id == customer.Id).SingleOrDefault());
    }

    [Theory]
    [InlineData("Firstname 1", "LastName 1", "UserName 1")]
    [InlineData("Firstname 2", "LastName 2", "UserName 2")]
    [InlineData("Firstname 3", "LastName 3", "UserName 3")]
    [InlineData("Firstname 4", "LastName 4", "UserName 4")]
    public void GetById(string firstname, string lastName, string userName)
    {
        Customer newCustomer = GetTestRecord(firstname, lastName, userName);
        _unitOfWork.CustomerRepository.Insert(newCustomer);
        _unitOfWork.SaveChanges();

        Customer retrievedCustomer = _unitOfWork.CustomerRepository.Get(newCustomer.Id);

        Assert.True(retrievedCustomer.Id == newCustomer.Id);
    }

    [Theory]
    [InlineData("Firstname 1", "LastName 1", "UserName 1")]
    [InlineData("Firstname 2", "LastName 2", "UserName 2")]
    [InlineData("Firstname 3", "LastName 3", "UserName 3")]
    [InlineData("Firstname 4", "LastName 4", "UserName 4")]
    public void Set(string firstname, string lastName, string userName)
    {
        Customer newCustomer = GetTestRecord(firstname, lastName, userName);
        List<Customer> expectedSet = new();
        expectedSet.Add(newCustomer);

        _unitOfWork.CustomerRepository.Insert(newCustomer);
        _unitOfWork.SaveChanges();

        var retrievedCustomers = _unitOfWork.CustomerRepository.Set();

        Assert.True(expectedSet.Last().FirstName == retrievedCustomers.Last().FirstName &&
                    expectedSet.Last().LastName == retrievedCustomers.Last().LastName &&
                    expectedSet.Last().UserName == retrievedCustomers.Last().UserName
        );
    }

    private static Customer GetTestRecord(string firstname, string lastName, string userName)
    {
        Customer customer = new()
        {
            FirstName = firstname,
            LastName = lastName,
            UserName = userName,
        };
        return customer;
    }
}