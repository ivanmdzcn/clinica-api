using Domain.Entities.Clinica;

namespace Application.Interfaces.Repositories.Clinica;

public interface IOrdenLaboratorioRepository
{
    Task<int> CreateAsync(OrdenLaboratorio orden);
    Task UpdateAsync(OrdenLaboratorio orden);
    Task DeleteAsync(int id);
    Task<OrdenLaboratorio?> GetByIdAsync(int id);
    Task<IEnumerable<OrdenLaboratorio>> GetByConsultaIdAsync(int consultaId);
    Task<IEnumerable<OrdenLaboratorio>> GetByPacienteIdAsync(int pacienteId);
    Task<bool> ExistsAsync(int id);
    Task<bool> ExistsNumeroOrdenAsync(string numeroOrden, int? excludeId = null);
}