using Microsoft.EntityFrameworkCore;
using StoreManager.Facade.Interfaces.Repositories;
using StoreManager.Facade.Interfaces.Services;
using StoreManager.Repositories;
using StoreManager.Services;

namespace StoreManager.API.Configuration;

internal static class DependencyConfigurationHelper
{
    public static void ConfigureDependency(this WebApplicationBuilder builder, ConfigurationManager configuration)
    {
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        builder.Services.AddTransient<ICategoryQueryService, CategoryQueryService>();
        builder.Services.AddTransient<ICategoryCommandService, CategoryCommandService>();
        builder.Services.AddTransient<IProductQueryService, ProductQueryService>();
        builder.Services.AddTransient<IProductCommandService, ProductCommandService>();
<<<<<<< HEAD
        builder.Services.AddTransient<ICountryQueryService, CountryQueryService>();
        builder.Services.AddTransient<ICountryCommandService, CountryCommandService>();
=======
        builder.Services.AddTransient<ICityQueryService, CityQueryService>();
        builder.Services.AddTransient<ICityCommandService, CityCommandService>();
>>>>>>> store-manager-#19
        builder.Services.AddDbContext<StoreManagerDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("StoreManager")));
    }
}
