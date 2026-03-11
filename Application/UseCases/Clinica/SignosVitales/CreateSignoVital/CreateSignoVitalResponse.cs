namespace Application.UseCases.Clinica.SignosVitales.CreateSignoVital;

public class CreateSignoVitalResponse
{
    public int Id { get; init; }
    public int ConsultaId { get; init; }
    public int EnfermeraId { get; init; }
    public DateTime FechaRegistro { get; init; }
    public decimal? IMC { get; init; }
}