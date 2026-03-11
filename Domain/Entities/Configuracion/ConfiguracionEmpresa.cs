namespace Domain.Entities.Configuracion;

public class ConfiguracionEmpresa
{
    public int Id { get; private set; }
    
    // Datos básicos
    public string RazonSocial { get; private set; }
    public string? NombreComercial { get; private set; }
    public string? NumeroIdentificacionFiscal { get; private set; }
    
    // Dirección
    public string Direccion { get; private set; }
    public string? Ciudad { get; private set; }
    public string? EstadoProvincia { get; private set; }
    public string? CodigoPostal { get; private set; }
    public string Pais { get; private set; }
    
    // Contacto
    public string? TelefonoPrincipal { get; private set; }
    public string? TelefonoSecundario { get; private set; }
    public string EmailPrincipal { get; private set; }
    public string? EmailSecundario { get; private set; }
    public string? SitioWeb { get; private set; }
    
    // Configuración de moneda
    public string CodigoMoneda { get; private set; }
    public string SimboloMoneda { get; private set; }
    public string? NombreMoneda { get; private set; }
    public string PosicionSimbolo { get; private set; } // 'antes' o 'despues'
    public string SeparadorMiles { get; private set; }
    public string SeparadorDecimales { get; private set; }
    public int Decimales { get; private set; }
    
    // Logo y marca
    public string? LogoUrl { get; private set; }
    public string ColorPrimario { get; private set; }
    
    // Textos para documentos
    public string? PiePaginaDocumentos { get; private set; }
    public string? MensajeAgradecimiento { get; private set; }
    
    // Auditoría
    public DateTime FechaCreacion { get; private set; }
    public DateTime FechaActualizacion { get; private set; }
    public int? ActualizadoPor { get; private set; }

    // Constructor para crear nueva configuración
    public ConfiguracionEmpresa(
        string razonSocial,
        string direccion,
        string pais,
        string emailPrincipal,
        string? nombreComercial = null,
        string? numeroIdentificacionFiscal = null,
        string? ciudad = null,
        string? estadoProvincia = null,
        string? codigoPostal = null,
        string? telefonoPrincipal = null,
        string? telefonoSecundario = null,
        string? emailSecundario = null,
        string? sitioWeb = null,
        string codigoMoneda = "GTQ",
        string simboloMoneda = "Q",
        string? nombreMoneda = "Quetzal",
        string posicionSimbolo = "antes",
        string separadorMiles = ",",
        string separadorDecimales = ".",
        int decimales = 2,
        string? logoUrl = null,
        string colorPrimario = "#3B82F6",
        string? piePaginaDocumentos = null,
        string? mensajeAgradecimiento = null)
    {
        RazonSocial = razonSocial;
        NombreComercial = nombreComercial;
        NumeroIdentificacionFiscal = numeroIdentificacionFiscal;
        Direccion = direccion;
        Ciudad = ciudad;
        EstadoProvincia = estadoProvincia;
        CodigoPostal = codigoPostal;
        Pais = pais;
        TelefonoPrincipal = telefonoPrincipal;
        TelefonoSecundario = telefonoSecundario;
        EmailPrincipal = emailPrincipal;
        EmailSecundario = emailSecundario;
        SitioWeb = sitioWeb;
        CodigoMoneda = codigoMoneda;
        SimboloMoneda = simboloMoneda;
        NombreMoneda = nombreMoneda;
        PosicionSimbolo = ValidarPosicionSimbolo(posicionSimbolo);
        SeparadorMiles = separadorMiles;
        SeparadorDecimales = separadorDecimales;
        Decimales = decimales;
        LogoUrl = logoUrl;
        ColorPrimario = colorPrimario;
        PiePaginaDocumentos = piePaginaDocumentos;
        MensajeAgradecimiento = mensajeAgradecimiento;
        FechaCreacion = DateTime.Now;
        FechaActualizacion = DateTime.Now;
    }

