namespace Application.UseCases.Clinica.Consultas.CreateConsulta;

public class CreateConsultaResponse
{
    public int Id { get; init; }
    public int PacienteId { get; init; }
    public int MedicoId { get; init; }
    public string? TipoConsulta { get; init; }
    public string MotivoConsulta { get; init; } = string.Empty;
    public DateTime FechaConsulta { get; init; }
    public string Estado { get; init; } = string.Empty;
}