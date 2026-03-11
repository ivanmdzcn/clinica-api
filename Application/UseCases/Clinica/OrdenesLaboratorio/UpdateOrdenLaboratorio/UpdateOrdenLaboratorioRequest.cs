namespace Application.UseCases.Clinica.OrdenesLaboratorio.UpdateOrdenLaboratorio;

public class UpdateOrdenLaboratorioRequest
{
    public string NumeroOrden { get; init; } = string.Empty;
    public DateTime FechaOrden { get; init; }
    public string? DiagnosticoCie10 { get; init; }
    public string? Observaciones { get; init; }
}