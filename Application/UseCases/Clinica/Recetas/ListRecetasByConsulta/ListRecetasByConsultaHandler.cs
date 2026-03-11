using Application.Interfaces.Repositories.Clinica;

namespace Application.UseCases.Clinica.Recetas.ListRecetasByConsulta;

public class ListRecetasByConsultaHandler
{
    private readonly IRecetaRepository _recetaRepository;

    public ListRecetasByConsultaHandler(IRecetaRepository recetaRepository)
    {
        _recetaRepository = recetaRepository;
    }

    public async Task<IEnumerable<ListRecetasByConsultaResponse>> HandleAsync(int consultaId)
    {
        var recetas = await _recetaRepository.GetByConsultaIdAsync(consultaId);

        return recetas.Select(r => new ListRecetasByConsultaResponse
        {
            Id = r.Id,
            ConsultaId = r.ConsultaId,
            Medicamento = r.Medicamento,
            Dosis = r.Dosis,
            Frecuencia = r.Frecuencia,
            Duracion = r.Duracion,
            ViaAdministracion = r.ViaAdministracion,
            Indicaciones = r.Indicaciones,
            FechaRegistro = r.FechaRegistro
        });
    }
}