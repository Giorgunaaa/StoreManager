using StoreManager.DTO;
using StoreManager.Facade.Interfaces.Repositories;
using StoreManager.Facade.Interfaces.Services;
namespace StoreManager.Services;

public class ProductCommandService : IProductCommandService
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductCommandService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public int Insert(Product product)
    {
        if (product == null) throw new ArgumentNullException(nameof(product));

        _unitOfWork.ProductRepository.Insert(product);
        _unitOfWork.SaveChanges();

        return product.Id;
    }

    public void Update(Product product)
    {
        if (product == null) throw new ArgumentNullException(nameof(product));

        _unitOfWork.ProductRepository.Update(product);
        _unitOfWork.SaveChanges();
    }

    public void Delete(Product product)
    {
        if (product == null) throw new ArgumentNullException(nameof(product));

        product.IsDeleted = true;
        _unitOfWork.ProductRepository.Update(product);
        _unitOfWork.SaveChanges();
    }
}
