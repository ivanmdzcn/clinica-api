using Application.Interfaces.Repositories.Clinica;

namespace Application.UseCases.Clinica.Consultas.ListConsultasByPaciente;

public class ListConsultasByPacienteHandler
{
    private readonly IConsultaRepository _consultaRepository;

    public ListConsultasByPacienteHandler(IConsultaRepository consultaRepository)
    {
        _consultaRepository = consultaRepository;
    }

    public async Task<IEnumerable<ListConsultasByPacienteResponse>> HandleAsync(int pacienteId)
    {
        var consultas = await _consultaRepository.GetByPacienteIdAsync(pacienteId);

        return consultas.Select(c => new ListConsultasByPacienteResponse
        {
            Id = c.Id,
            PacienteId = c.PacienteId,
            MedicoId = c.MedicoId,
            TipoConsulta = c.TipoConsulta,
            MotivoConsulta = c.MotivoConsulta,
            FechaConsulta = c.FechaConsulta,
            Estado = c.Estado
        });
    }
}