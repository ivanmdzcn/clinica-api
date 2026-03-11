using System.Security.Claims;

namespace API.Extensions;

public static class ClaimsPrincipalExtensions
{
    /// <summary>
    /// Verifica si el usuario tiene un permiso específico
    /// </summary>
    public static bool HasPermission(this ClaimsPrincipal user, string permission)
    {
        return user.Claims.Any(c => c.Type == "Permission" && c.Value == permission);
    }

    /// <summary>
    /// Verifica si el usuario tiene todos los permisos especificados
    /// </summary>
    public static bool HasAllPermissions(this ClaimsPrincipal user, params string[] permissions)
    {
        var userPermissions = user.Claims
            .Where(c => c.Type == "Permission")
            .Select(c => c.Value)
            .ToHashSet();

        return permissions.All(p => userPermissions.Contains(p));
    }

    /// <summary>
    /// Verifica si el usuario tiene al menos uno de los permisos especificados
    /// </summary>
    public static bool HasAnyPermission(this ClaimsPrincipal user, params string[] permissions)
    {
        var userPermissions = user.Claims
            .Where(c => c.Type == "Permission")
            .Select(c => c.Value)
            .ToHashSet();

        return permissions.Any(p => userPermissions.Contains(p));
    }

    /// <summary>
    /// Obtiene todos los permisos del usuario
    /// </summary>
    public static List<string> GetPermissions(this ClaimsPrincipal user)
    {
        return user.Claims
            .Where(c => c.Type == "Permission")
            .Select(c => c.Value)
            .ToList();
    }

    /// <summary>
    /// Obtiene el rol del usuario
    /// </summary>
    public static string? GetRole(this ClaimsPrincipal user)
    {
        return user.FindFirst(ClaimTypes.Role)?.Value;
    }

    /// <summary>
    /// Obtiene el ID del usuario
    /// </summary>
    public static int? GetUserId(this ClaimsPrincipal user)
    {
        var userIdClaim = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        return int.TryParse(userIdClaim, out var userId) ? userId : null;
    }
}