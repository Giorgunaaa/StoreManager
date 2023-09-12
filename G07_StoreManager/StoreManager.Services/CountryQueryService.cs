using StoreManager.DTO;
using StoreManager.Facade.Interfaces.Repositories;
using StoreManager.Facade.Interfaces.Services;

namespace StoreManager.Services;

public sealed class CountryQueryService : QueryServiceBase<Country, ICountryRepository>, ICountryQueryService
{
    private readonly IUnitOfWork _unitOfWork;

    public CountryQueryService(IUnitOfWork unitOfWork) : base(unitOfWork.CountryRepository)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
}
