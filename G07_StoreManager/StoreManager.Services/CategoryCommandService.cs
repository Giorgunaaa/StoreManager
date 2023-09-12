using StoreManager.DTO;
using StoreManager.Facade.Interfaces.Repositories;
using StoreManager.Facade.Interfaces.Services;

namespace StoreManager.Services;

public sealed class CategoryCommandService : CommandServiceBase<Category, ICategoryRepository>, ICategoryCommandService
{
    private readonly IUnitOfWork _unitOfWork;

    public CategoryCommandService(IUnitOfWork unitOfWork) : base(unitOfWork, unitOfWork.CategoryRepository)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
}
