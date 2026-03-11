using Application.Interfaces.Repositories.Auth;

namespace Application.UseCases.Auth.Usuarios.UpdateUsuario;

public class UpdateUsuarioHandler
{
    private readonly IUsuarioRepository _usuarioRepository;

    public UpdateUsuarioHandler(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public async Task<UpdateUsuarioResponse> HandleAsync(int id, UpdateUsuarioRequest request)
    {
        var usuario = await _usuarioRepository.GetByIdAsync(id);
        
        if (usuario is null)
            throw new InvalidOperationException("Usuario no encontrado");

        // Validar email único (si cambió)
        if (!string.IsNullOrEmpty(request.Email) && 
            request.Email != usuario.Email &&
            await _usuarioRepository.ExistsEmailAsync(request.Email, id))
        {
            throw new InvalidOperationException($"El email '{request.Email}' ya está en uso");
        }

        usuario.Actualizar(request.NombreCompleto, request.Email, request.RolId);

        await _usuarioRepository.UpdateAsync(usuario);

        return new UpdateUsuarioResponse
        {
            Id = usuario.Id,
            NombreCompleto = usuario.NombreCompleto,
            Email = usuario.Email
        };
    }
}