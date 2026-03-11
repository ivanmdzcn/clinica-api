using Application.Interfaces.Repositories.Clinica;

namespace Application.UseCases.Clinica.Antecedentes.DeleteAntecedente;

public class DeleteAntecedenteHandler
{
    private readonly IAntecedenteRepository _antecedenteRepository;

    public DeleteAntecedenteHandler(IAntecedenteRepository antecedenteRepository)
    {
        _antecedenteRepository = antecedenteRepository;
    }

    public async Task HandleAsync(int id)
    {
        if (!await _antecedenteRepository.ExistsAsync(id))
            throw new KeyNotFoundException($"El antecedente con ID {id} no existe");

        await _antecedenteRepository.DeleteAsync(id);
    }
}