using Application.Interfaces.Repositories;

namespace Application.UseCases.Pacientes.GetPaciente;

public class GetPacienteHandler
{
    private readonly IPacienteRepository _pacienteRepository;

    public GetPacienteHandler(IPacienteRepository pacienteRepository)
    {
        _pacienteRepository = pacienteRepository;
    }

    public async Task<GetPacienteResponse> HandleAsync(GetPacienteRequest request)
    {
        var paciente = await _pacienteRepository.GetByIdAsync(request.Id)
            ?? throw new KeyNotFoundException($"No se encontró el paciente con ID {request.Id}");

        return new GetPacienteResponse
        {
            Id = paciente.Id,
            Dpi = paciente.Dpi,
            Nombres = paciente.Nombres,
            Apellidos = paciente.Apellidos,
            NombreCompleto = paciente.NombreCompleto,
            FechaNacimiento = paciente.FechaNacimiento,
            Edad = paciente.CalcularEdad(),
            Sexo = paciente.Sexo,
            Telefono = paciente.Telefono,
            Direccion = paciente.Direccion,
            Email = paciente.Email,
            FechaRegistro = paciente.FechaRegistro,
            CreadoPor = paciente.CreadoPor
        };
    }
}