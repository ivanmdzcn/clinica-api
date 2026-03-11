namespace Application.UseCases.Auth.Roles.UpdateRol;

public class UpdateRolRequest
{
    public string Nombre { get; init; } = default!;
    public string? Descripcion { get; init; }
}