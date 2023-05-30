using System.Linq.Expressions;

namespace StoreManager.Facade.Interfaces;

public interface IRepository<TEntity> where TEntity : class
{
    TEntity Get(int id);
    IQueryable<TEntity> Set(Expression<Func<TEntity, bool>> predicate);
    IQueryable<TEntity> Set();

    void Insert(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
    void Delete(int id);

    int SaveChanges();
}
