namespace Application.UseCases.Clinica.Consultas.CreateConsulta;

public class CreateConsultaRequest
{
    public int PacienteId { get; init; }
    public int MedicoId { get; init; }
    public string? TipoConsulta { get; init; }
    public string MotivoConsulta { get; init; } = string.Empty;
    public string? Observaciones { get; init; }
    public DateTime? ProximaCita { get; init; }
}