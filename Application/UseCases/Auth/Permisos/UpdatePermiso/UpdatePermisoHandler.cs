using Application.Interfaces.Repositories.Auth;

namespace Application.UseCases.Auth.Permisos.UpdatePermiso;

public class UpdatePermisoHandler
{
    private readonly IPermisoRepository _permisoRepository;

    public UpdatePermisoHandler(IPermisoRepository permisoRepository)
    {
        _permisoRepository = permisoRepository;
    }

    public async Task<UpdatePermisoResponse> HandleAsync(int id, UpdatePermisoRequest request)
    {
        var permiso = await _permisoRepository.GetByIdAsync(id);

        if (permiso is null)
            throw new InvalidOperationException("Permiso no encontrado");

        // Validar código único (si cambió)
        if (request.Codigo != permiso.Codigo && await _permisoRepository.ExistsCodigoAsync(request.Codigo, id))
            throw new InvalidOperationException($"Ya existe un permiso con el código '{request.Codigo}'");

        permiso.Actualizar(request.Codigo, request.Modulo, request.Accion, request.Descripcion);

        await _permisoRepository.UpdateAsync(permiso);

        return new UpdatePermisoResponse
        {
            Id = permiso.Id,
            Codigo = permiso.Codigo,
            Modulo = permiso.Modulo,
            Accion = permiso.Accion
        };
    }
}