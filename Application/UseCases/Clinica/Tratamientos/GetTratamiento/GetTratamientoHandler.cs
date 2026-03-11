using Application.Interfaces.Repositories.Clinica;

namespace Application.UseCases.Clinica.Tratamientos.GetTratamiento;

public class GetTratamientoHandler
{
    private readonly ITratamientoRepository _tratamientoRepository;

    public GetTratamientoHandler(ITratamientoRepository tratamientoRepository)
    {
        _tratamientoRepository = tratamientoRepository;
    }

    public async Task<GetTratamientoResponse> HandleAsync(int id)
    {
        var tratamiento = await _tratamientoRepository.GetByIdAsync(id)
            ?? throw new KeyNotFoundException($"El tratamiento con ID {id} no existe");

        return new GetTratamientoResponse
        {
            Id = tratamiento.Id,
            ConsultaId = tratamiento.ConsultaId,
            Descripcion = tratamiento.Descripcion,
            Indicaciones = tratamiento.Indicaciones,
            FechaInicio = tratamiento.FechaInicio,
            FechaFin = tratamiento.FechaFin,
            FechaRegistro = tratamiento.FechaRegistro
        };
    }
}