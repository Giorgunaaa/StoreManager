using StoreManager.DTO;
using StoreManager.Facade.Interfaces.Repositories;
using StoreManager.Facade.Interfaces.Services;

namespace StoreManager.Services;

public sealed class CategoryQueryService : QueryServiceBase<Category, ICategoryRepository>, ICategoryQueryService
{
    public CategoryQueryService(IUnitOfWork unitOfWork) : base(unitOfWork.CategoryRepository)
    {
        
    }
}
