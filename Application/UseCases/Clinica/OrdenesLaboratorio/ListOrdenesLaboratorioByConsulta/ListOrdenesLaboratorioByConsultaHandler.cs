using Application.Interfaces.Repositories.Clinica;

namespace Application.UseCases.Clinica.OrdenesLaboratorio.ListOrdenesLaboratorioByConsulta;

public class ListOrdenesLaboratorioByConsultaHandler
{
    private readonly IOrdenLaboratorioRepository _ordenLaboratorioRepository;

    public ListOrdenesLaboratorioByConsultaHandler(IOrdenLaboratorioRepository ordenLaboratorioRepository)
    {
        _ordenLaboratorioRepository = ordenLaboratorioRepository;
    }

    public async Task<IEnumerable<ListOrdenesLaboratorioByConsultaResponse>> HandleAsync(int consultaId)
    {
        var ordenes = await _ordenLaboratorioRepository.GetByConsultaIdAsync(consultaId);

        return ordenes.Select(o => new ListOrdenesLaboratorioByConsultaResponse
        {
            Id = o.Id,
            ConsultaId = o.ConsultaId,
            NumeroOrden = o.NumeroOrden,
            FechaOrden = o.FechaOrden,
            DiagnosticoCie10 = o.DiagnosticoCie10,
            FechaRegistro = o.FechaRegistro
        });
    }
}