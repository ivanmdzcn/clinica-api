namespace Application.UseCases.Auth.Permisos.CreatePermiso;

public class CreatePermisoResponse
{
    public int Id { get; init; }
    public string Codigo { get; init; } = default!;
    public string Modulo { get; init; } = default!;
    public string Accion { get; init; } = default!;
}