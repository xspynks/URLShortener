using URLShortener.Model.Interfaces;

namespace URLShortener.Model.Entity;

public class BaseEntity : Model, IEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
}