using Application.Interfaces.Security;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Infrastructure.Security;

public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public int GetUserId()
    {
        var userId = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        return int.TryParse(userId, out var id) ? id : 0;
    }

    public string GetUsername()
    {
        return _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.Name)?.Value ?? string.Empty;
    }

    public bool IsAuthenticated()
    {
        return _httpContextAccessor.HttpContext?.User.Identity?.IsAuthenticated ?? false;
    }
}