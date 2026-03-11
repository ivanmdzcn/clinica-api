using Application.Interfaces.Repositories.Configuracion;

namespace Application.UseCases.Configuracion.ConfiguracionEmpresa.GetConfiguracionEmpresa;

public class GetConfiguracionEmpresaHandler
{
    private readonly IConfiguracionEmpresaRepository _repository;

    public GetConfiguracionEmpresaHandler(IConfiguracionEmpresaRepository repository)
    {
        _repository = repository;
    }

    public async Task<GetConfiguracionEmpresaResponse?> HandleAsync()
    {
        var config = await _repository.GetConfiguracionAsync();
        
        if (config == null)
            return null;

        return new GetConfiguracionEmpresaResponse
        {
            Id = config.Id,
            RazonSocial = config.RazonSocial,
            NombreComercial = config.NombreComercial,
            NumeroIdentificacionFiscal = config.NumeroIdentificacionFiscal,
            Direccion = config.Direccion,
            Ciudad = config.Ciudad,
            EstadoProvincia = config.EstadoProvincia,
            CodigoPostal = config.CodigoPostal,
            Pais = config.Pais,
            TelefonoPrincipal = config.TelefonoPrincipal,
            TelefonoSecundario = config.TelefonoSecundario,
            EmailPrincipal = config.EmailPrincipal,
            EmailSecundario = config.EmailSecundario,
            SitioWeb = config.SitioWeb,
            CodigoMoneda = config.CodigoMoneda,
            SimboloMoneda = config.SimboloMoneda,
            NombreMoneda = config.NombreMoneda,
            PosicionSimbolo = config.PosicionSimbolo,
            SeparadorMiles = config.SeparadorMiles,
            SeparadorDecimales = config.SeparadorDecimales,
            Decimales = config.Decimales,
            LogoUrl = config.LogoUrl,
            ColorPrimario = config.ColorPrimario,
            PiePaginaDocumentos = config.PiePaginaDocumentos,
            MensajeAgradecimiento = config.MensajeAgradecimiento,
            FechaCreacion = config.FechaCreacion,
            FechaActualizacion = config.FechaActualizacion
        };
    }
}