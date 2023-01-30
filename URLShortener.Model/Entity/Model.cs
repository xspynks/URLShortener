using URLShortener.Model.Interfaces;

namespace URLShortener.Model.Entity;

public class Model : IModel
{
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public DateTime ModifiedDate { get; set; } = DateTime.UtcNow;
}