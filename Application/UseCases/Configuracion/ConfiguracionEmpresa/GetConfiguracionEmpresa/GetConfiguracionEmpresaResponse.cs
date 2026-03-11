namespace Application.UseCases.Configuracion.ConfiguracionEmpresa.GetConfiguracionEmpresa;

public class GetConfiguracionEmpresaResponse
{
    public int Id { get; init; }
    public string RazonSocial { get; init; } = string.Empty;
    public string? NombreComercial { get; init; }
    public string? NumeroIdentificacionFiscal { get; init; }
    public string Direccion { get; init; } = string.Empty;
    public string? Ciudad { get; init; }
    public string? EstadoProvincia { get; init; }
    public string? CodigoPostal { get; init; }
    public string Pais { get; init; } = string.Empty;
    public string? TelefonoPrincipal { get; init; }
    public string? TelefonoSecundario { get; init; }
    public string EmailPrincipal { get; init; } = string.Empty;
    public string? EmailSecundario { get; init; }
    public string? SitioWeb { get; init; }
    public string CodigoMoneda { get; init; } = string.Empty;
    public string SimboloMoneda { get; init; } = string.Empty;
    public string? NombreMoneda { get; init; }
    public string PosicionSimbolo { get; init; } = string.Empty;
    public string SeparadorMiles { get; init; } = string.Empty;
    public string SeparadorDecimales { get; init; } = string.Empty;
    public int Decimales { get; init; }
    public string? LogoUrl { get; init; }
    public string ColorPrimario { get; init; } = string.Empty;
    public string? PiePaginaDocumentos { get; init; }
    public string? MensajeAgradecimiento { get; init; }
    public DateTime FechaCreacion { get; init; }
    public DateTime FechaActualizacion { get; init; }
}