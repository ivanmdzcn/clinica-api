using Application.Interfaces.Repositories.Dashboard;
using Application.UseCases.Dashboard.Estadisticas.Shared;
using Dapper;
using Infrastructure.Persistence.Dapper;

namespace Infrastructure.Persistence.Repositories.Dashboard;

public class EstadisticasRepository : IEstadisticasRepository
{
    private readonly DapperContext _context;

    public EstadisticasRepository(DapperContext context)
    {
        _context = context;
    }

    public async Task<ResumenGeneralDto> ObtenerResumenGeneralAsync()
    {
        const string sql = @"
            SELECT 
                (SELECT COUNT(*) FROM usuarios WHERE activo = 1) AS TotalUsuarios,
                (SELECT COUNT(*) FROM pacientes) AS TotalPacientes,
                (SELECT COUNT(*) FROM medicos WHERE activo = 1) AS TotalMedicosActivos,
                (SELECT COUNT(*) FROM consultas 
                 WHERE YEAR(fecha_consulta) = YEAR(CURDATE()) 
                 AND MONTH(fecha_consulta) = MONTH(CURDATE())) AS ConsultasDelMes,
                (SELECT COUNT(*) FROM consultas 
                 WHERE DATE(fecha_consulta) = CURDATE()) AS ConsultasHoy;";

        using var connection = _context.CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<ResumenGeneralDto>(sql) 
               ?? new ResumenGeneralDto();
    }

    public async Task<IEnumerable<ConsultaPorDiaDto>> ObtenerConsultasPorDiaAsync(DateTime fechaInicio, DateTime fechaFin)
    {
        const string sql = @"
            SELECT 
                DATE(fecha_consulta) AS Fecha,
                COUNT(*) AS CantidadConsultas
            FROM consultas
            WHERE fecha_consulta BETWEEN @FechaInicio AND @FechaFin
            GROUP BY DATE(fecha_consulta)
            ORDER BY Fecha;";

        using var connection = _context.CreateConnection();
        var result = await connection.QueryAsync<ConsultaPorDiaDto>(sql, new 
        { 
            FechaInicio = fechaInicio, 
            FechaFin = fechaFin 
        });

        return result ?? Enumerable.Empty<ConsultaPorDiaDto>();
    }

    public async Task<IEnumerable<ConsultaPorMedicoDto>> ObtenerConsultasPorMedicoAsync(DateTime fechaInicio, DateTime fechaFin)
    {
        const string sql = @"
            SELECT 
                c.medico_id AS MedicoId,
                u.nombre_completo AS NombreMedico,
                COALESCE(m.especialidad, 'Sin especialidad') AS Especialidad,
                COUNT(*) AS CantidadConsultas
            FROM consultas c
            INNER JOIN usuarios u ON c.medico_id = u.id
            LEFT JOIN medicos m ON u.id = m.usuario_id
            WHERE c.fecha_consulta BETWEEN @FechaInicio AND @FechaFin
            GROUP BY c.medico_id, u.nombre_completo, m.especialidad
            ORDER BY CantidadConsultas DESC;";

        using var connection = _context.CreateConnection();
        var result = await connection.QueryAsync<ConsultaPorMedicoDto>(sql, new 
        { 
            FechaInicio = fechaInicio, 
            FechaFin = fechaFin 
        });

        return result ?? Enumerable.Empty<ConsultaPorMedicoDto>();
    }

    public async Task<IEnumerable<PacientesPorMesDto>> ObtenerPacientesPorMesAsync(int anio)
    {
        const string sql = @"
            SELECT 
                @Anio AS Anio,
                mes_numero AS Mes,
                CASE mes_numero
                    WHEN 1 THEN 'Enero'
                    WHEN 2 THEN 'Febrero'
                    WHEN 3 THEN 'Marzo'
                    WHEN 4 THEN 'Abril'
                    WHEN 5 THEN 'Mayo'
                    WHEN 6 THEN 'Junio'
                    WHEN 7 THEN 'Julio'
                    WHEN 8 THEN 'Agosto'
                    WHEN 9 THEN 'Septiembre'
                    WHEN 10 THEN 'Octubre'
                    WHEN 11 THEN 'Noviembre'
                    WHEN 12 THEN 'Diciembre'
                END AS NombreMes,
                COUNT(*) AS CantidadPacientes
            FROM (
                SELECT MONTH(fecha_registro) AS mes_numero
                FROM pacientes
                WHERE YEAR(fecha_registro) = @Anio
            ) AS meses_con_registros
            GROUP BY mes_numero
            ORDER BY mes_numero;";

        using var connection = _context.CreateConnection();
        var result = await connection.QueryAsync<PacientesPorMesDto>(sql, new { Anio = anio });

        return result ?? Enumerable.Empty<PacientesPorMesDto>();
    }

    public async Task<IEnumerable<DistribucionEstadoDto>> ObtenerDistribucionEstadosAsync()
    {
        const string sql = @"
            SELECT 
                estado AS Estado,
                COUNT(*) AS Cantidad,
                ROUND((COUNT(*) * 100.0 / (SELECT COUNT(*) FROM consultas)), 2) AS Porcentaje
            FROM consultas
            GROUP BY estado
            ORDER BY Cantidad DESC;";

        using var connection = _context.CreateConnection();
        var result = await connection.QueryAsync<DistribucionEstadoDto>(sql);

        return result ?? Enumerable.Empty<DistribucionEstadoDto>();
    }
}