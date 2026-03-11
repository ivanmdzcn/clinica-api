using Application.Interfaces.Repositories.Clinica;

namespace Application.UseCases.Clinica.SignosVitales.UpdateSignoVital;

public class UpdateSignoVitalHandler
{
    private readonly ISignoVitalRepository _signoVitalRepository;

    public UpdateSignoVitalHandler(ISignoVitalRepository signoVitalRepository)
    {
        _signoVitalRepository = signoVitalRepository;
    }

    public async Task<UpdateSignoVitalResponse> HandleAsync(int id, UpdateSignoVitalRequest request)
    {
        var signoVital = await _signoVitalRepository.GetByIdAsync(id)
            ?? throw new KeyNotFoundException($"El signo vital con ID {id} no existe");

        signoVital.Actualizar(
            request.PresionSistolica,
            request.PresionDiastolica,
            request.Temperatura,
            request.FrecuenciaCardiaca,
            request.FrecuenciaRespiratoria,
            request.SaturacionOxigeno,
            request.Peso,
            request.Altura,
            request.GlucosaCapilar,
            request.NivelDolor,
            request.Observaciones
        );

        await _signoVitalRepository.UpdateAsync(signoVital);

        return new UpdateSignoVitalResponse
        {
            Id = signoVital.Id,
            ConsultaId = signoVital.ConsultaId,
            IMC = signoVital.CalcularIMC()
        };
    }
}