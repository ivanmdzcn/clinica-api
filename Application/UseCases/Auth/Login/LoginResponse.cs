namespace Application.UseCases.Auth.Login;

public class LoginResponse
{
    public string Token { get; init; } = default!;
    public int UsuarioId { get; init; }
    public string Username { get; init; } = default!;
    public string NombreCompleto { get; init; } = default!;
    public string Rol { get; init; } = default!;
    public List<string> Permisos { get; init; } = new();
}
