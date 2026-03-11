namespace Application.UseCases.Clinica.Antecedentes.UpdateAntecedente;

public class UpdateAntecedenteResponse
{
    public int Id { get; init; }
    public int PacienteId { get; init; }
    public string Tipo { get; init; } = string.Empty;
    public string Condicion { get; init; } = string.Empty;
    public string? Descripcion { get; init; }
}