using Domain.Entities.Clinica;

namespace Application.Interfaces.Repositories.Clinica;

public interface IDiagnosticoRepository
{
    Task<int> CreateAsync(Diagnostico diagnostico);
    Task UpdateAsync(Diagnostico diagnostico);
    Task DeleteAsync(int id);
    Task<Diagnostico?> GetByIdAsync(int id);
    Task<IEnumerable<Diagnostico>> GetByConsultaIdAsync(int consultaId);
    Task<bool> ExistsAsync(int id);
}