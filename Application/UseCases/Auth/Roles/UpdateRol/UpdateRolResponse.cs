namespace Application.UseCases.Auth.Roles.UpdateRol;

public class UpdateRolResponse
{
    public int Id { get; init; }
    public string Nombre { get; init; } = default!;
    public string? Descripcion { get; init; }
}