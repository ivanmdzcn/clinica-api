using Domain.Entities.Clinica;

namespace Application.Interfaces.Repositories.Clinica;

public interface ITratamientoRepository
{
    Task<int> CreateAsync(Tratamiento tratamiento);
    Task UpdateAsync(Tratamiento tratamiento);
    Task DeleteAsync(int id);
    Task<Tratamiento?> GetByIdAsync(int id);
    Task<IEnumerable<Tratamiento>> GetByConsultaIdAsync(int consultaId);
    Task<bool> ExistsAsync(int id);
}