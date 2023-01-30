using Microsoft.AspNetCore.Mvc;
using Ardalis.Result;
using Ardalis.Result.AspNetCore;
using URLShortener.Model.Models;
using URLShortener.Service.Interfaces;

namespace URLShortener.Http.Controllers;

[ApiController]
[Route("[controller]")]
public class ShortLinkController : Controller
{
    private readonly IShortLinkService _shortLinkService;
    
    public ShortLinkController(IShortLinkService shortLinkService)
    {
        _shortLinkService = shortLinkService;
    }
    
    [TranslateResultToActionResult]
    [HttpPost, Route("Create")]
    public async Task<Result<ShortLink>> Create(Guid id, string slug, string destination, Guid userId)
    {
        var shortLink = new ShortLink
        {
            Id = Guid.NewGuid(),
            Slug = slug,
            Destination = destination,
            UserId = userId
        };
        return await _shortLinkService.Create(shortLink);
    }
}
