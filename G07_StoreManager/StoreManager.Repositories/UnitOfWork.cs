using StoreManager.Facade.Interfaces;

namespace StoreManager.Repositories;

//todo: Modify all repository initialization with Lazy instance.
public class UnitOfWork : IUnitOfWork
{
    private readonly StoreManagerDbContext _context;
    private ICategoryRepository? _categoryRepository;
    private ICityRepository? _cityRepository;
    private readonly Lazy<ICountryRepository> _countryRepositoryLazy;
    private readonly ICustomerRepository _customerRepository;
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IOrderDetailsRepository _orderDetailsRepository;
    private readonly IOrderRepository _orderRepository;
    private readonly IProductRepository _productRepository;

    public UnitOfWork(StoreManagerDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        //_categoryRepository = new CategoryRepository(context);
        //_cityRepository = new CityRepository(context);
        _countryRepositoryLazy = new Lazy<ICountryRepository>(() => new CountryRepository(context));
        _customerRepository = new CustomerRepository(context);
        _employeeRepository = new EmployeeRepository(context);
        _orderDetailsRepository = new OrderDetailsRepository(context);
        _orderRepository = new OrderRepository(context);
        _productRepository = new ProductRepository(context);
    }

    //todo: we need to implement lazy loading for such properties.
    public ICategoryRepository CategoryRepository
    {
        get
        {
            if (_categoryRepository == null)
            {
                _categoryRepository = new CategoryRepository(_context);
            }
            return _categoryRepository;
        }
    }

    public ICityRepository CityRepository
    {
        get
        {
            return _cityRepository ??= new CityRepository(_context);
        }
    }

    public ICountryRepository CountryRepository => _countryRepositoryLazy.Value;

    public ICustomerRepository CustomerRepository => _customerRepository;

    public IEmployeeRepository EmployeeRepository => _employeeRepository;

    public IOrderDetailsRepository OrderDetailsRepository => _orderDetailsRepository;

    public IOrderRepository OrderRepository => _orderRepository;

    public IProductRepository ProductRepository => _productRepository;

    public int SaveChanges()
    {
        return _context.SaveChanges();
    }

    public void Dispose() => _context.Dispose();
}
