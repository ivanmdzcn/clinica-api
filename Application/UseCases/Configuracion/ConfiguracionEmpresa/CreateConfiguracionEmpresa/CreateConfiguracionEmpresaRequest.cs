namespace Application.UseCases.Configuracion.ConfiguracionEmpresa.CreateConfiguracionEmpresa;

public class CreateConfiguracionEmpresaRequest
{
    // Datos básicos
    public string RazonSocial { get; init; } = string.Empty;
    public string? NombreComercial { get; init; }
    public string? NumeroIdentificacionFiscal { get; init; }
    
    // Dirección
    public string Direccion { get; init; } = string.Empty;
    public string? Ciudad { get; init; }
    public string? EstadoProvincia { get; init; }
    public string? CodigoPostal { get; init; }
    public string Pais { get; init; } = string.Empty;
    
    // Contacto
    public string? TelefonoPrincipal { get; init; }
    public string? TelefonoSecundario { get; init; }
    public string EmailPrincipal { get; init; } = string.Empty;
    public string? EmailSecundario { get; init; }
    public string? SitioWeb { get; init; }
    
    // Configuración de moneda
    public string CodigoMoneda { get; init; } = "GTQ";
    public string SimboloMoneda { get; init; } = "Q";
    public string? NombreMoneda { get; init; } = "Quetzal";
    public string PosicionSimbolo { get; init; } = "antes";
    public string SeparadorMiles { get; init; } = ",";
    public string SeparadorDecimales { get; init; } = ".";
    public int Decimales { get; init; } = 2;
    
    // Logo y marca
    public string? LogoUrl { get; init; }
    public string ColorPrimario { get; init; } = "#3B82F6";
    
    // Textos
    public string? PiePaginaDocumentos { get; init; }
    public string? MensajeAgradecimiento { get; init; }
}