using Application.Interfaces.Repositories.Clinica;

namespace Application.UseCases.Clinica.Diagnosticos.DeleteDiagnostico;

public class DeleteDiagnosticoHandler
{
    private readonly IDiagnosticoRepository _diagnosticoRepository;

    public DeleteDiagnosticoHandler(IDiagnosticoRepository diagnosticoRepository)
    {
        _diagnosticoRepository = diagnosticoRepository;
    }

    public async Task HandleAsync(int id)
    {
        if (!await _diagnosticoRepository.ExistsAsync(id))
            throw new KeyNotFoundException($"El diagnóstico con ID {id} no existe");

        await _diagnosticoRepository.DeleteAsync(id);
    }
}