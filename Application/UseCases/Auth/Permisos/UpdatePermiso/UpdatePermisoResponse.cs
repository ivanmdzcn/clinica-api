namespace Application.UseCases.Auth.Permisos.UpdatePermiso;

public class UpdatePermisoResponse
{
    public int Id { get; init; }
    public string Codigo { get; init; } = default!;
    public string Modulo { get; init; } = default!;
    public string Accion { get; init; } = default!;
}