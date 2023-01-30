using URLShortener.Model.Interfaces;
using URLShortener.MongoDB.Interfaces;

namespace URLShortener.Repository.Entity;

public abstract class EntityRepository<TE, MDE> : IEntityRepository<TE>
    where TE : IEntity
    where MDE : IEntityProvider<TE>
{
    protected MDE _provider;

    protected EntityRepository(MDE provider)
    {
        _provider = provider;
    }

    public Task<IEnumerable<TE>> GetAll()
    {
        throw new NotImplementedException();
    }

    public async Task<long> Count()
    {
        return await _provider.Count();
    }

    public async Task<TE> Create(TE instance)
    {
        return await _provider.Insert(instance);
    }

    public Task<TE> Update(TE instance)
    {
        throw new NotImplementedException();
    }

    public async void Delete(Guid instance)
    {
        await _provider.Remove(instance);
    }

    public async Task<TE> Get(Guid id)
    {
        return await _provider.Get(id);
    }
}
