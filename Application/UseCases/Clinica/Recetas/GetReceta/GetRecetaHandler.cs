using Application.Interfaces.Repositories.Clinica;

namespace Application.UseCases.Clinica.Recetas.GetReceta;

public class GetRecetaHandler
{
    private readonly IRecetaRepository _recetaRepository;

    public GetRecetaHandler(IRecetaRepository recetaRepository)
    {
        _recetaRepository = recetaRepository;
    }

    public async Task<GetRecetaResponse> HandleAsync(int id)
    {
        var receta = await _recetaRepository.GetByIdAsync(id)
            ?? throw new KeyNotFoundException($"La receta con ID {id} no existe");

        return new GetRecetaResponse
        {
            Id = receta.Id,
            ConsultaId = receta.ConsultaId,
            Medicamento = receta.Medicamento,
            Dosis = receta.Dosis,
            Frecuencia = receta.Frecuencia,
            Duracion = receta.Duracion,
            ViaAdministracion = receta.ViaAdministracion,
            Indicaciones = receta.Indicaciones,
            FechaRegistro = receta.FechaRegistro
        };
    }
}