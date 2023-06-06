using StoreManager.DTO;
using StoreManager.Facade.Interfaces;

namespace StoreManager.Repositories;

public sealed class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
{
    public CategoryRepository(StoreManagerDbContext context) : base(context) { }
}