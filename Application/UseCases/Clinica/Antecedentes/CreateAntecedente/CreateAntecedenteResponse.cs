namespace Application.UseCases.Clinica.Antecedentes.CreateAntecedente;

public class CreateAntecedenteResponse
{
    public int Id { get; init; }
    public int PacienteId { get; init; }
    public string Tipo { get; init; } = string.Empty;
    public string Condicion { get; init; } = string.Empty;
    public string? Descripcion { get; init; }
}