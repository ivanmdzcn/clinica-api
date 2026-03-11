using Application.UseCases.Clinica.Alergias.CreateAlergia;
using Application.UseCases.Clinica.Alergias.UpdateAlergia;
using Application.UseCases.Clinica.Alergias.GetAlergia;
using Application.UseCases.Clinica.Alergias.ListAlergiasByPaciente;
using Application.UseCases.Clinica.Alergias.DeleteAlergia;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Clinica;

[Authorize]
[ApiController]
[Route("api/clinica/[controller]")]
public class AlergiasController : ControllerBase
{
    private readonly CreateAlergiaHandler _createHandler;
    private readonly UpdateAlergiaHandler _updateHandler;
    private readonly GetAlergiaHandler _getHandler;
    private readonly ListAlergiasByPacienteHandler _listByPacienteHandler;
    private readonly DeleteAlergiaHandler _deleteHandler;

    public AlergiasController(
        CreateAlergiaHandler createHandler,
        UpdateAlergiaHandler updateHandler,
        GetAlergiaHandler getHandler,
        ListAlergiasByPacienteHandler listByPacienteHandler,
        DeleteAlergiaHandler deleteHandler)
    {
        _createHandler = createHandler;
        _updateHandler = updateHandler;
        _getHandler = getHandler;
        _listByPacienteHandler = listByPacienteHandler;
        _deleteHandler = deleteHandler;
    }

    [HttpPost]
    public async Task<ActionResult<CreateAlergiaResponse>> Create([FromBody] CreateAlergiaRequest request)
    {
        var response = await _createHandler.HandleAsync(request);
        return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<UpdateAlergiaResponse>> Update(int id, [FromBody] UpdateAlergiaRequest request)
    {
        var response = await _updateHandler.HandleAsync(id, request);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetAlergiaResponse>> GetById(int id)
    {
        var response = await _getHandler.HandleAsync(id);
        return Ok(response);
    }

    [HttpGet("paciente/{pacienteId}")]
    public async Task<ActionResult<IEnumerable<ListAlergiasByPacienteResponse>>> GetByPaciente(int pacienteId)
    {
        var response = await _listByPacienteHandler.HandleAsync(pacienteId);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _deleteHandler.HandleAsync(id);
        return NoContent();
    }
}