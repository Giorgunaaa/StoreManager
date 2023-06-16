using StoreManager.DTO;
using StoreManager.Facade.Interfaces;

namespace StoreManager.Tests;

public class CategoryRepositoryTests : RepositoryUnitTestBase
{
	private readonly ICategoryRepository _categoryRepository;

	public CategoryRepositoryTests(ICategoryRepository categoryRepository)
	{
		_categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
	}

	[Fact]
	public void Insert()
	{
		var category = GetTestRecord();
		_categoryRepository.Insert(category);
		_categoryRepository.SaveChanges();

		Assert.True(category.Id > 0);
	}

	[Fact]
	public void Update()
	{
		var newCategory = GetTestRecord();
		_categoryRepository.Insert(newCategory);
		_categoryRepository.SaveChanges();

		newCategory.Name = "New Category 1";
		newCategory.Description = "New Test Description.";
		_categoryRepository.Update(newCategory);
		_categoryRepository.SaveChanges();

		var updatedCategory = _categoryRepository.Set(x => x.Id == newCategory.Id).Single();

		Assert.True(updatedCategory.Name == "New Category 1" && updatedCategory.Description == "New Test Description.");
	}

	[Fact]
	public void Delete()
	{
		var newCategory = GetTestRecord();
		_categoryRepository.Insert(newCategory);
		_categoryRepository.SaveChanges();
		
		var existingCategory = _categoryRepository.Set(x => x.Id == newCategory.Id).Single();
		_categoryRepository.Delete(existingCategory);
		_categoryRepository.SaveChanges();
		
		Assert.Null(_categoryRepository.Set(x => x.Id == newCategory.Id).SingleOrDefault());
	}

	private static Category GetTestRecord()
	{
		Category category = new()
		{
			Name = "Category 1",
			Description = "Test Description."
		};
		return category;
	}
}