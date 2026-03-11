using Application.Interfaces.Repositories.Clinica;
using Domain.Entities.Clinica;

namespace Application.UseCases.Clinica.Recetas.CreateReceta;

public class CreateRecetaHandler
{
    private readonly IRecetaRepository _recetaRepository;
    private readonly IConsultaRepository _consultaRepository;

    public CreateRecetaHandler(
        IRecetaRepository recetaRepository,
        IConsultaRepository consultaRepository)
    {
        _recetaRepository = recetaRepository;
        _consultaRepository = consultaRepository;
    }

    public async Task<CreateRecetaResponse> HandleAsync(CreateRecetaRequest request)
    {
        // Validar que la consulta existe
        if (!await _consultaRepository.ExistsAsync(request.ConsultaId))
            throw new InvalidOperationException($"La consulta con ID {request.ConsultaId} no existe");

        var receta = new Receta(
            request.ConsultaId,
            request.Medicamento,
            request.Dosis,
            request.Frecuencia,
            request.Duracion,
            request.ViaAdministracion,
            request.Indicaciones
        );

        var id = await _recetaRepository.CreateAsync(receta);

        return new CreateRecetaResponse
        {
            Id = id,
            ConsultaId = receta.ConsultaId,
            Medicamento = receta.Medicamento,
            FechaRegistro = receta.FechaRegistro
        };
    }
}