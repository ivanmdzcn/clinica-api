using Application.Interfaces.Repositories;
using Application.Interfaces.Security;
using Domain.Entities;

namespace Application.UseCases.Pacientes.CreatePaciente;

public class CreatePacienteHandler
{
    private readonly IPacienteRepository _pacienteRepository;
    private readonly ICurrentUserService _currentUserService;

    public CreatePacienteHandler(
        IPacienteRepository pacienteRepository,
        ICurrentUserService currentUserService)
    {
        _pacienteRepository = pacienteRepository;
        _currentUserService = currentUserService;
    }

    public async Task<CreatePacienteResponse> HandleAsync(CreatePacienteRequest request)
    {
        // Validar DPI único (si se proporciona)
        if (!string.IsNullOrEmpty(request.Dpi) && await _pacienteRepository.ExistsDpiAsync(request.Dpi))
            throw new InvalidOperationException($"El DPI '{request.Dpi}' ya está registrado");

        // Validar email único (si se proporciona)
        if (!string.IsNullOrEmpty(request.Email) && await _pacienteRepository.ExistsEmailAsync(request.Email))
            throw new InvalidOperationException($"El email '{request.Email}' ya está registrado");

        // Obtener usuario autenticado
        var usuarioId = _currentUserService.GetUserId();

        // Crear paciente
        var paciente = new Paciente(
            request.Nombres,
            request.Apellidos,
            request.FechaNacimiento,
            request.Sexo,
            usuarioId,
            request.Dpi,
            request.Telefono,
            request.Direccion,
            request.Email
        );

        var id = await _pacienteRepository.CreateAsync(paciente);

        return new CreatePacienteResponse
        {
            Id = id,
            NombreCompleto = paciente.NombreCompleto,
            Dpi = paciente.Dpi
        };
    }
}