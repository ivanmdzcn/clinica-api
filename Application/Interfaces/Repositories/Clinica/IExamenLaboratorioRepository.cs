using Domain.Entities.Clinica;

namespace Application.Interfaces.Repositories.Clinica;

public interface IExamenLaboratorioRepository
{
    Task<int> CreateAsync(ExamenLaboratorio examen);
    Task UpdateAsync(ExamenLaboratorio examen);
    Task DeleteAsync(int id);
    Task<ExamenLaboratorio?> GetByIdAsync(int id);
    Task<IEnumerable<ExamenLaboratorio>> GetByOrdenLaboratorioIdAsync(int ordenLaboratorioId);
    Task<bool> ExistsAsync(int id);
}