using Application.Interfaces.Repositories.Clinica;

namespace Application.UseCases.Clinica.Consultas.UpdateConsulta;

public class UpdateConsultaHandler
{
    private readonly IConsultaRepository _consultaRepository;

    public UpdateConsultaHandler(IConsultaRepository consultaRepository)
    {
        _consultaRepository = consultaRepository;
    }

    public async Task<UpdateConsultaResponse> HandleAsync(int id, UpdateConsultaRequest request)
    {
        var consulta = await _consultaRepository.GetByIdAsync(id)
            ?? throw new KeyNotFoundException($"La consulta con ID {id} no existe");

        // No permitir actualizar consultas cerradas o anuladas
        if (consulta.Estado == "cerrada")
            throw new InvalidOperationException("No se puede actualizar una consulta cerrada");

        if (consulta.Estado == "anulada")
            throw new InvalidOperationException("No se puede actualizar una consulta anulada");

        consulta.Actualizar(
            request.TipoConsulta,
            request.MotivoConsulta,
            request.Observaciones,
            request.ProximaCita
        );

        await _consultaRepository.UpdateAsync(consulta);

        return new UpdateConsultaResponse
        {
            Id = consulta.Id,
            PacienteId = consulta.PacienteId,
            MedicoId = consulta.MedicoId,
            TipoConsulta = consulta.TipoConsulta,
            MotivoConsulta = consulta.MotivoConsulta,
            Observaciones = consulta.Observaciones,
            ProximaCita = consulta.ProximaCita,
            FechaActualizacion = consulta.FechaActualizacion,
            Estado = consulta.Estado
        };
    }
}