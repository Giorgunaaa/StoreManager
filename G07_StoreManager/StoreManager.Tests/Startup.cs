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
       .UseSqlServer("server = LAPTOP-KJO35V1P; database = G07_StoreManager; integrated security = true; TrustServerCertificate = true")
       .Options;

        services.AddScoped(_ => new StoreManagerDbContext(options));
        services.AddScoped<ICategoryRepository, CategoryRepository>();
    }
}