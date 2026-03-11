using Application.Interfaces.Repositories.Clinica;
using Dapper;
using Domain.Entities.Clinica;
using Infrastructure.Persistence.Dapper;

namespace Infrastructure.Persistence.Repositories.Clinica;

public class ExamenFisicoRepository : IExamenFisicoRepository
{
    private readonly DapperContext _context;

    public ExamenFisicoRepository(DapperContext context)
    {
        _context = context;
    }

    public async Task<int> CreateAsync(ExamenFisico examenFisico)
    {
        const string sql = @"
            INSERT INTO examen_fisico (consulta_id, es_normal, descripcion, fecha_registro)
            VALUES (@ConsultaId, @EsNormal, @Descripcion, @FechaRegistro);
            SELECT LAST_INSERT_ID();";

        using var connection = _context.CreateConnection();
        return await connection.ExecuteScalarAsync<int>(sql, examenFisico);
    }

    public async Task UpdateAsync(ExamenFisico examenFisico)
    {
        const string sql = @"
            UPDATE examen_fisico
            SET es_normal = @EsNormal,
                descripcion = @Descripcion
            WHERE id = @Id";

        using var connection = _context.CreateConnection();
        await connection.ExecuteAsync(sql, examenFisico);
    }

    public async Task DeleteAsync(int id)
    {
        const string sql = "DELETE FROM examen_fisico WHERE id = @Id";

        using var connection = _context.CreateConnection();
        await connection.ExecuteAsync(sql, new { Id = id });
    }

    public async Task<ExamenFisico?> GetByIdAsync(int id)
    {
        const string sql = @"
            SELECT id, consulta_id, es_normal, descripcion, fecha_registro
            FROM examen_fisico
            WHERE id = @Id";

        using var connection = _context.CreateConnection();
        var row = await connection.QueryFirstOrDefaultAsync<dynamic>(sql, new { Id = id });

        if (row == null) return null;

        return new ExamenFisico(
            (int)row.id,
            (int)row.consulta_id,
            (bool)row.es_normal,
            row.descripcion as string,
            (DateTime)row.fecha_registro
        );
    }

    public async Task<ExamenFisico?> GetByConsultaIdAsync(int consultaId)
    {
        const string sql = @"
            SELECT id, consulta_id, es_normal, descripcion, fecha_registro
            FROM examen_fisico
            WHERE consulta_id = @ConsultaId";

        using var connection = _context.CreateConnection();
        var row = await connection.QueryFirstOrDefaultAsync<dynamic>(sql, new { ConsultaId = consultaId });

        if (row == null) return null;

        return new ExamenFisico(
            (int)row.id,
            (int)row.consulta_id,
            (bool)row.es_normal,
            row.descripcion as string,
            (DateTime)row.fecha_registro
        );
    }

    public async Task<bool> ExistsAsync(int id)
    {
        const string sql = "SELECT COUNT(1) FROM examen_fisico WHERE id = @Id";

        using var connection = _context.CreateConnection();
        return await connection.ExecuteScalarAsync<bool>(sql, new { Id = id });
    }
}