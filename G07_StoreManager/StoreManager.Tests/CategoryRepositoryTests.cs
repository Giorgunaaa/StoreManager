using StoreManager.Facade.Interfaces;

namespace StoreManager.Tests;

public class CategoryRepositoryTests : RepositoryUnitTestBase
{
	private readonly ICategoryRepository _categoryRepository;

	public CategoryRepositoryTests(ICategoryRepository categoryRepository)
	{
		_categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
		//todo: research how to implement DI in unit tests.	

	}
}