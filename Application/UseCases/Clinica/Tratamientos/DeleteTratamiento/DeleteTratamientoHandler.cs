using Application.Interfaces.Repositories.Clinica;

namespace Application.UseCases.Clinica.Tratamientos.DeleteTratamiento;

public class DeleteTratamientoHandler
{
    private readonly ITratamientoRepository _tratamientoRepository;

    public DeleteTratamientoHandler(ITratamientoRepository tratamientoRepository)
    {
        _tratamientoRepository = tratamientoRepository;
    }

    public async Task HandleAsync(int id)
    {
        if (!await _tratamientoRepository.ExistsAsync(id))
            throw new KeyNotFoundException($"El tratamiento con ID {id} no existe");

        await _tratamientoRepository.DeleteAsync(id);
    }
}