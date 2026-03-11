using Application.Interfaces.Repositories.Auth;

namespace Application.UseCases.Auth.Roles.DeleteRol;

public class DeleteRolHandler
{
    private readonly IRolRepository _rolRepository;
    private readonly IUsuarioRepository _usuarioRepository;

    public DeleteRolHandler(IRolRepository rolRepository, IUsuarioRepository usuarioRepository)
    {
        _rolRepository = rolRepository;
        _usuarioRepository = usuarioRepository;
    }

    public async Task HandleAsync(DeleteRolRequest request)
    {
        var rol = await _rolRepository.GetByIdAsync(request.Id);

        if (rol is null)
            throw new InvalidOperationException("Rol no encontrado");

        // Validar que no haya usuarios con este rol
        var usuariosConRol = await _usuarioRepository.GetByRolIdAsync(request.Id);
        if (usuariosConRol.Any())
            throw new InvalidOperationException($"No se puede eliminar el rol porque tiene {usuariosConRol.Count()} usuario(s) asignado(s)");

        await _rolRepository.DeleteAsync(request.Id);
    }
}