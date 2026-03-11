using Domain.Entities.Clinica;

namespace Application.Interfaces.Repositories.Clinica;

public interface IAntecedenteRepository
{
    Task<int> CreateAsync(PacienteAntecedente antecedente);
    Task UpdateAsync(PacienteAntecedente antecedente);
    Task DeleteAsync(int id);
    Task<PacienteAntecedente?> GetByIdAsync(int id);
    Task<IEnumerable<PacienteAntecedente>> GetByPacienteIdAsync(int pacienteId);
    Task<IEnumerable<PacienteAntecedente>> GetByPacienteIdAndTipoAsync(int pacienteId, string tipo);
    Task<bool> ExistsAsync(int id);
}