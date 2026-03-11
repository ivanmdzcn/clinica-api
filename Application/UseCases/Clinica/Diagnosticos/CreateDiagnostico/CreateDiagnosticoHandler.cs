using Application.Interfaces.Repositories.Clinica;
using Domain.Entities.Clinica;

namespace Application.UseCases.Clinica.Diagnosticos.CreateDiagnostico;

public class CreateDiagnosticoHandler
{
    private readonly IDiagnosticoRepository _diagnosticoRepository;
    private readonly IConsultaRepository _consultaRepository;

    public CreateDiagnosticoHandler(
        IDiagnosticoRepository diagnosticoRepository,
        IConsultaRepository consultaRepository)
    {
        _diagnosticoRepository = diagnosticoRepository;
        _consultaRepository = consultaRepository;
    }

    public async Task<CreateDiagnosticoResponse> HandleAsync(CreateDiagnosticoRequest request)
    {
        // Validar que la consulta existe
        if (!await _consultaRepository.ExistsAsync(request.ConsultaId))
            throw new InvalidOperationException($"La consulta con ID {request.ConsultaId} no existe");

        var diagnostico = new Diagnostico(
            request.ConsultaId,
            request.Descripcion,
            request.Tipo,
            request.CodigoCie10
        );

        var id = await _diagnosticoRepository.CreateAsync(diagnostico);

        return new CreateDiagnosticoResponse
        {
            Id = id,
            ConsultaId = diagnostico.ConsultaId,
            CodigoCie10 = diagnostico.CodigoCie10,
            Descripcion = diagnostico.Descripcion,
            Tipo = diagnostico.Tipo,
            FechaRegistro = diagnostico.FechaRegistro
        };
    }
}