using Application.Interfaces.Repositories.Clinica;
using Domain.Entities.Clinica;

namespace Application.UseCases.Clinica.ExamenesLaboratorio.CreateExamenLaboratorio;

public class CreateExamenLaboratorioHandler
{
    private readonly IExamenLaboratorioRepository _examenLaboratorioRepository;
    private readonly IOrdenLaboratorioRepository _ordenLaboratorioRepository;

    public CreateExamenLaboratorioHandler(
        IExamenLaboratorioRepository examenLaboratorioRepository,
        IOrdenLaboratorioRepository ordenLaboratorioRepository)
    {
        _examenLaboratorioRepository = examenLaboratorioRepository;
        _ordenLaboratorioRepository = ordenLaboratorioRepository;
    }

    public async Task<CreateExamenLaboratorioResponse> HandleAsync(CreateExamenLaboratorioRequest request)
    {
        // Validar que la orden de laboratorio existe
        if (!await _ordenLaboratorioRepository.ExistsAsync(request.OrdenLaboratorioId))
            throw new InvalidOperationException($"La orden de laboratorio con ID {request.OrdenLaboratorioId} no existe");

        var examen = new ExamenLaboratorio(
            request.OrdenLaboratorioId,
            request.NombreExamen,
            request.Resultado,
            request.Unidad,
            request.ValorReferencia,
            request.FechaResultado
        );

        var id = await _examenLaboratorioRepository.CreateAsync(examen);

        return new CreateExamenLaboratorioResponse
        {
            Id = id,
            OrdenLaboratorioId = examen.OrdenLaboratorioId,
            NombreExamen = examen.NombreExamen,
            FechaRegistro = examen.FechaRegistro
        };
    }
}