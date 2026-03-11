namespace Application.UseCases.Clinica.ExamenesLaboratorio.ListExamenesLaboratorioByOrden;

public class ListExamenesLaboratorioByOrdenResponse
{
    public int Id { get; init; }
    public int OrdenLaboratorioId { get; init; }
    public string NombreExamen { get; init; } = string.Empty;
    public string? Resultado { get; init; }
    public string? Unidad { get; init; }
    public string? ValorReferencia { get; init; }
    public DateTime? FechaResultado { get; init; }
}