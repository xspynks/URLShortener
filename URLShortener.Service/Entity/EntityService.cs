using Ardalis.Result;
using URLShortener.Model.Interfaces;
using URLShortener.Service.Common;

namespace URLShortener.Service.Entity;

public class EntityService<TE> : IEntityService<TE, Result<TE>>
{
    private readonly IEntityRepository<TE> _entityRepository;
    
    public EntityService(IEntityRepository<TE> entityRepository)
    {
        _entityRepository = entityRepository;
    }
    public async Task<long> Count()
    {
        return await _entityRepository.Count();
    }
    
    public async Task<Result<TE>> Create(TE instance)
    {
        var createdInstance = await _entityRepository.Create(instance);
        if (createdInstance == null)
        {
            return Result<TE>.Error($"{typeof(TE).Name} {ErrorMessage.NotCreated}");
        }
        
        return Result<TE>.Success(createdInstance);
    }
    
    public virtual async Task<Result<TE>> Delete(Guid id)
    {
        var instance = await _entityRepository.Get(id);
        if (instance == null)
        {
            return Ardalis.Result.Result.NotFound($"{typeof(TE).Name} {ErrorMessage.NotFound}");
        }
        _entityRepository.Delete(id);
        return Ardalis.Result.Result.Success();
    }
    
    public virtual async Task<Result<TE>> Get(Guid id)
    {
        var instance = await _entityRepository.Get(id);
        if (instance == null)
        {
            return Result<TE>.NotFound($"{typeof(TE).Name} {ErrorMessage.NotFound}");
        }
        
        return instance;
    }
    
    public async Task<IEnumerable<TE>> GetAll()
    {
        return await _entityRepository.GetAll();
    }
    
    public async Task<Result<TE>> Update(Guid id, TE instance)
    {
        var searchedInstance = await _entityRepository.Get(id);
        if (searchedInstance == null)
        {
            return Result<TE>.NotFound($"{typeof(TE).Name} {ErrorMessage.NotFound}");
        }
        
        var updatedInstance = await _entityRepository.Update(instance);
        if (updatedInstance == null)
        {
            return Result<TE>.Error($"{typeof(TE).Name} {ErrorMessage.NotUpdated}");
        }
        
        return Result<TE>.Success(updatedInstance);
    }
}