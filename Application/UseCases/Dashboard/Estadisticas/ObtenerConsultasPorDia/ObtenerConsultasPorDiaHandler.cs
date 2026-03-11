using Application.Interfaces.Repositories.Dashboard;
using Application.UseCases.Dashboard.Estadisticas.Shared;

namespace Application.UseCases.Dashboard.Estadisticas.ObtenerConsultasPorDia;

public class ObtenerConsultasPorDiaHandler
{
    private readonly IEstadisticasRepository _estadisticasRepository;

    public ObtenerConsultasPorDiaHandler(IEstadisticasRepository estadisticasRepository)
    {
        _estadisticasRepository = estadisticasRepository;
    }

    public async Task<IEnumerable<ConsultaPorDiaDto>> HandleAsync(ObtenerConsultasPorDiaRequest request)
    {
        if (request.FechaInicio > request.FechaFin)
            throw new ArgumentException("La fecha de inicio no puede ser mayor que la fecha fin");

        return await _estadisticasRepository.ObtenerConsultasPorDiaAsync(request.FechaInicio, request.FechaFin);
    }
}