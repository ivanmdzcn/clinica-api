using Application.Interfaces.Repositories.Configuracion;

namespace Application.UseCases.Configuracion.ConfiguracionEmpresa.CreateConfiguracionEmpresa;

public class CreateConfiguracionEmpresaHandler
{
    private readonly IConfiguracionEmpresaRepository _repository;

    public CreateConfiguracionEmpresaHandler(IConfiguracionEmpresaRepository repository)
    {
        _repository = repository;
    }

    public async Task<CreateConfiguracionEmpresaResponse> HandleAsync(CreateConfiguracionEmpresaRequest request)
    {
        // Validar que no exista ya una configuración
        var existente = await _repository.GetConfiguracionAsync();
        if (existente != null)
            throw new InvalidOperationException("Ya existe una configuración de empresa. Use el endpoint de actualización.");

        var configuracion = new Domain.Entities.Configuracion.ConfiguracionEmpresa(
            request.RazonSocial,
            request.Direccion,
            request.Pais,
            request.EmailPrincipal,
            request.NombreComercial,
            request.NumeroIdentificacionFiscal,
            request.Ciudad,
            request.EstadoProvincia,
            request.CodigoPostal,
            request.TelefonoPrincipal,
            request.TelefonoSecundario,
            request.EmailSecundario,
            request.SitioWeb,
            request.CodigoMoneda,
            request.SimboloMoneda,
            request.NombreMoneda,
            request.PosicionSimbolo,
            request.SeparadorMiles,
            request.SeparadorDecimales,
            request.Decimales,
            request.LogoUrl,
            request.ColorPrimario,
            request.PiePaginaDocumentos,
            request.MensajeAgradecimiento
        );

        var id = await _repository.CreateAsync(configuracion);

        return new CreateConfiguracionEmpresaResponse
        {
            Id = id,
            RazonSocial = configuracion.RazonSocial,
            NombreComercial = configuracion.NombreComercial,
            FechaCreacion = configuracion.FechaCreacion
        };
    }
}