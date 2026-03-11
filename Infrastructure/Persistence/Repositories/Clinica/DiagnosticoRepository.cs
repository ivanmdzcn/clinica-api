using Application.Interfaces.Repositories.Clinica;
using Dapper;
using Domain.Entities.Clinica;
using Infrastructure.Persistence.Dapper;

namespace Infrastructure.Persistence.Repositories.Clinica;

public class DiagnosticoRepository : IDiagnosticoRepository
{
    private readonly DapperContext _context;

    public DiagnosticoRepository(DapperContext context)
    {
        _context = context;
    }

    public async Task<int> CreateAsync(Diagnostico diagnostico)
    {
        const string sql = @"
            INSERT INTO diagnosticos (consulta_id, codigo_cie10, descripcion, tipo, fecha_registro)
            VALUES (@ConsultaId, @CodigoCie10, @Descripcion, @Tipo, @FechaRegistro);
            SELECT LAST_INSERT_ID();";

        using var connection = _context.CreateConnection();
        return await connection.ExecuteScalarAsync<int>(sql, diagnostico);
    }

    public async Task UpdateAsync(Diagnostico diagnostico)
    {
        const string sql = @"
            UPDATE diagnosticos
            SET codigo_cie10 = @CodigoCie10,
                descripcion = @Descripcion,
                tipo = @Tipo
            WHERE id = @Id";

        using var connection = _context.CreateConnection();
        await connection.ExecuteAsync(sql, diagnostico);
    }

    public async Task DeleteAsync(int id)
    {
        const string sql = "DELETE FROM diagnosticos WHERE id = @Id";

        using var connection = _context.CreateConnection();
        await connection.ExecuteAsync(sql, new { Id = id });
    }

    public async Task<Diagnostico?> GetByIdAsync(int id)
    {
        const string sql = @"
            SELECT id, consulta_id, codigo_cie10, descripcion, tipo, fecha_registro
            FROM diagnosticos
            WHERE id = @Id";

        using var connection = _context.CreateConnection();
        var row = await connection.QueryFirstOrDefaultAsync<dynamic>(sql, new { Id = id });

        if (row == null) return null;

        return new Diagnostico(
            (int)row.id,
            (int)row.consulta_id,
            row.codigo_cie10 as string,
            (string)row.descripcion,
            (string)row.tipo,
            (DateTime)row.fecha_registro
        );
    }

    public async Task<IEnumerable<Diagnostico>> GetByConsultaIdAsync(int consultaId)
    {
        const string sql = @"
            SELECT id, consulta_id, codigo_cie10, descripcion, tipo, fecha_registro
            FROM diagnosticos
            WHERE consulta_id = @ConsultaId
            ORDER BY fecha_registro DESC";

        using var connection = _context.CreateConnection();
        var rows = await connection.QueryAsync<dynamic>(sql, new { ConsultaId = consultaId });

        return rows.Select(row => new Diagnostico(
            (int)row.id,
            (int)row.consulta_id,
            row.codigo_cie10 as string,
            (string)row.descripcion,
            (string)row.tipo,
            (DateTime)row.fecha_registro
        ));
    }

    public async Task<bool> ExistsAsync(int id)
    {
        const string sql = "SELECT COUNT(1) FROM diagnosticos WHERE id = @Id";

        using var connection = _context.CreateConnection();
        return await connection.ExecuteScalarAsync<bool>(sql, new { Id = id });
    }
}