using Application.Interfaces.Repositories.Auth;

namespace Application.UseCases.Auth.Permisos.ListModulos;

public class ListModulosHandler
{
    private readonly IPermisoRepository _permisoRepository;

    public ListModulosHandler(IPermisoRepository permisoRepository)
    {
        _permisoRepository = permisoRepository;
    }

    public async Task<IEnumerable<string>> HandleAsync()
    {
        return await _permisoRepository.GetModulosAsync();
    }
}