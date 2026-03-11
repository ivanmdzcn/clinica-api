using API.Attributes;
using Application.UseCases.Pacientes.CreatePaciente;
using Application.UseCases.Pacientes.UpdatePaciente;
using Application.UseCases.Pacientes.GetPaciente;
using Application.UseCases.Pacientes.ListPacientes;
using Application.UseCases.Pacientes.DeletePaciente;
using Application.UseCases.Pacientes.SearchPacientes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Clinica;

[ApiController]
[Route("api/pacientes")]
[Authorize]
public class PacientesController : ControllerBase
{
    private readonly CreatePacienteHandler _createHandler;
    private readonly UpdatePacienteHandler _updateHandler;
    private readonly GetPacienteHandler _getHandler;
    private readonly ListPacientesHandler _listHandler;
    private readonly DeletePacienteHandler _deleteHandler;
    private readonly SearchPacientesHandler _searchHandler;

    public PacientesController(
        CreatePacienteHandler createHandler,
        UpdatePacienteHandler updateHandler,
        GetPacienteHandler getHandler,
        ListPacientesHandler listHandler,
        DeletePacienteHandler deleteHandler,
        SearchPacientesHandler searchHandler)
    {
        _createHandler = createHandler;
        _updateHandler = updateHandler;
        _getHandler = getHandler;
        _listHandler = listHandler;
        _deleteHandler = deleteHandler;
        _searchHandler = searchHandler;
    }

    /// <summary>
    /// Crear paciente - Requiere permiso Pacientes.Crear
    /// </summary>
    [HttpPost]
    [RequirePermission("Pacientes.Crear")]
    public async Task<IActionResult> Create([FromBody] CreatePacienteRequest request)
    {
        var result = await _createHandler.HandleAsync(request);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    /// <summary>
    /// Listar pacientes - Requiere permiso Pacientes.Ver
    /// </summary>
    [HttpGet]
    [RequirePermission("Pacientes.Ver")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _listHandler.HandleAsync();
        return Ok(result);
    }

    /// <summary>
    /// Obtener paciente por ID - Requiere permiso Pacientes.Ver
    /// </summary>
    [HttpGet("{id}")]
    [RequirePermission("Pacientes.Ver")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _getHandler.HandleAsync(new GetPacienteRequest { Id = id });
        return Ok(result);
    }

    /// <summary>
    /// Buscar pacientes - Requiere permiso Pacientes.Ver
    /// </summary>
    [HttpGet("search")]
    [RequirePermission("Pacientes.Ver")]
    public async Task<IActionResult> Search([FromQuery] string searchTerm)
    {
        var result = await _searchHandler.HandleAsync(new SearchPacientesRequest { SearchTerm = searchTerm });
        return Ok(result);
    }

    /// <summary>
    /// Actualizar paciente - Requiere permiso Pacientes.Editar
    /// </summary>
    [HttpPut("{id}")]
    [RequirePermission("Pacientes.Editar")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdatePacienteRequest request)
    {
        var result = await _updateHandler.HandleAsync(id, request);
        return Ok(result);
    }

    /// <summary>
    /// Eliminar paciente - Requiere permiso Pacientes.Eliminar
    /// </summary>
    [HttpDelete("{id}")]
    [RequirePermission("Pacientes.Eliminar")]
    public async Task<IActionResult> Delete(int id)
    {
        await _deleteHandler.HandleAsync(new DeletePacienteRequest { Id = id });
        return NoContent();
    }
}