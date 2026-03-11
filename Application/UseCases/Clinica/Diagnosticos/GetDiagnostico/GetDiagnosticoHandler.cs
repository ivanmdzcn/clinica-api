using Application.Interfaces.Repositories.Clinica;

namespace Application.UseCases.Clinica.Diagnosticos.GetDiagnostico;

public class GetDiagnosticoHandler
{
    private readonly IDiagnosticoRepository _diagnosticoRepository;

    public GetDiagnosticoHandler(IDiagnosticoRepository diagnosticoRepository)
    {
        _diagnosticoRepository = diagnosticoRepository;
    }

    public async Task<GetDiagnosticoResponse> HandleAsync(int id)
    {
        var diagnostico = await _diagnosticoRepository.GetByIdAsync(id)
            ?? throw new KeyNotFoundException($"El diagnóstico con ID {id} no existe");

        return new GetDiagnosticoResponse
        {
            Id = diagnostico.Id,
            ConsultaId = diagnostico.ConsultaId,
            CodigoCie10 = diagnostico.CodigoCie10,
            Descripcion = diagnostico.Descripcion,
            Tipo = diagnostico.Tipo,
            FechaRegistro = diagnostico.FechaRegistro
        };
    }
}