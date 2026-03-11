using Application.Interfaces.Repositories.Clinica;

namespace Application.UseCases.Clinica.Consultas.GetConsulta;

public class GetConsultaHandler
{
    private readonly IConsultaRepository _consultaRepository;

    public GetConsultaHandler(IConsultaRepository consultaRepository)
    {
        _consultaRepository = consultaRepository;
    }

    public async Task<GetConsultaResponse> HandleAsync(int id)
    {
        var consulta = await _consultaRepository.GetByIdAsync(id)
            ?? throw new KeyNotFoundException($"La consulta con ID {id} no existe");

        return new GetConsultaResponse
        {
            Id = consulta.Id,
            PacienteId = consulta.PacienteId,
            MedicoId = consulta.MedicoId,
            TipoConsulta = consulta.TipoConsulta,
            MotivoConsulta = consulta.MotivoConsulta,
            Observaciones = consulta.Observaciones,
            ProximaCita = consulta.ProximaCita,
            FechaConsulta = consulta.FechaConsulta,
            FechaActualizacion = consulta.FechaActualizacion,
            Estado = consulta.Estado
        };
    }
}