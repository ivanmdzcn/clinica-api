using Application.Interfaces.Repositories.Clinica;

namespace Application.UseCases.Clinica.OrdenesLaboratorio.DeleteOrdenLaboratorio;

public class DeleteOrdenLaboratorioHandler
{
    private readonly IOrdenLaboratorioRepository _ordenLaboratorioRepository;

    public DeleteOrdenLaboratorioHandler(IOrdenLaboratorioRepository ordenLaboratorioRepository)
    {
        _ordenLaboratorioRepository = ordenLaboratorioRepository;
    }

    public async Task HandleAsync(int id)
    {
        if (!await _ordenLaboratorioRepository.ExistsAsync(id))
            throw new KeyNotFoundException($"La orden de laboratorio con ID {id} no existe");

        await _ordenLaboratorioRepository.DeleteAsync(id);
    }
}