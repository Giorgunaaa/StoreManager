using StoreManager.DTO;

namespace StoreManager.Repositories;

public sealed class CityRepository : RepositoryBase<City>
{
    public CityRepository(StoreManagerDbContext context) : base(context) { }
}