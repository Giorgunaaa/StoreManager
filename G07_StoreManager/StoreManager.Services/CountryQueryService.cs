using StoreManager.DTO;
using StoreManager.Facade.Interfaces.Repositories;
using StoreManager.Facade.Interfaces.Services;
using System.Linq.Expressions;

namespace StoreManager.Services;

public class CountryQueryService : ICountryQueryService
{
    private readonly IUnitOfWork _unitOfWork;

    public CountryQueryService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));

    public Country Get(params object[] id) => _unitOfWork
        .CountryRepository
        .Set()
        .Single(x => x.Id == Convert.ToInt32(id) && !x.IsDeleted);

    public IEnumerable<Country> Set(Expression<Func<Country, bool>> predicate) => _unitOfWork
        .CountryRepository
        .Set(predicate);

    public IEnumerable<Country> Set() => _unitOfWork.CountryRepository.Set();
}
