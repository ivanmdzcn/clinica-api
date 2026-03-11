using Application.Interfaces.Repositories.Auth;

namespace Application.UseCases.Auth.Permisos.ListPermisosByModulo;

public class ListPermisosByModuloHandler
{
    private readonly IPermisoRepository _permisoRepository;

    public ListPermisosByModuloHandler(IPermisoRepository permisoRepository)
    {
        _permisoRepository = permisoRepository;
    }

    public async Task<IEnumerable<ListPermisosByModuloResponse>> HandleAsync(ListPermisosByModuloRequest request)
    {
        var permisos = await _permisoRepository.GetByModuloAsync(request.Modulo);

        return permisos.Select(p => new ListPermisosByModuloResponse
        {
            Id = p.Id,
            Codigo = p.Codigo,
            Modulo = p.Modulo,
            Accion = p.Accion,
            Descripcion = p.Descripcion
        });
    }
}