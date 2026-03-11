namespace Application.UseCases.Auth.Roles.CreateRol;

public class CreateRolRequest
{
    public string Nombre { get; init; } = default!;
    public string? Descripcion { get; init; }
}