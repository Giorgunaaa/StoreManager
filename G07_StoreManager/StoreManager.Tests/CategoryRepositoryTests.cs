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
    public void Test() => 
        Assert.True(true);
}