using Application.Interfaces.Repositories.Clinica;

namespace Application.UseCases.Clinica.Recetas.UpdateReceta;

public class UpdateRecetaHandler
{
    private readonly IRecetaRepository _recetaRepository;

    public UpdateRecetaHandler(IRecetaRepository recetaRepository)
    {
        _recetaRepository = recetaRepository;
    }

    public async Task<UpdateRecetaResponse> HandleAsync(int id, UpdateRecetaRequest request)
    {
        var receta = await _recetaRepository.GetByIdAsync(id)
            ?? throw new KeyNotFoundException($"La receta con ID {id} no existe");

        receta.Actualizar(
            request.Medicamento,
            request.Dosis,
            request.Frecuencia,
            request.Duracion,
            request.ViaAdministracion,
            request.Indicaciones
        );

        await _recetaRepository.UpdateAsync(receta);

        return new UpdateRecetaResponse
        {
            Id = receta.Id,
            ConsultaId = receta.ConsultaId,
            Medicamento = receta.Medicamento,
            Dosis = receta.Dosis,
            Frecuencia = receta.Frecuencia,
            Duracion = receta.Duracion,
            ViaAdministracion = receta.ViaAdministracion,
            Indicaciones = receta.Indicaciones
        };
    }
}