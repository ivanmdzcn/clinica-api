using Application.Interfaces.Repositories.Clinica;
using Dapper;
using Domain.Entities.Clinica;
using Infrastructure.Persistence.Dapper;

namespace Infrastructure.Persistence.Repositories.Clinica;

public class TratamientoRepository : ITratamientoRepository
{
    private readonly DapperContext _context;

    public TratamientoRepository(DapperContext context)
    {
        _context = context;
    }

    public async Task<int> CreateAsync(Tratamiento tratamiento)
    {
        const string sql = @"
            INSERT INTO tratamientos (
                consulta_id, descripcion, indicaciones, fecha_inicio, fecha_fin, fecha_registro
            )
            VALUES (
                @ConsultaId, @Descripcion, @Indicaciones, @FechaInicio, @FechaFin, @FechaRegistro
            );
            SELECT LAST_INSERT_ID();";

        using var connection = _context.CreateConnection();
        return await connection.ExecuteScalarAsync<int>(sql, tratamiento);
    }

    public async Task UpdateAsync(Tratamiento tratamiento)
    {
        const string sql = @"
            UPDATE tratamientos
            SET descripcion = @Descripcion,
                indicaciones = @Indicaciones,
                fecha_inicio = @FechaInicio,
                fecha_fin = @FechaFin
            WHERE id = @Id";

        using var connection = _context.CreateConnection();
        await connection.ExecuteAsync(sql, tratamiento);
    }

    public async Task DeleteAsync(int id)
    {
        const string sql = "DELETE FROM tratamientos WHERE id = @Id";

        using var connection = _context.CreateConnection();
        await connection.ExecuteAsync(sql, new { Id = id });
    }

    public async Task<Tratamiento?> GetByIdAsync(int id)
    {
        const string sql = @"
            SELECT id, consulta_id, descripcion, indicaciones, fecha_inicio, fecha_fin, fecha_registro
            FROM tratamientos
            WHERE id = @Id";

        using var connection = _context.CreateConnection();
        var row = await connection.QueryFirstOrDefaultAsync<dynamic>(sql, new { Id = id });

        if (row == null) return null;

        return new Tratamiento(
            (int)row.id,
            (int)row.consulta_id,
            (string)row.descripcion,
            row.indicaciones as string,
            row.fecha_inicio as DateTime?,
            row.fecha_fin as DateTime?,
            (DateTime)row.fecha_registro
        );
    }

    public async Task<IEnumerable<Tratamiento>> GetByConsultaIdAsync(int consultaId)
    {
        const string sql = @"
            SELECT id, consulta_id, descripcion, indicaciones, fecha_inicio, fecha_fin, fecha_registro
            FROM tratamientos
            WHERE consulta_id = @ConsultaId
            ORDER BY fecha_registro DESC";

        using var connection = _context.CreateConnection();
        var rows = await connection.QueryAsync<dynamic>(sql, new { ConsultaId = consultaId });

        return rows.Select(row => new Tratamiento(
            (int)row.id,
            (int)row.consulta_id,
            (string)row.descripcion,
            row.indicaciones as string,
            row.fecha_inicio as DateTime?,
            row.fecha_fin as DateTime?,
            (DateTime)row.fecha_registro
        ));
    }

    public async Task<bool> ExistsAsync(int id)
    {
        const string sql = "SELECT COUNT(1) FROM tratamientos WHERE id = @Id";

        using var connection = _context.CreateConnection();
        return await connection.ExecuteScalarAsync<bool>(sql, new { Id = id });
    }
}