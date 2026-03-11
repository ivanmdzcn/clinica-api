using Application.Interfaces.Repositories.Clinica;

namespace Application.UseCases.Clinica.ExamenesLaboratorio.ListExamenesLaboratorioByOrden;

public class ListExamenesLaboratorioByOrdenHandler
{
    private readonly IExamenLaboratorioRepository _examenLaboratorioRepository;

    public ListExamenesLaboratorioByOrdenHandler(IExamenLaboratorioRepository examenLaboratorioRepository)
    {
        _examenLaboratorioRepository = examenLaboratorioRepository;
    }

    public async Task<IEnumerable<ListExamenesLaboratorioByOrdenResponse>> HandleAsync(int ordenLaboratorioId)
    {
        var examenes = await _examenLaboratorioRepository.GetByOrdenLaboratorioIdAsync(ordenLaboratorioId);

        return examenes.Select(e => new ListExamenesLaboratorioByOrdenResponse
        {
            Id = e.Id,
            OrdenLaboratorioId = e.OrdenLaboratorioId,
            NombreExamen = e.NombreExamen,
            Resultado = e.Resultado,
            Unidad = e.Unidad,
            ValorReferencia = e.ValorReferencia,
            FechaResultado = e.FechaResultado
        });
    }
}