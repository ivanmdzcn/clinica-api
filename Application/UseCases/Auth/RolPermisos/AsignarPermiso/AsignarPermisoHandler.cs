using Application.Interfaces.Repositories.Auth;

namespace Application.UseCases.Auth.RolPermisos.AsignarPermiso;

public class AsignarPermisoHandler
{
    private readonly IRolPermisoRepository _rolPermisoRepository;
    private readonly IRolRepository _rolRepository;
    private readonly IPermisoRepository _permisoRepository;

    public AsignarPermisoHandler(
        IRolPermisoRepository rolPermisoRepository,
        IRolRepository rolRepository,
        IPermisoRepository permisoRepository)
    {
        _rolPermisoRepository = rolPermisoRepository;
        _rolRepository = rolRepository;
        _permisoRepository = permisoRepository;
    }

    public async Task HandleAsync(AsignarPermisoRequest request)
    {
        // Validar que el rol exista
        if (!await _rolRepository.ExistsAsync(request.RolId))
            throw new InvalidOperationException("Rol no encontrado");

        // Validar que el permiso exista
        if (!await _permisoRepository.ExistsAsync(request.PermisoId))
            throw new InvalidOperationException("Permiso no encontrado");

        // Validar que no esté ya asignado
        if (await _rolPermisoRepository.RolTienePermisoAsync(request.RolId, request.PermisoId))
            throw new InvalidOperationException("El permiso ya está asignado a este rol");

        await _rolPermisoRepository.AsignarPermisoAsync(request.RolId, request.PermisoId);
    }
}