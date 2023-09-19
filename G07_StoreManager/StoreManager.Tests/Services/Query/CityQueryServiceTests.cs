using StoreManager.DTO;
using StoreManager.Facade.Interfaces.Repositories;
using StoreManager.Services;

namespace StoreManager.Tests.Services.Query;

public class CityQueryServiceTests : QueryUnitTestsBase
{
    //private City city;

    public CityQueryServiceTests(IUnitOfWork unitOfWork) : base(unitOfWork) { }

    [Theory]
    [InlineData("City 1")]
    [InlineData("City 2")]
    [InlineData("City 3")]
    [InlineData("City 4")]
    public void Get(string name)
    {
        City newCity = GetTestRecord(name);
        _unitOfWork.CityRepository.Insert(newCity);
        _unitOfWork.SaveChanges();

        CityQueryService cityQueryService = new(_unitOfWork);

        City retrievedCity = cityQueryService.Get(newCity.Name);

        Assert.True(retrievedCity.Name == newCity.Name);
    }
    [Theory]
    [InlineData("City 1")]
    [InlineData("City 2")]
    [InlineData("City 3")]
    [InlineData("City 4")]
    public void Set(string name)
    {
        CityQueryService cityQueryService = new(_unitOfWork);

        City newCity = GetTestRecord(name);
        List<City> expectedSet = new();
        expectedSet.Add(newCity);

        _unitOfWork.CityRepository.Insert(newCity);
        _unitOfWork.SaveChanges();

        var retrievedCitys = cityQueryService.Set();

        Assert.True(expectedSet.Last().Name == retrievedCitys.Last().Name 
                );
    }

    [Theory]
    [InlineData("City 1")]
    [InlineData("City 2")]
    [InlineData("City 3")]
    [InlineData("City 4")]
    public void ExpressionSet(string name)
    {
        CityQueryService cityQueryService = new(_unitOfWork);

        City newCity = GetTestRecord(name);
        List<City> expectedSet = new();
        expectedSet.Add(newCity);

        _unitOfWork.CityRepository.Insert(newCity);
        _unitOfWork.SaveChanges();

        var retrievedCitys = cityQueryService.Set(x => x.Name == name);

        Assert.True(expectedSet.Last().Name == retrievedCitys.Last().Name 
                );
    }

    private static City GetTestRecord(string name)
    {
        City city = new()
        {
            Name = name
        };
        return city;
    }
}

