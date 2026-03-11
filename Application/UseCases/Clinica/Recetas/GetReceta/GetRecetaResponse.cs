namespace Application.UseCases.Clinica.Recetas.GetReceta;

public class GetRecetaResponse
{
    public int Id { get; init; }
    public int ConsultaId { get; init; }
    public string Medicamento { get; init; } = string.Empty;
    public string? Dosis { get; init; }
    public string? Frecuencia { get; init; }
    public string? Duracion { get; init; }
    public string? ViaAdministracion { get; init; }
    public string? Indicaciones { get; init; }
    public DateTime FechaRegistro { get; init; }
}