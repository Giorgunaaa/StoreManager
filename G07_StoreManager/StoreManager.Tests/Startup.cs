using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StoreManager.Facade.Interfaces;
using StoreManager.Repositories;

namespace StoreManager.Tests;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        var options = new DbContextOptionsBuilder<StoreManagerDbContext>()
        .UseInMemoryDatabase(databaseName: "MyTestDatabase")
        .Options;

        services.AddScoped(_ => new StoreManagerDbContext(options));

        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<ICityRepository, CityRepository>();
        services.AddScoped<ICountryRepository, CountryRepository>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<IOrderDetailsRepository, OrderDetailsRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
    }
}