using Application.Interfaces.Repositories;

namespace Application.UseCases.Pacientes.UpdatePaciente;

public class UpdatePacienteHandler
{
    private readonly IPacienteRepository _pacienteRepository;

    public UpdatePacienteHandler(IPacienteRepository pacienteRepository)
    {
        _pacienteRepository = pacienteRepository;
    }

    public async Task<UpdatePacienteResponse> HandleAsync(int id, UpdatePacienteRequest request)
    {
        var paciente = await _pacienteRepository.GetByIdAsync(id)
            ?? throw new KeyNotFoundException($"No se encontró el paciente con ID {id}");

        // Validar DPI único (si se proporciona y cambió)
        if (!string.IsNullOrEmpty(request.Dpi) && request.Dpi != paciente.Dpi)
        {
            if (await _pacienteRepository.ExistsDpiAsync(request.Dpi, id))
                throw new InvalidOperationException($"El DPI '{request.Dpi}' ya está registrado");
        }

        // Validar email único (si se proporciona y cambió)
        if (!string.IsNullOrEmpty(request.Email) && request.Email != paciente.Email)
        {
            if (await _pacienteRepository.ExistsEmailAsync(request.Email, id))
                throw new InvalidOperationException($"El email '{request.Email}' ya está registrado");
        }

        // Actualizar paciente
        paciente.Actualizar(
            request.Nombres,
            request.Apellidos,
            request.FechaNacimiento,
            request.Sexo,
            request.Dpi,
            request.Telefono,
            request.Direccion,
            request.Email
        );

        await _pacienteRepository.UpdateAsync(paciente);

        return new UpdatePacienteResponse
        {
            Id = paciente.Id,
            NombreCompleto = paciente.NombreCompleto,
            Dpi = paciente.Dpi
        };
    }
}