using Application.Interfaces.Repositories.Auth;
using Domain.Entities.Auth;

namespace Application.UseCases.Auth.Permisos.CreatePermiso;

public class CreatePermisoHandler
{
    private readonly IPermisoRepository _permisoRepository;

    public CreatePermisoHandler(IPermisoRepository permisoRepository)
    {
        _permisoRepository = permisoRepository;
    }

    public async Task<CreatePermisoResponse> HandleAsync(CreatePermisoRequest request)
    {
        // Validar que no exista el código
        if (await _permisoRepository.ExistsCodigoAsync(request.Codigo))
            throw new InvalidOperationException($"Ya existe un permiso con el código '{request.Codigo}'");

        var permiso = new Permiso(
            request.Codigo,
            request.Modulo,
            request.Accion,
            request.Descripcion
        );

        var id = await _permisoRepository.CreateAsync(permiso);

        return new CreatePermisoResponse
        {
            Id = id,
            Codigo = permiso.Codigo,
            Modulo = permiso.Modulo,
            Accion = permiso.Accion
        };
    }
}