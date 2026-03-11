using Application.UseCases.Clinica.Tratamientos.CreateTratamiento;
using Application.UseCases.Clinica.Tratamientos.UpdateTratamiento;
using Application.UseCases.Clinica.Tratamientos.GetTratamiento;
using Application.UseCases.Clinica.Tratamientos.ListTratamientosByConsulta;
using Application.UseCases.Clinica.Tratamientos.DeleteTratamiento;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Clinica;

[Authorize]
[ApiController]
[Route("api/clinica/[controller]")]
public class TratamientosController : ControllerBase
{
    private readonly CreateTratamientoHandler _createHandler;
    private readonly UpdateTratamientoHandler _updateHandler;
    private readonly GetTratamientoHandler _getHandler;
    private readonly ListTratamientosByConsultaHandler _listByConsultaHandler;
    private readonly DeleteTratamientoHandler _deleteHandler;

    public TratamientosController(
        CreateTratamientoHandler createHandler,
        UpdateTratamientoHandler updateHandler,
        GetTratamientoHandler getHandler,
        ListTratamientosByConsultaHandler listByConsultaHandler,
        DeleteTratamientoHandler deleteHandler)
    {
        _createHandler = createHandler;
        _updateHandler = updateHandler;
        _getHandler = getHandler;
        _listByConsultaHandler = listByConsultaHandler;
        _deleteHandler = deleteHandler;
    }

    [HttpPost]
    public async Task<ActionResult<CreateTratamientoResponse>> Create([FromBody] CreateTratamientoRequest request)
    {
        var response = await _createHandler.HandleAsync(request);
        return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<UpdateTratamientoResponse>> Update(int id, [FromBody] UpdateTratamientoRequest request)
    {
        var response = await _updateHandler.HandleAsync(id, request);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetTratamientoResponse>> GetById(int id)
    {
        var response = await _getHandler.HandleAsync(id);
        return Ok(response);
    }

    [HttpGet("consulta/{consultaId}")]
    public async Task<ActionResult<IEnumerable<ListTratamientosByConsultaResponse>>> GetByConsulta(int consultaId)
    {
        var response = await _listByConsultaHandler.HandleAsync(consultaId);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _deleteHandler.HandleAsync(id);
        return NoContent();
    }
}