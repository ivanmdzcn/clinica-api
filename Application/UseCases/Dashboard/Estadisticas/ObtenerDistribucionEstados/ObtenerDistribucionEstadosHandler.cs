using Application.Interfaces.Repositories.Dashboard;
using Application.UseCases.Dashboard.Estadisticas.Shared;

namespace Application.UseCases.Dashboard.Estadisticas.ObtenerDistribucionEstados;

public class ObtenerDistribucionEstadosHandler
{
    private readonly IEstadisticasRepository _estadisticasRepository;

    public ObtenerDistribucionEstadosHandler(IEstadisticasRepository estadisticasRepository)
    {
        _estadisticasRepository = estadisticasRepository;
    }

    public async Task<IEnumerable<DistribucionEstadoDto>> HandleAsync()
    {
        return await _estadisticasRepository.ObtenerDistribucionEstadosAsync();
    }
}