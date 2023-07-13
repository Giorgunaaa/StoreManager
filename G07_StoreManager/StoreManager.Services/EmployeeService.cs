using StoreManager.DTO;
using StoreManager.Facade.Interfaces.Repositories;
using StoreManager.Facade.Interfaces.Services;
using System.Linq.Expressions;

namespace StoreManager.Services;

public sealed class EmployeeService : IEmployeeService
{
    private readonly IUnitOfWork _unitOfWork;

    public EmployeeService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public void Delete(Employee entity)
    {
        entity.IsDeleted = true;
        _unitOfWork.EmployeeRepository.Update(entity);
        _unitOfWork.SaveChanges();
    }

    public int? Insert(Employee entity)
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

    public Employee Get(params object[] id) => _unitOfWork.EmployeeRepository.Set().Single(x => x.Id == Convert.ToInt32(id) && !x.IsDeleted);

    public IEnumerable<Employee> Set(Expression<Func<Employee, bool>> predicate) => _unitOfWork.EmployeeRepository.Set(predicate);

    public IEnumerable<Employee> Set() => _unitOfWork.EmployeeRepository.Set();
}
