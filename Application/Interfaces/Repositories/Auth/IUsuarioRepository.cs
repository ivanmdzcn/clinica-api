using Domain.Entities.Auth;

namespace Application.Interfaces.Repositories.Auth;

public interface IUsuarioRepository
{
    Task<Usuario?> GetByIdAsync(int id);
    Task<Usuario?> GetByUsernameAsync(string username);
    Task<Usuario?> GetByEmailAsync(string email);
    Task<IEnumerable<Usuario>> GetAllAsync();
    Task<IEnumerable<Usuario>> GetByRolIdAsync(int rolId);
    Task<int> CreateAsync(Usuario usuario);
    Task UpdateAsync(Usuario usuario);
    Task DeleteAsync(int id);
    Task UpdateUltimoAccesoAsync(int usuarioId);
    Task<bool> ExistsUsernameAsync(string username, int? excludeId = null);
    Task<bool> ExistsEmailAsync(string email, int? excludeId = null);
}
