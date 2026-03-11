using API.Attributes;
using Application.UseCases.Auth.Usuarios.CreateUsuario;
using Application.UseCases.Auth.Usuarios.UpdateUsuario;
using Application.UseCases.Auth.Usuarios.GetUsuario;
using Application.UseCases.Auth.Usuarios.ListUsuarios;
using Application.UseCases.Auth.Usuarios.DeleteUsuario;
using Application.UseCases.Auth.Usuarios.ListUsuariosByRol;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Auth;

[ApiController]
[Route("api/usuarios")]
[Authorize] // 👈 Requiere autenticación
public class UsuariosController : ControllerBase
{
    private readonly CreateUsuarioHandler _createHandler;
    private readonly UpdateUsuarioHandler _updateHandler;
    private readonly GetUsuarioHandler _getHandler;
    private readonly ListUsuariosHandler _listHandler;
    private readonly DeleteUsuarioHandler _deleteHandler;
    private readonly ListUsuariosByRolHandler _listByRolHandler;

    public UsuariosController(
        CreateUsuarioHandler createHandler,
        UpdateUsuarioHandler updateHandler,
        GetUsuarioHandler getHandler,
        ListUsuariosHandler listHandler,
        DeleteUsuarioHandler deleteHandler,
        ListUsuariosByRolHandler listByRolHandler)
    {
        _createHandler = createHandler;
        _updateHandler = updateHandler;
        _getHandler = getHandler;
        _listHandler = listHandler;
        _deleteHandler = deleteHandler;
        _listByRolHandler = listByRolHandler;
    }

    /// <summary>
    /// Crear usuario - Requiere permiso USUARIOS_CREATE
    /// </summary>
    [HttpPost]
    [RequirePermission("Usuarios.Crear")] // 👈 Validación de permiso
    public async Task<IActionResult> Create([FromBody] CreateUsuarioRequest request)
    {
        var result = await _createHandler.HandleAsync(request);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    /// <summary>
    /// Listar usuarios - Requiere permiso USUARIOS_VIEW
    /// </summary>
    [HttpGet]
    [RequirePermission("Usuarios.Ver")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _listHandler.HandleAsync();
        return Ok(result);
    }

    /// <summary>
    /// Obtener usuario por ID - Requiere permiso USUARIOS_VIEW
    /// </summary>
    [HttpGet("{id}")]
    [RequirePermission("Usuarios.Ver")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _getHandler.HandleAsync(new GetUsuarioRequest { Id = id });
        return Ok(result);
    }

    /// <summary>
    /// Actualizar usuario - Requiere permiso USUARIOS_UPDATE
    /// </summary>
    [HttpPut("{id}")]
    [RequirePermission("Usuarios.Editar")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateUsuarioRequest request)
    {
        var result = await _updateHandler.HandleAsync(id, request);
        return Ok(result);
    }

    /// <summary>
    /// Eliminar usuario - Requiere permiso USUARIOS_DELETE
    /// </summary>
    [HttpDelete("{id}")]
    [RequirePermission("Usuarios.Eliminar")]
    public async Task<IActionResult> Delete(int id)
    {
        await _deleteHandler.HandleAsync(new DeleteUsuarioRequest { Id = id });
        return NoContent();
    }

    /// <summary>
    /// Listar usuarios por rol - Requiere permiso USUARIOS_VIEW
    /// </summary>
    [HttpGet("rol/{rolId}")]
    [RequirePermission("Usuarios.Ver")]
    public async Task<ActionResult<IEnumerable<ListUsuariosByRolResponse>>> GetByRol(int rolId)
    {
        var response = await _listByRolHandler.HandleAsync(rolId);
        return Ok(response);
    }
}