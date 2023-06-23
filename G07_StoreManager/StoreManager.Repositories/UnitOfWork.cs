using StoreManager.Facade.Interfaces;

namespace StoreManager.Repositories;

public class UnitOfWork : IUnitOfWork
{
	private readonly StoreManagerDbContext _context;
	private ICategoryRepository? _categoryRepository;
	private readonly ICityRepository _cityRepository;
	private readonly ICountryRepository _countryRepository;
	private readonly ICustomerRepository _customerRepository;
	private readonly IEmployeeRepository _employeeRepository;
	private readonly IOrderDetailsRepository _orderDetailsRepository;
	private readonly IOrderRepository _orderRepository;
	private readonly IProductRepository _productRepository;

	protected UnitOfWork(StoreManagerDbContext context)
	{
		_context = context ?? throw new ArgumentNullException(nameof(context));
		//_categoryRepository = new CategoryRepository(context);
		_cityRepository = new CityRepository(context);
		_countryRepository = new CountryRepository(context);
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

	public ICityRepository CityRepository => _cityRepository;

	public ICountryRepository CountryRepository => _countryRepository;

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
