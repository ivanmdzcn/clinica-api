namespace Application.UseCases.Auth.Usuarios.UpdateUsuario;

public class UpdateUsuarioResponse
{
    public int Id { get; init; }
    public string NombreCompleto { get; init; } = default!;
    public string? Email { get; init; }
}