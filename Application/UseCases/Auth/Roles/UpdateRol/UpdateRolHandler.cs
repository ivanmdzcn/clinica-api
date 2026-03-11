using Application.Interfaces.Repositories.Auth;

namespace Application.UseCases.Auth.Roles.UpdateRol;

public class UpdateRolHandler
{
    private readonly IRolRepository _rolRepository;

    public UpdateRolHandler(IRolRepository rolRepository)
    {
        _rolRepository = rolRepository;
    }

    public async Task<UpdateRolResponse> HandleAsync(int id, UpdateRolRequest request)
    {
        var rol = await _rolRepository.GetByIdAsync(id);

        if (rol is null)
            throw new InvalidOperationException("Rol no encontrado");

        // Validar nombre único (si cambió)
        if (request.Nombre != rol.Nombre && await _rolRepository.ExistsNombreAsync(request.Nombre, id))
            throw new InvalidOperationException($"Ya existe un rol con el nombre '{request.Nombre}'");

        rol.Actualizar(request.Nombre, request.Descripcion);

        await _rolRepository.UpdateAsync(rol);

        return new UpdateRolResponse
        {
            Id = rol.Id,
            Nombre = rol.Nombre,
            Descripcion = rol.Descripcion
        };
    }
}