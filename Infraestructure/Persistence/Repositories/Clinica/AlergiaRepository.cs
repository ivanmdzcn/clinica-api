using Application.Interfaces.Repositories.Clinica;
using Dapper;
using Domain.Entities.Clinica;
using Infrastructure.Persistence.Dapper;

namespace Infrastructure.Persistence.Repositories.Clinica;

public class AlergiaRepository : IAlergiaRepository
{
    private readonly DapperContext _context;

    public AlergiaRepository(DapperContext context)
    {
        _context = context;
    }

    public async Task<int> CreateAsync(PacienteAlergia alergia)
    {
        const string sql = @"
            INSERT INTO paciente_alergias (paciente_id, medicamento_o_elemento, reaccion)
            VALUES (@PacienteId, @MedicamentoOElemento, @Reaccion);
            SELECT LAST_INSERT_ID();";

        using var connection = _context.CreateConnection();
        return await connection.ExecuteScalarAsync<int>(sql, alergia);
    }

    public async Task UpdateAsync(PacienteAlergia alergia)
    {
        const string sql = @"
            UPDATE paciente_alergias
            SET medicamento_o_elemento = @MedicamentoOElemento,
                reaccion = @Reaccion
            WHERE id = @Id";

        using var connection = _context.CreateConnection();
        await connection.ExecuteAsync(sql, alergia);
    }

    public async Task DeleteAsync(int id)
    {
        const string sql = "DELETE FROM paciente_alergias WHERE id = @Id";

        using var connection = _context.CreateConnection();
        await connection.ExecuteAsync(sql, new { Id = id });
    }

    public async Task<PacienteAlergia?> GetByIdAsync(int id)
    {
        const string sql = @"
            SELECT id, paciente_id, medicamento_o_elemento, reaccion
            FROM paciente_alergias
            WHERE id = @Id";

        using var connection = _context.CreateConnection();
        var row = await connection.QueryFirstOrDefaultAsync<dynamic>(sql, new { Id = id });

        if (row == null) return null;

        return new PacienteAlergia(
            (int)row.id,
            (int)row.paciente_id,
            (string)row.medicamento_o_elemento,
            row.reaccion as string
        );
    }

    public async Task<IEnumerable<PacienteAlergia>> GetByPacienteIdAsync(int pacienteId)
    {
        const string sql = @"
            SELECT id, paciente_id, medicamento_o_elemento, reaccion
            FROM paciente_alergias
            WHERE paciente_id = @PacienteId
            ORDER BY medicamento_o_elemento";

        using var connection = _context.CreateConnection();
        var rows = await connection.QueryAsync<dynamic>(sql, new { PacienteId = pacienteId });

        return rows.Select(row => new PacienteAlergia(
            (int)row.id,
            (int)row.paciente_id,
            (string)row.medicamento_o_elemento,
            row.reaccion as string
        ));
    }

    public async Task<bool> ExistsAsync(int id)
    {
        const string sql = "SELECT COUNT(1) FROM paciente_alergias WHERE id = @Id";

        using var connection = _context.CreateConnection();
        return await connection.ExecuteScalarAsync<bool>(sql, new { Id = id });
    }
}