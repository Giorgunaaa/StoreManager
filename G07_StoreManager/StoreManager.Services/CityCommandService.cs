using StoreManager.DTO;
using StoreManager.Facade.Interfaces.Repositories;
using StoreManager.Facade.Interfaces.Services;

namespace StoreManager.Services;

public sealed class CityCommandService : ICityCommandService
{ 
    private readonly IUnitOfWork _unitOfWork;

    public CityCommandService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));

    public int Insert(City entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));

        _unitOfWork.CityRepository.Insert(entity);
        _unitOfWork.SaveChanges();

        return entity.Id;
    }

    public void Update(City entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));

        _unitOfWork.CityRepository.Update(entity);
        _unitOfWork.SaveChanges();
    }

    public void Delete(City entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));

        entity.IsDeleted = true;
        _unitOfWork.CityRepository.Update(entity);
        _unitOfWork.SaveChanges();
    }
}