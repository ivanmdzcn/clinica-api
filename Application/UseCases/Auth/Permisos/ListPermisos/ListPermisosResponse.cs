namespace Application.UseCases.Auth.Permisos.ListPermisos;

public class ListPermisosResponse
{
    public int Id { get; init; }
    public string Codigo { get; init; } = default!;
    public string Modulo { get; init; } = default!;
    public string Accion { get; init; } = default!;
    public string? Descripcion { get; init; }
}