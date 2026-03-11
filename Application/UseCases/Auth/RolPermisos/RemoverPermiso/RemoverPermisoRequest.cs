namespace Application.UseCases.Auth.RolPermisos.RemoverPermiso;

public class RemoverPermisoRequest
{
    public int RolId { get; init; }
    public int PermisoId { get; init; }
}