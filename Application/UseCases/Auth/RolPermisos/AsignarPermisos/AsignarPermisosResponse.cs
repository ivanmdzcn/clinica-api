namespace Application.UseCases.Auth.RolPermisos.AsignarPermisos;

public class AsignarPermisosResponse
{
    public int RolId { get; init; }
    public int PermisosAsignados { get; init; }
    public List<int> PermisoIds { get; init; } = new();
}