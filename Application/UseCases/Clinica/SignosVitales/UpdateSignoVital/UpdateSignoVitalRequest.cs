namespace Application.UseCases.Clinica.SignosVitales.UpdateSignoVital;

public class UpdateSignoVitalRequest
{
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
}