    // Constructor para recuperar desde BD
    public ConfiguracionEmpresa(
        int id,
        string razonSocial,
        string? nombreComercial,
        string? numeroIdentificacionFiscal,
        string direccion,
        string? ciudad,
        string? estadoProvincia,
        string? codigoPostal,
        string pais,
        string? telefonoPrincipal,
        string? telefonoSecundario,
        string emailPrincipal,
        string? emailSecundario,
        string? sitioWeb,
        string codigoMoneda,
        string simboloMoneda,
        string? nombreMoneda,
        string posicionSimbolo,
        string separadorMiles,
        string separadorDecimales,
        int decimales,
        string? logoUrl,
        string colorPrimario,
        string? piePaginaDocumentos,
        string? mensajeAgradecimiento,
        DateTime fechaCreacion,
        DateTime fechaActualizacion,
        int? actualizadoPor)
    {
        Id = id;
        RazonSocial = razonSocial;
        NombreComercial = nombreComercial;
        NumeroIdentificacionFiscal = numeroIdentificacionFiscal;
        Direccion = direccion;
        Ciudad = ciudad;
        EstadoProvincia = estadoProvincia;
        CodigoPostal = codigoPostal;
        Pais = pais;
        TelefonoPrincipal = telefonoPrincipal;
        TelefonoSecundario = telefonoSecundario;
        EmailPrincipal = emailPrincipal;
        EmailSecundario = emailSecundario;
        SitioWeb = sitioWeb;
        CodigoMoneda = codigoMoneda;
        SimboloMoneda = simboloMoneda;
        NombreMoneda = nombreMoneda;
        PosicionSimbolo = posicionSimbolo;
        SeparadorMiles = separadorMiles;
        SeparadorDecimales = separadorDecimales;
        Decimales = decimales;
        LogoUrl = logoUrl;
        ColorPrimario = colorPrimario;
        PiePaginaDocumentos = piePaginaDocumentos;
        MensajeAgradecimiento = mensajeAgradecimiento;
        FechaCreacion = fechaCreacion;
        FechaActualizacion = fechaActualizacion;
        ActualizadoPor = actualizadoPor;
    }

    public void Actualizar(
        string razonSocial,
        string direccion,
        string pais,
        string emailPrincipal,
        int actualizadoPor,
        string? nombreComercial = null,
        string? numeroIdentificacionFiscal = null,
        string? ciudad = null,
        string? estadoProvincia = null,
        string? codigoPostal = null,
        string? telefonoPrincipal = null,
        string? telefonoSecundario = null,
        string? emailSecundario = null,
        string? sitioWeb = null,
        string? codigoMoneda = null,
        string? simboloMoneda = null,
        string? nombreMoneda = null,
        string? posicionSimbolo = null,
        string? separadorMiles = null,
        string? separadorDecimales = null,
        int? decimales = null,
        string? logoUrl = null,
        string? colorPrimario = null,
        string? piePaginaDocumentos = null,
        string? mensajeAgradecimiento = null)
    {
        RazonSocial = razonSocial;
        NombreComercial = nombreComercial;
        NumeroIdentificacionFiscal = numeroIdentificacionFiscal;
        Direccion = direccion;
        Ciudad = ciudad;
        EstadoProvincia = estadoProvincia;
        CodigoPostal = codigoPostal;
        Pais = pais;
        TelefonoPrincipal = telefonoPrincipal;
        TelefonoSecundario = telefonoSecundario;
        EmailPrincipal = emailPrincipal;
        EmailSecundario = emailSecundario;
        SitioWeb = sitioWeb;
        
        if (codigoMoneda != null) CodigoMoneda = codigoMoneda;
        if (simboloMoneda != null) SimboloMoneda = simboloMoneda;
        if (nombreMoneda != null) NombreMoneda = nombreMoneda;
        if (posicionSimbolo != null) PosicionSimbolo = ValidarPosicionSimbolo(posicionSimbolo);
        if (separadorMiles != null) SeparadorMiles = separadorMiles;
        if (separadorDecimales != null) SeparadorDecimales = separadorDecimales;
        if (decimales.HasValue) Decimales = decimales.Value;
        
        LogoUrl = logoUrl;
        if (colorPrimario != null) ColorPrimario = colorPrimario;
        PiePaginaDocumentos = piePaginaDocumentos;
        MensajeAgradecimiento = mensajeAgradecimiento;
        
        FechaActualizacion = DateTime.Now;
        ActualizadoPor = actualizadoPor;
    }

    private static string ValidarPosicionSimbolo(string posicion)
    {
        if (posicion != "antes" && posicion != "despues")
            throw new ArgumentException("La posición del símbolo debe ser 'antes' o 'despues'", nameof(posicion));
        return posicion;
    }

    public string FormatearMoneda(decimal monto)
    {
        var montoFormateado = monto.ToString($"N{Decimales}")
            .Replace(",", "_TEMP_")
            .Replace(".", SeparadorDecimales)
            .Replace("_TEMP_", SeparadorMiles);

        return PosicionSimbolo == "antes"
            ? $"{SimboloMoneda}{montoFormateado}"
            : $"{montoFormateado}{SimboloMoneda}";
    }
}