namespace Application.UseCases.Auth.Permisos.CreatePermiso;

public class CreatePermisoRequest
{
    public string Codigo { get; init; } = default!;
    public string Modulo { get; init; } = default!;
    public string Accion { get; init; } = default!;
    public string? Descripcion { get; init; }
}