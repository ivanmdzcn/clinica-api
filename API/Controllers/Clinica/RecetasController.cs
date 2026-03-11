using Application.UseCases.Clinica.Recetas.CreateReceta;
using Application.UseCases.Clinica.Recetas.UpdateReceta;
using Application.UseCases.Clinica.Recetas.GetReceta;
using Application.UseCases.Clinica.Recetas.ListRecetasByConsulta;
using Application.UseCases.Clinica.Recetas.DeleteReceta;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Clinica;

[Authorize]
[ApiController]
[Route("api/clinica/[controller]")]
public class RecetasController : ControllerBase
{
    private readonly CreateRecetaHandler _createHandler;
    private readonly UpdateRecetaHandler _updateHandler;
    private readonly GetRecetaHandler _getHandler;
    private readonly ListRecetasByConsultaHandler _listByConsultaHandler;
    private readonly DeleteRecetaHandler _deleteHandler;

    public RecetasController(
        CreateRecetaHandler createHandler,
        UpdateRecetaHandler updateHandler,
        GetRecetaHandler getHandler,
        ListRecetasByConsultaHandler listByConsultaHandler,
        DeleteRecetaHandler deleteHandler)
    {
        _createHandler = createHandler;
        _updateHandler = updateHandler;
        _getHandler = getHandler;
        _listByConsultaHandler = listByConsultaHandler;
        _deleteHandler = deleteHandler;
    }

    [HttpPost]
    public async Task<ActionResult<CreateRecetaResponse>> Create([FromBody] CreateRecetaRequest request)
    {
        var response = await _createHandler.HandleAsync(request);
        return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<UpdateRecetaResponse>> Update(int id, [FromBody] UpdateRecetaRequest request)
    {
        var response = await _updateHandler.HandleAsync(id, request);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetRecetaResponse>> GetById(int id)
    {
        var response = await _getHandler.HandleAsync(id);
        return Ok(response);
    }

    [HttpGet("consulta/{consultaId}")]
    public async Task<ActionResult<IEnumerable<ListRecetasByConsultaResponse>>> GetByConsulta(int consultaId)
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