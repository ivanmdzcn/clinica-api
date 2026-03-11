using Application.Interfaces.Repositories.Clinica;

namespace Application.UseCases.Clinica.Diagnosticos.UpdateDiagnostico;

public class UpdateDiagnosticoHandler
{
    private readonly IDiagnosticoRepository _diagnosticoRepository;

    public UpdateDiagnosticoHandler(IDiagnosticoRepository diagnosticoRepository)
    {
        _diagnosticoRepository = diagnosticoRepository;
    }

    public async Task<UpdateDiagnosticoResponse> HandleAsync(int id, UpdateDiagnosticoRequest request)
    {
        var diagnostico = await _diagnosticoRepository.GetByIdAsync(id)
            ?? throw new KeyNotFoundException($"El diagnóstico con ID {id} no existe");

        diagnostico.Actualizar(request.Descripcion, request.Tipo, request.CodigoCie10);

        await _diagnosticoRepository.UpdateAsync(diagnostico);

        return new UpdateDiagnosticoResponse
        {
            Id = diagnostico.Id,
            ConsultaId = diagnostico.ConsultaId,
            CodigoCie10 = diagnostico.CodigoCie10,
            Descripcion = diagnostico.Descripcion,
            Tipo = diagnostico.Tipo
        };
    }
}