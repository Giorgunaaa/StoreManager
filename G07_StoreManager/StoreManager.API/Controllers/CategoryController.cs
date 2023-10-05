using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StoreManager.DTO;
using StoreManager.Facade.Interfaces.Services;
using StoreManager.Models;

namespace StoreManager.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICategoryQueryService _categoryQueryService;
    private readonly ICategoryCommandService _categoryCommandService;
    private readonly IMapper _mapper;

    public CategoryController(ICategoryQueryService categoryQueryService, ICategoryCommandService categoryCommandService)
    {
        _categoryQueryService = categoryQueryService;
        _categoryCommandService = categoryCommandService;
        _mapper = ConfigureMapper().CreateMapper();
    }

    private MapperConfiguration ConfigureMapper()
    {
        return new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Category, CategoryModel>();
            cfg.CreateMap<CategoryModel, Category>();
        });
    }

    [HttpGet]
    [Route("{id}")]
    public CategoryModel Get(int id)
    {
        return _mapper.Map<CategoryModel>(_categoryQueryService.Get(id));
    }

    [HttpPost]
    public int Insert(CategoryModel model)
    {
        _categoryCommandService.Insert(_mapper.Map<Category>(model));

        return 1;
    }

    [HttpPut]
    [Route("{id}")]
    public int Update(int id, CategoryModel model)
    {
        var category = _mapper.Map<Category>(model);
        category.Id = id;
        _categoryCommandService.Update(category);

        return 1;
    }

    [HttpDelete]
    [Route("{id}")]
    public int Delete(int id)
    {
        _categoryCommandService.Delete(id);

        return 1;
    }
}