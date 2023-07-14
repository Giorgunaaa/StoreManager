using StoreManager.DTO;
using StoreManager.Facade.Interfaces.Repositories;
using StoreManager.Facade.Interfaces.Services;
using System.Linq.Expressions;

namespace StoreManager.Services;

public sealed class ProductService : IProductService
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductService(IUnitOfWork unitOfWork)
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

    public Product Get(params object[] id) => _unitOfWork.ProductRepository.Set().Single(x => x.Id == Convert.ToInt32(id) && !x.IsDeleted);
   
    public IEnumerable<Product> Set(Expression<Func<Product, bool>> predicate) => _unitOfWork.ProductRepository.Set(predicate);

    public IEnumerable<Product> Set() => _unitOfWork.ProductRepository.Set();
}




