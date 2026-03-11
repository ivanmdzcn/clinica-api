namespace Application.UseCases.Clinica.Diagnosticos.CreateDiagnostico;

public class CreateDiagnosticoRequest
{
    public int ConsultaId { get; init; }
    public string? CodigoCie10 { get; init; }
    public string Descripcion { get; init; } = string.Empty;
    public string Tipo { get; init; } = "definitivo";
}