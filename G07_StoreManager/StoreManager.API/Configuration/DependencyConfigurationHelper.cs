﻿using Microsoft.EntityFrameworkCore;
using StoreManager.Facade.Interfaces.Repositories;
using StoreManager.Facade.Interfaces.Services;
using StoreManager.Repositories;
using StoreManager.Services;

namespace StoreManager.API.Configuration
{
    internal static class DependencyConfigurationHelper
    {
        public static void ConfigureDependency(this WebApplicationBuilder builder, ConfigurationManager configuration)
        {
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddTransient<ICategoryCommandService, CategoryCommandService>();
            builder.Services.AddDbContext<StoreManagerDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("StoreManager")));
        }
    }
}
