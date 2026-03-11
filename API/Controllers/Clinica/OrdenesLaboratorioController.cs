using Application.UseCases.Clinica.OrdenesLaboratorio.CreateOrdenLaboratorio;
using Application.UseCases.Clinica.OrdenesLaboratorio.UpdateOrdenLaboratorio;
using Application.UseCases.Clinica.OrdenesLaboratorio.GetOrdenLaboratorio;
using Application.UseCases.Clinica.OrdenesLaboratorio.ListOrdenesLaboratorioByConsulta;
using Application.UseCases.Clinica.OrdenesLaboratorio.DeleteOrdenLaboratorio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Clinica;

[Authorize]
[ApiController]
[Route("api/clinica/[controller]")]
public class OrdenesLaboratorioController : ControllerBase
{
    private readonly CreateOrdenLaboratorioHandler _createHandler;
    private readonly UpdateOrdenLaboratorioHandler _updateHandler;
    private readonly GetOrdenLaboratorioHandler _getHandler;
    private readonly ListOrdenesLaboratorioByConsultaHandler _listByConsultaHandler;
    private readonly DeleteOrdenLaboratorioHandler _deleteHandler;

    public OrdenesLaboratorioController(
        CreateOrdenLaboratorioHandler createHandler,
        UpdateOrdenLaboratorioHandler updateHandler,
        GetOrdenLaboratorioHandler getHandler,
        ListOrdenesLaboratorioByConsultaHandler listByConsultaHandler,
        DeleteOrdenLaboratorioHandler deleteHandler)
    {
        _createHandler = createHandler;
        _updateHandler = updateHandler;
        _getHandler = getHandler;
        _listByConsultaHandler = listByConsultaHandler;
        _deleteHandler = deleteHandler;
    }

    [HttpPost]
    public async Task<ActionResult<CreateOrdenLaboratorioResponse>> Create([FromBody] CreateOrdenLaboratorioRequest request)
    {
        var response = await _createHandler.HandleAsync(request);
        return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<UpdateOrdenLaboratorioResponse>> Update(int id, [FromBody] UpdateOrdenLaboratorioRequest request)
    {
        var response = await _updateHandler.HandleAsync(id, request);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetOrdenLaboratorioResponse>> GetById(int id)
    {
        var response = await _getHandler.HandleAsync(id);
        return Ok(response);
    }

    [HttpGet("consulta/{consultaId}")]
    public async Task<ActionResult<IEnumerable<ListOrdenesLaboratorioByConsultaResponse>>> GetByConsulta(int consultaId)
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