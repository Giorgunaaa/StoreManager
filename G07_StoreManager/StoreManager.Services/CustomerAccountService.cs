using StoreManager.DTO;
using StoreManager.Facade.Exceptions;
using StoreManager.Facade.HelpExtentions;
using StoreManager.Facade.Interfaces.Repositories;
using StoreManager.Facade.Interfaces.Services;
using StoreManager.Models;

namespace StoreManager.Services;

public sealed class CustomerAccountService : ICustomerAccountService
{
    private readonly IUnitOfWork _unitOfWork;

    public CustomerAccountService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public AuthorizedUserModel Login(string username, string password)
    {
        if (string.IsNullOrEmpty(username)) throw new ArgumentException($"{nameof(username)} cannot be null or empty.", nameof(username));
        if (string.IsNullOrEmpty(password)) throw new ArgumentException($"{nameof(password)} cannot be null or empty.", nameof(password));

        Customer? customer = _unitOfWork.CustomerRepository
            .Set()
            .SingleOrDefault(x => x.AccountDetails != null &&
                                  x.AccountDetails.Username == username &&
                                  x.AccountDetails.Password == password.GetHash() &&
                                  !x.IsDeleted);

        return customer == null
            ? throw new LoginException(username)
            : new AuthorizedUserModel(customer.Id,customer.AccountDetails!.Username);
    }

    public void Register(int id, string username, string password)
    {
        if (username == null) throw new ArgumentNullException(nameof(username));
        if (password == null) throw new ArgumentNullException(nameof(password));

        Customer customer = _unitOfWork.CustomerRepository
            .Set()
            .Single(x => x.Id == id && !x.IsDeleted);

        customer.AccountDetails = new AccountDetails
        {
            Username = username,
            Password = password.GetHash()
        };
        _unitOfWork.CustomerRepository.Update(customer);
        _unitOfWork.SaveChanges();
    }

    public void UpdatePassword(int id, string oldPassword, string newPassword)
    {
        if (oldPassword == null) throw new ArgumentNullException(nameof(oldPassword));
        if (newPassword == null) throw new ArgumentNullException(nameof(newPassword));

        Customer customer = _unitOfWork.CustomerRepository
            .Set()
            .Single(x => x.Id == id && x.AccountDetails!.Password == oldPassword.GetHash() && !x.IsDeleted);

        customer.AccountDetails!.Password = newPassword.GetHash();

        _unitOfWork.CustomerRepository.Update(customer);
        _unitOfWork.SaveChanges();
    }

    public void Unregister(int customerId)
    {
        Customer customer = _unitOfWork.CustomerRepository
            .Set()
            .Single(x => x.Id == customerId && !x.IsDeleted);

        _unitOfWork.CustomerRepository.DeleteAccount(customer);
        _unitOfWork.SaveChanges();
    }
}

