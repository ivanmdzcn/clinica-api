namespace Application.UseCases.Clinica.Diagnosticos.UpdateDiagnostico;

public class UpdateDiagnosticoRequest
{
    public string? CodigoCie10 { get; init; }
    public string Descripcion { get; init; } = string.Empty;
    public string Tipo { get; init; } = "definitivo";
}