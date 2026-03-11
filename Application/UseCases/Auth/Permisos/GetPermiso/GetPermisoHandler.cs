using Application.Interfaces.Repositories.Auth;

namespace Application.UseCases.Auth.Permisos.GetPermiso;

public class GetPermisoHandler
{
    private readonly IPermisoRepository _permisoRepository;

    public GetPermisoHandler(IPermisoRepository permisoRepository)
    {
        _permisoRepository = permisoRepository;
    }

    public async Task<GetPermisoResponse> HandleAsync(GetPermisoRequest request)
    {
        var permiso = await _permisoRepository.GetByIdAsync(request.Id);

        if (permiso is null)
            throw new InvalidOperationException("Permiso no encontrado");

        return new GetPermisoResponse
        {
            Id = permiso.Id,
            Codigo = permiso.Codigo,
            Modulo = permiso.Modulo,
            Accion = permiso.Accion,
            Descripcion = permiso.Descripcion
        };
    }
}