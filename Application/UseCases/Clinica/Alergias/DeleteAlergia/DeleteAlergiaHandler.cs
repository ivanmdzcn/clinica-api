using Application.Interfaces.Repositories.Clinica;

namespace Application.UseCases.Clinica.Alergias.DeleteAlergia;

public class DeleteAlergiaHandler
{
    private readonly IAlergiaRepository _alergiaRepository;

    public DeleteAlergiaHandler(IAlergiaRepository alergiaRepository)
    {
        _alergiaRepository = alergiaRepository;
    }

    public async Task HandleAsync(int id)
    {
        if (!await _alergiaRepository.ExistsAsync(id))
            throw new KeyNotFoundException($"La alergia con ID {id} no existe");

        await _alergiaRepository.DeleteAsync(id);
    }
}