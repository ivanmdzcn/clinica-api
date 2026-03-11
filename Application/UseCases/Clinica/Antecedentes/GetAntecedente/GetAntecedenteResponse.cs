namespace Application.UseCases.Clinica.Antecedentes.GetAntecedente;

public class GetAntecedenteResponse
{
    public int Id { get; init; }
    public int PacienteId { get; init; }
    public string Tipo { get; init; } = string.Empty;
    public string Condicion { get; init; } = string.Empty;
    public string? Descripcion { get; init; }
}