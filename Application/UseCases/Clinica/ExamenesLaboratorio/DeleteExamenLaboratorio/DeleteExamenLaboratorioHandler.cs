using Application.Interfaces.Repositories.Clinica;

namespace Application.UseCases.Clinica.ExamenesLaboratorio.DeleteExamenLaboratorio;

public class DeleteExamenLaboratorioHandler
{
    private readonly IExamenLaboratorioRepository _examenLaboratorioRepository;

    public DeleteExamenLaboratorioHandler(IExamenLaboratorioRepository examenLaboratorioRepository)
    {
        _examenLaboratorioRepository = examenLaboratorioRepository;
    }

    public async Task HandleAsync(int id)
    {
        if (!await _examenLaboratorioRepository.ExistsAsync(id))
            throw new KeyNotFoundException($"El examen de laboratorio con ID {id} no existe");

        await _examenLaboratorioRepository.DeleteAsync(id);
    }
}