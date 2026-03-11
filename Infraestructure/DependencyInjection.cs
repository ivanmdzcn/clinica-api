using Application.Interfaces.Repositories;
using Application.Interfaces.Repositories.Auth;
using Application.Interfaces.Repositories.Clinica;
using Application.Interfaces.Repositories.Configuracion;
using Application.Interfaces.Repositories.Dashboard;
using Application.Interfaces.Repositories.Security;
using Application.Interfaces.Security;
using Infraestructure.Persistence.Repositories.Auth;
using Infraestructure.Persistence.Repositories.Security;
using Infrastructure.Persistence.Dapper;
using Infrastructure.Persistence.Repositories;
using Infrastructure.Persistence.Repositories.Clinica;
using Infrastructure.Persistence.Repositories.Configuracion;
using Infrastructure.Persistence.Repositories.Dashboard;
using Infrastructure.Security;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        // Dapper Context
        services.AddSingleton<DapperContext>();

        // Repositories AUTH
        services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        services.AddScoped<IRolRepository, RolRepository>();
        services.AddScoped<IPermisoRepository, PermisoRepository>();
        services.AddScoped<IRolPermisoRepository, RolPermisoRepository>();

        // Security
        services.AddScoped<IPasswordHasher, BCryptPasswordHasher>();
        services.AddScoped<ITokenGenerator, JwtTokenGenerator>();
        services.AddScoped<ICurrentUserService, CurrentUserService>();

        // Clinica Repositories
        services.AddScoped<IPacienteRepository, PacienteRepository>();
        services.AddScoped<IAlergiaRepository, AlergiaRepository>();
        services.AddScoped<IAntecedenteRepository, AntecedenteRepository>();
        services.AddScoped<IConsultaRepository, ConsultaRepository>();  
        services.AddScoped<ISignoVitalRepository, SignoVitalRepository>();
        services.AddScoped<IExamenFisicoRepository, ExamenFisicoRepository>();
        services.AddScoped<IDiagnosticoRepository, DiagnosticoRepository>();
        services.AddScoped<ITratamientoRepository, TratamientoRepository>();
        services.AddScoped<IOrdenLaboratorioRepository, OrdenLaboratorioRepository>();
        services.AddScoped<IExamenLaboratorioRepository, ExamenLaboratorioRepository>();
        services.AddScoped<IRecetaRepository, RecetaRepository>();
        services.AddScoped<IMedicoRepository, MedicoRepository>();

        // Configuración Repositories
        services.AddScoped<IConfiguracionEmpresaRepository, ConfiguracionEmpresaRepository>();

        // Dashboard Repositories
        services.AddScoped<IEstadisticasRepository, EstadisticasRepository>();

        return services;
    }
}
