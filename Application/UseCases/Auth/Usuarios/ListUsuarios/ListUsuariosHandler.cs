using Application.Interfaces.Repositories.Auth;

namespace Application.UseCases.Auth.Usuarios.ListUsuarios;

public class ListUsuariosHandler
{
    private readonly IUsuarioRepository _usuarioRepository;

    public ListUsuariosHandler(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public async Task<IEnumerable<ListUsuariosResponse>> HandleAsync()
    {
        var usuarios = await _usuarioRepository.GetAllAsync();

        return usuarios.Select(u => new ListUsuariosResponse
        {
            Id = u.Id,
            Username = u.Username,
            NombreCompleto = u.NombreCompleto,
            Email = u.Email,
            RolId = u.RolId,
            Activo = u.Activo,
            FechaCreacion = u.FechaCreacion,
            UltimoAcceso = u.UltimoAcceso
        });
    }
}