namespace StoreManager.Facade.Interfaces;

public interface IUnitOfWork : IDisposable
{
    ICategoryRepository CategoryRepository { get; }
    ICityRepository CityRepository { get; }
    ICountryRepository CountryRepository { get; }
    ICustomerRepository CustomerRepository { get; }
    IEmployeeRepository EmployeeRepository { get; }
    IOrderDetailsRepository OrderDetailsRepository { get; }
    IOrderRepository OrderRepository { get; }
    IProductRepository ProductRepository { get; }

    int SaveChanges();
}
