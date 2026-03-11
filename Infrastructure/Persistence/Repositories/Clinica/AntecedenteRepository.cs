using Application.Interfaces.Repositories.Clinica;
using Dapper;
using Domain.Entities.Clinica;
using Infrastructure.Persistence.Dapper;

namespace Infrastructure.Persistence.Repositories.Clinica;

public class AntecedenteRepository : IAntecedenteRepository
{
    private readonly DapperContext _context;

    public AntecedenteRepository(DapperContext context)
    {
        _context = context;
    }

    public async Task<int> CreateAsync(PacienteAntecedente antecedente)
    {
        const string sql = @"
            INSERT INTO paciente_antecedentes (paciente_id, tipo, condicion, descripcion)
            VALUES (@PacienteId, @Tipo, @Condicion, @Descripcion);
            SELECT LAST_INSERT_ID();";

        using var connection = _context.CreateConnection();
        return await connection.ExecuteScalarAsync<int>(sql, antecedente);
    }

    public async Task UpdateAsync(PacienteAntecedente antecedente)
    {
        const string sql = @"
            UPDATE paciente_antecedentes
            SET tipo = @Tipo,
                condicion = @Condicion,
                descripcion = @Descripcion
            WHERE id = @Id";

        using var connection = _context.CreateConnection();
        await connection.ExecuteAsync(sql, antecedente);
    }

    public async Task DeleteAsync(int id)
    {
        const string sql = "DELETE FROM paciente_antecedentes WHERE id = @Id";

        using var connection = _context.CreateConnection();
        await connection.ExecuteAsync(sql, new { Id = id });
    }

    public async Task<PacienteAntecedente?> GetByIdAsync(int id)
    {
        const string sql = @"
            SELECT id, paciente_id, tipo, condicion, descripcion
            FROM paciente_antecedentes
            WHERE id = @Id";

        using var connection = _context.CreateConnection();
        var row = await connection.QueryFirstOrDefaultAsync<dynamic>(sql, new { Id = id });

        if (row == null) return null;

        return new PacienteAntecedente(
            (int)row.id,
            (int)row.paciente_id,
            (string)row.tipo,
            (string)row.condicion,
            row.descripcion as string
        );
    }

    public async Task<IEnumerable<PacienteAntecedente>> GetByPacienteIdAsync(int pacienteId)
    {
        const string sql = @"
            SELECT id, paciente_id, tipo, condicion, descripcion
            FROM paciente_antecedentes
            WHERE paciente_id = @PacienteId
            ORDER BY tipo, condicion";

        using var connection = _context.CreateConnection();
        var rows = await connection.QueryAsync<dynamic>(sql, new { PacienteId = pacienteId });

        return rows.Select(row => new PacienteAntecedente(
            (int)row.id,
            (int)row.paciente_id,
            (string)row.tipo,
            (string)row.condicion,
            row.descripcion as string
        ));
    }

    public async Task<IEnumerable<PacienteAntecedente>> GetByPacienteIdAndTipoAsync(int pacienteId, string tipo)
    {
        const string sql = @"
            SELECT id, paciente_id, tipo, condicion, descripcion
            FROM paciente_antecedentes
            WHERE paciente_id = @PacienteId AND tipo = @Tipo
            ORDER BY condicion";

        using var connection = _context.CreateConnection();
        var rows = await connection.QueryAsync<dynamic>(sql, new { PacienteId = pacienteId, Tipo = tipo });

        return rows.Select(row => new PacienteAntecedente(
            (int)row.id,
            (int)row.paciente_id,
            (string)row.tipo,
            (string)row.condicion,
            row.descripcion as string
        ));
    }

    public async Task<bool> ExistsAsync(int id)
    {
        const string sql = "SELECT COUNT(1) FROM paciente_antecedentes WHERE id = @Id";

        using var connection = _context.CreateConnection();
        return await connection.ExecuteScalarAsync<bool>(sql, new { Id = id });
    }
}