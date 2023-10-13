using AutoMapper;
using StoreManager.DTO;
using StoreManager.Models;

namespace StoreManager.API.MapperProfiles;

public class MapperProfileConfiguration : Profile
{
    public MapperProfileConfiguration()
    {
        CreateMap<Category, CategoryModel>().ReverseMap();
        CreateMap<Product, ProductModel>().ReverseMap();
        CreateMap<Country, CountryModel>().ReverseMap();
        CreateMap<City, CityModel>().ReverseMap();
    }
}
