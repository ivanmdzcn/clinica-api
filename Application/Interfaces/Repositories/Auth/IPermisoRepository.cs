using Domain.Entities.Auth;

namespace Application.Interfaces.Repositories.Auth;

public interface IPermisoRepository
{
    Task<Permiso?> GetByIdAsync(int id);
    Task<Permiso?> GetByCodigoAsync(string codigo);
    Task<IEnumerable<Permiso>> GetAllAsync();
    Task<IEnumerable<Permiso>> GetByModuloAsync(string modulo);
    Task<IEnumerable<string>> GetModulosAsync();
    Task<int> CreateAsync(Permiso permiso);
    Task UpdateAsync(Permiso permiso);
    Task DeleteAsync(int id);
    Task<bool> ExistsAsync(int id);
    Task<bool> ExistsCodigoAsync(string codigo, int? excludeId = null);
}