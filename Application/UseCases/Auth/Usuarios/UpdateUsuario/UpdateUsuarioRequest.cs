namespace Application.UseCases.Auth.Usuarios.UpdateUsuario;

public class UpdateUsuarioRequest
{
    public string NombreCompleto { get; init; } = default!;
    public string? Email { get; init; }
    public int RolId { get; init; }
}