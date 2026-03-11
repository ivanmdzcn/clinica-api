namespace Application.UseCases.Clinica.Diagnosticos.CreateDiagnostico;

public class CreateDiagnosticoResponse
{
    public int Id { get; init; }
    public int ConsultaId { get; init; }
    public string? CodigoCie10 { get; init; }
    public string Descripcion { get; init; } = string.Empty;
    public string Tipo { get; init; } = string.Empty;
    public DateTime FechaRegistro { get; init; }
}