using Application.Interfaces.Repositories.Auth;

namespace Application.UseCases.Auth.Roles.ListRoles;

public class ListRolesHandler
{
    private readonly IRolRepository _rolRepository;

    public ListRolesHandler(IRolRepository rolRepository)
    {
        _rolRepository = rolRepository;
    }

    public async Task<IEnumerable<ListRolesResponse>> HandleAsync()
    {
        var roles = await _rolRepository.GetAllAsync();

        return roles.Select(r => new ListRolesResponse
        {
            Id = r.Id,
            Nombre = r.Nombre,
            Descripcion = r.Descripcion,
            FechaCreacion = r.FechaCreacion
        });
    }
}