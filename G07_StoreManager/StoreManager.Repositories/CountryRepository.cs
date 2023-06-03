using StoreManager.DTO;

namespace StoreManager.Repositories;

public sealed class CountryRepository : RepositoryBase<Country>
{
    public CountryRepository(StoreManagerDbContext context) : base(context) { }
}