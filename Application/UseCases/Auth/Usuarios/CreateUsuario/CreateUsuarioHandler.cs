using Application.Interfaces.Repositories.Auth;
using Application.Interfaces.Repositories.Security;
using Domain.Entities.Auth;

namespace Application.UseCases.Auth.Usuarios.CreateUsuario;

public class CreateUsuarioHandler
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IPasswordHasher _passwordHasher;

    public CreateUsuarioHandler(
        IUsuarioRepository usuarioRepository,
        IPasswordHasher passwordHasher)
    {
        _usuarioRepository = usuarioRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task<CreateUsuarioResponse> HandleAsync(CreateUsuarioRequest request)
    {
        // Validar username único
        if (await _usuarioRepository.ExistsUsernameAsync(request.Username))
            throw new InvalidOperationException($"El username '{request.Username}' ya está en uso");

        // Validar email único (si se proporciona)
        if (!string.IsNullOrEmpty(request.Email) && await _usuarioRepository.ExistsEmailAsync(request.Email))
            throw new InvalidOperationException($"El email '{request.Email}' ya está en uso");

        // Hash del password
        var passwordHash = _passwordHasher.Hash(request.Password);

        // Crear usuario
        var usuario = new Usuario(
            request.Username,
            request.NombreCompleto,
            passwordHash,
            request.RolId,
            request.Email
        );

        var id = await _usuarioRepository.CreateAsync(usuario);

        return new CreateUsuarioResponse
        {
            Id = id,
            Username = usuario.Username,
            NombreCompleto = usuario.NombreCompleto
        };
    }
}