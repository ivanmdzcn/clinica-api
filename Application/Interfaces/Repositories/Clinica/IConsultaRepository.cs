using Domain.Entities.Clinica;

namespace Application.Interfaces.Repositories.Clinica;

public interface IConsultaRepository
{
    Task<int> CreateAsync(Consulta consulta);
    Task UpdateAsync(Consulta consulta);
    Task<Consulta?> GetByIdAsync(int id);
    Task<IEnumerable<Consulta>> GetByPacienteIdAsync(int pacienteId);
    Task<IEnumerable<Consulta>> GetByMedicoIdAsync(int medicoId);
    Task<IEnumerable<Consulta>> GetByEstadoAsync(string estado);
    Task<bool> ExistsAsync(int id);
}