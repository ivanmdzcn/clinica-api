using Domain.Entities.Auth;
using Dapper;
using Infrastructure.Persistence.Dapper;
using Application.Interfaces.Repositories.Auth;

namespace Infraestructure.Persistence.Repositories.Auth;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly DapperContext _context;

    public UsuarioRepository(DapperContext context)
    {
        _context = context;
    }

    public async Task<Usuario?> GetByIdAsync(int id)
    {
        const string sql = @"
            SELECT 
                id AS Id,
                username AS Username,
                nombre_completo AS NombreCompleto,
                email AS Email,
                password_hash AS PasswordHash,
                rol_id AS RolId,
                activo AS Activo,
                fecha_creacion AS FechaCreacion,
                ultimo_acceso AS UltimoAcceso
            FROM usuarios
            WHERE id = @Id
            LIMIT 1;
        ";

        using var connection = _context.CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<Usuario>(sql, new { Id = id });
    }

    public async Task<Usuario?> GetByUsernameAsync(string username)
    {
        const string sql = @"
            SELECT 
                id AS Id,
                username AS Username,
                nombre_completo AS NombreCompleto,
                email AS Email,
                password_hash AS PasswordHash,
                rol_id AS RolId,
                activo AS Activo,
                fecha_creacion AS FechaCreacion,
                ultimo_acceso AS UltimoAcceso
            FROM usuarios
            WHERE username = @Username
            LIMIT 1;
        ";

        using var connection = _context.CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<Usuario>(sql, new { Username = username });
    }

    public async Task<Usuario?> GetByEmailAsync(string email)
    {
        const string sql = @"
            SELECT 
                id AS Id,
                username AS Username,
                nombre_completo AS NombreCompleto,
                email AS Email,
                password_hash AS PasswordHash,
                rol_id AS RolId,
                activo AS Activo,
                fecha_creacion AS FechaCreacion,
                ultimo_acceso AS UltimoAcceso
            FROM usuarios
            WHERE email = @Email
            LIMIT 1;
        ";

        using var connection = _context.CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<Usuario>(sql, new { Email = email });
    }

    public async Task<IEnumerable<Usuario>> GetAllAsync()
    {
        const string sql = @"
            SELECT 
                id AS Id,
                username AS Username,
                nombre_completo AS NombreCompleto,
                email AS Email,
                password_hash AS PasswordHash,
                rol_id AS RolId,
                activo AS Activo,
                fecha_creacion AS FechaCreacion,
                ultimo_acceso AS UltimoAcceso
            FROM usuarios
            ORDER BY fecha_creacion DESC;
        ";

        using var connection = _context.CreateConnection();
        return await connection.QueryAsync<Usuario>(sql);
    }

    public async Task<IEnumerable<Usuario>> GetByRolIdAsync(int rolId)
    {
        const string sql = @"
            SELECT 
                id AS Id,
                username AS Username,
                nombre_completo AS NombreCompleto,
                email AS Email,
                password_hash AS PasswordHash,
                rol_id AS RolId,
                activo AS Activo,
                fecha_creacion AS FechaCreacion,
                ultimo_acceso AS UltimoAcceso
            FROM usuarios
            WHERE rol_id = @RolId
            ORDER BY fecha_creacion DESC;
        ";

        using var connection = _context.CreateConnection();
        return await connection.QueryAsync<Usuario>(sql, new { RolId = rolId });
    }

    public async Task<int> CreateAsync(Usuario usuario)
    {
        const string sql = @"
            INSERT INTO usuarios (username, nombre_completo, email, password_hash, rol_id, activo, fecha_creacion)
            VALUES (@Username, @NombreCompleto, @Email, @PasswordHash, @RolId, @Activo, @FechaCreacion);
            SELECT LAST_INSERT_ID();
        ";

        using var connection = _context.CreateConnection();
        return await connection.ExecuteScalarAsync<int>(sql, usuario);
    }

    public async Task UpdateAsync(Usuario usuario)
    {
        const string sql = @"
            UPDATE usuarios
            SET 
                nombre_completo = @NombreCompleto,
                email = @Email,
                rol_id = @RolId,
                activo = @Activo
            WHERE id = @Id;
        ";

        using var connection = _context.CreateConnection();
        await connection.ExecuteAsync(sql, usuario);
    }

    public async Task DeleteAsync(int id)
    {
        const string sql = "DELETE FROM usuarios WHERE id = @Id;";

        using var connection = _context.CreateConnection();
        await connection.ExecuteAsync(sql, new { Id = id });
    }

    public async Task UpdateUltimoAccesoAsync(int usuarioId)
    {
        const string sql = @"
            UPDATE usuarios
            SET ultimo_acceso = UTC_TIMESTAMP()
            WHERE id = @Id;
        ";

        using var connection = _context.CreateConnection();
        await connection.ExecuteAsync(sql, new { Id = usuarioId });
    }

    public async Task<bool> ExistsUsernameAsync(string username, int? excludeId = null)
    {
        const string sql = @"
            SELECT COUNT(1)
            FROM usuarios
            WHERE username = @Username
            AND (@ExcludeId IS NULL OR id != @ExcludeId);
        ";

        using var connection = _context.CreateConnection();
        var count = await connection.ExecuteScalarAsync<int>(sql, new { Username = username, ExcludeId = excludeId });
        return count > 0;
    }

    public async Task<bool> ExistsEmailAsync(string email, int? excludeId = null)
    {
        const string sql = @"
            SELECT COUNT(1)
            FROM usuarios
            WHERE email = @Email
            AND (@ExcludeId IS NULL OR id != @ExcludeId);
        ";

        using var connection = _context.CreateConnection();
        var count = await connection.ExecuteScalarAsync<int>(sql, new { Email = email, ExcludeId = excludeId });
        return count > 0;
    }
}
