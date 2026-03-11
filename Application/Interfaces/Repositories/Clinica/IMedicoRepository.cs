using Domain.Entities.Clinica;

namespace Application.Interfaces.Repositories.Clinica;

public interface IMedicoRepository
{
    Task<int> CreateAsync(Medico medico);
    Task UpdateAsync(Medico medico);
    Task DeleteAsync(int id);
    Task<Medico?> GetByIdAsync(int id);
    Task<Medico?> GetByUsuarioIdAsync(int usuarioId);
    Task<IEnumerable<Medico>> GetAllAsync(bool? soloActivos = null);
    Task<IEnumerable<Medico>> GetByEspecialidadAsync(string especialidad);
    Task<bool> ExistsAsync(int id);
    Task<bool> ExistsByUsuarioIdAsync(int usuarioId);
    Task<bool> ExistsByCedulaAsync(string cedula, int? excludeId = null);
}