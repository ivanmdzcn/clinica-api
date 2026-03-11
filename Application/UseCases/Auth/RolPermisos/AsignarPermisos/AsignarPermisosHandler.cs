using Application.Interfaces.Repositories.Auth;

namespace Application.UseCases.Auth.RolPermisos.AsignarPermisos;

public class AsignarPermisosHandler
{
    private readonly IRolPermisoRepository _rolPermisoRepository;
    private readonly IRolRepository _rolRepository;
    private readonly IPermisoRepository _permisoRepository;

    public AsignarPermisosHandler(
        IRolPermisoRepository rolPermisoRepository,
        IRolRepository rolRepository,
        IPermisoRepository permisoRepository)
    {
        _rolPermisoRepository = rolPermisoRepository;
        _rolRepository = rolRepository;
        _permisoRepository = permisoRepository;
    }

    public async Task<AsignarPermisosResponse> HandleAsync(AsignarPermisosRequest request)
    {
        // Validar que el rol exista
        if (!await _rolRepository.ExistsAsync(request.RolId))
            throw new InvalidOperationException("Rol no encontrado");

        // Validar que todos los permisos existan
        foreach (var permisoId in request.PermisoIds)
        {
            if (!await _permisoRepository.ExistsAsync(permisoId))
                throw new InvalidOperationException($"El permiso con ID {permisoId} no existe");
        }

        // Remover todos los permisos actuales
        await _rolPermisoRepository.RemoverTodosLosPermisosAsync(request.RolId);

        // Asignar los nuevos permisos
        if (request.PermisoIds.Any())
        {
            await _rolPermisoRepository.AsignarPermisosAsync(request.RolId, request.PermisoIds);
        }

        return new AsignarPermisosResponse
        {
            RolId = request.RolId,
            PermisosAsignados = request.PermisoIds.Count,
            PermisoIds = request.PermisoIds
        };
    }
}