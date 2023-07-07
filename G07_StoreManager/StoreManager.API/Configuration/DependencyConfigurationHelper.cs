using Microsoft.EntityFrameworkCore;
using StoreManager.Facade.Interfaces.Repositories;
using StoreManager.Repositories;

namespace StoreManager.API.Configuration
{
    internal static class DependencyConfigurationHelper
    {
        public static void ConfigureDependency(this WebApplicationBuilder builder, ConfigurationManager configuration)
        {
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddDbContext<StoreManagerDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("StoreManager")));
        }
    }
}
