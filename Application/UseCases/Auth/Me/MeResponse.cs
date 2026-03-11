namespace Application.UseCases.Auth.Me;

public class MeResponse
{
    public int UsuarioId { get; init; }
    public string Username { get; init; } = default!;
    public string NombreCompleto { get; init; } = default!;
    public string Rol { get; init; } = default!;
    public List<string> Permisos { get; init; } = new();
    public DateTime? UltimoAcceso { get; init; }
    public bool Activo { get; init; }
}