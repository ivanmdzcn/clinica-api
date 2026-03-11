using Application.UseCases.Auth.RolPermisos.GetPermisosByRol;
using Application.UseCases.Auth.RolPermisos.AsignarPermisos;
using Application.UseCases.Auth.RolPermisos.AsignarPermiso;
using Application.UseCases.Auth.RolPermisos.RemoverPermiso;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Auth;

[ApiController]
[Route("api/roles/{rolId}/permisos")]
[Authorize]
public class RolPermisosController : ControllerBase
{
    private readonly GetPermisosByRolHandler _getPermisosHandler;
    private readonly AsignarPermisosHandler _asignarPermisosHandler;
    private readonly AsignarPermisoHandler _asignarPermisoHandler;
    private readonly RemoverPermisoHandler _removerPermisoHandler;

    public RolPermisosController(
        GetPermisosByRolHandler getPermisosHandler,
        AsignarPermisosHandler asignarPermisosHandler,
        AsignarPermisoHandler asignarPermisoHandler,
        RemoverPermisoHandler removerPermisoHandler)
    {
        _getPermisosHandler = getPermisosHandler;
        _asignarPermisosHandler = asignarPermisosHandler;
        _asignarPermisoHandler = asignarPermisoHandler;
        _removerPermisoHandler = removerPermisoHandler;
    }

    /// <summary>
    /// Obtener todos los permisos asignados a un rol
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> GetPermisosByRol(int rolId)
    {
        var result = await _getPermisosHandler.HandleAsync(new GetPermisosByRolRequest { RolId = rolId });
        return Ok(result);
    }

    /// <summary>
    /// Asignar múltiples permisos a un rol (reemplaza los existentes)
    /// </summary>
    [HttpPut]
    public async Task<IActionResult> AsignarPermisos(int rolId, [FromBody] AsignarPermisosRequest request)
    {
        // Asegurar que el RolId de la ruta coincida con el del body
        var requestWithRolId = new AsignarPermisosRequest 
        { 
            RolId = rolId, 
            PermisoIds = request.PermisoIds 
        };

        var result = await _asignarPermisosHandler.HandleAsync(requestWithRolId);
        return Ok(result);
    }

    /// <summary>
    /// Asignar un permiso individual a un rol
    /// </summary>
    [HttpPost("{permisoId}")]
    public async Task<IActionResult> AsignarPermiso(int rolId, int permisoId)
    {
        await _asignarPermisoHandler.HandleAsync(new AsignarPermisoRequest 
        { 
            RolId = rolId, 
            PermisoId = permisoId 
        });
        return NoContent();
    }

    /// <summary>
    /// Remover un permiso de un rol
    /// </summary>
    [HttpDelete("{permisoId}")]
    public async Task<IActionResult> RemoverPermiso(int rolId, int permisoId)
    {
        await _removerPermisoHandler.HandleAsync(new RemoverPermisoRequest 
        { 
            RolId = rolId, 
            PermisoId = permisoId 
        });
        return NoContent();
    }
}