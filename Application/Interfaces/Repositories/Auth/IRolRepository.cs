using Domain.Entities.Auth;

namespace Application.Interfaces.Repositories.Auth;

public interface IRolRepository
{
    Task<Rol?> GetByIdAsync(int id);
    Task<Rol?> GetByNombreAsync(string nombre);
    Task<IEnumerable<Rol>> GetAllAsync();
    Task<int> CreateAsync(Rol rol);
    Task UpdateAsync(Rol rol);
    Task DeleteAsync(int id);
    Task<bool> ExistsAsync(int id);
    Task<bool> ExistsNombreAsync(string nombre, int? excludeId = null);
}