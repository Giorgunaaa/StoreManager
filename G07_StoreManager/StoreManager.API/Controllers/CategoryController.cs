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

	public CategoryController(ICategoryQueryService categoryQueryService, ICategoryCommandService categoryCommandService)
	{
		_categoryQueryService = categoryQueryService;
		_categoryCommandService = categoryCommandService;
	}

	//TODO: Modify to models.
	[HttpGet]
	[Route("{id}")]
	public Category Get(int id)
	{
		//return _categoryQueryService.Get(id);
		return new Category();
	}

	[HttpPost]
	public int Insert(CategoryModel model)
	{
		//_categoryCommandService.Insert(category);
		return 1;
	}
}