namespace Application.UseCases.Clinica.ExamenesLaboratorio.GetExamenLaboratorio;

public class GetExamenLaboratorioResponse
{
    public int Id { get; init; }
    public int OrdenLaboratorioId { get; init; }
    public string NombreExamen { get; init; } = string.Empty;
    public string? Resultado { get; init; }
    public string? Unidad { get; init; }
    public string? ValorReferencia { get; init; }
    public DateTime? FechaResultado { get; init; }
    public DateTime FechaRegistro { get; init; }
}