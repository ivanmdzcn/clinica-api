using Application.Interfaces.Repositories.Auth;

namespace Application.UseCases.Auth.Usuarios.ListUsuariosByRol;

public class ListUsuariosByRolHandler
{
    private readonly IUsuarioRepository _usuarioRepository;

    public ListUsuariosByRolHandler(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public async Task<IEnumerable<ListUsuariosByRolResponse>> HandleAsync(int rolId)
    {
        var usuarios = await _usuarioRepository.GetByRolIdAsync(rolId);

        return usuarios.Select(u => new ListUsuariosByRolResponse
        {
            Id = u.Id,
            Username = u.Username,
            NombreCompleto = u.NombreCompleto,
            RolId = u.RolId,
            Activo = u.Activo
        });
    }
}