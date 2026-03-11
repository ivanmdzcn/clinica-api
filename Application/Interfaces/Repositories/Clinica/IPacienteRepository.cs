using Domain.Entities;

namespace Application.Interfaces.Repositories;

public interface IPacienteRepository
{
    Task<Paciente?> GetByIdAsync(int id);
    Task<Paciente?> GetByDpiAsync(string dpi);
    Task<IEnumerable<Paciente>> GetAllAsync();
    Task<IEnumerable<Paciente>> SearchAsync(string searchTerm);
    Task<int> CreateAsync(Paciente paciente);
    Task UpdateAsync(Paciente paciente);
    Task DeleteAsync(int id);
    Task<bool> ExistsDpiAsync(string dpi, int? excludeId = null);
    Task<bool> ExistsEmailAsync(string email, int? excludeId = null);
}