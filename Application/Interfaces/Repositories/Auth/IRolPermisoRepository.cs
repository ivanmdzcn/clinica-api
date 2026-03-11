using Domain.Entities.Auth;

namespace Application.Interfaces.Repositories.Auth;

public interface IRolPermisoRepository
{
    Task<IEnumerable<Permiso>> GetPermisosByRolIdAsync(int rolId);
    Task<IEnumerable<int>> GetPermisoIdsByRolIdAsync(int rolId);
    Task AsignarPermisoAsync(int rolId, int permisoId);
    Task AsignarPermisosAsync(int rolId, IEnumerable<int> permisoIds);
    Task RemoverPermisoAsync(int rolId, int permisoId);
    Task RemoverTodosLosPermisosAsync(int rolId);
    Task<bool> RolTienePermisoAsync(int rolId, int permisoId);
}