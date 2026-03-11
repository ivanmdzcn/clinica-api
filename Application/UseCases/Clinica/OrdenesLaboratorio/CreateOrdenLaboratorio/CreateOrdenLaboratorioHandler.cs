using Application.Interfaces.Repositories;
using Application.Interfaces.Repositories.Auth;
using Application.Interfaces.Repositories.Clinica;
using Domain.Entities.Clinica;

namespace Application.UseCases.Clinica.OrdenesLaboratorio.CreateOrdenLaboratorio;

public class CreateOrdenLaboratorioHandler
{
    private readonly IOrdenLaboratorioRepository _ordenLaboratorioRepository;
    private readonly IConsultaRepository _consultaRepository;
    private readonly IPacienteRepository _pacienteRepository;
    private readonly IUsuarioRepository _usuarioRepository;

    public CreateOrdenLaboratorioHandler(
        IOrdenLaboratorioRepository ordenLaboratorioRepository,
        IConsultaRepository consultaRepository,
        IPacienteRepository pacienteRepository,
        IUsuarioRepository usuarioRepository)
    {
        _ordenLaboratorioRepository = ordenLaboratorioRepository;
        _consultaRepository = consultaRepository;
        _pacienteRepository = pacienteRepository;
        _usuarioRepository = usuarioRepository;
    }

    public async Task<CreateOrdenLaboratorioResponse> HandleAsync(CreateOrdenLaboratorioRequest request)
    {
        // Validar que la consulta existe
        if (!await _consultaRepository.ExistsAsync(request.ConsultaId))
            throw new InvalidOperationException($"La consulta con ID {request.ConsultaId} no existe");

        // Validar que el paciente existe
        var paciente = await _pacienteRepository.GetByIdAsync(request.PacienteId);
        if (paciente == null)
            throw new InvalidOperationException($"El paciente con ID {request.PacienteId} no existe");

        // Validar que el médico existe
        var medico = await _usuarioRepository.GetByIdAsync(request.MedicoId);
        if (medico == null)
            throw new InvalidOperationException($"El médico con ID {request.MedicoId} no existe");

        // Validar que el número de orden sea único
        if (await _ordenLaboratorioRepository.ExistsNumeroOrdenAsync(request.NumeroOrden))
            throw new InvalidOperationException($"El número de orden '{request.NumeroOrden}' ya existe");

        var orden = new OrdenLaboratorio(
            request.ConsultaId,
            request.NumeroOrden,
            request.FechaOrden,
            request.PacienteId,
            request.MedicoId,
            request.DiagnosticoCie10,
            request.Observaciones
        );

        var id = await _ordenLaboratorioRepository.CreateAsync(orden);

        return new CreateOrdenLaboratorioResponse
        {
            Id = id,
            ConsultaId = orden.ConsultaId,
            NumeroOrden = orden.NumeroOrden,
            FechaOrden = orden.FechaOrden,
            FechaRegistro = orden.FechaRegistro
        };
    }
}