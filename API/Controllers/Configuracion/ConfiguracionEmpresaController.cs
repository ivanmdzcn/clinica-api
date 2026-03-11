using Application.UseCases.Configuracion.ConfiguracionEmpresa.CreateConfiguracionEmpresa;
using Application.UseCases.Configuracion.ConfiguracionEmpresa.UpdateConfiguracionEmpresa;
using Application.UseCases.Configuracion.ConfiguracionEmpresa.GetConfiguracionEmpresa;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Configuracion;

[Authorize]
[ApiController]
[Route("api/configuracion/empresa")]
public class ConfiguracionEmpresaController : ControllerBase
{
    private readonly CreateConfiguracionEmpresaHandler _createHandler;
    private readonly UpdateConfiguracionEmpresaHandler _updateHandler;
    private readonly GetConfiguracionEmpresaHandler _getHandler;

    public ConfiguracionEmpresaController(
        CreateConfiguracionEmpresaHandler createHandler,
        UpdateConfiguracionEmpresaHandler updateHandler,
        GetConfiguracionEmpresaHandler getHandler)
    {
        _createHandler = createHandler;
        _updateHandler = updateHandler;
        _getHandler = getHandler;
    }

    [HttpPost]
    public async Task<ActionResult<CreateConfiguracionEmpresaResponse>> Create([FromBody] CreateConfiguracionEmpresaRequest request)
    {
        var response = await _createHandler.HandleAsync(request);
        return Created(string.Empty, response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateConfiguracionEmpresaRequest request)
    {
        await _updateHandler.HandleAsync(request);
        return NoContent();
    }

    [HttpGet]
    [AllowAnonymous] // Permitir acceso público para logo, nombre, etc.
    public async Task<ActionResult<GetConfiguracionEmpresaResponse>> Get()
    {
        var response = await _getHandler.HandleAsync();
        
        if (response == null)
            return Ok(null); // Devuelve 200 con null en lugar de error
        
        return Ok(response);
    }
}