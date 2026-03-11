namespace Application.UseCases.Auth.Roles.CreateRol;

public class CreateRolResponse
{
    public int Id { get; init; }
    public string Nombre { get; init; } = default!;
    public string? Descripcion { get; init; }
}