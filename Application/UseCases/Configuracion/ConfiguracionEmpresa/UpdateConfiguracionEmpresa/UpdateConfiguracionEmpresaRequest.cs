namespace Application.UseCases.Configuracion.ConfiguracionEmpresa.UpdateConfiguracionEmpresa;

public class UpdateConfiguracionEmpresaRequest
{
    // Mismo estructura que Create pero todos los campos de moneda opcionales
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
    public string? CodigoMoneda { get; init; }
    public string? SimboloMoneda { get; init; }
    public string? NombreMoneda { get; init; }
    public string? PosicionSimbolo { get; init; }
    public string? SeparadorMiles { get; init; }
    public string? SeparadorDecimales { get; init; }
    public int? Decimales { get; init; }
    public string? LogoUrl { get; init; }
    public string? ColorPrimario { get; init; }
    public string? PiePaginaDocumentos { get; init; }
    public string? MensajeAgradecimiento { get; init; }
}