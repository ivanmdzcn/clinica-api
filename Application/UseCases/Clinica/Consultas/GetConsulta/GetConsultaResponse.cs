namespace Application.UseCases.Clinica.Consultas.GetConsulta;

public class GetConsultaResponse
{
    public int Id { get; init; }
    public int PacienteId { get; init; }
    public int MedicoId { get; init; }
    public string? TipoConsulta { get; init; }
    public string MotivoConsulta { get; init; } = string.Empty;
    public string? Observaciones { get; init; }
    public DateTime? ProximaCita { get; init; }
    public DateTime FechaConsulta { get; init; }
    public DateTime FechaActualizacion { get; init; }
    public string Estado { get; init; } = string.Empty;
}