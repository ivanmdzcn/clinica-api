using Application.Interfaces.Repositories.Clinica;
using Dapper;
using Domain.Entities.Clinica;
using Infrastructure.Persistence.Dapper;

namespace Infrastructure.Persistence.Repositories.Clinica;

public class ExamenLaboratorioRepository : IExamenLaboratorioRepository
{
    private readonly DapperContext _context;

    public ExamenLaboratorioRepository(DapperContext context)
    {
        _context = context;
    }

    public async Task<int> CreateAsync(ExamenLaboratorio examen)
    {
        const string sql = @"
            INSERT INTO examen_laboratorio (
                orden_laboratorio_id, nombre_examen, resultado, unidad,
                valor_referencia, fecha_resultado, fecha_registro
            )
            VALUES (
                @OrdenLaboratorioId, @NombreExamen, @Resultado, @Unidad,
                @ValorReferencia, @FechaResultado, @FechaRegistro
            );
            SELECT LAST_INSERT_ID();";

        using var connection = _context.CreateConnection();
        return await connection.ExecuteScalarAsync<int>(sql, examen);
    }

    public async Task UpdateAsync(ExamenLaboratorio examen)
    {
        const string sql = @"
            UPDATE examen_laboratorio
            SET nombre_examen = @NombreExamen,
                resultado = @Resultado,
                unidad = @Unidad,
                valor_referencia = @ValorReferencia,
                fecha_resultado = @FechaResultado
            WHERE id = @Id";

        using var connection = _context.CreateConnection();
        await connection.ExecuteAsync(sql, examen);
    }

    public async Task DeleteAsync(int id)
    {
        const string sql = "DELETE FROM examen_laboratorio WHERE id = @Id";

        using var connection = _context.CreateConnection();
        await connection.ExecuteAsync(sql, new { Id = id });
    }

    public async Task<ExamenLaboratorio?> GetByIdAsync(int id)
    {
        const string sql = @"
            SELECT id, orden_laboratorio_id, nombre_examen, resultado, unidad,
                   valor_referencia, fecha_resultado, fecha_registro
            FROM examen_laboratorio
            WHERE id = @Id";

        using var connection = _context.CreateConnection();
        var row = await connection.QueryFirstOrDefaultAsync<dynamic>(sql, new { Id = id });

        if (row == null) return null;

        return new ExamenLaboratorio(
            (int)row.id,
            (int)row.orden_laboratorio_id,
            (string)row.nombre_examen,
            row.resultado as string,
            row.unidad as string,
            row.valor_referencia as string,
            row.fecha_resultado as DateTime?,
            (DateTime)row.fecha_registro
        );
    }

    public async Task<IEnumerable<ExamenLaboratorio>> GetByOrdenLaboratorioIdAsync(int ordenLaboratorioId)
    {
        const string sql = @"
            SELECT id, orden_laboratorio_id, nombre_examen, resultado, unidad,
                   valor_referencia, fecha_resultado, fecha_registro
            FROM examen_laboratorio
            WHERE orden_laboratorio_id = @OrdenLaboratorioId
            ORDER BY nombre_examen";

        using var connection = _context.CreateConnection();
        var rows = await connection.QueryAsync<dynamic>(sql, new { OrdenLaboratorioId = ordenLaboratorioId });

        return rows.Select(row => new ExamenLaboratorio(
            (int)row.id,
            (int)row.orden_laboratorio_id,
            (string)row.nombre_examen,
            row.resultado as string,
            row.unidad as string,
            row.valor_referencia as string,
            row.fecha_resultado as DateTime?,
            (DateTime)row.fecha_registro
        ));
    }

    public async Task<bool> ExistsAsync(int id)
    {
        const string sql = "SELECT COUNT(1) FROM examen_laboratorio WHERE id = @Id";

        using var connection = _context.CreateConnection();
        return await connection.ExecuteScalarAsync<bool>(sql, new { Id = id });
    }
}