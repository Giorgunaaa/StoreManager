using StoreManager.DTO;
using StoreManager.Facade.Interfaces.Repositories;
using StoreManager.Facade.Interfaces.Services;

namespace StoreManager.Services;

public sealed class EmployeeCommandService : IEmployeeCommandService
{
    private readonly IUnitOfWork _unitOfWork;

    public EmployeeCommandService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public int Insert(Employee entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));

        _unitOfWork.EmployeeRepository.Insert(entity);
        _unitOfWork.SaveChanges();

        return entity.Id;
    }

    public void Update(Employee entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));

        Employee? employee = _unitOfWork.EmployeeRepository
            .Set()
            .SingleOrDefault(x => x.Id == entity.Id && !x.IsDeleted);

        entity.AccountDetails = employee?.AccountDetails;

        _unitOfWork.EmployeeRepository.Update(entity);
        _unitOfWork.SaveChanges();
    }

    public void Delete(Employee entity)
    {
        entity.IsDeleted = true;
        _unitOfWork.EmployeeRepository.Update(entity);
        _unitOfWork.SaveChanges();
    }
}
