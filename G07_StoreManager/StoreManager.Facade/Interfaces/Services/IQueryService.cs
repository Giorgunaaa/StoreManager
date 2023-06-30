using System.Linq.Expressions;

namespace StoreManager.Facade.Interfaces.Services;

public interface IQueryService<TEntity>
{
    TEntity Get(params object[] id);
    IEnumerable<TEntity> Set(Expression<Func<TEntity, bool>> predicate);
    IEnumerable<TEntity> Set();
}
