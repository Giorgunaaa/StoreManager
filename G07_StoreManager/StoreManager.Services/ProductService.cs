using StoreManager.DTO;
using StoreManager.Facade.Exceptions;
using StoreManager.Facade.HelpExtentions;
using StoreManager.Facade.Interfaces.Repositories;
using StoreManager.Facade.Interfaces.Services;
using StoreManager.Models;
using System.Linq.Expressions;

namespace StoreManager.Services;

public sealed class ProductService : IProductCommandService
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }


    //public int? CreateProduct(Product product)
    //{
    //    if (product == null) throw new ArgumentNullException(nameof(product));

    //    _unitOfWork.ProductRepository.Insert(product);
    //    _unitOfWork.SaveChanges();
    //}

    //public void UpdateProduct(Product product)
    //{
    //    if (product == null) throw new ArgumentNullException(nameof(product));

    //    Product existingProduct = _unitOfWork.ProductRepository
    //        .Set()
    //        .Single(x => x.Id == product.Id && !x.IsDeleted);

    //    if (existingProduct == null)
    //        throw new ArgumentNullException(nameof(existingProduct));

    //    _unitOfWork.ProductRepository.Update(existingProduct);
    //    _unitOfWork.SaveChanges();
    //}

    //public void DeleteProduct(int productId)
    //{
    //    Product product = _unitOfWork.ProductRepository
    //        .Set()
    //        .Single(x => x.Id == productId && !x.IsDeleted);

    //    if (product == null)
    //        throw new ArgumentNullException(nameof(product));

    //    product.IsDeleted = true;

    //    _unitOfWork.ProductRepository.Update(product);
    //    _unitOfWork.SaveChanges();
    //}

    public int? Insert(Product product)
    {
        if (product == null) throw new ArgumentNullException(nameof(product));

        _unitOfWork.ProductRepository.Insert(product);
        _unitOfWork.SaveChanges();
    }

    public void Update(Product product)
    {
        if (product == null) throw new ArgumentNullException(nameof(product));

        Product existingProduct = _unitOfWork.ProductRepository
            .Set()
            .Single(x => x.Id == product.Id && !x.IsDeleted);

        if (existingProduct == null)
            throw new ArgumentNullException(nameof(existingProduct));

        _unitOfWork.ProductRepository.Update(existingProduct);
        _unitOfWork.SaveChanges();
    }

    public void Delete(int productId)
    {
        Product product = _unitOfWork.ProductRepository
            .Set()
            .Single(x => x.Id == product.Id && !x.IsDeleted);

        if (product == null)
            throw new ArgumentNullException(nameof(product));

        product.IsDeleted = true;

        _unitOfWork.ProductRepository.Update(product);
        _unitOfWork.SaveChanges();
    }
}




