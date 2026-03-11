using Application.Interfaces.Repositories.Clinica;

namespace Application.UseCases.Clinica.ExamenesFisicos.DeleteExamenFisico;

public class DeleteExamenFisicoHandler
{
    private readonly IExamenFisicoRepository _examenFisicoRepository;

    public DeleteExamenFisicoHandler(IExamenFisicoRepository examenFisicoRepository)
    {
        _examenFisicoRepository = examenFisicoRepository;
    }

    public async Task HandleAsync(int id)
    {
        if (!await _examenFisicoRepository.ExistsAsync(id))
            throw new KeyNotFoundException($"El examen físico con ID {id} no existe");

        await _examenFisicoRepository.DeleteAsync(id);
    }
}