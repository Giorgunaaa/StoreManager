using StoreManager.DTO;
using StoreManager.Facade.Interfaces.Repositories;
using StoreManager.Facade.Interfaces.Services;
using System.Linq.Expressions;

namespace StoreManager.Services;

public sealed class CityQueryService : ICityQueryService
{
    private readonly IUnitOfWork _unitOfWork;

    public CityQueryService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));

    City IQueryService<City>.Get(params object[] id) => _unitOfWork
        .CityRepository
        .Set()
        .Single(x => x.Id == Convert.ToInt32(id) && !x.IsDeleted);

    public IEnumerable<City> Set(Expression<Func<City, bool>> predicate) => _unitOfWork
        .CityRepository
        .Set(predicate);

    IEnumerable<City> IQueryService<City>.Set() => _unitOfWork.CityRepository.Set();
}
