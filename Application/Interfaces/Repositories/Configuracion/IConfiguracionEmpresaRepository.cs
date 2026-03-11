using ConfigEmpresa = Domain.Entities.Configuracion.ConfiguracionEmpresa;

namespace Application.Interfaces.Repositories.Configuracion;

public interface IConfiguracionEmpresaRepository
{
    Task<int> CreateAsync(ConfigEmpresa configuracion);
    Task UpdateAsync(ConfigEmpresa configuracion);
    Task<ConfigEmpresa?> GetConfiguracionAsync();
}