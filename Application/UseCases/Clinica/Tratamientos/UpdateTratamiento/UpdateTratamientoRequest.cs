namespace Application.UseCases.Clinica.Tratamientos.UpdateTratamiento;

public class UpdateTratamientoRequest
{
    public string Descripcion { get; init; } = string.Empty;
    public string? Indicaciones { get; init; }
    public DateTime? FechaInicio { get; init; }
    public DateTime? FechaFin { get; init; }
}