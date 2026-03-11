namespace Application.UseCases.Auth.Usuarios.CreateUsuario;

public class CreateUsuarioRequest
{
    public string Username { get; init; } = default!;
    public string NombreCompleto { get; init; } = default!;
    public string? Email { get; init; }
    public string Password { get; init; } = default!;
    public int RolId { get; init; }
}