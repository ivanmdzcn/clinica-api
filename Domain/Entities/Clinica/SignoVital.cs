namespace Domain.Entities.Clinica;

public class SignoVital
{
    public int Id { get; private set; }
    public int ConsultaId { get; private set; }
    public int EnfermeraId { get; private set; }
    public int? PresionSistolica { get; private set; }
    public int? PresionDiastolica { get; private set; }
    public decimal? Temperatura { get; private set; }
    public int? FrecuenciaCardiaca { get; private set; }
    public int? FrecuenciaRespiratoria { get; private set; }
    public int? SaturacionOxigeno { get; private set; }
    public decimal? Peso { get; private set; } // en kg
    public decimal? Altura { get; private set; } // en metros
    public decimal? GlucosaCapilar { get; private set; }
    public int? NivelDolor { get; private set; } // 0-10
    public string? Observaciones { get; private set; }
    public DateTime FechaRegistro { get; private set; }

    // Constructor para crear nuevo signo vital
    public SignoVital(
        int consultaId,
        int enfermeraId,
        int? presionSistolica = null,
        int? presionDiastolica = null,
        decimal? temperatura = null,
        int? frecuenciaCardiaca = null,
        int? frecuenciaRespiratoria = null,
        int? saturacionOxigeno = null,
        decimal? peso = null,
        decimal? altura = null,
        decimal? glucosaCapilar = null,
        int? nivelDolor = null,
        string? observaciones = null)
    {
        ConsultaId = consultaId;
        EnfermeraId = enfermeraId;
        PresionSistolica = presionSistolica;
        PresionDiastolica = presionDiastolica;
        Temperatura = temperatura;
        FrecuenciaCardiaca = frecuenciaCardiaca;
        FrecuenciaRespiratoria = frecuenciaRespiratoria;
        SaturacionOxigeno = saturacionOxigeno;
        Peso = peso;
        Altura = altura;
        GlucosaCapilar = glucosaCapilar;
        NivelDolor = ValidarNivelDolor(nivelDolor);
        Observaciones = observaciones;
        FechaRegistro = DateTime.Now;
    }

    // Constructor para recuperar desde BD
    public SignoVital(
        int id,
        int consultaId,
        int enfermeraId,
        int? presionSistolica,
        int? presionDiastolica,
        decimal? temperatura,
        int? frecuenciaCardiaca,
        int? frecuenciaRespiratoria,
        int? saturacionOxigeno,
        decimal? peso,
        decimal? altura,
        decimal? glucosaCapilar,
        int? nivelDolor,
        string? observaciones,
        DateTime fechaRegistro)
    {
        Id = id;
        ConsultaId = consultaId;
        EnfermeraId = enfermeraId;
        PresionSistolica = presionSistolica;
        PresionDiastolica = presionDiastolica;
        Temperatura = temperatura;
        FrecuenciaCardiaca = frecuenciaCardiaca;
        FrecuenciaRespiratoria = frecuenciaRespiratoria;
        SaturacionOxigeno = saturacionOxigeno;
        Peso = peso;
        Altura = altura;
        GlucosaCapilar = glucosaCapilar;
        NivelDolor = nivelDolor;
        Observaciones = observaciones;
        FechaRegistro = fechaRegistro;
    }

    public void Actualizar(
        int? presionSistolica,
        int? presionDiastolica,
        decimal? temperatura,
        int? frecuenciaCardiaca,
        int? frecuenciaRespiratoria,
        int? saturacionOxigeno,
        decimal? peso,
        decimal? altura,
        decimal? glucosaCapilar,
        int? nivelDolor,
        string? observaciones)
    {
        PresionSistolica = presionSistolica;
        PresionDiastolica = presionDiastolica;
        Temperatura = temperatura;
        FrecuenciaCardiaca = frecuenciaCardiaca;
        FrecuenciaRespiratoria = frecuenciaRespiratoria;
        SaturacionOxigeno = saturacionOxigeno;
        Peso = peso;
        Altura = altura;
        GlucosaCapilar = glucosaCapilar;
        NivelDolor = ValidarNivelDolor(nivelDolor);
        Observaciones = observaciones;
    }

    private static int? ValidarNivelDolor(int? nivel)
    {
        if (nivel.HasValue && (nivel.Value < 0 || nivel.Value > 10))
            throw new ArgumentException("El nivel de dolor debe estar entre 0 y 10", nameof(nivel));
        return nivel;
    }

    public decimal? CalcularIMC()
    {
        if (Peso.HasValue && Altura.HasValue && Altura.Value > 0)
            return Math.Round(Peso.Value / (Altura.Value * Altura.Value), 2);
        return null;
    }
}