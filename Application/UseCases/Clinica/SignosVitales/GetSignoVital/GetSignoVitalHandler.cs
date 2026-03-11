using Application.Interfaces.Repositories.Clinica;

namespace Application.UseCases.Clinica.SignosVitales.GetSignoVital;

public class GetSignoVitalHandler
{
    private readonly ISignoVitalRepository _signoVitalRepository;

    public GetSignoVitalHandler(ISignoVitalRepository signoVitalRepository)
    {
        _signoVitalRepository = signoVitalRepository;
    }

    public async Task<GetSignoVitalResponse> HandleAsync(int id)
    {
        var signoVital = await _signoVitalRepository.GetByIdAsync(id)
            ?? throw new KeyNotFoundException($"El signo vital con ID {id} no existe");

        return new GetSignoVitalResponse
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