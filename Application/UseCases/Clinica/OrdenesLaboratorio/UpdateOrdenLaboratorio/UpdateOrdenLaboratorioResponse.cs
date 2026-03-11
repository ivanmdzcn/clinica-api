namespace Application.UseCases.Clinica.OrdenesLaboratorio.UpdateOrdenLaboratorio;

public class UpdateOrdenLaboratorioResponse
{
    public int Id { get; init; }
    public int ConsultaId { get; init; }
    public string NumeroOrden { get; init; } = string.Empty;
    public DateTime FechaOrden { get; init; }
    public string? DiagnosticoCie10 { get; init; }
    public string? Observaciones { get; init; }
}