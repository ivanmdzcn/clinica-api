using Application.Interfaces.Repositories.Dashboard;
using Application.UseCases.Dashboard.Estadisticas.Shared;

namespace Application.UseCases.Dashboard.Estadisticas.ObtenerConsultasPorMedico;

public class ObtenerConsultasPorMedicoHandler
{
    private readonly IEstadisticasRepository _estadisticasRepository;

    public ObtenerConsultasPorMedicoHandler(IEstadisticasRepository estadisticasRepository)
    {
        _estadisticasRepository = estadisticasRepository;
    }

    public async Task<IEnumerable<ConsultaPorMedicoDto>> HandleAsync(ObtenerConsultasPorMedicoRequest request)
    {
        if (request.FechaInicio > request.FechaFin)
            throw new ArgumentException("La fecha de inicio no puede ser mayor que la fecha fin");

        return await _estadisticasRepository.ObtenerConsultasPorMedicoAsync(request.FechaInicio, request.FechaFin);
    }
}