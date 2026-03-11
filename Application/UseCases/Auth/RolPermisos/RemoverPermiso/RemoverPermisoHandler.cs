using Application.Interfaces.Repositories.Auth;

namespace Application.UseCases.Auth.RolPermisos.RemoverPermiso;

public class RemoverPermisoHandler
{
    private readonly IRolPermisoRepository _rolPermisoRepository;
    private readonly IRolRepository _rolRepository;
    private readonly IPermisoRepository _permisoRepository;

    public RemoverPermisoHandler(
        IRolPermisoRepository rolPermisoRepository,
        IRolRepository rolRepository,
        IPermisoRepository permisoRepository)
    {
        _rolPermisoRepository = rolPermisoRepository;
        _rolRepository = rolRepository;
        _permisoRepository = permisoRepository;
    }

    public async Task HandleAsync(RemoverPermisoRequest request)
    {
        // Validar que el rol exista
        if (!await _rolRepository.ExistsAsync(request.RolId))
            throw new InvalidOperationException("Rol no encontrado");

        // Validar que el permiso exista
        if (!await _permisoRepository.ExistsAsync(request.PermisoId))
            throw new InvalidOperationException("Permiso no encontrado");

        // Validar que el permiso esté asignado
        if (!await _rolPermisoRepository.RolTienePermisoAsync(request.RolId, request.PermisoId))
            throw new InvalidOperationException("El permiso no está asignado a este rol");

        await _rolPermisoRepository.RemoverPermisoAsync(request.RolId, request.PermisoId);
    }
}