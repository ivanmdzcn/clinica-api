using Application.Interfaces.Repositories.Auth;

namespace Application.UseCases.Auth.Permisos.DeletePermiso;

public class DeletePermisoHandler
{
    private readonly IPermisoRepository _permisoRepository;

    public DeletePermisoHandler(IPermisoRepository permisoRepository)
    {
        _permisoRepository = permisoRepository;
    }

    public async Task HandleAsync(DeletePermisoRequest request)
    {
        var permiso = await _permisoRepository.GetByIdAsync(request.Id);

        if (permiso is null)
            throw new InvalidOperationException("Permiso no encontrado");

        await _permisoRepository.DeleteAsync(request.Id);
    }
}