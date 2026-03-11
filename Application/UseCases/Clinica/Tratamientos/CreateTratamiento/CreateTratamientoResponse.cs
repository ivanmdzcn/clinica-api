namespace Application.UseCases.Clinica.Tratamientos.CreateTratamiento;

public class CreateTratamientoResponse
{
    public int Id { get; init; }
    public int ConsultaId { get; init; }
    public string Descripcion { get; init; } = string.Empty;
    public DateTime FechaRegistro { get; init; }
}