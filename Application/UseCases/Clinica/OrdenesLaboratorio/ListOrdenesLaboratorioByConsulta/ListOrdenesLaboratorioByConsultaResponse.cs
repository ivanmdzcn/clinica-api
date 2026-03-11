namespace Application.UseCases.Clinica.OrdenesLaboratorio.ListOrdenesLaboratorioByConsulta;

public class ListOrdenesLaboratorioByConsultaResponse
{
    public int Id { get; init; }
    public int ConsultaId { get; init; }
    public string NumeroOrden { get; init; } = string.Empty;
    public DateTime FechaOrden { get; init; }
    public string? DiagnosticoCie10 { get; init; }
    public DateTime FechaRegistro { get; init; }
}