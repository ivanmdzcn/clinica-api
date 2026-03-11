using Application.Interfaces.Repositories.Auth;

namespace Application.UseCases.Auth.Usuarios.GetUsuario;

public class GetUsuarioHandler
{
    private readonly IUsuarioRepository _usuarioRepository;

    public GetUsuarioHandler(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public async Task<GetUsuarioResponse> HandleAsync(GetUsuarioRequest request)
    {
        var usuario = await _usuarioRepository.GetByIdAsync(request.Id);

        if (usuario is null)
            throw new InvalidOperationException("Usuario no encontrado");

        return new GetUsuarioResponse
        {
            Id = usuario.Id,
            Username = usuario.Username,
            NombreCompleto = usuario.NombreCompleto,
            Email = usuario.Email,
            RolId = usuario.RolId,
            Activo = usuario.Activo,
            FechaCreacion = usuario.FechaCreacion,
            UltimoAcceso = usuario.UltimoAcceso
        };
    }
}