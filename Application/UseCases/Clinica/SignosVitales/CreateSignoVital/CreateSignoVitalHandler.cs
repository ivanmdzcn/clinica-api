using Application.Interfaces.Repositories.Auth;
using Application.Interfaces.Repositories.Clinica;
using Domain.Entities.Clinica;

namespace Application.UseCases.Clinica.SignosVitales.CreateSignoVital;

public class CreateSignoVitalHandler
{
    private readonly ISignoVitalRepository _signoVitalRepository;
    private readonly IConsultaRepository _consultaRepository;
    private readonly IUsuarioRepository _usuarioRepository;

    public CreateSignoVitalHandler(
        ISignoVitalRepository signoVitalRepository,
        IConsultaRepository consultaRepository,
        IUsuarioRepository usuarioRepository)
    {
        _signoVitalRepository = signoVitalRepository;
        _consultaRepository = consultaRepository;
        _usuarioRepository = usuarioRepository;
    }

    public async Task<CreateSignoVitalResponse> HandleAsync(CreateSignoVitalRequest request)
    {
        // Validar que la consulta existe
        if (!await _consultaRepository.ExistsAsync(request.ConsultaId))
            throw new InvalidOperationException($"La consulta con ID {request.ConsultaId} no existe");

        // Validar que la enfermera existe
        var enfermera = await _usuarioRepository.GetByIdAsync(request.EnfermeraId);
        if (enfermera == null)
            throw new InvalidOperationException($"La enfermera con ID {request.EnfermeraId} no existe");

        var signoVital = new SignoVital(
            request.ConsultaId,
            request.EnfermeraId,
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

        var id = await _signoVitalRepository.CreateAsync(signoVital);

        return new CreateSignoVitalResponse
        {
            Id = id,
            ConsultaId = signoVital.ConsultaId,
            EnfermeraId = signoVital.EnfermeraId,
            FechaRegistro = signoVital.FechaRegistro,
            IMC = signoVital.CalcularIMC()
        };
    }
}