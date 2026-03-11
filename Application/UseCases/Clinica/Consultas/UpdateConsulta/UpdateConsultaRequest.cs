namespace Application.UseCases.Clinica.Consultas.UpdateConsulta;

public class UpdateConsultaRequest
{
    public string? TipoConsulta { get; init; }
    public string MotivoConsulta { get; init; } = string.Empty;
    public string? Observaciones { get; init; }
    public DateTime? ProximaCita { get; init; }
}