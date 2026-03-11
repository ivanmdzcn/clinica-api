using Domain.Entities.Clinica;

namespace Application.Interfaces.Repositories.Clinica;

public interface IRecetaRepository
{
    Task<int> CreateAsync(Receta receta);
    Task UpdateAsync(Receta receta);
    Task DeleteAsync(int id);
    Task<Receta?> GetByIdAsync(int id);
    Task<IEnumerable<Receta>> GetByConsultaIdAsync(int consultaId);
    Task<bool> ExistsAsync(int id);
}