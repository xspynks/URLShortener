namespace URLShortener.Model.Interfaces;

public interface IEntityService<TE, TR>
{
    Task<TR> Create(TE instance);
    Task<TR> Get(Guid id);
    Task<TR> Update(Guid id, TE instance);
    Task<TR> Delete(Guid instance);
    Task<IEnumerable<TE>> GetAll();
    Task<long> Count();
}