using Application.Interfaces.Repositories.Clinica;
using Dapper;
using Domain.Entities.Clinica;
using Infrastructure.Persistence.Dapper;

namespace Infrastructure.Persistence.Repositories.Clinica;

public class SignoVitalRepository : ISignoVitalRepository
{
    private readonly DapperContext _context;

    public SignoVitalRepository(DapperContext context)
    {
        _context = context;
    }

    public async Task<int> CreateAsync(SignoVital signoVital)
    {
        const string sql = @"
            INSERT INTO signos_vitales (
                consulta_id, enfermera_id, presion_sistolica, presion_diastolica,
                temperatura, frecuencia_cardiaca, frecuencia_respiratoria, saturacion_oxigeno,
                peso, altura, glucosa_capilar, nivel_dolor, observaciones, fecha_registro
            )
            VALUES (
                @ConsultaId, @EnfermeraId, @PresionSistolica, @PresionDiastolica,
                @Temperatura, @FrecuenciaCardiaca, @FrecuenciaRespiratoria, @SaturacionOxigeno,
                @Peso, @Altura, @GlucosaCapilar, @NivelDolor, @Observaciones, @FechaRegistro
            );
            SELECT LAST_INSERT_ID();";

        using var connection = _context.CreateConnection();
        return await connection.ExecuteScalarAsync<int>(sql, signoVital);
    }

    public async Task UpdateAsync(SignoVital signoVital)
    {
        const string sql = @"
            UPDATE signos_vitales
            SET presion_sistolica = @PresionSistolica,
                presion_diastolica = @PresionDiastolica,
                temperatura = @Temperatura,
                frecuencia_cardiaca = @FrecuenciaCardiaca,
                frecuencia_respiratoria = @FrecuenciaRespiratoria,
                saturacion_oxigeno = @SaturacionOxigeno,
                peso = @Peso,
                altura = @Altura,
                glucosa_capilar = @GlucosaCapilar,
                nivel_dolor = @NivelDolor,
                observaciones = @Observaciones
            WHERE id = @Id";

        using var connection = _context.CreateConnection();
        await connection.ExecuteAsync(sql, signoVital);
    }

    public async Task DeleteAsync(int id)
    {
        const string sql = "DELETE FROM signos_vitales WHERE id = @Id";

        using var connection = _context.CreateConnection();
        await connection.ExecuteAsync(sql, new { Id = id });
    }

    public async Task<SignoVital?> GetByIdAsync(int id)
    {
        const string sql = @"
            SELECT id, consulta_id, enfermera_id, presion_sistolica, presion_diastolica,
                   temperatura, frecuencia_cardiaca, frecuencia_respiratoria, saturacion_oxigeno,
                   peso, altura, glucosa_capilar, nivel_dolor, observaciones, fecha_registro
            FROM signos_vitales
            WHERE id = @Id";

        using var connection = _context.CreateConnection();
        var row = await connection.QueryFirstOrDefaultAsync<dynamic>(sql, new { Id = id });

        if (row == null) return null;

        return MapToEntity(row);
    }

    public async Task<SignoVital?> GetByConsultaIdAsync(int consultaId)
    {
        const string sql = @"
            SELECT id, consulta_id, enfermera_id, presion_sistolica, presion_diastolica,
                   temperatura, frecuencia_cardiaca, frecuencia_respiratoria, saturacion_oxigeno,
                   peso, altura, glucosa_capilar, nivel_dolor, observaciones, fecha_registro
            FROM signos_vitales
            WHERE consulta_id = @ConsultaId";

        using var connection = _context.CreateConnection();
        var row = await connection.QueryFirstOrDefaultAsync<dynamic>(sql, new { ConsultaId = consultaId });

        if (row == null) return null;

        return MapToEntity(row);
    }

    public async Task<bool> ExistsAsync(int id)
    {
        const string sql = "SELECT COUNT(1) FROM signos_vitales WHERE id = @Id";

        using var connection = _context.CreateConnection();
        return await connection.ExecuteScalarAsync<bool>(sql, new { Id = id });
    }

    private static SignoVital MapToEntity(dynamic row)
    {
        return new SignoVital(
            (int)row.id,
            (int)row.consulta_id,
            (int)row.enfermera_id,
            row.presion_sistolica as int?,
            row.presion_diastolica as int?,
            row.temperatura as decimal?,
            row.frecuencia_cardiaca as int?,
            row.frecuencia_respiratoria as int?,
            row.saturacion_oxigeno as int?,
            row.peso as decimal?,
            row.altura as decimal?,
            row.glucosa_capilar as decimal?,
            row.nivel_dolor as int?,
            row.observaciones as string,
            (DateTime)row.fecha_registro
        );
    }
}