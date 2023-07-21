using StoreManager.DTO;
using StoreManager.Facade.Interfaces.Repositories;
using StoreManager.Facade.Interfaces.Services;

namespace StoreManager.Services;

public sealed class CustomerCommandService : ICustomerCommandService
{
    private readonly IUnitOfWork _unitOfWork;

    public CustomerCommandService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public int Insert(Customer entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));

        _unitOfWork.CustomerRepository.Insert(entity);
        _unitOfWork.SaveChanges();

        return entity.Id;
    }

    public void Update(Customer entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));

        Customer? customer = _unitOfWork.CustomerRepository
            .Set()
            .SingleOrDefault(x => x.Id == entity.Id && !x.IsDeleted);

        entity.AccountDetails = customer?.AccountDetails;

        _unitOfWork.CustomerRepository.Update(entity);
        _unitOfWork.SaveChanges();
    }

    public void Delete(Customer entity)
    {
        entity.IsDeleted = true;
        _unitOfWork.CustomerRepository.Update(entity);
        _unitOfWork.SaveChanges();
    }
}

