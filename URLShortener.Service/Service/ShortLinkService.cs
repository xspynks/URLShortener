using Ardalis.Result;
using URLShortener.Model.Interfaces;
using URLShortener.Model.Models;
using URLShortener.Service.Common;
using URLShortener.Service.Entity;
using URLShortener.Service.Interfaces;

namespace URLShortener.Service.Service;

public class ShortLinkService : EntityService<ShortLink>, IShortLinkService
{
    private readonly IEntityRepository<ShortLink> _repository;
    
    public ShortLinkService(IEntityRepository<ShortLink> repository) : base(repository)
    {
        _repository = repository;
    }
    
    public async Task<Result<ShortLink>> Create(ShortLink shortLink)
    {
        var createdInstance = await _repository.Create(shortLink);
        if (createdInstance == null)
        {
            return Result<ShortLink>.Error($"{typeof(ShortLink).Name} {ErrorMessage.NotCreated}");
        }
        
        return Result<ShortLink>.Success(createdInstance);
    }
}