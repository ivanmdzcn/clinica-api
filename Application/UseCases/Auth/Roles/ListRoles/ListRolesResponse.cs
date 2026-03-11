namespace Application.UseCases.Auth.Roles.ListRoles;

public class ListRolesResponse
{
    public int Id { get; init; }
    public string Nombre { get; init; } = default!;
    public string? Descripcion { get; init; }
    public DateTime FechaCreacion { get; init; }
}