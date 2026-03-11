using Application.Interfaces.Repositories;
using Domain.Entities;
using Dapper;
using Infrastructure.Persistence.Dapper;

namespace Infrastructure.Persistence.Repositories;

public class PacienteRepository : IPacienteRepository
{
    private readonly DapperContext _context;

    public PacienteRepository(DapperContext context)
    {
        _context = context;
    }

    public async Task<Paciente?> GetByIdAsync(int id)
    {
        const string sql = @"
            SELECT 
                id AS Id,
                dpi AS Dpi,
                nombres AS Nombres,
                apellidos AS Apellidos,
                nombre_completo AS NombreCompleto,
                fecha_nacimiento AS FechaNacimiento,
                sexo AS Sexo,
                telefono AS Telefono,
                direccion AS Direccion,
                email AS Email,
                fecha_registro AS FechaRegistro,
                creado_por AS CreadoPor
            FROM pacientes
            WHERE id = @Id
            LIMIT 1;
        ";

        using var connection = _context.CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<Paciente>(sql, new { Id = id });
    }

    public async Task<Paciente?> GetByDpiAsync(string dpi)
    {
        const string sql = @"
            SELECT 
                id AS Id,
                dpi AS Dpi,
                nombres AS Nombres,
                apellidos AS Apellidos,
                nombre_completo AS NombreCompleto,
                fecha_nacimiento AS FechaNacimiento,
                sexo AS Sexo,
                telefono AS Telefono,
                direccion AS Direccion,
                email AS Email,
                fecha_registro AS FechaRegistro,
                creado_por AS CreadoPor
            FROM pacientes
            WHERE dpi = @Dpi
            LIMIT 1;
        ";

        using var connection = _context.CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<Paciente>(sql, new { Dpi = dpi });
    }

    public async Task<IEnumerable<Paciente>> GetAllAsync()
    {
        const string sql = @"
            SELECT 
                id AS Id,
                dpi AS Dpi,
                nombres AS Nombres,
                apellidos AS Apellidos,
                nombre_completo AS NombreCompleto,
                fecha_nacimiento AS FechaNacimiento,
                sexo AS Sexo,
                telefono AS Telefono,
                direccion AS Direccion,
                email AS Email,
                fecha_registro AS FechaRegistro,
                creado_por AS CreadoPor
            FROM pacientes
            ORDER BY fecha_registro DESC;
        ";

        using var connection = _context.CreateConnection();
        return await connection.QueryAsync<Paciente>(sql);
    }

    public async Task<IEnumerable<Paciente>> SearchAsync(string searchTerm)
    {
        const string sql = @"
            SELECT 
                id AS Id,
                dpi AS Dpi,
                nombres AS Nombres,
                apellidos AS Apellidos,
                nombre_completo AS NombreCompleto,
                fecha_nacimiento AS FechaNacimiento,
                sexo AS Sexo,
                telefono AS Telefono,
                direccion AS Direccion,
                email AS Email,
                fecha_registro AS FechaRegistro,
                creado_por AS CreadoPor
            FROM pacientes
            WHERE nombre_completo LIKE @SearchTerm
               OR dpi LIKE @SearchTerm
               OR telefono LIKE @SearchTerm
            ORDER BY nombre_completo;
        ";

        using var connection = _context.CreateConnection();
        return await connection.QueryAsync<Paciente>(sql, new { SearchTerm = $"%{searchTerm}%" });
    }

    public async Task<int> CreateAsync(Paciente paciente)
    {
        const string sql = @"
            INSERT INTO pacientes (dpi, nombres, apellidos, nombre_completo, fecha_nacimiento, sexo, telefono, direccion, email, fecha_registro, creado_por)
            VALUES (@Dpi, @Nombres, @Apellidos, @NombreCompleto, @FechaNacimiento, @Sexo, @Telefono, @Direccion, @Email, @FechaRegistro, @CreadoPor);
            SELECT LAST_INSERT_ID();
        ";

        using var connection = _context.CreateConnection();
        return await connection.ExecuteScalarAsync<int>(sql, paciente);
    }

    public async Task UpdateAsync(Paciente paciente)
    {
        const string sql = @"
            UPDATE pacientes
            SET 
                dpi = @Dpi,
                nombres = @Nombres,
                apellidos = @Apellidos,
                nombre_completo = @NombreCompleto,
                fecha_nacimiento = @FechaNacimiento,
                sexo = @Sexo,
                telefono = @Telefono,
                direccion = @Direccion,
                email = @Email
            WHERE id = @Id;
        ";

        using var connection = _context.CreateConnection();
        await connection.ExecuteAsync(sql, paciente);
    }

    public async Task DeleteAsync(int id)
    {
        const string sql = "DELETE FROM pacientes WHERE id = @Id;";

        using var connection = _context.CreateConnection();
        await connection.ExecuteAsync(sql, new { Id = id });
    }

    public async Task<bool> ExistsDpiAsync(string dpi, int? excludeId = null)
    {
        const string sql = @"
            SELECT COUNT(1)
            FROM pacientes
            WHERE dpi = @Dpi
            AND (@ExcludeId IS NULL OR id != @ExcludeId);
        ";

        using var connection = _context.CreateConnection();
        var count = await connection.ExecuteScalarAsync<int>(sql, new { Dpi = dpi, ExcludeId = excludeId });
        return count > 0;
    }

    public async Task<bool> ExistsEmailAsync(string email, int? excludeId = null)
    {
        const string sql = @"
            SELECT COUNT(1)
            FROM pacientes
            WHERE email = @Email
            AND (@ExcludeId IS NULL OR id != @ExcludeId);
        ";

        using var connection = _context.CreateConnection();
        var count = await connection.ExecuteScalarAsync<int>(sql, new { Email = email, ExcludeId = excludeId });
        return count > 0;
    }
}