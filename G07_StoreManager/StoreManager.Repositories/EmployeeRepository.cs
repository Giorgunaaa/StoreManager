using StoreManager.DTO;
using StoreManager.Facade.Interfaces;

namespace StoreManager.Repositories;

public sealed class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
{
    public EmployeeRepository(StoreManagerDbContext context) : base(context) { }
}