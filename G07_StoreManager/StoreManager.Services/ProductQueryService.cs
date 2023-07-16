using StoreManager.DTO;
using StoreManager.Facade.Interfaces.Repositories;
using StoreManager.Facade.Interfaces.Services;
using System.Linq.Expressions;

namespace StoreManager.Services;

public sealed class ProductQueryService : IProductQueryService
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductQueryService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public Product Get(params object[] id) => _unitOfWork.ProductRepository.Set().Single(x => x.Id == Convert.ToInt32(id) && !x.IsDeleted);

    public IEnumerable<Product> Set(Expression<Func<Product, bool>> predicate) => _unitOfWork.ProductRepository.Set(predicate);

    public IEnumerable<Product> Set() => _unitOfWork.ProductRepository.Set();
}