using StoreManager.DTO;

namespace StoreManager.Repositories;

public sealed class CategoryRepository : RepositoryBase<Category>
{
    public CategoryRepository(StoreManagerDbContext context) : base(context) { }
}