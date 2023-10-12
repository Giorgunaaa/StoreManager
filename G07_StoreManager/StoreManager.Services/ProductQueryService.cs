using StoreManager.DTO;
using StoreManager.Facade.Interfaces.Repositories;
using StoreManager.Facade.Interfaces.Services;

namespace StoreManager.Services;

public sealed class ProductQueryService : QueryServiceBase<Customer, IProductRepository>, IProductQueryService
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductQueryService(IUnitOfWork unitOfWork) : base(unitOfWork.ProductRepository)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public IEnumerable<Customer> Search(string text)
    {
        if (text == null) throw new ArgumentNullException(nameof(text));

        return _unitOfWork
            .ProductRepository
            .Set()
            .Where(x => x.Name.Contains(text) || x.Description.Contains(text));
    }
}
