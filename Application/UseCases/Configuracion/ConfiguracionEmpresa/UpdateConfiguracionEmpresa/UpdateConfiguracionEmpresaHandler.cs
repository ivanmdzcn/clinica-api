using Application.Interfaces.Repositories.Configuracion;
using Application.Interfaces.Security;

namespace Application.UseCases.Configuracion.ConfiguracionEmpresa.UpdateConfiguracionEmpresa;

public class UpdateConfiguracionEmpresaHandler
{
    private readonly IConfiguracionEmpresaRepository _repository;
    private readonly ICurrentUserService _currentUserService;

    public UpdateConfiguracionEmpresaHandler(
        IConfiguracionEmpresaRepository repository,
        ICurrentUserService currentUserService)
    {
        _repository = repository;
        _currentUserService = currentUserService;
    }

    public async Task HandleAsync(UpdateConfiguracionEmpresaRequest request)
    {
        var configuracion = await _repository.GetConfiguracionAsync()
            ?? throw new KeyNotFoundException("No existe configuración de empresa. Debe crearla primero.");

        var usuarioId = _currentUserService.GetUserId();

        configuracion.Actualizar(
            request.RazonSocial,
            request.Direccion,
            request.Pais,
            request.EmailPrincipal,
            usuarioId,
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

        await _repository.UpdateAsync(configuracion);
    }
}