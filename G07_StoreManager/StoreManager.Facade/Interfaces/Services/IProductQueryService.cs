using StoreManager.DTO;

namespace StoreManager.Facade.Interfaces.Services;

public interface IProductQueryService : IQueryService<Customer>
{
    IEnumerable<Customer> Search(string text);
}
