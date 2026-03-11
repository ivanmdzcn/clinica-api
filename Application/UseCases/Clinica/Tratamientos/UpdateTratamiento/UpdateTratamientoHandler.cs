using Application.Interfaces.Repositories.Clinica;

namespace Application.UseCases.Clinica.Tratamientos.UpdateTratamiento;

public class UpdateTratamientoHandler
{
    private readonly ITratamientoRepository _tratamientoRepository;

    public UpdateTratamientoHandler(ITratamientoRepository tratamientoRepository)
    {
        _tratamientoRepository = tratamientoRepository;
    }

    public async Task<UpdateTratamientoResponse> HandleAsync(int id, UpdateTratamientoRequest request)
    {
        var tratamiento = await _tratamientoRepository.GetByIdAsync(id)
            ?? throw new KeyNotFoundException($"El tratamiento con ID {id} no existe");

        tratamiento.Actualizar(
            request.Descripcion,
            request.Indicaciones,
            request.FechaInicio,
            request.FechaFin
        );

        await _tratamientoRepository.UpdateAsync(tratamiento);

        return new UpdateTratamientoResponse
        {
            Id = tratamiento.Id,
            ConsultaId = tratamiento.ConsultaId,
            Descripcion = tratamiento.Descripcion,
            Indicaciones = tratamiento.Indicaciones,
            FechaInicio = tratamiento.FechaInicio,
            FechaFin = tratamiento.FechaFin
        };
    }
}