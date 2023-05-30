using Microsoft.EntityFrameworkCore;
using StoreManager.DTO;

namespace StoreManager.Repositories;

public class CategoryRepository
{
    private readonly StoreManagerDbContext _context;

    public CategoryRepository(StoreManagerDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public Category? Get(int id)
    {
        return _context.Find<Category>(id);
    }

    public IEnumerable<Category> Set(Func<Category, bool> predicate)
    {
        return _context.Categories.Where(predicate);
    }

    public void Insert(Category category)
    {
        _context.Categories.Add(category);
        _context.SaveChanges();
    }

    public void Update(Category category)
    {
        var entityEntry = _context.Entry(category);
        if (entityEntry == null || entityEntry.State == EntityState.Detached)
        {
            _context.Categories.Add(category);
        }
        _context.SaveChanges();
    }

    public void Delete(Category category)
    {
        _context.Categories.Remove(category);
        _context.SaveChanges();
    }
}
