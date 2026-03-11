using Application.Interfaces.Repositories.Clinica;

namespace Application.UseCases.Clinica.SignosVitales.DeleteSignoVital;

public class DeleteSignoVitalHandler
{
    private readonly ISignoVitalRepository _signoVitalRepository;

    public DeleteSignoVitalHandler(ISignoVitalRepository signoVitalRepository)
    {
        _signoVitalRepository = signoVitalRepository;
    }

    public async Task HandleAsync(int id)
    {
        if (!await _signoVitalRepository.ExistsAsync(id))
            throw new KeyNotFoundException($"El signo vital con ID {id} no existe");

        await _signoVitalRepository.DeleteAsync(id);
    }
}