using Domain.Entities.Clinica;

namespace Application.Interfaces.Repositories.Clinica;

public interface IExamenFisicoRepository
{
    Task<int> CreateAsync(ExamenFisico examenFisico);
    Task UpdateAsync(ExamenFisico examenFisico);
    Task DeleteAsync(int id);
    Task<ExamenFisico?> GetByIdAsync(int id);
    Task<ExamenFisico?> GetByConsultaIdAsync(int consultaId);
    Task<bool> ExistsAsync(int id);
}