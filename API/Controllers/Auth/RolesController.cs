using API.Attributes;
using Application.UseCases.Auth.Roles.CreateRol;
using Application.UseCases.Auth.Roles.UpdateRol;
using Application.UseCases.Auth.Roles.GetRol;
using Application.UseCases.Auth.Roles.ListRoles;
using Application.UseCases.Auth.Roles.DeleteRol;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Auth;

[ApiController]
[Route("api/roles")]
[Authorize]
public class RolesController : ControllerBase
{
    private readonly CreateRolHandler _createHandler;
    private readonly UpdateRolHandler _updateHandler;
    private readonly GetRolHandler _getHandler;
    private readonly ListRolesHandler _listHandler;
    private readonly DeleteRolHandler _deleteHandler;

    public RolesController(
        CreateRolHandler createHandler,
        UpdateRolHandler updateHandler,
        GetRolHandler getHandler,
        ListRolesHandler listHandler,
        DeleteRolHandler deleteHandler)
    {
        _createHandler = createHandler;
        _updateHandler = updateHandler;
        _getHandler = getHandler;
        _listHandler = listHandler;
        _deleteHandler = deleteHandler;
    }

    [HttpPost]
    [RequirePermission("Roles.Crear")]
    public async Task<IActionResult> Create([FromBody] CreateRolRequest request)
    {
        var result = await _createHandler.HandleAsync(request);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpGet]
    [RequirePermission("Roles.Ver")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _listHandler.HandleAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    [RequirePermission("Roles.Ver")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _getHandler.HandleAsync(new GetRolRequest { Id = id });
        return Ok(result);
    }

    [HttpPut("{id}")]
    [RequirePermission("Roles.Editar")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateRolRequest request)
    {
        var result = await _updateHandler.HandleAsync(id, request);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    [RequirePermission("Roles.Eliminar")]
    public async Task<IActionResult> Delete(int id)
    {
        await _deleteHandler.HandleAsync(new DeleteRolRequest { Id = id });
        return NoContent();
    }

    /// <summary>
    /// Endpoint que requiere AMBOS permisos (AND)
    /// </summary>
    [HttpPost("admin-action")]
    [RequirePermission(PermissionOperator.And, "Usuarios.Crear", "Roles.Crear")]
    public async Task<IActionResult> AdminAction()
    {
        // Solo accesible si tiene AMBOS permisos
        return Ok(new { message = "Acción de administrador ejecutada" });
    }

    /// <summary>
    /// Endpoint que requiere AL MENOS UNO de los permisos (OR)
    /// </summary>
    [HttpGet("dashboard")]
    [RequirePermission("Usuarios.Ver", "Roles.Ver", "Permisos.Ver")]
    public async Task<IActionResult> GetDashboard()
    {
        // Accesible si tiene al menos uno de los permisos
        return Ok(new { message = "Dashboard data" });
    }
}