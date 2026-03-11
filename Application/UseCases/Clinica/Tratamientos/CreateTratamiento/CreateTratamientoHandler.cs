using Application.Interfaces.Repositories.Clinica;
using Domain.Entities.Clinica;

namespace Application.UseCases.Clinica.Tratamientos.CreateTratamiento;

public class CreateTratamientoHandler
{
    private readonly ITratamientoRepository _tratamientoRepository;
    private readonly IConsultaRepository _consultaRepository;

    public CreateTratamientoHandler(
        ITratamientoRepository tratamientoRepository,
        IConsultaRepository consultaRepository)
    {
        _tratamientoRepository = tratamientoRepository;
        _consultaRepository = consultaRepository;
    }

    public async Task<CreateTratamientoResponse> HandleAsync(CreateTratamientoRequest request)
    {
        // Validar que la consulta existe
        if (!await _consultaRepository.ExistsAsync(request.ConsultaId))
            throw new InvalidOperationException($"La consulta con ID {request.ConsultaId} no existe");

        var tratamiento = new Tratamiento(
            request.ConsultaId,
            request.Descripcion,
            request.Indicaciones,
            request.FechaInicio,
            request.FechaFin
        );

        var id = await _tratamientoRepository.CreateAsync(tratamiento);

        return new CreateTratamientoResponse
        {
            Id = id,
            ConsultaId = tratamiento.ConsultaId,
            Descripcion = tratamiento.Descripcion,
            FechaRegistro = tratamiento.FechaRegistro
        };
    }
}