using Ardalis.Result;
using URLShortener.Model.Models;

namespace URLShortener.Service.Interfaces;

public interface IShortLinkService
{
    Task<Result<ShortLink>> Create(ShortLink shortLink);
}