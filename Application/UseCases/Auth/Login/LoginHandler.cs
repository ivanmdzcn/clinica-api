using Application.Interfaces.Repositories.Auth;
using Application.Interfaces.Repositories.Security;

namespace Application.UseCases.Auth.Login;

public class LoginHandler
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IRolRepository _rolRepository;
    private readonly IRolPermisoRepository _rolPermisoRepository;
    private readonly ITokenGenerator _tokenGenerator;
    private readonly IPasswordHasher _passwordHasher;

    public LoginHandler(
        IUsuarioRepository usuarioRepository,
        IRolRepository rolRepository,
        IRolPermisoRepository rolPermisoRepository,
        ITokenGenerator tokenGenerator,
        IPasswordHasher passwordHasher)
    {
        _usuarioRepository = usuarioRepository;
        _rolRepository = rolRepository;
        _rolPermisoRepository = rolPermisoRepository;
        _tokenGenerator = tokenGenerator;
        _passwordHasher = passwordHasher;
    }

    public async Task<LoginResponse> HandleAsync(LoginRequest request)
    {
        // Validar credenciales
        var usuario = await _usuarioRepository.GetByUsernameAsync(request.Username);

        if (usuario is null || !usuario.Activo)
            throw new UnauthorizedAccessException("Credenciales inválidas");

        bool passwordValido = _passwordHasher.Verify(
            request.Password,
            usuario.PasswordHash);

        if (!passwordValido)
            throw new UnauthorizedAccessException("Credenciales inválidas");

        // Obtener rol del usuario
        var rol = await _rolRepository.GetByIdAsync(usuario.RolId);
        if (rol is null)
            throw new InvalidOperationException("El rol del usuario no existe");

        // Obtener permisos del rol
        var permisos = await _rolPermisoRepository.GetPermisosByRolIdAsync(usuario.RolId);
        var permisoCodigos = permisos.Select(p => p.Codigo).ToList();

        // Generar token con rol y permisos
        var token = await _tokenGenerator.GenerateAsync(usuario, rol.Nombre, permisoCodigos);

        // Registrar acceso
        usuario.RegistrarAcceso();
        await _usuarioRepository.UpdateUltimoAccesoAsync(usuario.Id);

        return new LoginResponse
        {
            Token = token,
            UsuarioId = usuario.Id,
            Username = usuario.Username,
            NombreCompleto = usuario.NombreCompleto,
            Rol = rol.Nombre,
            Permisos = permisoCodigos.ToList()
        };
    }
}
