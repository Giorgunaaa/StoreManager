using StoreManager.DTO;
using StoreManager.Facade.Interfaces.Repositories;
using StoreManager.Facade.Interfaces.Services;
using System.Linq.Expressions;

namespace StoreManager.Services;

public class CategoryQueryService : ICategoryQueryService
{
    private readonly IUnitOfWork _unitOfWork;

    public CategoryQueryService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public Category Get(params object[] id) => _unitOfWork.CategoryRepository.Set().Single(x => x.Id == Convert.ToInt32(id) && !x.IsDeleted);

    public IEnumerable<Category> Set(Expression<Func<Category, bool>> predicate) => _unitOfWork.CategoryRepository.Set(predicate);

    public IEnumerable<Category> Set() => _unitOfWork.CategoryRepository.Set();
}
