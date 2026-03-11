using Application.Interfaces.Repositories.Clinica;
using Dapper;
using Domain.Entities.Clinica;
using Infrastructure.Persistence.Dapper;

namespace Infrastructure.Persistence.Repositories.Clinica;

public class ConsultaRepository : IConsultaRepository
{
    private readonly DapperContext _context;

    public ConsultaRepository(DapperContext context)
    {
        _context = context;
    }

    public async Task<int> CreateAsync(Consulta consulta)
    {
        const string sql = @"
            INSERT INTO consultas (
                paciente_id, medico_id, tipo_consulta, motivo_consulta,
                observaciones, proxima_cita,
                fecha_consulta, fecha_actualizacion, estado
            )
            VALUES (
                @PacienteId, @MedicoId, @TipoConsulta, @MotivoConsulta,
                @Observaciones, @ProximaCita,
                @FechaConsulta, @FechaActualizacion, @Estado
            );
            SELECT LAST_INSERT_ID();";

        using var connection = _context.CreateConnection();
        return await connection.ExecuteScalarAsync<int>(sql, consulta);
    }

    public async Task UpdateAsync(Consulta consulta)
    {
        const string sql = @"
            UPDATE consultas
            SET tipo_consulta = @TipoConsulta,
                motivo_consulta = @MotivoConsulta,
                observaciones = @Observaciones,
                proxima_cita = @ProximaCita,
                fecha_actualizacion = @FechaActualizacion,
                estado = @Estado
            WHERE id = @Id";

        using var connection = _context.CreateConnection();
        await connection.ExecuteAsync(sql, consulta);
    }

    public async Task<Consulta?> GetByIdAsync(int id)
    {
        const string sql = @"
            SELECT id, paciente_id, medico_id, tipo_consulta, motivo_consulta,
                   observaciones, proxima_cita,
                   fecha_consulta, fecha_actualizacion, estado
            FROM consultas
            WHERE id = @Id";

        using var connection = _context.CreateConnection();
        var row = await connection.QueryFirstOrDefaultAsync<dynamic>(sql, new { Id = id });

        if (row == null) return null;

        return new Consulta(
            (int)row.id,
            (int)row.paciente_id,
            (int)row.medico_id,
            row.tipo_consulta as string,
            (string)row.motivo_consulta,
            row.observaciones as string,
            row.proxima_cita as DateTime?,
            (DateTime)row.fecha_consulta,
            (DateTime)row.fecha_actualizacion,
            (string)row.estado
        );
    }

    public async Task<IEnumerable<Consulta>> GetByPacienteIdAsync(int pacienteId)
    {
        const string sql = @"
            SELECT id, paciente_id, medico_id, tipo_consulta, motivo_consulta,
                   observaciones, proxima_cita,
                   fecha_consulta, fecha_actualizacion, estado
            FROM consultas
            WHERE paciente_id = @PacienteId
            ORDER BY fecha_consulta DESC";

        using var connection = _context.CreateConnection();
        var rows = await connection.QueryAsync<dynamic>(sql, new { PacienteId = pacienteId });

        return rows.Select(row => new Consulta(
            (int)row.id,
            (int)row.paciente_id,
            (int)row.medico_id,
            row.tipo_consulta as string,
            (string)row.motivo_consulta,
            row.observaciones as string,
            row.proxima_cita as DateTime?,
            (DateTime)row.fecha_consulta,
            (DateTime)row.fecha_actualizacion,
            (string)row.estado
        ));
    }

    public async Task<IEnumerable<Consulta>> GetByMedicoIdAsync(int medicoId)
    {
        const string sql = @"
            SELECT id, paciente_id, medico_id, tipo_consulta, motivo_consulta,
                   observaciones, proxima_cita,
                   fecha_consulta, fecha_actualizacion, estado
            FROM consultas
            WHERE medico_id = @MedicoId
            ORDER BY fecha_consulta DESC";

        using var connection = _context.CreateConnection();
        var rows = await connection.QueryAsync<dynamic>(sql, new { MedicoId = medicoId });

        return rows.Select(row => new Consulta(
            (int)row.id,
            (int)row.paciente_id,
            (int)row.medico_id,
            row.tipo_consulta as string,
            (string)row.motivo_consulta,
            row.observaciones as string,
            row.proxima_cita as DateTime?,
            (DateTime)row.fecha_consulta,
            (DateTime)row.fecha_actualizacion,
            (string)row.estado
        ));
    }

    public async Task<IEnumerable<Consulta>> GetByEstadoAsync(string estado)
    {
        const string sql = @"
            SELECT id, paciente_id, medico_id, tipo_consulta, motivo_consulta,
                   observaciones, proxima_cita,
                   fecha_consulta, fecha_actualizacion, estado
            FROM consultas
            WHERE estado = @Estado
            ORDER BY fecha_consulta DESC";

        using var connection = _context.CreateConnection();
        var rows = await connection.QueryAsync<dynamic>(sql, new { Estado = estado });

        return rows.Select(row => new Consulta(
            (int)row.id,
            (int)row.paciente_id,
            (int)row.medico_id,
            row.tipo_consulta as string,
            (string)row.motivo_consulta,
            row.observaciones as string,
            row.proxima_cita as DateTime?,
            (DateTime)row.fecha_consulta,
            (DateTime)row.fecha_actualizacion,
            (string)row.estado
        ));
    }

    public async Task<bool> ExistsAsync(int id)
    {
        const string sql = "SELECT COUNT(1) FROM consultas WHERE id = @Id";

        using var connection = _context.CreateConnection();
        return await connection.ExecuteScalarAsync<bool>(sql, new { Id = id });
    }
}