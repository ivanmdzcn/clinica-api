namespace Application.UseCases.Clinica.Consultas.UpdateConsulta;

public class UpdateConsultaResponse
{
    public int Id { get; init; }
    public int PacienteId { get; init; }
    public int MedicoId { get; init; }
    public string? TipoConsulta { get; init; }
    public string MotivoConsulta { get; init; } = string.Empty;
    public string? Diagnostico { get; init; }
    public string? EvolucionTratamiento { get; init; }
    public string? Observaciones { get; init; }
    public DateTime? ProximaCita { get; init; }
    public DateTime FechaActualizacion { get; init; }
    public string Estado { get; init; } = string.Empty;
}