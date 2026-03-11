namespace Application.UseCases.Auth.Usuarios.ListUsuariosByRol;

public class ListUsuariosByRolResponse
{
    public int Id { get; init; }
    public string Username { get; init; } = string.Empty;
    public string NombreCompleto { get; init; } = string.Empty;
    public int RolId { get; init; }
    public bool Activo { get; init; }
}