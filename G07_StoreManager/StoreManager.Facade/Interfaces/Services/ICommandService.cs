namespace StoreManager.Facade.Interfaces.Services;

public interface ICommandService<in TEntity, out TKey>
{
	TKey Insert(TEntity entity);
	void Update(TEntity entity);
	void Delete(TEntity entity);
}

public interface ICommandService<in TEntity> : ICommandService<TEntity, int>
{

}