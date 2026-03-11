namespace Application.UseCases.Clinica.Tratamientos.ListTratamientosByConsulta;

public class ListTratamientosByConsultaResponse
{
    public int Id { get; init; }
    public int ConsultaId { get; init; }
    public string Descripcion { get; init; } = string.Empty;
    public string? Indicaciones { get; init; }
    public DateTime? FechaInicio { get; init; }
    public DateTime? FechaFin { get; init; }
    public DateTime FechaRegistro { get; init; }
}