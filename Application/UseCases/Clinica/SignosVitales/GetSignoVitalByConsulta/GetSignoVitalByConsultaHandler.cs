using Application.Interfaces.Repositories.Clinica;

namespace Application.UseCases.Clinica.SignosVitales.GetSignoVitalByConsulta;

public class GetSignoVitalByConsultaHandler
{
    private readonly ISignoVitalRepository _signoVitalRepository;

    public GetSignoVitalByConsultaHandler(ISignoVitalRepository signoVitalRepository)
    {
        _signoVitalRepository = signoVitalRepository;
    }

    public async Task<GetSignoVitalByConsultaResponse?> HandleAsync(int consultaId)
    {
        var signoVital = await _signoVitalRepository.GetByConsultaIdAsync(consultaId);

        if (signoVital == null)
            return null;

        return new GetSignoVitalByConsultaResponse
        {
            Id = signoVital.Id,
            ConsultaId = signoVital.ConsultaId,
            EnfermeraId = signoVital.EnfermeraId,
            PresionSistolica = signoVital.PresionSistolica,
            PresionDiastolica = signoVital.PresionDiastolica,
            Temperatura = signoVital.Temperatura,
            FrecuenciaCardiaca = signoVital.FrecuenciaCardiaca,
            FrecuenciaRespiratoria = signoVital.FrecuenciaRespiratoria,
            SaturacionOxigeno = signoVital.SaturacionOxigeno,
            Peso = signoVital.Peso,
            Altura = signoVital.Altura,
            GlucosaCapilar = signoVital.GlucosaCapilar,
            NivelDolor = signoVital.NivelDolor,
            Observaciones = signoVital.Observaciones,
            FechaRegistro = signoVital.FechaRegistro,
            IMC = signoVital.CalcularIMC()
        };
    }
}