using StoreManager.DTO;

namespace StoreManager.Repositories;

public sealed class EmployeeRepository : RepositoryBase<Employee>
{
    public EmployeeRepository(StoreManagerDbContext context) : base(context) { }
}