namespace Application.UseCases.Clinica.SignosVitales.UpdateSignoVital;

public class UpdateSignoVitalResponse
{
    public int Id { get; init; }
    public int ConsultaId { get; init; }
    public decimal? IMC { get; init; }
}