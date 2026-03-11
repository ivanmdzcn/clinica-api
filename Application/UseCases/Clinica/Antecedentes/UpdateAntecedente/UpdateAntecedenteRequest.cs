namespace Application.UseCases.Clinica.Antecedentes.UpdateAntecedente;

public class UpdateAntecedenteRequest
{
    public string Tipo { get; init; } = string.Empty;
    public string Condicion { get; init; } = string.Empty;
    public string? Descripcion { get; init; }
}