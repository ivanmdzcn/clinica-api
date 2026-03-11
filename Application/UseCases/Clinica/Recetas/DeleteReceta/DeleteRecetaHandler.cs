using Application.Interfaces.Repositories.Clinica;

namespace Application.UseCases.Clinica.Recetas.DeleteReceta;

public class DeleteRecetaHandler
{
    private readonly IRecetaRepository _recetaRepository;

    public DeleteRecetaHandler(IRecetaRepository recetaRepository)
    {
        _recetaRepository = recetaRepository;
    }

    public async Task HandleAsync(int id)
    {
        if (!await _recetaRepository.ExistsAsync(id))
            throw new KeyNotFoundException($"La receta con ID {id} no existe");

        await _recetaRepository.DeleteAsync(id);
    }
}