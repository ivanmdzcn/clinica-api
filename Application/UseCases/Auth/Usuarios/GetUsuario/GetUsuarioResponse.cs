namespace Application.UseCases.Auth.Usuarios.GetUsuario;

public class GetUsuarioResponse
{
    public int Id { get; init; }
    public string Username { get; init; } = default!;
    public string NombreCompleto { get; init; } = default!;
    public string? Email { get; init; }
    public int RolId { get; init; }
    public bool Activo { get; init; }
    public DateTime FechaCreacion { get; init; }
    public DateTime? UltimoAcceso { get; init; }
}