using Application.Interfaces.Repositories.Auth;

namespace Application.UseCases.Auth.RolPermisos.GetPermisosByRol;

public class GetPermisosByRolHandler
{
    private readonly IRolPermisoRepository _rolPermisoRepository;
    private readonly IRolRepository _rolRepository;

    public GetPermisosByRolHandler(
        IRolPermisoRepository rolPermisoRepository,
        IRolRepository rolRepository)
    {
        _rolPermisoRepository = rolPermisoRepository;
        _rolRepository = rolRepository;
    }

    public async Task<IEnumerable<GetPermisosByRolResponse>> HandleAsync(GetPermisosByRolRequest request)
    {
        // Validar que el rol exista
        if (!await _rolRepository.ExistsAsync(request.RolId))
            throw new InvalidOperationException("Rol no encontrado");

        var permisos = await _rolPermisoRepository.GetPermisosByRolIdAsync(request.RolId);

        return permisos.Select(p => new GetPermisosByRolResponse
        {
            Id = p.Id,
            Codigo = p.Codigo,
            Modulo = p.Modulo,
            Accion = p.Accion,
            Descripcion = p.Descripcion
        });
    }
}