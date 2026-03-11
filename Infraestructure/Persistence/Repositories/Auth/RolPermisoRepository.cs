using Domain.Entities.Auth;
using Dapper;
using Infrastructure.Persistence.Dapper;
using Application.Interfaces.Repositories.Auth;

namespace Infraestructure.Persistence.Repositories.Auth;

public class RolPermisoRepository : IRolPermisoRepository
{
    private readonly DapperContext _context;

    public RolPermisoRepository(DapperContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Permiso>> GetPermisosByRolIdAsync(int rolId)
    {
        const string sql = @"
            SELECT 
                p.id AS Id,
                p.codigo AS Codigo,
                p.modulo AS Modulo,
                p.accion AS Accion,
                p.descripcion AS Descripcion
            FROM permisos p
            INNER JOIN rol_permisos rp ON p.id = rp.permiso_id
            WHERE rp.rol_id = @RolId
            ORDER BY p.modulo, p.accion;
        ";

        using var connection = _context.CreateConnection();
        return await connection.QueryAsync<Permiso>(sql, new { RolId = rolId });
    }

    public async Task<IEnumerable<int>> GetPermisoIdsByRolIdAsync(int rolId)
    {
        const string sql = @"
            SELECT permiso_id
            FROM rol_permisos
            WHERE rol_id = @RolId;
        ";

        using var connection = _context.CreateConnection();
        return await connection.QueryAsync<int>(sql, new { RolId = rolId });
    }

    public async Task AsignarPermisoAsync(int rolId, int permisoId)
    {
        const string sql = @"
            INSERT IGNORE INTO rol_permisos (rol_id, permiso_id, fecha_asignacion)
            VALUES (@RolId, @PermisoId, UTC_TIMESTAMP());
        ";

        using var connection = _context.CreateConnection();
        await connection.ExecuteAsync(sql, new { RolId = rolId, PermisoId = permisoId });
    }

    public async Task AsignarPermisosAsync(int rolId, IEnumerable<int> permisoIds)
    {
        const string sql = @"
            INSERT IGNORE INTO rol_permisos (rol_id, permiso_id, fecha_asignacion)
            VALUES (@RolId, @PermisoId, UTC_TIMESTAMP());
        ";

        using var connection = _context.CreateConnection();
        
        foreach (var permisoId in permisoIds)
        {
            await connection.ExecuteAsync(sql, new { RolId = rolId, PermisoId = permisoId });
        }
    }

    public async Task RemoverPermisoAsync(int rolId, int permisoId)
    {
        const string sql = @"
            DELETE FROM rol_permisos
            WHERE rol_id = @RolId AND permiso_id = @PermisoId;
        ";

        using var connection = _context.CreateConnection();
        await connection.ExecuteAsync(sql, new { RolId = rolId, PermisoId = permisoId });
    }

    public async Task RemoverTodosLosPermisosAsync(int rolId)
    {
        const string sql = @"
            DELETE FROM rol_permisos
            WHERE rol_id = @RolId;
        ";

        using var connection = _context.CreateConnection();
        await connection.ExecuteAsync(sql, new { RolId = rolId });
    }

    public async Task<bool> RolTienePermisoAsync(int rolId, int permisoId)
    {
        const string sql = @"
            SELECT COUNT(1)
            FROM rol_permisos
            WHERE rol_id = @RolId AND permiso_id = @PermisoId;
        ";

        using var connection = _context.CreateConnection();
        var count = await connection.ExecuteScalarAsync<int>(sql, new { RolId = rolId, PermisoId = permisoId });
        return count > 0;
    }
}