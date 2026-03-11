using Application.Interfaces.Repositories;

namespace Application.UseCases.Pacientes.DeletePaciente;

public class DeletePacienteHandler
{
    private readonly IPacienteRepository _pacienteRepository;

    public DeletePacienteHandler(IPacienteRepository pacienteRepository)
    {
        _pacienteRepository = pacienteRepository;
    }

    public async Task HandleAsync(DeletePacienteRequest request)
    {
        var paciente = await _pacienteRepository.GetByIdAsync(request.Id)
            ?? throw new KeyNotFoundException($"No se encontró el paciente con ID {request.Id}");

        await _pacienteRepository.DeleteAsync(request.Id);
    }
}