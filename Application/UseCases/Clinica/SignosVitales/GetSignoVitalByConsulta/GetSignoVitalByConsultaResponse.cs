namespace Application.UseCases.Clinica.SignosVitales.GetSignoVitalByConsulta;

public class GetSignoVitalByConsultaResponse
{
    public int Id { get; init; }
    public int ConsultaId { get; init; }
    public int EnfermeraId { get; init; }
    public int? PresionSistolica { get; init; }
    public int? PresionDiastolica { get; init; }
    public decimal? Temperatura { get; init; }
    public int? FrecuenciaCardiaca { get; init; }
    public int? FrecuenciaRespiratoria { get; init; }
    public int? SaturacionOxigeno { get; init; }
    public decimal? Peso { get; init; }
    public decimal? Altura { get; init; }
    public decimal? GlucosaCapilar { get; init; }
    public int? NivelDolor { get; init; }
    public string? Observaciones { get; init; }
    public DateTime FechaRegistro { get; init; }
    public decimal? IMC { get; init; }
}