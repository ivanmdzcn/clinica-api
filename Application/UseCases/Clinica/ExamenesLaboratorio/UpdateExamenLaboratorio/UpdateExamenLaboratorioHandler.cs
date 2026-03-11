using Application.Interfaces.Repositories.Clinica;

namespace Application.UseCases.Clinica.ExamenesLaboratorio.UpdateExamenLaboratorio;

public class UpdateExamenLaboratorioHandler
{
    private readonly IExamenLaboratorioRepository _examenLaboratorioRepository;

    public UpdateExamenLaboratorioHandler(IExamenLaboratorioRepository examenLaboratorioRepository)
    {
        _examenLaboratorioRepository = examenLaboratorioRepository;
    }

    public async Task<UpdateExamenLaboratorioResponse> HandleAsync(int id, UpdateExamenLaboratorioRequest request)
    {
        var examen = await _examenLaboratorioRepository.GetByIdAsync(id)
            ?? throw new KeyNotFoundException($"El examen de laboratorio con ID {id} no existe");

        examen.Actualizar(
            request.NombreExamen,
            request.Resultado,
            request.Unidad,
            request.ValorReferencia,
            request.FechaResultado
        );

        await _examenLaboratorioRepository.UpdateAsync(examen);

        return new UpdateExamenLaboratorioResponse
        {
            Id = examen.Id,
            OrdenLaboratorioId = examen.OrdenLaboratorioId,
            NombreExamen = examen.NombreExamen,
            Resultado = examen.Resultado,
            Unidad = examen.Unidad,
            ValorReferencia = examen.ValorReferencia,
            FechaResultado = examen.FechaResultado
        };
    }
}