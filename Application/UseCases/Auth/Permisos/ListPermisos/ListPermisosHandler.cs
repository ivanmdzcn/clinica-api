using Application.Interfaces.Repositories.Auth;

namespace Application.UseCases.Auth.Permisos.ListPermisos;

public class ListPermisosHandler
{
    private readonly IPermisoRepository _permisoRepository;

    public ListPermisosHandler(IPermisoRepository permisoRepository)
    {
        _permisoRepository = permisoRepository;
    }

    public async Task<IEnumerable<ListPermisosResponse>> HandleAsync()
    {
        var permisos = await _permisoRepository.GetAllAsync();

        return permisos.Select(p => new ListPermisosResponse
        {
            Id = p.Id,
            Codigo = p.Codigo,
            Modulo = p.Modulo,
            Accion = p.Accion,
            Descripcion = p.Descripcion
        });
    }
}