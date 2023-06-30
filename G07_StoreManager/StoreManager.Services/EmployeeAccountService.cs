using StoreManager.DTO;
using StoreManager.Facade.Interfaces.Services;

namespace StoreManager.Services;

public sealed class EmployeeAccountService : IEmployeeAccountService
{
    public int? Insert(Employee entity)
    {
        throw new NotImplementedException();
    }

    public void Update(Employee entity)
    {
        throw new NotImplementedException();
    }
    
    void ICommandService<Employee>.Delete(Employee entity)
    {
        throw new NotImplementedException();
    }
}
