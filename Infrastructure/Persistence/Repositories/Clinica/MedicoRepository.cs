using Application.Interfaces.Repositories.Clinica;
using Dapper;
using Domain.Entities.Clinica;
using Infrastructure.Persistence.Dapper;

namespace Infrastructure.Persistence.Repositories.Clinica;

public class MedicoRepository : IMedicoRepository
{
    private readonly DapperContext _context;

    public MedicoRepository(DapperContext context)
    {
        _context = context;
    }

    public async Task<int> CreateAsync(Medico medico)
    {
        const string sql = @"
            INSERT INTO medicos (
                usuario_id, cedula_profesional, especialidad, subespecialidad,
                consultorio, telefono_consultorio, horario_atencion, observaciones, activo
            )
            VALUES (
                @UsuarioId, @CedulaProfesional, @Especialidad, @Subespecialidad,
                @Consultorio, @TelefonoConsultorio, @HorarioAtencion, @Observaciones, @Activo
            );
            SELECT LAST_INSERT_ID();";

        using var connection = _context.CreateConnection();
        return await connection.ExecuteScalarAsync<int>(sql, medico);
    }

    public async Task UpdateAsync(Medico medico)
    {
        const string sql = @"
            UPDATE medicos
            SET cedula_profesional = @CedulaProfesional,
                especialidad = @Especialidad,
                subespecialidad = @Subespecialidad,
                consultorio = @Consultorio,
                telefono_consultorio = @TelefonoConsultorio,
                horario_atencion = @HorarioAtencion,
                observaciones = @Observaciones,
                activo = @Activo
            WHERE id = @Id";

        using var connection = _context.CreateConnection();
        await connection.ExecuteAsync(sql, medico);
    }

    public async Task DeleteAsync(int id)
    {
        const string sql = "DELETE FROM medicos WHERE id = @Id";

        using var connection = _context.CreateConnection();
        await connection.ExecuteAsync(sql, new { Id = id });
    }

    public async Task<Medico?> GetByIdAsync(int id)
    {
        const string sql = @"
            SELECT id, usuario_id, cedula_profesional, especialidad, subespecialidad,
                   consultorio, telefono_consultorio, horario_atencion, observaciones,
                   activo, fecha_creacion
            FROM medicos
            WHERE id = @Id";

        using var connection = _context.CreateConnection();
        var row = await connection.QueryFirstOrDefaultAsync<dynamic>(sql, new { Id = id });

        if (row == null) return null;

        return new Medico(
            (int)row.id,
            (int)row.usuario_id,
            (string)row.cedula_profesional,
            (string)row.especialidad,
            row.subespecialidad as string,
            row.consultorio as string,
            row.telefono_consultorio as string,
            row.horario_atencion as string,
            row.observaciones as string,
            (bool)row.activo,
            (DateTime)row.fecha_creacion
        );
    }

    public async Task<Medico?> GetByUsuarioIdAsync(int usuarioId)
    {
        const string sql = @"
            SELECT id, usuario_id, cedula_profesional, especialidad, subespecialidad,
                   consultorio, telefono_consultorio, horario_atencion, observaciones,
                   activo, fecha_creacion
            FROM medicos
            WHERE usuario_id = @UsuarioId";

        using var connection = _context.CreateConnection();
        var row = await connection.QueryFirstOrDefaultAsync<dynamic>(sql, new { UsuarioId = usuarioId });

        if (row == null) return null;

        return new Medico(
            (int)row.id,
            (int)row.usuario_id,
            (string)row.cedula_profesional,
            (string)row.especialidad,
            row.subespecialidad as string,
            row.consultorio as string,
            row.telefono_consultorio as string,
            row.horario_atencion as string,
            row.observaciones as string,
            (bool)row.activo,
            (DateTime)row.fecha_creacion
        );
    }

    public async Task<IEnumerable<Medico>> GetAllAsync(bool? soloActivos = null)
    {
        var sql = @"
            SELECT id, usuario_id, cedula_profesional, especialidad, subespecialidad,
                   consultorio, telefono_consultorio, horario_atencion, observaciones,
                   activo, fecha_creacion
            FROM medicos";

        // Corrección: verificar si tiene valor Y si es true
        if (soloActivos.HasValue && soloActivos.Value)
            sql += " WHERE activo = 1";
        else if (soloActivos.HasValue && !soloActivos.Value)
            sql += " WHERE activo = 0";
        // Si soloActivos es null, no aplica filtro

        sql += " ORDER BY especialidad, cedula_profesional";

        using var connection = _context.CreateConnection();
        var rows = await connection.QueryAsync<dynamic>(sql);

        return rows.Select(row => new Medico(
            (int)row.id,
            (int)row.usuario_id,
            (string)row.cedula_profesional,
            (string)row.especialidad,
            row.subespecialidad as string,
            row.consultorio as string,
            row.telefono_consultorio as string,
            row.horario_atencion as string,
            row.observaciones as string,
            (bool)row.activo,
            (DateTime)row.fecha_creacion
        ));
    }

    public async Task<IEnumerable<Medico>> GetByEspecialidadAsync(string especialidad)
    {
        const string sql = @"
            SELECT id, usuario_id, cedula_profesional, especialidad, subespecialidad,
                   consultorio, telefono_consultorio, horario_atencion, observaciones,
                   activo, fecha_creacion
            FROM medicos
            WHERE especialidad = @Especialidad AND activo = 1
            ORDER BY cedula_profesional";

        using var connection = _context.CreateConnection();
        var rows = await connection.QueryAsync<dynamic>(sql, new { Especialidad = especialidad });

        return rows.Select(row => new Medico(
            (int)row.id,
            (int)row.usuario_id,
            (string)row.cedula_profesional,
            (string)row.especialidad,
            row.subespecialidad as string,
            row.consultorio as string,
            row.telefono_consultorio as string,
            row.horario_atencion as string,
            row.observaciones as string,
            (bool)row.activo,
            (DateTime)row.fecha_creacion
        ));
    }

    public async Task<bool> ExistsAsync(int id)
    {
        const string sql = "SELECT COUNT(1) FROM medicos WHERE id = @Id";

        using var connection = _context.CreateConnection();
        return await connection.ExecuteScalarAsync<bool>(sql, new { Id = id });
    }

    public async Task<bool> ExistsByUsuarioIdAsync(int usuarioId)
    {
        const string sql = "SELECT COUNT(1) FROM medicos WHERE usuario_id = @UsuarioId";

        using var connection = _context.CreateConnection();
        return await connection.ExecuteScalarAsync<bool>(sql, new { UsuarioId = usuarioId });
    }

    public async Task<bool> ExistsByCedulaAsync(string cedula, int? excludeId = null)
    {
        var sql = "SELECT COUNT(1) FROM medicos WHERE cedula_profesional = @Cedula";
        
        if (excludeId.HasValue)
            sql += " AND id != @ExcludeId";

        using var connection = _context.CreateConnection();
        return await connection.ExecuteScalarAsync<bool>(sql, new { Cedula = cedula, ExcludeId = excludeId });
    }
}