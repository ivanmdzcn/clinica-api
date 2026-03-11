using Application.Interfaces.Repositories.Auth;

namespace Application.UseCases.Auth.Roles.GetRol;

public class GetRolHandler
{
    private readonly IRolRepository _rolRepository;

    public GetRolHandler(IRolRepository rolRepository)
    {
        _rolRepository = rolRepository;
    }

    public async Task<GetRolResponse> HandleAsync(GetRolRequest request)
    {
        var rol = await _rolRepository.GetByIdAsync(request.Id);

        if (rol is null)
            throw new InvalidOperationException("Rol no encontrado");

        return new GetRolResponse
        {
            Id = rol.Id,
            Nombre = rol.Nombre,
            Descripcion = rol.Descripcion,
            FechaCreacion = rol.FechaCreacion
        };
    }
}