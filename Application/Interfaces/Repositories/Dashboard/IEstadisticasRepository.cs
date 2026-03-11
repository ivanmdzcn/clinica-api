using Application.UseCases.Dashboard.Estadisticas.Shared;

namespace Application.Interfaces.Repositories.Dashboard;

public interface IEstadisticasRepository
{
    Task<ResumenGeneralDto> ObtenerResumenGeneralAsync();
    Task<IEnumerable<ConsultaPorDiaDto>> ObtenerConsultasPorDiaAsync(DateTime fechaInicio, DateTime fechaFin);
    Task<IEnumerable<ConsultaPorMedicoDto>> ObtenerConsultasPorMedicoAsync(DateTime fechaInicio, DateTime fechaFin);
    Task<IEnumerable<PacientesPorMesDto>> ObtenerPacientesPorMesAsync(int anio);
    Task<IEnumerable<DistribucionEstadoDto>> ObtenerDistribucionEstadosAsync();
}