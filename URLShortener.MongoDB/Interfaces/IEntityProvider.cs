using MongoDB.Driver;

namespace URLShortener.MongoDB.Interfaces;

public interface IEntityProvider<TEntity>
{
    Task<IEnumerable<TEntity>> GetAll();
    Task<TEntity> Get(Guid objectId);
    Task<IEnumerable<TEntity>> Get(FilterDefinition<TEntity> filters);
    Task<IEnumerable<TEntity>> Get(FilterDefinition<TEntity> filters, FindOptions<TEntity> options);
    Task<TEntity> Insert(TEntity entityObject);
    Task<TEntity> Update(TEntity entityObject);
    Task<TEntity> Upsert(TEntity entityObject);
    Task<DeleteResult> Remove(Guid objectId);
    Task<long> Count();
    void RemoveCollection();
}