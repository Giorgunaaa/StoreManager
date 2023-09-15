using Microsoft.AspNetCore.Mvc;
using StoreManager.DTO;
using StoreManager.Facade.Interfaces.Services;

namespace StoreManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryCommandService _categoryCommandService;

        public CategoryController(ICategoryCommandService categoryCommandService)
        {
            _categoryCommandService = categoryCommandService;
        }

        public void Insert(Category category)
        {
            _categoryCommandService.Insert(category);
        }
    }
}
