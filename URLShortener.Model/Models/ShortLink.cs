namespace URLShortener.Model.Models;

public class ShortLink
{
    public Guid Id { get; set; }
    public string Destination { get; set; }
    public string Slug { get; set; }
    public Guid UserId { get; set; }
    
}