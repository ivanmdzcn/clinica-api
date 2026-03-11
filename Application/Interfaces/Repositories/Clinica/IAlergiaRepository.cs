using Domain.Entities.Clinica;

namespace Application.Interfaces.Repositories.Clinica;

public interface IAlergiaRepository
{
    Task<int> CreateAsync(PacienteAlergia alergia);
    Task UpdateAsync(PacienteAlergia alergia);
    Task DeleteAsync(int id);
    Task<PacienteAlergia?> GetByIdAsync(int id);
    Task<IEnumerable<PacienteAlergia>> GetByPacienteIdAsync(int pacienteId);
    Task<bool> ExistsAsync(int id);
}