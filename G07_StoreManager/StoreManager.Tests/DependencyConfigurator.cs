using Microsoft.Extensions.DependencyInjection;
using StoreManager.Facade.Interfaces;
using StoreManager.Repositories;

namespace StoreManager.Tests;

public static class DependencyConfigurator
{
    public static IServiceProvider ConfigurateDependencies()
    {
        var services = new ServiceCollection();

        services.AddSingleton<ICategoryRepository, CategoryRepository>();

        return services.BuildServiceProvider();
    }
}