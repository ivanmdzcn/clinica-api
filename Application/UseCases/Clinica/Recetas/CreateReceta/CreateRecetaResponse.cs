namespace Application.UseCases.Clinica.Recetas.CreateReceta;

public class CreateRecetaResponse
{
    public int Id { get; init; }
    public int ConsultaId { get; init; }
    public string Medicamento { get; init; } = string.Empty;
    public DateTime FechaRegistro { get; init; }
}