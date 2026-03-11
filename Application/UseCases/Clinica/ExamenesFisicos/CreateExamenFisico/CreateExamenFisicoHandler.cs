using Application.Interfaces.Repositories.Clinica;
using Domain.Entities.Clinica;

namespace Application.UseCases.Clinica.ExamenesFisicos.CreateExamenFisico;

public class CreateExamenFisicoHandler
{
    private readonly IExamenFisicoRepository _examenFisicoRepository;
    private readonly IConsultaRepository _consultaRepository;

    public CreateExamenFisicoHandler(
        IExamenFisicoRepository examenFisicoRepository,
        IConsultaRepository consultaRepository)
    {
        _examenFisicoRepository = examenFisicoRepository;
        _consultaRepository = consultaRepository;
    }

    public async Task<CreateExamenFisicoResponse> HandleAsync(CreateExamenFisicoRequest request)
    {
        // Validar que la consulta existe
        if (!await _consultaRepository.ExistsAsync(request.ConsultaId))
            throw new InvalidOperationException($"La consulta con ID {request.ConsultaId} no existe");

        // Validar que no exista ya un examen físico para esta consulta
        var examenExistente = await _examenFisicoRepository.GetByConsultaIdAsync(request.ConsultaId);
        if (examenExistente != null)
            throw new InvalidOperationException($"Ya existe un examen físico registrado para la consulta {request.ConsultaId}");

        var examenFisico = new ExamenFisico(
            request.ConsultaId,
            request.EsNormal,
            request.Descripcion
        );

        var id = await _examenFisicoRepository.CreateAsync(examenFisico);

        return new CreateExamenFisicoResponse
        {
            Id = id,
            ConsultaId = examenFisico.ConsultaId,
            EsNormal = examenFisico.EsNormal,
            FechaRegistro = examenFisico.FechaRegistro
        };
    }
}