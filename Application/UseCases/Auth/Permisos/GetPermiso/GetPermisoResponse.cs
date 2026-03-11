namespace Application.UseCases.Auth.Permisos.GetPermiso;

public class GetPermisoResponse
{
    public int Id { get; init; }
    public string Codigo { get; init; } = default!;
    public string Modulo { get; init; } = default!;
    public string Accion { get; init; } = default!;
    public string? Descripcion { get; init; }
}