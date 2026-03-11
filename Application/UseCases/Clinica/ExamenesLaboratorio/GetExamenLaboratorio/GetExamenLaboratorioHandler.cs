using Application.Interfaces.Repositories.Clinica;

namespace Application.UseCases.Clinica.ExamenesLaboratorio.GetExamenLaboratorio;

public class GetExamenLaboratorioHandler
{
    private readonly IExamenLaboratorioRepository _examenLaboratorioRepository;

    public GetExamenLaboratorioHandler(IExamenLaboratorioRepository examenLaboratorioRepository)
    {
        _examenLaboratorioRepository = examenLaboratorioRepository;
    }

    public async Task<GetExamenLaboratorioResponse> HandleAsync(int id)
    {
        var examen = await _examenLaboratorioRepository.GetByIdAsync(id)
            ?? throw new KeyNotFoundException($"El examen de laboratorio con ID {id} no existe");

        return new GetExamenLaboratorioResponse
        {
            Id = examen.Id,
            OrdenLaboratorioId = examen.OrdenLaboratorioId,
            NombreExamen = examen.NombreExamen,
            Resultado = examen.Resultado,
            Unidad = examen.Unidad,
            ValorReferencia = examen.ValorReferencia,
            FechaResultado = examen.FechaResultado,
            FechaRegistro = examen.FechaRegistro
        };
    }
}