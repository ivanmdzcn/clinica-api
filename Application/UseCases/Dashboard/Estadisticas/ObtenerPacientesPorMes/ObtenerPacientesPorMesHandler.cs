using Application.Interfaces.Repositories.Dashboard;
using Application.UseCases.Dashboard.Estadisticas.Shared;

namespace Application.UseCases.Dashboard.Estadisticas.ObtenerPacientesPorMes;

public class ObtenerPacientesPorMesHandler
{
    private readonly IEstadisticasRepository _estadisticasRepository;

    public ObtenerPacientesPorMesHandler(IEstadisticasRepository estadisticasRepository)
    {
        _estadisticasRepository = estadisticasRepository;
    }

    public async Task<IEnumerable<PacientesPorMesDto>> HandleAsync(ObtenerPacientesPorMesRequest request)
    {
        if (request.Anio < 2000 || request.Anio > DateTime.Now.Year)
            throw new ArgumentException($"El año debe estar entre 2000 y {DateTime.Now.Year}");

        return await _estadisticasRepository.ObtenerPacientesPorMesAsync(request.Anio);
    }
}