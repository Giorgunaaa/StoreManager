using StoreManager.DTO;
using StoreManager.Facade.Interfaces;

namespace StoreManager.Repositories;

public sealed class CountryRepository : RepositoryBase<Country>, ICountryRepository
{
    public CountryRepository(StoreManagerDbContext context) : base(context) { }
}