using API.Attributes;
using Application.UseCases.Auth.Permisos.CreatePermiso;
using Application.UseCases.Auth.Permisos.DeletePermiso;
using Application.UseCases.Auth.Permisos.GetPermiso;
using Application.UseCases.Auth.Permisos.ListModulos;
using Application.UseCases.Auth.Permisos.ListPermisos;
using Application.UseCases.Auth.Permisos.ListPermisosByModulo;
using Application.UseCases.Auth.Permisos.UpdatePermiso;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Auth;

[ApiController]
[Route("api/permisos")]
[Authorize]
public class PermisosController : ControllerBase
{
    private readonly CreatePermisoHandler _createHandler;
    private readonly UpdatePermisoHandler _updateHandler;
    private readonly GetPermisoHandler _getHandler;
    private readonly ListPermisosHandler _listHandler;
    private readonly ListPermisosByModuloHandler _listByModuloHandler;
    private readonly ListModulosHandler _listModulosHandler;
    private readonly DeletePermisoHandler _deleteHandler;

    public PermisosController(
        CreatePermisoHandler createHandler,
        UpdatePermisoHandler updateHandler,
        GetPermisoHandler getHandler,
        ListPermisosHandler listHandler,
        ListPermisosByModuloHandler listByModuloHandler,
        ListModulosHandler listModulosHandler,
        DeletePermisoHandler deleteHandler)
    {
        _createHandler = createHandler;
        _updateHandler = updateHandler;
        _getHandler = getHandler;
        _listHandler = listHandler;
        _listByModuloHandler = listByModuloHandler;
        _listModulosHandler = listModulosHandler;
        _deleteHandler = deleteHandler;
    }

    /// <summary>
    /// Crear permiso - Requiere permiso Permisos.Crear
    /// </summary>
    [HttpPost]
    [RequirePermission("Permisos.Crear")]
    public async Task<IActionResult> Create([FromBody] CreatePermisoRequest request)
    {
        var result = await _createHandler.HandleAsync(request);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    /// <summary>
    /// Listar todos los permisos - Requiere permiso Permisos.Ver
    /// </summary>
    [HttpGet]
    [RequirePermission("Permisos.Ver")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _listHandler.HandleAsync();
        return Ok(result);
    }

    /// <summary>
    /// Obtener permiso por ID - Requiere permiso Permisos.Ver
    /// </summary>
    [HttpGet("{id}")]
    [RequirePermission("Permisos.Ver")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _getHandler.HandleAsync(new GetPermisoRequest { Id = id });
        return Ok(result);
    }

    /// <summary>
    /// Listar permisos por módulo - Requiere permiso Permisos.Ver
    /// </summary>
    [HttpGet("modulo/{modulo}")]
    [RequirePermission("Permisos.Ver")]
    public async Task<IActionResult> GetByModulo(string modulo)
    {
        var result = await _listByModuloHandler.HandleAsync(new ListPermisosByModuloRequest { Modulo = modulo });
        return Ok(result);
    }

    /// <summary>
    /// Listar módulos disponibles - Requiere permiso Permisos.Ver
    /// </summary>
    [HttpGet("modulos")]
    [RequirePermission("Permisos.Ver")]
    public async Task<IActionResult> GetModulos()
    {
        var result = await _listModulosHandler.HandleAsync();
        return Ok(result);
    }

    /// <summary>
    /// Actualizar permiso - Requiere permiso Permisos.Editar
    /// </summary>
    [HttpPut("{id}")]
    [RequirePermission("Permisos.Editar")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdatePermisoRequest request)
    {
        var result = await _updateHandler.HandleAsync(id, request);
        return Ok(result);
    }

    /// <summary>
    /// Eliminar permiso - Requiere permiso Permisos.Eliminar
    /// </summary>
    [HttpDelete("{id}")]
    [RequirePermission("Permisos.Eliminar")]
    public async Task<IActionResult> Delete(int id)
    {
        await _deleteHandler.HandleAsync(new DeletePermisoRequest { Id = id });
        return NoContent();
    }
}