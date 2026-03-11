namespace Application.UseCases.Auth.Usuarios.CreateUsuario;

public class CreateUsuarioResponse
{
    public int Id { get; init; }
    public string Username { get; init; } = default!;
    public string NombreCompleto { get; init; } = default!;
}