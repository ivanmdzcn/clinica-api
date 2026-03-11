using Application.Interfaces.Repositories.Clinica;

namespace Application.UseCases.Clinica.Tratamientos.ListTratamientosByConsulta;

public class ListTratamientosByConsultaHandler
{
    private readonly ITratamientoRepository _tratamientoRepository;

    public ListTratamientosByConsultaHandler(ITratamientoRepository tratamientoRepository)
    {
        _tratamientoRepository = tratamientoRepository;
    }

    public async Task<IEnumerable<ListTratamientosByConsultaResponse>> HandleAsync(int consultaId)
    {
        var tratamientos = await _tratamientoRepository.GetByConsultaIdAsync(consultaId);

        return tratamientos.Select(t => new ListTratamientosByConsultaResponse
        {
            Id = t.Id,
            ConsultaId = t.ConsultaId,
            Descripcion = t.Descripcion,
            Indicaciones = t.Indicaciones,
            FechaInicio = t.FechaInicio,
            FechaFin = t.FechaFin,
            FechaRegistro = t.FechaRegistro
        });
    }
}