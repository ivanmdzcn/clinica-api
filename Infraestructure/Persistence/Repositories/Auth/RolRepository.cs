using Domain.Entities.Auth;
using Dapper;
using Infrastructure.Persistence.Dapper;
using Application.Interfaces.Repositories.Auth;

namespace Infraestructure.Persistence.Repositories.Auth;

public class RolRepository : IRolRepository
{
    private readonly DapperContext _context;

    public RolRepository(DapperContext context)
    {
        _context = context;
    }

    public async Task<Rol?> GetByIdAsync(int id)
    {
        const string sql = @"
            SELECT 
                id AS Id,
                nombre AS Nombre,
                descripcion AS Descripcion,
                fecha_creacion AS FechaCreacion
            FROM roles
            WHERE id = @Id
            LIMIT 1;
        ";

        using var connection = _context.CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<Rol>(sql, new { Id = id });
    }

    public async Task<Rol?> GetByNombreAsync(string nombre)
    {
        const string sql = @"
            SELECT 
                id AS Id,
                nombre AS Nombre,
                descripcion AS Descripcion,
                fecha_creacion AS FechaCreacion
            FROM roles
            WHERE nombre = @Nombre
            LIMIT 1;
        ";

        using var connection = _context.CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<Rol>(sql, new { Nombre = nombre });
    }

    public async Task<IEnumerable<Rol>> GetAllAsync()
    {
        const string sql = @"
            SELECT 
                id AS Id,
                nombre AS Nombre,
                descripcion AS Descripcion,
                fecha_creacion AS FechaCreacion
            FROM roles
            ORDER BY nombre;
        ";

        using var connection = _context.CreateConnection();
        return await connection.QueryAsync<Rol>(sql);
    }

    public async Task<int> CreateAsync(Rol rol)
    {
        const string sql = @"
            INSERT INTO roles (nombre, descripcion, fecha_creacion)
            VALUES (@Nombre, @Descripcion, @FechaCreacion);
            SELECT LAST_INSERT_ID();
        ";

        using var connection = _context.CreateConnection();
        return await connection.ExecuteScalarAsync<int>(sql, rol);
    }

    public async Task UpdateAsync(Rol rol)
    {
        const string sql = @"
            UPDATE roles
            SET 
                nombre = @Nombre,
                descripcion = @Descripcion
            WHERE id = @Id;
        ";

        using var connection = _context.CreateConnection();
        await connection.ExecuteAsync(sql, rol);
    }

    public async Task DeleteAsync(int id)
    {
        const string sql = "DELETE FROM roles WHERE id = @Id;";

        using var connection = _context.CreateConnection();
        await connection.ExecuteAsync(sql, new { Id = id });
    }

    public async Task<bool> ExistsAsync(int id)
    {
        const string sql = "SELECT COUNT(1) FROM roles WHERE id = @Id;";

        using var connection = _context.CreateConnection();
        var count = await connection.ExecuteScalarAsync<int>(sql, new { Id = id });
        return count > 0;
    }

    public async Task<bool> ExistsNombreAsync(string nombre, int? excludeId = null)
    {
        const string sql = @"
            SELECT COUNT(1)
            FROM roles
            WHERE nombre = @Nombre
            AND (@ExcludeId IS NULL OR id != @ExcludeId);
        ";

        using var connection = _context.CreateConnection();
        var count = await connection.ExecuteScalarAsync<int>(sql, new { Nombre = nombre, ExcludeId = excludeId });
        return count > 0;
    }
}