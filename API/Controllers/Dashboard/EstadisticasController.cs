using API.Attributes;
using Application.UseCases.Dashboard.Estadisticas.ObtenerConsultasPorDia;
using Application.UseCases.Dashboard.Estadisticas.ObtenerConsultasPorMedico;
using Application.UseCases.Dashboard.Estadisticas.ObtenerDistribucionEstados;
using Application.UseCases.Dashboard.Estadisticas.ObtenerPacientesPorMes;
using Application.UseCases.Dashboard.Estadisticas.ObtenerResumenGeneral;
using Application.UseCases.Dashboard.Estadisticas.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Dashboard;

[ApiController]
[Route("api/dashboard/[controller]")]
[Authorize]
public class EstadisticasController : ControllerBase
{
    private readonly ObtenerResumenGeneralHandler _resumenGeneralHandler;
    private readonly ObtenerConsultasPorDiaHandler _consultasPorDiaHandler;
    private readonly ObtenerConsultasPorMedicoHandler _consultasPorMedicoHandler;
    private readonly ObtenerPacientesPorMesHandler _pacientesPorMesHandler;
    private readonly ObtenerDistribucionEstadosHandler _distribucionEstadosHandler;

    public EstadisticasController(
        ObtenerResumenGeneralHandler resumenGeneralHandler,
        ObtenerConsultasPorDiaHandler consultasPorDiaHandler,
        ObtenerConsultasPorMedicoHandler consultasPorMedicoHandler,
        ObtenerPacientesPorMesHandler pacientesPorMesHandler,
        ObtenerDistribucionEstadosHandler distribucionEstadosHandler)
    {
        _resumenGeneralHandler = resumenGeneralHandler;
        _consultasPorDiaHandler = consultasPorDiaHandler;
        _consultasPorMedicoHandler = consultasPorMedicoHandler;
        _pacientesPorMesHandler = pacientesPorMesHandler;
        _distribucionEstadosHandler = distribucionEstadosHandler;
    }

    /// <summary>
    /// Obtener resumen general del dashboard - Requiere permiso Dashboard.Ver
    /// </summary>
    [HttpGet("resumen-general")]
    [RequirePermission("Dashboard.Ver")]
    public async Task<ActionResult<ResumenGeneralDto>> ObtenerResumenGeneral()
    {
        var result = await _resumenGeneralHandler.HandleAsync();
        return Ok(result);
    }

    /// <summary>
    /// Obtener consultas por día en un rango de fechas - Requiere permiso Dashboard.Ver
    /// </summary>
    [HttpGet("consultas-por-dia")]
    [RequirePermission("Dashboard.Ver")]
    public async Task<ActionResult<IEnumerable<ConsultaPorDiaDto>>> ObtenerConsultasPorDia(
        [FromQuery] DateTime fechaInicio,
        [FromQuery] DateTime fechaFin)
    {
        var request = new ObtenerConsultasPorDiaRequest
        {
            FechaInicio = fechaInicio,
            FechaFin = fechaFin
        };

        var result = await _consultasPorDiaHandler.HandleAsync(request);
        return Ok(result);
    }

    /// <summary>
    /// Obtener consultas agrupadas por médico - Requiere permiso Dashboard.Ver
    /// </summary>
    [HttpGet("consultas-por-medico")]
    [RequirePermission("Dashboard.Ver")]
    public async Task<ActionResult<IEnumerable<ConsultaPorMedicoDto>>> ObtenerConsultasPorMedico(
        [FromQuery] DateTime fechaInicio,
        [FromQuery] DateTime fechaFin)
    {
        var request = new ObtenerConsultasPorMedicoRequest
        {
            FechaInicio = fechaInicio,
            FechaFin = fechaFin
        };

        var result = await _consultasPorMedicoHandler.HandleAsync(request);
        return Ok(result);
    }

    /// <summary>
    /// Obtener pacientes registrados por mes en un año - Requiere permiso Dashboard.Ver
    /// </summary>
    [HttpGet("pacientes-por-mes")]
    [RequirePermission("Dashboard.Ver")]
    public async Task<ActionResult<IEnumerable<PacientesPorMesDto>>> ObtenerPacientesPorMes(
        [FromQuery] int anio)
    {
        var request = new ObtenerPacientesPorMesRequest { Anio = anio };
        var result = await _pacientesPorMesHandler.HandleAsync(request);
        return Ok(result);
    }

    /// <summary>
    /// Obtener distribución de consultas por estado - Requiere permiso Dashboard.Ver
    /// </summary>
    [HttpGet("distribucion-estados")]
    [RequirePermission("Dashboard.Ver")]
    public async Task<ActionResult<IEnumerable<DistribucionEstadoDto>>> ObtenerDistribucionEstados()
    {
        var result = await _distribucionEstadosHandler.HandleAsync();
        return Ok(result);
    }
}