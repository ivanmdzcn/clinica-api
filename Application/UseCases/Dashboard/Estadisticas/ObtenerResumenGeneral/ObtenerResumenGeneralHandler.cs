using Application.Interfaces.Repositories.Dashboard;
using Application.UseCases.Dashboard.Estadisticas.Shared;

namespace Application.UseCases.Dashboard.Estadisticas.ObtenerResumenGeneral;

public class ObtenerResumenGeneralHandler
{
    private readonly IEstadisticasRepository _estadisticasRepository;

    public ObtenerResumenGeneralHandler(IEstadisticasRepository estadisticasRepository)
    {
        _estadisticasRepository = estadisticasRepository;
    }

    public async Task<ResumenGeneralDto> HandleAsync()
    {
        return await _estadisticasRepository.ObtenerResumenGeneralAsync();
    }
}