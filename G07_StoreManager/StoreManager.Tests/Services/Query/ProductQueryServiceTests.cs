using StoreManager.DTO;
using StoreManager.Facade.Interfaces.Repositories;
using StoreManager.Services;

namespace StoreManager.Tests.Services.Query;

public class ProductQueryServiceTests : QueryUnitTestsBase
{
    public ProductQueryServiceTests(IUnitOfWork unitOfWork) : base(unitOfWork) { }

    [Theory]
    [InlineData("Product 1", 1)]
    [InlineData("Product 2", 2)]
    [InlineData("Product 3", 3)]
    [InlineData("Product 4", 4)]
    public void Get(string name, decimal price)
    {
        Customer newProduct = GetTestRecord(name, price);
        _unitOfWork.ProductRepository.Insert(newProduct);
        _unitOfWork.SaveChanges();

        ProductQueryService productQueryService = new(_unitOfWork);

        Customer retrievedProduct = productQueryService.Get(newProduct.Id);

        Assert.True(retrievedProduct.Id == newProduct.Id);
    }
    [Theory]
    [InlineData("Product 1", 1)]
    [InlineData("Product 2", 2)]
    [InlineData("Product 3", 3)]
    [InlineData("Product 4", 4)]
    public void Set(string name, decimal price)
    {
        ProductQueryService productQueryService = new(_unitOfWork);
        Customer newProduct = GetTestRecord(name, price);
        List<Customer> expectedSet = new();
        expectedSet.Add(newProduct);

        _unitOfWork.ProductRepository.Insert(newProduct);
        _unitOfWork.SaveChanges();

        var retrievedProducts = productQueryService.Set();

        Assert.True(expectedSet.Last().Name == retrievedProducts.Last().Name &&
                    expectedSet.Last().Price == retrievedProducts.Last().Price
            );
    }
    [Theory]
    [InlineData("Product 1", 1)]
    [InlineData("Product 2", 2)]
    [InlineData("Product 3", 3)]
    [InlineData("Product 4", 4)]
    public void ExpressionSet(string name, decimal price)
    {
        ProductQueryService productQueryService = new(_unitOfWork);
        Customer newProduct = GetTestRecord(name, price);
        List<Customer> expectedSet = new();
        expectedSet.Add(newProduct);

        _unitOfWork.ProductRepository.Insert(newProduct);
        _unitOfWork.SaveChanges();

        var retrievedProducts = productQueryService.Set(x => x.Name == name);

        Assert.True(expectedSet.Last().Name == retrievedProducts.Last().Name &&
                    expectedSet.Last().Price == retrievedProducts.Last().Price
            );
    }
    private static Customer GetTestRecord(string name, decimal price)
    {
        Customer product = new()
        {
            Name = name,
            Price = price
        };
        return product;
    }
}

