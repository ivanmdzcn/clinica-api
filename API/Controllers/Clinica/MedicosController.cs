using API.Attributes;
using Application.UseCases.Clinica.Medicos.CreateMedico;
using Application.UseCases.Clinica.Medicos.DeleteMedico;
using Application.UseCases.Clinica.Medicos.GetMedico;
using Application.UseCases.Clinica.Medicos.ListMedicos;
using Application.UseCases.Clinica.Medicos.UpdateMedico;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Clinica;

[Authorize]
[ApiController]
[Route("api/clinica/[controller]")]
public class MedicosController : ControllerBase
{
    private readonly CreateMedicoHandler _createHandler;
    private readonly UpdateMedicoHandler _updateHandler;
    private readonly GetMedicoHandler _getHandler;
    private readonly ListMedicosHandler _listHandler;
    private readonly DeleteMedicoHandler _deleteHandler;

    public MedicosController(
        CreateMedicoHandler createHandler,
        UpdateMedicoHandler updateHandler,
        GetMedicoHandler getHandler,
        ListMedicosHandler listHandler,
        DeleteMedicoHandler deleteHandler)
    {
        _createHandler = createHandler;
        _updateHandler = updateHandler;
        _getHandler = getHandler;
        _listHandler = listHandler;
        _deleteHandler = deleteHandler;
    }

    [HttpPost]   
    [RequirePermission("Medicos.Crear")]
    public async Task<ActionResult<CreateMedicoResponse>> Create([FromBody] CreateMedicoRequest request)
    {
        var response = await _createHandler.HandleAsync(request);
        return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
    }

    [HttpPut("{id}")]
    [RequirePermission("Medicos.Editar")]
    public async Task<ActionResult<UpdateMedicoResponse>> Update(int id, [FromBody] UpdateMedicoRequest request)
    {
        var response = await _updateHandler.HandleAsync(id, request);
        return Ok(response);
    }

    [HttpGet("{id}")]
    [RequirePermission("Medicos.Ver")]
    public async Task<ActionResult<GetMedicoResponse>> GetById(int id)
    {
        var response = await _getHandler.HandleAsync(id);
        return Ok(response);
    }

    [HttpGet]
    [RequirePermission("Medicos.Ver")]
    public async Task<ActionResult<IEnumerable<ListMedicosResponse>>> GetAll([FromQuery] bool? soloActivos = true)
    {
        var response = await _listHandler.HandleAsync(soloActivos);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    [RequirePermission("Medicos.Eliminar")]
    public async Task<IActionResult> Delete(int id)
    {
        await _deleteHandler.HandleAsync(id);
        return NoContent();
    }
}