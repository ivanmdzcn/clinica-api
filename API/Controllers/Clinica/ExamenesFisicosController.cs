using Application.UseCases.Clinica.ExamenesFisicos.CreateExamenFisico;
using Application.UseCases.Clinica.ExamenesFisicos.UpdateExamenFisico;
using Application.UseCases.Clinica.ExamenesFisicos.GetExamenFisico;
using Application.UseCases.Clinica.ExamenesFisicos.GetExamenFisicoByConsulta;
using Application.UseCases.Clinica.ExamenesFisicos.DeleteExamenFisico;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Clinica;

[Authorize]
[ApiController]
[Route("api/clinica/[controller]")]
public class ExamenesFisicosController : ControllerBase
{
    private readonly CreateExamenFisicoHandler _createHandler;
    private readonly UpdateExamenFisicoHandler _updateHandler;
    private readonly GetExamenFisicoHandler _getHandler;
    private readonly GetExamenFisicoByConsultaHandler _getByConsultaHandler;
    private readonly DeleteExamenFisicoHandler _deleteHandler;

    public ExamenesFisicosController(
        CreateExamenFisicoHandler createHandler,
        UpdateExamenFisicoHandler updateHandler,
        GetExamenFisicoHandler getHandler,
        GetExamenFisicoByConsultaHandler getByConsultaHandler,
        DeleteExamenFisicoHandler deleteHandler)
    {
        _createHandler = createHandler;
        _updateHandler = updateHandler;
        _getHandler = getHandler;
        _getByConsultaHandler = getByConsultaHandler;
        _deleteHandler = deleteHandler;
    }

    [HttpPost]
    public async Task<ActionResult<CreateExamenFisicoResponse>> Create([FromBody] CreateExamenFisicoRequest request)
    {
        var response = await _createHandler.HandleAsync(request);
        return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<UpdateExamenFisicoResponse>> Update(int id, [FromBody] UpdateExamenFisicoRequest request)
    {
        var response = await _updateHandler.HandleAsync(id, request);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetExamenFisicoResponse>> GetById(int id)
    {
        var response = await _getHandler.HandleAsync(id);
        return Ok(response);
    }

    [HttpGet("consulta/{consultaId}")]
    public async Task<ActionResult<GetExamenFisicoByConsultaResponse>> GetByConsulta(int consultaId)
    {
        var response = await _getByConsultaHandler.HandleAsync(consultaId);
        if (response == null)
            return NotFound($"No se encontró examen físico para la consulta {consultaId}");
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _deleteHandler.HandleAsync(id);
        return NoContent();
    }
}