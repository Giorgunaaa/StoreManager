using StoreManager.DTO;

namespace StoreManager.Facade.Interfaces.Services;

public interface IProductService : IQueryService<Product>, ICommandService<Product>
{

}
