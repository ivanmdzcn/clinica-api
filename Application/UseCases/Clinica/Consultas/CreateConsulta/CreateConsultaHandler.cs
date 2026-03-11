using Application.Interfaces.Repositories;
using Application.Interfaces.Repositories.Auth;
using Application.Interfaces.Repositories.Clinica;
using Domain.Entities.Clinica;

namespace Application.UseCases.Clinica.Consultas.CreateConsulta;

public class CreateConsultaHandler
{
    private readonly IConsultaRepository _consultaRepository;
    private readonly IPacienteRepository _pacienteRepository;
    private readonly IUsuarioRepository _usuarioRepository;

    public CreateConsultaHandler(
        IConsultaRepository consultaRepository,
        IPacienteRepository pacienteRepository,
        IUsuarioRepository usuarioRepository)
    {
        _consultaRepository = consultaRepository;
        _pacienteRepository = pacienteRepository;
        _usuarioRepository = usuarioRepository;
    }

    public async Task<CreateConsultaResponse> HandleAsync(CreateConsultaRequest request)
    {
        // Validar que el paciente existe
        var paciente = await _pacienteRepository.GetByIdAsync(request.PacienteId);
        if (paciente == null)
            throw new InvalidOperationException($"El paciente con ID {request.PacienteId} no existe");

        // Validar que el médico existe
        var medico = await _usuarioRepository.GetByIdAsync(request.MedicoId);
        if (medico == null)
            throw new InvalidOperationException($"El médico con ID {request.MedicoId} no existe");

        var consulta = new Consulta(
            request.PacienteId,
            request.MedicoId,
            request.MotivoConsulta,
            request.TipoConsulta,
            request.Observaciones,
            request.ProximaCita
        );

        var id = await _consultaRepository.CreateAsync(consulta);

        return new CreateConsultaResponse
        {
            Id = id,
            PacienteId = consulta.PacienteId,
            MedicoId = consulta.MedicoId,
            TipoConsulta = consulta.TipoConsulta,
            MotivoConsulta = consulta.MotivoConsulta,
            FechaConsulta = consulta.FechaConsulta,
            Estado = consulta.Estado
        };
    }
}