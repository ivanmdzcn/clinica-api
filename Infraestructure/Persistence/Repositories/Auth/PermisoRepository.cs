using Domain.Entities.Auth;
using Dapper;
using Infrastructure.Persistence.Dapper;
using Application.Interfaces.Repositories.Auth;

namespace Infraestructure.Persistence.Repositories.Auth;

public class PermisoRepository : IPermisoRepository
{
    private readonly DapperContext _context;

    public PermisoRepository(DapperContext context)
    {
        _context = context;
    }

    public async Task<Permiso?> GetByIdAsync(int id)
    {
        const string sql = @"
            SELECT 
                id AS Id,
                codigo AS Codigo,
                modulo AS Modulo,
                accion AS Accion,
                descripcion AS Descripcion
            FROM permisos
            WHERE id = @Id
            LIMIT 1;
        ";

        using var connection = _context.CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<Permiso>(sql, new { Id = id });
    }

    public async Task<Permiso?> GetByCodigoAsync(string codigo)
    {
        const string sql = @"
            SELECT 
                id AS Id,
                codigo AS Codigo,
                modulo AS Modulo,
                accion AS Accion,
                descripcion AS Descripcion
            FROM permisos
            WHERE codigo = @Codigo
            LIMIT 1;
        ";

        using var connection = _context.CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<Permiso>(sql, new { Codigo = codigo });
    }

    public async Task<IEnumerable<Permiso>> GetAllAsync()
    {
        const string sql = @"
            SELECT 
                id AS Id,
                codigo AS Codigo,
                modulo AS Modulo,
                accion AS Accion,
                descripcion AS Descripcion
            FROM permisos
            ORDER BY modulo, accion;
        ";

        using var connection = _context.CreateConnection();
        return await connection.QueryAsync<Permiso>(sql);
    }

    public async Task<IEnumerable<Permiso>> GetByModuloAsync(string modulo)
    {
        const string sql = @"
            SELECT 
                id AS Id,
                codigo AS Codigo,
                modulo AS Modulo,
                accion AS Accion,
                descripcion AS Descripcion
            FROM permisos
            WHERE modulo = @Modulo
            ORDER BY accion;
        ";

        using var connection = _context.CreateConnection();
        return await connection.QueryAsync<Permiso>(sql, new { Modulo = modulo });
    }

    public async Task<IEnumerable<string>> GetModulosAsync()
    {
        const string sql = @"
            SELECT DISTINCT modulo
            FROM permisos
            ORDER BY modulo;
        ";

        using var connection = _context.CreateConnection();
        return await connection.QueryAsync<string>(sql);
    }

    public async Task<int> CreateAsync(Permiso permiso)
    {
        const string sql = @"
            INSERT INTO permisos (codigo, modulo, accion, descripcion)
            VALUES (@Codigo, @Modulo, @Accion, @Descripcion);
            SELECT LAST_INSERT_ID();
        ";

        using var connection = _context.CreateConnection();
        return await connection.ExecuteScalarAsync<int>(sql, permiso);
    }

    public async Task UpdateAsync(Permiso permiso)
    {
        const string sql = @"
            UPDATE permisos
            SET 
                codigo = @Codigo,
                modulo = @Modulo,
                accion = @Accion,
                descripcion = @Descripcion
            WHERE id = @Id;
        ";

        using var connection = _context.CreateConnection();
        await connection.ExecuteAsync(sql, permiso);
    }

    public async Task DeleteAsync(int id)
    {
        const string sql = "DELETE FROM permisos WHERE id = @Id;";

        using var connection = _context.CreateConnection();
        await connection.ExecuteAsync(sql, new { Id = id });
    }

    public async Task<bool> ExistsAsync(int id)
    {
        const string sql = "SELECT COUNT(1) FROM permisos WHERE id = @Id;";

        using var connection = _context.CreateConnection();
        var count = await connection.ExecuteScalarAsync<int>(sql, new { Id = id });
        return count > 0;
    }

    public async Task<bool> ExistsCodigoAsync(string codigo, int? excludeId = null)
    {
        const string sql = @"
            SELECT COUNT(1)
            FROM permisos
            WHERE codigo = @Codigo
            AND (@ExcludeId IS NULL OR id != @ExcludeId);
        ";

        using var connection = _context.CreateConnection();
        var count = await connection.ExecuteScalarAsync<int>(sql, new { Codigo = codigo, ExcludeId = excludeId });
        return count > 0;
    }
}