namespace URLShortener.Model.Interfaces;

public interface IEntityRepository<TE>
{
    Task<TE> Create(TE instance);
    Task<TE> Get(Guid id);
    Task<TE> Update(TE instance);
    void Delete(Guid instance);
    Task<IEnumerable<TE>> GetAll();
    Task<long> Count();
}