namespace Domain.Entities.Auth;

public class RolPermiso
{
    public int RolId { get; private set; }
    public int PermisoId { get; private set; }
    public DateTime FechaAsignacion { get; private set; }

    protected RolPermiso() { }

    public RolPermiso(int rolId, int permisoId)
    {
        RolId = rolId;
        PermisoId = permisoId;
        FechaAsignacion = DateTime.UtcNow;
    }
}