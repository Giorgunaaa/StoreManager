using StoreManager.DTO;

namespace StoreManager.Facade.Interfaces.Services;

public interface ICategoryService : ICommandService<Category>, IQueryService<Category>
{ 

}