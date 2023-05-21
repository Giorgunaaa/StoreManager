using Microsoft.EntityFrameworkCore;
using StoreManager.DTO;

namespace StoreManager.Repositories;

public class StoreManagerDbContext : DbContext
{
    private const string ConnectionString =
        @"server = LAPTOP-KJO35V1P; database = G07_StoreManager; integrated security = true; TrustServerCertificate = true";

    public StoreManagerDbContext() : base(GetOptions()) { }

    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<Category> Categories { get; set; } = null!;

    private static DbContextOptions GetOptions()
    {
        var options = new DbContextOptionsBuilder();
        options.UseSqlServer(ConnectionString);
        return options.Options;
    }
}