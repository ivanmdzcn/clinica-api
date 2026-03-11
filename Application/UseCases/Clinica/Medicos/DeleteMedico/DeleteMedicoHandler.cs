using Application.Interfaces.Repositories.Clinica;

namespace Application.UseCases.Clinica.Medicos.DeleteMedico;

public class DeleteMedicoHandler
{
    private readonly IMedicoRepository _medicoRepository;

    public DeleteMedicoHandler(IMedicoRepository medicoRepository)
    {
        _medicoRepository = medicoRepository;
    }

    public async Task HandleAsync(int id)
    {
        if (!await _medicoRepository.ExistsAsync(id))
            throw new KeyNotFoundException($"El médico con ID {id} no existe");

        await _medicoRepository.DeleteAsync(id);
    }
}