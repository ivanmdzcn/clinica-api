namespace Application.UseCases.Auth.RolPermisos.AsignarPermisos;

public class AsignarPermisosRequest
{
    public int RolId { get; init; }
    public List<int> PermisoIds { get; init; } = new();
}