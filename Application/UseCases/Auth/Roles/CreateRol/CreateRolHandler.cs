using Application.Interfaces.Repositories.Auth;
using Domain.Entities.Auth;

namespace Application.UseCases.Auth.Roles.CreateRol;

public class CreateRolHandler
{
    private readonly IRolRepository _rolRepository;

    public CreateRolHandler(IRolRepository rolRepository)
    {
        _rolRepository = rolRepository;
    }

    public async Task<CreateRolResponse> HandleAsync(CreateRolRequest request)
    {
        // Validar que no exista el rol
        if (await _rolRepository.ExistsNombreAsync(request.Nombre))
            throw new InvalidOperationException($"Ya existe un rol con el nombre '{request.Nombre}'");

        var rol = new Rol(request.Nombre, request.Descripcion);

        var id = await _rolRepository.CreateAsync(rol);

        return new CreateRolResponse
        {
            Id = id,
            Nombre = rol.Nombre,
            Descripcion = rol.Descripcion
        };
    }
}