using Application.Interfaces.Repositories.Auth;
using Application.Interfaces.Repositories.Clinica;
using Domain.Entities.Clinica;

namespace Application.UseCases.Clinica.Medicos.CreateMedico;

public class CreateMedicoHandler
{
    private readonly IMedicoRepository _medicoRepository;
    private readonly IUsuarioRepository _usuarioRepository;

    public CreateMedicoHandler(
        IMedicoRepository medicoRepository,
        IUsuarioRepository usuarioRepository)
    {
        _medicoRepository = medicoRepository;
        _usuarioRepository = usuarioRepository;
    }

    public async Task<CreateMedicoResponse> HandleAsync(CreateMedicoRequest request)
    {
        // Validar que el usuario existe
        var usuario = await _usuarioRepository.GetByIdAsync(request.UsuarioId);
        if (usuario == null)
            throw new InvalidOperationException($"El usuario con ID {request.UsuarioId} no existe");

        // Validar que no exista ya un médico para este usuario
        if (await _medicoRepository.ExistsByUsuarioIdAsync(request.UsuarioId))
            throw new InvalidOperationException($"Ya existe un médico asociado al usuario {request.UsuarioId}");

        // Validar que la cédula sea única
        if (await _medicoRepository.ExistsByCedulaAsync(request.CedulaProfesional))
            throw new InvalidOperationException($"La cédula profesional '{request.CedulaProfesional}' ya está registrada");

        var medico = new Medico(
            request.UsuarioId,
            request.CedulaProfesional,
            request.Especialidad,
            request.Subespecialidad,
            request.Consultorio,
            request.TelefonoConsultorio,
            request.HorarioAtencion,
            request.Observaciones,
            request.Activo
        );

        var id = await _medicoRepository.CreateAsync(medico);

        return new CreateMedicoResponse
        {
            Id = id,
            UsuarioId = medico.UsuarioId,
            CedulaProfesional = medico.CedulaProfesional,
            Especialidad = medico.Especialidad,
            FechaCreacion = medico.FechaCreacion
        };
    }
}