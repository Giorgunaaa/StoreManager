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

    [Theory]
    [InlineData("Category 1", "Description 1")]
    [InlineData("Category 2", "Description 2")]
    [InlineData("Category 3", "Description 3")]
    [InlineData("Category 4", "Description 4")]
    public void Insert(string name, string description)
    {
        var category = GetTestRecord(name, description);
        _categoryRepository.Insert(category);
        _categoryRepository.SaveChanges();

        Assert.True(category.Id > 0);
    }

    [Theory]
    [InlineData("Category 1", "Description 1")]
    [InlineData("Category 2", "Description 2")]
    [InlineData("Category 3", "Description 3")]
    [InlineData("Category 4", "Description 4")]
    public void Update(string name, string description)
    {
        var newCategory = GetTestRecord(name, description);
        _categoryRepository.Insert(newCategory);
        _categoryRepository.SaveChanges();

        newCategory.Name = "New Category 1";
        newCategory.Description = "New Test Description.";
        _categoryRepository.Update(newCategory);
        _categoryRepository.SaveChanges();

        var updatedCategory = _categoryRepository.Set(x => x.Id == newCategory.Id).Single();

        Assert.True(updatedCategory.Name == "New Category 1" && updatedCategory.Description == "New Test Description.");
    }

    [Theory]
    [InlineData("Category 1", "Description 1")]
    [InlineData("Category 2", "Description 2")]
    [InlineData("Category 3", "Description 3")]
    [InlineData("Category 4", "Description 4")]
    public void Delete(string name, string description)
    {
        var newCategory = GetTestRecord(name, description);
        _categoryRepository.Insert(newCategory);
        _categoryRepository.SaveChanges();

        var existingCategory = _categoryRepository.Set(x => x.Id == newCategory.Id).Single();
        _categoryRepository.Delete(existingCategory);
        _categoryRepository.SaveChanges();

        Assert.Null(_categoryRepository.Set(x => x.Id == newCategory.Id).SingleOrDefault());
    }

    private static Category GetTestRecord(string name, string description)
    {
        Category category = new()
        {
            Name = name,
            Description = description
        };
        return category;
    }
}