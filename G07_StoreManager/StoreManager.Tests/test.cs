using StoreManager.DTO;
using StoreManager.Facade.Interfaces;
using Xunit.Sdk;

namespace StoreManager.Tests;

abstract class Tests<TEntity,TRepository> 
    where TEntity : class, new()
    where TRepository : IRepository<TEntity>
{
    private readonly TRepository _repository;

    public Tests(TRepository repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    protected abstract bool ValidateInsertEntry(TEntity entity);

    [Theory]
    [InlineData("Category 1", "Description 1")]
    [InlineData("Category 2", "Description 2")]
    [InlineData("Category 3", "Description 3")]
    [InlineData("Category 4", "Description 4")]
    public void Insert(string name, string description)
    {
        TEntity entity = new();
        _repository.Insert(entity);
        _repository.SaveChanges();

        Assert.True(ValidateInsertEntry(entity));
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

    [Theory]
    [InlineData("Category 1", "Description 1")]
    [InlineData("Category 2", "Description 2")]
    [InlineData("Category 3", "Description 3")]
    [InlineData("Category 4", "Description 4")]
    public void GetById(string name, string description)
    {
        var newCategory = GetTestRecord(name, description);
        _categoryRepository.Insert(newCategory);
        _categoryRepository.SaveChanges();

        var retrievedCategory = _categoryRepository.Get(1);

        Assert.True(retrievedCategory.Id == 1);
    }

    [Theory]
    [InlineData("Category 1", "Description 1")]
    [InlineData("Category 2", "Description 2")]
    [InlineData("Category 3", "Description 3")]
    [InlineData("Category 4", "Description 4")]
    public void Set(string name, string description) // Incomplete 
    {
        var newCategory = GetTestRecord(name, description);
        List<Category> expectedSet = new();
        expectedSet.Add(newCategory);

        _categoryRepository.Insert(newCategory);
        _categoryRepository.SaveChanges();

        var retrievedCategories = _categoryRepository.Set();

        Assert.True(expectedSet == retrievedCategories);
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