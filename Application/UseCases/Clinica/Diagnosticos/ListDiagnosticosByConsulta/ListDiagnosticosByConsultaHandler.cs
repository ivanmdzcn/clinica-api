using Application.Interfaces.Repositories.Clinica;

namespace Application.UseCases.Clinica.Diagnosticos.ListDiagnosticosByConsulta;

public class ListDiagnosticosByConsultaHandler
{
    private readonly IDiagnosticoRepository _diagnosticoRepository;

    public ListDiagnosticosByConsultaHandler(IDiagnosticoRepository diagnosticoRepository)
    {
        _diagnosticoRepository = diagnosticoRepository;
    }

    public async Task<IEnumerable<ListDiagnosticosByConsultaResponse>> HandleAsync(int consultaId)
    {
        var diagnosticos = await _diagnosticoRepository.GetByConsultaIdAsync(consultaId);

        return diagnosticos.Select(d => new ListDiagnosticosByConsultaResponse
        {
            Id = d.Id,
            ConsultaId = d.ConsultaId,
            CodigoCie10 = d.CodigoCie10,
            Descripcion = d.Descripcion,
            Tipo = d.Tipo,
            FechaRegistro = d.FechaRegistro
        });
    }
}