using Application.Interfaces.Repositories.Auth;

namespace Application.UseCases.Auth.Usuarios.DeleteUsuario;

public class DeleteUsuarioHandler
{
    private readonly IUsuarioRepository _usuarioRepository;

    public DeleteUsuarioHandler(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public async Task HandleAsync(DeleteUsuarioRequest request)
    {
        var usuario = await _usuarioRepository.GetByIdAsync(request.Id);

        if (usuario is null)
            throw new InvalidOperationException("Usuario no encontrado");

        await _usuarioRepository.DeleteAsync(request.Id);
    }
}