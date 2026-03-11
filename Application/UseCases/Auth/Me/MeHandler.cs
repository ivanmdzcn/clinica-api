using Application.Interfaces.Repositories.Auth;

namespace Application.UseCases.Auth.Me;

public class MeHandler
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IRolRepository _rolRepository;
    private readonly IRolPermisoRepository _rolPermisoRepository;

    public MeHandler(
        IUsuarioRepository usuarioRepository,
        IRolRepository rolRepository,
        IRolPermisoRepository rolPermisoRepository)
    {
        _usuarioRepository = usuarioRepository;
        _rolRepository = rolRepository;
        _rolPermisoRepository = rolPermisoRepository;
    }

    public async Task<MeResponse> HandleAsync(MeRequest request)
    {
        var usuario = await _usuarioRepository.GetByIdAsync(request.UsuarioId);

        if (usuario is null || !usuario.Activo)
            throw new UnauthorizedAccessException("Usuario no encontrado o inactivo");

        // Obtener rol
        var rol = await _rolRepository.GetByIdAsync(usuario.RolId);
        if (rol is null)
            throw new InvalidOperationException("El rol del usuario no existe");

        // Obtener permisos
        var permisos = await _rolPermisoRepository.GetPermisosByRolIdAsync(usuario.RolId);
        var permisoCodigos = permisos.Select(p => p.Codigo).ToList();

        return new MeResponse
        {
            UsuarioId = usuario.Id,
            Username = usuario.Username,
            NombreCompleto = usuario.NombreCompleto,
            Rol = rol.Nombre,
            Permisos = permisoCodigos,
            UltimoAcceso = usuario.UltimoAcceso,
            Activo = usuario.Activo
        };
    }
}