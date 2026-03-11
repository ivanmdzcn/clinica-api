using System.Security.Claims;

namespace API.Middleware;

/// <summary>
/// Middleware para registrar validaciones de permisos
/// </summary>
public class PermissionLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<PermissionLoggingMiddleware> _logger;

    public PermissionLoggingMiddleware(RequestDelegate next, ILogger<PermissionLoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // Registrar información del usuario y endpoint
        if (context.User.Identity?.IsAuthenticated ?? false)
        {
            var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var username = context.User.FindFirst(ClaimTypes.Name)?.Value;
            var endpoint = $"{context.Request.Method} {context.Request.Path}";

            _logger.LogInformation(
                "Usuario {Username} (ID: {UserId}) accediendo a {Endpoint}",
                username, userId, endpoint);
        }

        await _next(context);

        // Registrar si fue rechazado por permisos
        if (context.Response.StatusCode == StatusCodes.Status403Forbidden)
        {
            var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var username = context.User.FindFirst(ClaimTypes.Name)?.Value;
            var endpoint = $"{context.Request.Method} {context.Request.Path}";

            _logger.LogWarning(
                "⚠️ Acceso denegado: Usuario {Username} (ID: {UserId}) sin permisos para {Endpoint}",
                username, userId, endpoint);
        }
    }
}