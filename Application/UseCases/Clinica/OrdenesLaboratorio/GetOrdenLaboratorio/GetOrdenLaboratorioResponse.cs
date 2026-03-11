namespace Application.UseCases.Clinica.OrdenesLaboratorio.GetOrdenLaboratorio;

public class GetOrdenLaboratorioResponse
{
    public int Id { get; init; }
    public int ConsultaId { get; init; }
    public string NumeroOrden { get; init; } = string.Empty;
    public DateTime FechaOrden { get; init; }
    public int PacienteId { get; init; }
    public int MedicoId { get; init; }
    public string? DiagnosticoCie10 { get; init; }
    public string? Observaciones { get; init; }
    public DateTime FechaRegistro { get; init; }
}