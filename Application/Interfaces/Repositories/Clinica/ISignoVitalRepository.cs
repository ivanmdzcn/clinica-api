using Domain.Entities.Clinica;

namespace Application.Interfaces.Repositories.Clinica;

public interface ISignoVitalRepository
{
    Task<int> CreateAsync(SignoVital signoVital);
    Task UpdateAsync(SignoVital signoVital);
    Task DeleteAsync(int id);
    Task<SignoVital?> GetByIdAsync(int id);
    Task<SignoVital?> GetByConsultaIdAsync(int consultaId);
    Task<bool> ExistsAsync(int id);
}