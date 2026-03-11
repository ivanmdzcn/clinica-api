using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace API.Attributes;

/// <summary>
/// Atributo para validar que el usuario tenga un permiso específico
/// </summary>
[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
public class RequirePermissionAttribute : Attribute, IAuthorizationFilter
{
    private readonly string[] _requiredPermissions;
    private readonly PermissionOperator _operator;

    /// <summary>
    /// Constructor para validar uno o más permisos (operador OR por defecto)
    /// </summary>
    /// <param name="permissions">Códigos de permisos requeridos (ej: "Usuarios.Ver")</param>
    public RequirePermissionAttribute(params string[] permissions)
    {
        _requiredPermissions = permissions ?? throw new ArgumentNullException(nameof(permissions));
        _operator = PermissionOperator.Or; // Por defecto OR
    }

    /// <summary>
    /// Constructor para validar uno o más permisos con operador específico
    /// </summary>
    /// <param name="permissionOperator">Operador lógico: AND (todos) u OR (al menos uno)</param>
    /// <param name="permissions">Códigos de permisos requeridos</param>
    public RequirePermissionAttribute(PermissionOperator permissionOperator, params string[] permissions)
    {
        _requiredPermissions = permissions ?? throw new ArgumentNullException(nameof(permissions));
        _operator = permissionOperator;
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        // Verificar que el usuario esté autenticado
        if (!context.HttpContext.User.Identity?.IsAuthenticated ?? true)
        {
            context.Result = new UnauthorizedObjectResult(new
            {
                message = "Usuario no autenticado"
            });
            return;
        }

        // Obtener permisos del usuario desde los claims del JWT
        var userPermissions = context.HttpContext.User.Claims
            .Where(c => c.Type == "Permission")
            .Select(c => c.Value)
            .ToList();

        // Validar permisos según el operador
        bool hasPermission = _operator switch
        {
            PermissionOperator.And => _requiredPermissions.All(p => userPermissions.Contains(p)),
            PermissionOperator.Or => _requiredPermissions.Any(p => userPermissions.Contains(p)),
            _ => false
        };

        if (!hasPermission)
        {
            var missingPermissions = _requiredPermissions.Except(userPermissions).ToList();
            
            context.Result = new ObjectResult(new
            {
                message = "No tienes permisos suficientes para realizar esta acción",
                requiredPermissions = _requiredPermissions,
                missingPermissions = missingPermissions,
                @operator = _operator.ToString()
            })
            {
                StatusCode = StatusCodes.Status403Forbidden
            };
        }
    }
}

/// <summary>
/// Operador lógico para validar múltiples permisos
/// </summary>
public enum PermissionOperator
{
    /// <summary>
    /// El usuario debe tener TODOS los permisos
    /// </summary>
    And,
    
    /// <summary>
    /// El usuario debe tener AL MENOS UNO de los permisos
    /// </summary>
    Or
}