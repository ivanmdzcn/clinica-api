using Application.Interfaces.Repositories.Clinica;
using Dapper;
using Domain.Entities.Clinica;
using Infrastructure.Persistence.Dapper;

namespace Infrastructure.Persistence.Repositories.Clinica;

public class OrdenLaboratorioRepository : IOrdenLaboratorioRepository
{
    private readonly DapperContext _context;

    public OrdenLaboratorioRepository(DapperContext context)
    {
        _context = context;
    }

    public async Task<int> CreateAsync(OrdenLaboratorio orden)
    {
        const string sql = @"
            INSERT INTO orden_laboratorio (
                consulta_id, numero_orden, fecha_orden, paciente_id, medico_id,
                diagnostico_cie10, observaciones, fecha_registro
            )
            VALUES (
                @ConsultaId, @NumeroOrden, @FechaOrden, @PacienteId, @MedicoId,
                @DiagnosticoCie10, @Observaciones, @FechaRegistro
            );
            SELECT LAST_INSERT_ID();";

        using var connection = _context.CreateConnection();
        return await connection.ExecuteScalarAsync<int>(sql, orden);
    }

    public async Task UpdateAsync(OrdenLaboratorio orden)
    {
        const string sql = @"
            UPDATE orden_laboratorio
            SET numero_orden = @NumeroOrden,
                fecha_orden = @FechaOrden,
                diagnostico_cie10 = @DiagnosticoCie10,
                observaciones = @Observaciones
            WHERE id = @Id";

        using var connection = _context.CreateConnection();
        await connection.ExecuteAsync(sql, orden);
    }

    public async Task DeleteAsync(int id)
    {
        const string sql = "DELETE FROM orden_laboratorio WHERE id = @Id";

        using var connection = _context.CreateConnection();
        await connection.ExecuteAsync(sql, new { Id = id });
    }

    public async Task<OrdenLaboratorio?> GetByIdAsync(int id)
    {
        const string sql = @"
            SELECT id, consulta_id, numero_orden, fecha_orden, paciente_id, medico_id,
                   diagnostico_cie10, observaciones, fecha_registro
            FROM orden_laboratorio
            WHERE id = @Id";

        using var connection = _context.CreateConnection();
        var row = await connection.QueryFirstOrDefaultAsync<dynamic>(sql, new { Id = id });

        if (row == null) return null;

        return new OrdenLaboratorio(
            (int)row.id,
            (int)row.consulta_id,
            (string)row.numero_orden,
            (DateTime)row.fecha_orden,
            (int)row.paciente_id,
            (int)row.medico_id,
            row.diagnostico_cie10 as string,
            row.observaciones as string,
            (DateTime)row.fecha_registro
        );
    }

    public async Task<IEnumerable<OrdenLaboratorio>> GetByConsultaIdAsync(int consultaId)
    {
        const string sql = @"
            SELECT id, consulta_id, numero_orden, fecha_orden, paciente_id, medico_id,
                   diagnostico_cie10, observaciones, fecha_registro
            FROM orden_laboratorio
            WHERE consulta_id = @ConsultaId
            ORDER BY fecha_orden DESC";

        using var connection = _context.CreateConnection();
        var rows = await connection.QueryAsync<dynamic>(sql, new { ConsultaId = consultaId });

        return rows.Select(row => new OrdenLaboratorio(
            (int)row.id,
            (int)row.consulta_id,
            (string)row.numero_orden,
            (DateTime)row.fecha_orden,
            (int)row.paciente_id,
            (int)row.medico_id,
            row.diagnostico_cie10 as string,
            row.observaciones as string,
            (DateTime)row.fecha_registro
        ));
    }

    public async Task<IEnumerable<OrdenLaboratorio>> GetByPacienteIdAsync(int pacienteId)
    {
        const string sql = @"
            SELECT id, consulta_id, numero_orden, fecha_orden, paciente_id, medico_id,
                   diagnostico_cie10, observaciones, fecha_registro
            FROM orden_laboratorio
            WHERE paciente_id = @PacienteId
            ORDER BY fecha_orden DESC";

        using var connection = _context.CreateConnection();
        var rows = await connection.QueryAsync<dynamic>(sql, new { PacienteId = pacienteId });

        return rows.Select(row => new OrdenLaboratorio(
            (int)row.id,
            (int)row.consulta_id,
            (string)row.numero_orden,
            (DateTime)row.fecha_orden,
            (int)row.paciente_id,
            (int)row.medico_id,
            row.diagnostico_cie10 as string,
            row.observaciones as string,
            (DateTime)row.fecha_registro
        ));
    }

    public async Task<bool> ExistsAsync(int id)
    {
        const string sql = "SELECT COUNT(1) FROM orden_laboratorio WHERE id = @Id";

        using var connection = _context.CreateConnection();
        return await connection.ExecuteScalarAsync<bool>(sql, new { Id = id });
    }

    public async Task<bool> ExistsNumeroOrdenAsync(string numeroOrden, int? excludeId = null)
    {
        var sql = "SELECT COUNT(1) FROM orden_laboratorio WHERE numero_orden = @NumeroOrden";
        
        if (excludeId.HasValue)
            sql += " AND id != @ExcludeId";

        using var connection = _context.CreateConnection();
        return await connection.ExecuteScalarAsync<bool>(sql, new { NumeroOrden = numeroOrden, ExcludeId = excludeId });
    }
}