using Application.UseCases.Clinica.Antecedentes.CreateAntecedente;
using Application.UseCases.Clinica.Antecedentes.UpdateAntecedente;
using Application.UseCases.Clinica.Antecedentes.GetAntecedente;
using Application.UseCases.Clinica.Antecedentes.ListAntecedentesByPaciente;
using Application.UseCases.Clinica.Antecedentes.DeleteAntecedente;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Clinica;

[Authorize]
[ApiController]
[Route("api/clinica/[controller]")]
public class AntecedentesController : ControllerBase
{
    private readonly CreateAntecedenteHandler _createHandler;
    private readonly UpdateAntecedenteHandler _updateHandler;
    private readonly GetAntecedenteHandler _getHandler;
    private readonly ListAntecedentesByPacienteHandler _listByPacienteHandler;
    private readonly DeleteAntecedenteHandler _deleteHandler;

    public AntecedentesController(
        CreateAntecedenteHandler createHandler,
        UpdateAntecedenteHandler updateHandler,
        GetAntecedenteHandler getHandler,
        ListAntecedentesByPacienteHandler listByPacienteHandler,
        DeleteAntecedenteHandler deleteHandler)
    {
        _createHandler = createHandler;
        _updateHandler = updateHandler;
        _getHandler = getHandler;
        _listByPacienteHandler = listByPacienteHandler;
        _deleteHandler = deleteHandler;
    }

    [HttpPost]
    public async Task<ActionResult<CreateAntecedenteResponse>> Create([FromBody] CreateAntecedenteRequest request)
    {
        var response = await _createHandler.HandleAsync(request);
        return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<UpdateAntecedenteResponse>> Update(int id, [FromBody] UpdateAntecedenteRequest request)
    {
        var response = await _updateHandler.HandleAsync(id, request);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetAntecedenteResponse>> GetById(int id)
    {
        var response = await _getHandler.HandleAsync(id);
        return Ok(response);
    }

    [HttpGet("paciente/{pacienteId}")]
    public async Task<ActionResult<IEnumerable<ListAntecedentesByPacienteResponse>>> GetByPaciente(int pacienteId)
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