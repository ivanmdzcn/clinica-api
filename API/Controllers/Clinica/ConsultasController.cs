using API.Attributes;
using Application.UseCases.Clinica.Consultas.AnularConsulta;
using Application.UseCases.Clinica.Consultas.CerrarConsulta;
using Application.UseCases.Clinica.Consultas.CreateConsulta;
using Application.UseCases.Clinica.Consultas.GetConsulta;
using Application.UseCases.Clinica.Consultas.ListConsultasByPaciente;
using Application.UseCases.Clinica.Consultas.UpdateConsulta;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Clinica;

[Authorize]
[ApiController]
[Route("api/clinica/[controller]")]
public class ConsultasController : ControllerBase
{
    private readonly CreateConsultaHandler _createHandler;
    private readonly UpdateConsultaHandler _updateHandler;
    private readonly GetConsultaHandler _getHandler;
    private readonly ListConsultasByPacienteHandler _listByPacienteHandler;
    private readonly CerrarConsultaHandler _cerrarHandler;
    private readonly AnularConsultaHandler _anularHandler;

    public ConsultasController(
        CreateConsultaHandler createHandler,
        UpdateConsultaHandler updateHandler,
        GetConsultaHandler getHandler,
        ListConsultasByPacienteHandler listByPacienteHandler,
        CerrarConsultaHandler cerrarHandler,
        AnularConsultaHandler anularHandler)
    {
        _createHandler = createHandler;
        _updateHandler = updateHandler;
        _getHandler = getHandler;
        _listByPacienteHandler = listByPacienteHandler;
        _cerrarHandler = cerrarHandler;
        _anularHandler = anularHandler;
    }

    [HttpPost]
    [RequirePermission("Consultas.Ver")]
    public async Task<ActionResult<CreateConsultaResponse>> Create([FromBody] CreateConsultaRequest request)
    {
        var response = await _createHandler.HandleAsync(request);
        return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
    }

    [HttpPut("{id}")]
    [RequirePermission("Consultas.Editar")]
    public async Task<ActionResult<UpdateConsultaResponse>> Update(int id, [FromBody] UpdateConsultaRequest request)
    {
        var response = await _updateHandler.HandleAsync(id, request);
        return Ok(response);
    }

    [HttpGet("{id}")]
    [RequirePermission("Consultas.Ver")]
    public async Task<ActionResult<GetConsultaResponse>> GetById(int id)
    {
        var response = await _getHandler.HandleAsync(id);
        return Ok(response);
    }

    [HttpGet("paciente/{pacienteId}")]
    [RequirePermission("Consultas.Ver")]
    public async Task<ActionResult<IEnumerable<ListConsultasByPacienteResponse>>> GetByPaciente(int pacienteId)
    {
        var response = await _listByPacienteHandler.HandleAsync(pacienteId);
        return Ok(response);
    }

    [HttpPatch("{id}/cerrar")]
    [RequirePermission("Consultas.Editar")]
    public async Task<IActionResult> Cerrar(int id)
    {
        await _cerrarHandler.HandleAsync(id);
        return NoContent();
    }

    [HttpPatch("{id}/anular")]
    [RequirePermission("Consultas.Editar")]
    public async Task<IActionResult> Anular(int id)
    {
        await _anularHandler.HandleAsync(id);
        return NoContent();
    }
}