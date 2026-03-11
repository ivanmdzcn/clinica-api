using Application.Interfaces.Repositories.Clinica;
using Dapper;
using Domain.Entities.Clinica;
using Infrastructure.Persistence.Dapper;

namespace Infrastructure.Persistence.Repositories.Clinica;

public class RecetaRepository : IRecetaRepository
{
    private readonly DapperContext _context;

    public RecetaRepository(DapperContext context)
    {
        _context = context;
    }

    public async Task<int> CreateAsync(Receta receta)
    {
        const string sql = @"
            INSERT INTO recetas (
                consulta_id, medicamento, dosis, frecuencia, duracion,
                via_administracion, indicaciones, fecha_registro
            )
            VALUES (
                @ConsultaId, @Medicamento, @Dosis, @Frecuencia, @Duracion,
                @ViaAdministracion, @Indicaciones, @FechaRegistro
            );
            SELECT LAST_INSERT_ID();";

        using var connection = _context.CreateConnection();
        return await connection.ExecuteScalarAsync<int>(sql, receta);
    }

    public async Task UpdateAsync(Receta receta)
    {
        const string sql = @"
            UPDATE recetas
            SET medicamento = @Medicamento,
                dosis = @Dosis,
                frecuencia = @Frecuencia,
                duracion = @Duracion,
                via_administracion = @ViaAdministracion,
                indicaciones = @Indicaciones
            WHERE id = @Id";

        using var connection = _context.CreateConnection();
        await connection.ExecuteAsync(sql, receta);
    }

    public async Task DeleteAsync(int id)
    {
        const string sql = "DELETE FROM recetas WHERE id = @Id";

        using var connection = _context.CreateConnection();
        await connection.ExecuteAsync(sql, new { Id = id });
    }

    public async Task<Receta?> GetByIdAsync(int id)
    {
        const string sql = @"
            SELECT id, consulta_id, medicamento, dosis, frecuencia, duracion,
                   via_administracion, indicaciones, fecha_registro
            FROM recetas
            WHERE id = @Id";

        using var connection = _context.CreateConnection();
        var row = await connection.QueryFirstOrDefaultAsync<dynamic>(sql, new { Id = id });

        if (row == null) return null;

        return new Receta(
            (int)row.id,
            (int)row.consulta_id,
            (string)row.medicamento,
            row.dosis as string,
            row.frecuencia as string,
            row.duracion as string,
            row.via_administracion as string,
            row.indicaciones as string,
            (DateTime)row.fecha_registro
        );
    }

    public async Task<IEnumerable<Receta>> GetByConsultaIdAsync(int consultaId)
    {
        const string sql = @"
            SELECT id, consulta_id, medicamento, dosis, frecuencia, duracion,
                   via_administracion, indicaciones, fecha_registro
            FROM recetas
            WHERE consulta_id = @ConsultaId
            ORDER BY fecha_registro";

        using var connection = _context.CreateConnection();
        var rows = await connection.QueryAsync<dynamic>(sql, new { ConsultaId = consultaId });

        return rows.Select(row => new Receta(
            (int)row.id,
            (int)row.consulta_id,
            (string)row.medicamento,
            row.dosis as string,
            row.frecuencia as string,
            row.duracion as string,
            row.via_administracion as string,
            row.indicaciones as string,
            (DateTime)row.fecha_registro
        ));
    }

    public async Task<bool> ExistsAsync(int id)
    {
        const string sql = "SELECT COUNT(1) FROM recetas WHERE id = @Id";

        using var connection = _context.CreateConnection();
        return await connection.ExecuteScalarAsync<bool>(sql, new { Id = id });
    }
}