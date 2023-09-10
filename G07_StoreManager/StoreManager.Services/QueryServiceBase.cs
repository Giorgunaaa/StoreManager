using StoreManager.DTO;
using StoreManager.Facade.Interfaces.Repositories;
using StoreManager.Facade.Interfaces.Services;
using System.Linq.Expressions;

namespace StoreManager.Services;

public abstract class QueryServiceBase<TEntity, TRepository> : IQueryService<TEntity>
    where TEntity : class, IEntity
    where TRepository : IRepository<TEntity>
{
    private readonly IRepository<TEntity> _repository;

    public QueryServiceBase(TRepository repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public TEntity Get(params object[] id) => _repository
        .Set()
        .Single(x => x.Id == Convert.ToInt32(id) && !x.IsDeleted);

    public IEnumerable<TEntity> Set(Expression<Func<TEntity, bool>> predicate) => _repository.Set(predicate);

    public IEnumerable<TEntity> Set() => _repository.Set();
}
