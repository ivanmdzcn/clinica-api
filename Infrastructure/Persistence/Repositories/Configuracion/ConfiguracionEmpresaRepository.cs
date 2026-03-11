using Application.Interfaces.Repositories.Configuracion;
using Dapper;
using Infrastructure.Persistence.Dapper;
using ConfigEmpresa = Domain.Entities.Configuracion.ConfiguracionEmpresa;

namespace Infrastructure.Persistence.Repositories.Configuracion;

public class ConfiguracionEmpresaRepository : IConfiguracionEmpresaRepository
{
    private readonly DapperContext _context;

    public ConfiguracionEmpresaRepository(DapperContext context)
    {
        _context = context;
    }

    public async Task<int> CreateAsync(ConfigEmpresa configuracion)
    {
        const string sql = @"
            INSERT INTO configuracion_empresa (
                razon_social, nombre_comercial, numero_identificacion_fiscal,
                direccion, ciudad, estado_provincia, codigo_postal, pais,
                telefono_principal, telefono_secundario, email_principal, email_secundario, sitio_web,
                codigo_moneda, simbolo_moneda, nombre_moneda, posicion_simbolo,
                separador_miles, separador_decimales, decimales,
                logo_url, color_primario, pie_pagina_documentos, mensaje_agradecimiento
            )
            VALUES (
                @RazonSocial, @NombreComercial, @NumeroIdentificacionFiscal,
                @Direccion, @Ciudad, @EstadoProvincia, @CodigoPostal, @Pais,
                @TelefonoPrincipal, @TelefonoSecundario, @EmailPrincipal, @EmailSecundario, @SitioWeb,
                @CodigoMoneda, @SimboloMoneda, @NombreMoneda, @PosicionSimbolo,
                @SeparadorMiles, @SeparadorDecimales, @Decimales,
                @LogoUrl, @ColorPrimario, @PiePaginaDocumentos, @MensajeAgradecimiento
            );
            SELECT LAST_INSERT_ID();";

        using var connection = _context.CreateConnection();
        return await connection.ExecuteScalarAsync<int>(sql, configuracion);
    }

    public async Task UpdateAsync(ConfigEmpresa configuracion)
    {
        const string sql = @"
            UPDATE configuracion_empresa
            SET razon_social = @RazonSocial,
                nombre_comercial = @NombreComercial,
                numero_identificacion_fiscal = @NumeroIdentificacionFiscal,
                direccion = @Direccion,
                ciudad = @Ciudad,
                estado_provincia = @EstadoProvincia,
                codigo_postal = @CodigoPostal,
                pais = @Pais,
                telefono_principal = @TelefonoPrincipal,
                telefono_secundario = @TelefonoSecundario,
                email_principal = @EmailPrincipal,
                email_secundario = @EmailSecundario,
                sitio_web = @SitioWeb,
                codigo_moneda = @CodigoMoneda,
                simbolo_moneda = @SimboloMoneda,
                nombre_moneda = @NombreMoneda,
                posicion_simbolo = @PosicionSimbolo,
                separador_miles = @SeparadorMiles,
                separador_decimales = @SeparadorDecimales,
                decimales = @Decimales,
                logo_url = @LogoUrl,
                color_primario = @ColorPrimario,
                pie_pagina_documentos = @PiePaginaDocumentos,
                mensaje_agradecimiento = @MensajeAgradecimiento,
                actualizado_por = @ActualizadoPor
            WHERE id = @Id";

        using var connection = _context.CreateConnection();
        await connection.ExecuteAsync(sql, configuracion);
    }

    public async Task<ConfigEmpresa?> GetConfiguracionAsync()
    {
        const string sql = @"
            SELECT * FROM configuracion_empresa LIMIT 1";

        using var connection = _context.CreateConnection();
        var row = await connection.QueryFirstOrDefaultAsync<dynamic>(sql);

        if (row == null) return null;

        return new ConfigEmpresa(
            (int)row.id,
            (string)row.razon_social,
            row.nombre_comercial as string,
            row.numero_identificacion_fiscal as string,
            (string)row.direccion,
            row.ciudad as string,
            row.estado_provincia as string,
            row.codigo_postal as string,
            (string)row.pais,
            row.telefono_principal as string,
            row.telefono_secundario as string,
            (string)row.email_principal,
            row.email_secundario as string,
            row.sitio_web as string,
            (string)row.codigo_moneda,
            (string)row.simbolo_moneda,
            row.nombre_moneda as string,
            (string)row.posicion_simbolo,
            (string)row.separador_miles,
            (string)row.separador_decimales,
            (int)row.decimales,
            row.logo_url as string,
            (string)row.color_primario,
            row.pie_pagina_documentos as string,
            row.mensaje_agradecimiento as string,
            (DateTime)row.fecha_creacion,
            (DateTime)row.fecha_actualizacion,
            row.actualizado_por as int?
        );
    }
}