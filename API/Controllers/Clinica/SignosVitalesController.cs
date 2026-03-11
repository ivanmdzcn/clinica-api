using API.Attributes;
using Application.UseCases.Clinica.SignosVitales.CreateSignoVital;
using Application.UseCases.Clinica.SignosVitales.DeleteSignoVital;
using Application.UseCases.Clinica.SignosVitales.GetSignoVital;
using Application.UseCases.Clinica.SignosVitales.GetSignoVitalByConsulta;
using Application.UseCases.Clinica.SignosVitales.UpdateSignoVital;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Clinica;

[Authorize]
[ApiController]
[Route("api/clinica/[controller]")]
public class SignosVitalesController : ControllerBase
{
    private readonly CreateSignoVitalHandler _createHandler;
    private readonly UpdateSignoVitalHandler _updateHandler;
    private readonly GetSignoVitalHandler _getHandler;
    private readonly GetSignoVitalByConsultaHandler _getByConsultaHandler;
    private readonly DeleteSignoVitalHandler _deleteHandler;

    public SignosVitalesController(
        CreateSignoVitalHandler createHandler,
        UpdateSignoVitalHandler updateHandler,
        GetSignoVitalHandler getHandler,
        GetSignoVitalByConsultaHandler getByConsultaHandler,
        DeleteSignoVitalHandler deleteHandler)
    {
        _createHandler = createHandler;
        _updateHandler = updateHandler;
        _getHandler = getHandler;
        _getByConsultaHandler = getByConsultaHandler;
        _deleteHandler = deleteHandler;
    }

    [HttpPost]
    [RequirePermission("SignosVitales.Crear")]
    public async Task<ActionResult<CreateSignoVitalResponse>> Create([FromBody] CreateSignoVitalRequest request)
    {
        var response = await _createHandler.HandleAsync(request);
        return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
    }

    [HttpPut("{id}")]
    [RequirePermission("SignosVitales.Editar")]
    public async Task<ActionResult<UpdateSignoVitalResponse>> Update(int id, [FromBody] UpdateSignoVitalRequest request)
    {
        var response = await _updateHandler.HandleAsync(id, request);
        return Ok(response);
    }

    [HttpGet("{id}")]
    [RequirePermission("SignosVitales.Ver")]
    public async Task<ActionResult<GetSignoVitalResponse>> GetById(int id)
    {
        var response = await _getHandler.HandleAsync(id);
        return Ok(response);
    }

    [HttpGet("consulta/{consultaId}")]
    [RequirePermission("SignosVitales.Ver")]
    public async Task<ActionResult<GetSignoVitalByConsultaResponse>> GetByConsulta(int consultaId)
    {
        var response = await _getByConsultaHandler.HandleAsync(consultaId);
        if (response == null)
            return NotFound($"No se encontraron signos vitales para la consulta {consultaId}");
        return Ok(response);
    }

    [HttpDelete("{id}")]
    [RequirePermission("SignosVitales.Eliminar")]
    public async Task<IActionResult> Delete(int id)
    {
        await _deleteHandler.HandleAsync(id);
        return NoContent();
    }
}