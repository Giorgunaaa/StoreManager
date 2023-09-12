using StoreManager.DTO;
using StoreManager.Facade.Interfaces.Repositories;
using StoreManager.Facade.Interfaces.Services;

namespace StoreManager.Services;

public sealed class CategoryQueryService : QueryServiceBase<Category, ICategoryRepository>, ICategoryQueryService
{
    private readonly IUnitOfWork _unitOfWork;

    public CategoryQueryService(IUnitOfWork unitOfWork) : base(unitOfWork.CategoryRepository)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
}
