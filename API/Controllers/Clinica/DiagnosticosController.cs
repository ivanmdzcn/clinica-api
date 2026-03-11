using Application.UseCases.Clinica.Diagnosticos.CreateDiagnostico;
using Application.UseCases.Clinica.Diagnosticos.UpdateDiagnostico;
using Application.UseCases.Clinica.Diagnosticos.GetDiagnostico;
using Application.UseCases.Clinica.Diagnosticos.ListDiagnosticosByConsulta;
using Application.UseCases.Clinica.Diagnosticos.DeleteDiagnostico;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Clinica;

[Authorize]
[ApiController]
[Route("api/clinica/[controller]")]
public class DiagnosticosController : ControllerBase
{
    private readonly CreateDiagnosticoHandler _createHandler;
    private readonly UpdateDiagnosticoHandler _updateHandler;
    private readonly GetDiagnosticoHandler _getHandler;
    private readonly ListDiagnosticosByConsultaHandler _listByConsultaHandler;
    private readonly DeleteDiagnosticoHandler _deleteHandler;

    public DiagnosticosController(
        CreateDiagnosticoHandler createHandler,
        UpdateDiagnosticoHandler updateHandler,
        GetDiagnosticoHandler getHandler,
        ListDiagnosticosByConsultaHandler listByConsultaHandler,
        DeleteDiagnosticoHandler deleteHandler)
    {
        _createHandler = createHandler;
        _updateHandler = updateHandler;
        _getHandler = getHandler;
        _listByConsultaHandler = listByConsultaHandler;
        _deleteHandler = deleteHandler;
    }

    [HttpPost]
    public async Task<ActionResult<CreateDiagnosticoResponse>> Create([FromBody] CreateDiagnosticoRequest request)
    {
        var response = await _createHandler.HandleAsync(request);
        return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<UpdateDiagnosticoResponse>> Update(int id, [FromBody] UpdateDiagnosticoRequest request)
    {
        var response = await _updateHandler.HandleAsync(id, request);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetDiagnosticoResponse>> GetById(int id)
    {
        var response = await _getHandler.HandleAsync(id);
        return Ok(response);
    }

    [HttpGet("consulta/{consultaId}")]
    public async Task<ActionResult<IEnumerable<ListDiagnosticosByConsultaResponse>>> GetByConsulta(int consultaId)
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