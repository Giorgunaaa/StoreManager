using StoreManager.DTO;
using StoreManager.Facade.Interfaces.Repositories;
using StoreManager.Facade.Interfaces.Services;

namespace StoreManager.Services;

public sealed class CountryCommandService : ICountryCommandService
{
    private readonly IUnitOfWork _unitOfWork;

    public CountryCommandService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));

    public int Insert(Country entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));

        _unitOfWork.CountryRepository.Insert(entity);
        _unitOfWork.SaveChanges();

        return entity.Id;
    }

    public void Update(Country entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));

        _unitOfWork.CountryRepository.Update(entity);
        _unitOfWork.SaveChanges();
    }

    public void Delete(Country entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));

        entity.IsDeleted = true;
        _unitOfWork.CountryRepository.Update(entity);
        _unitOfWork.SaveChanges();
    }
}
