using Application.UseCases.Clinica.ExamenesLaboratorio.CreateExamenLaboratorio;
using Application.UseCases.Clinica.ExamenesLaboratorio.UpdateExamenLaboratorio;
using Application.UseCases.Clinica.ExamenesLaboratorio.GetExamenLaboratorio;
using Application.UseCases.Clinica.ExamenesLaboratorio.ListExamenesLaboratorioByOrden;
using Application.UseCases.Clinica.ExamenesLaboratorio.DeleteExamenLaboratorio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Clinica;

[Authorize]
[ApiController]
[Route("api/clinica/[controller]")]
public class ExamenesLaboratorioController : ControllerBase
{
    private readonly CreateExamenLaboratorioHandler _createHandler;
    private readonly UpdateExamenLaboratorioHandler _updateHandler;
    private readonly GetExamenLaboratorioHandler _getHandler;
    private readonly ListExamenesLaboratorioByOrdenHandler _listByOrdenHandler;
    private readonly DeleteExamenLaboratorioHandler _deleteHandler;

    public ExamenesLaboratorioController(
        CreateExamenLaboratorioHandler createHandler,
        UpdateExamenLaboratorioHandler updateHandler,
        GetExamenLaboratorioHandler getHandler,
        ListExamenesLaboratorioByOrdenHandler listByOrdenHandler,
        DeleteExamenLaboratorioHandler deleteHandler)
    {
        _createHandler = createHandler;
        _updateHandler = updateHandler;
        _getHandler = getHandler;
        _listByOrdenHandler = listByOrdenHandler;
        _deleteHandler = deleteHandler;
    }

    [HttpPost]
    public async Task<ActionResult<CreateExamenLaboratorioResponse>> Create([FromBody] CreateExamenLaboratorioRequest request)
    {
        var response = await _createHandler.HandleAsync(request);
        return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<UpdateExamenLaboratorioResponse>> Update(int id, [FromBody] UpdateExamenLaboratorioRequest request)
    {
        var response = await _updateHandler.HandleAsync(id, request);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetExamenLaboratorioResponse>> GetById(int id)
    {
        var response = await _getHandler.HandleAsync(id);
        return Ok(response);
    }

    [HttpGet("orden/{ordenLaboratorioId}")]
    public async Task<ActionResult<IEnumerable<ListExamenesLaboratorioByOrdenResponse>>> GetByOrden(int ordenLaboratorioId)
    {
        var response = await _listByOrdenHandler.HandleAsync(ordenLaboratorioId);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _deleteHandler.HandleAsync(id);
        return NoContent();
    }
}