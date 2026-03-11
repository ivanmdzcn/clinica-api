namespace Application.UseCases.Clinica.ExamenesLaboratorio.UpdateExamenLaboratorio;

public class UpdateExamenLaboratorioResponse
{
    public int Id { get; init; }
    public int OrdenLaboratorioId { get; init; }
    public string NombreExamen { get; init; } = string.Empty;
    public string? Resultado { get; init; }
    public string? Unidad { get; init; }
    public string? ValorReferencia { get; init; }
    public DateTime? FechaResultado { get; init; }
}