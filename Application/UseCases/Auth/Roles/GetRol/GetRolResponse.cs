namespace Application.UseCases.Auth.Roles.GetRol;

public class GetRolResponse
{
    public int Id { get; init; }
    public string Nombre { get; init; } = default!;
    public string? Descripcion { get; init; }
    public DateTime FechaCreacion { get; init; }
}