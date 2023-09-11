using StoreManager.DTO;
using StoreManager.Facade.Interfaces.Repositories;
using StoreManager.Facade.Interfaces.Services;

namespace StoreManager.Services;

public sealed class EmployeeCommandService : CommandServiceBase<Employee, IEmployeeRepository>, IEmployeeCommandService
{
    private readonly IUnitOfWork _unitOfWork;

    public EmployeeCommandService(IUnitOfWork unitOfWork) : base(unitOfWork, unitOfWork.EmployeeRepository)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
    override public void Update(Employee entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));

        Employee? employee = _unitOfWork.EmployeeRepository
            .Set()
            .SingleOrDefault(x => x.Id == entity.Id && !x.IsDeleted);

        entity.AccountDetails = employee?.AccountDetails;

        _unitOfWork.EmployeeRepository.Update(entity);
        _unitOfWork.SaveChanges();
    }
}
