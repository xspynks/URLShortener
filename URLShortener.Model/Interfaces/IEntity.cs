namespace URLShortener.Model.Interfaces;

public interface IEntity : IModel
{
    Guid Id { get; set; }
}