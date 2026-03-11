namespace Application.UseCases.Configuracion.ConfiguracionEmpresa.CreateConfiguracionEmpresa;

public class CreateConfiguracionEmpresaResponse
{
    public int Id { get; init; }
    public string RazonSocial { get; init; } = string.Empty;
    public string? NombreComercial { get; init; }
    public DateTime FechaCreacion { get; init; }
}