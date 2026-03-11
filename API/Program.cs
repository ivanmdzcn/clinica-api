using API.Middleware;
using Application.UseCases.Auth.Login;
using Application.UseCases.Auth.Me;
using Application.UseCases.Auth.Usuarios.CreateUsuario;
using Application.UseCases.Auth.Usuarios.UpdateUsuario;
using Application.UseCases.Auth.Usuarios.GetUsuario;
using Application.UseCases.Auth.Usuarios.ListUsuarios;
using Application.UseCases.Auth.Usuarios.DeleteUsuario;
using Application.UseCases.Auth.Usuarios.ListUsuariosByRol;
using Application.UseCases.Auth.Roles.CreateRol;
using Application.UseCases.Auth.Roles.UpdateRol;
using Application.UseCases.Auth.Roles.GetRol;
using Application.UseCases.Auth.Roles.ListRoles;
using Application.UseCases.Auth.Roles.DeleteRol;
using Application.UseCases.Auth.Permisos.CreatePermiso;
using Application.UseCases.Auth.Permisos.UpdatePermiso;
using Application.UseCases.Auth.Permisos.GetPermiso;
using Application.UseCases.Auth.Permisos.ListPermisos;
using Application.UseCases.Auth.Permisos.ListPermisosByModulo;
using Application.UseCases.Auth.Permisos.ListModulos;
using Application.UseCases.Auth.Permisos.DeletePermiso;
using Application.UseCases.Auth.RolPermisos.GetPermisosByRol;
using Application.UseCases.Auth.RolPermisos.AsignarPermisos;
using Application.UseCases.Auth.RolPermisos.AsignarPermiso;
using Application.UseCases.Auth.RolPermisos.RemoverPermiso;
using FluentValidation;
using FluentValidation.AspNetCore;
using Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Application.UseCases.Pacientes.CreatePaciente;
using Application.UseCases.Pacientes.UpdatePaciente;
using Application.UseCases.Pacientes.GetPaciente;
using Application.UseCases.Pacientes.ListPacientes;
using Application.UseCases.Pacientes.DeletePaciente;
using Application.UseCases.Pacientes.SearchPacientes;
using Application.UseCases.Clinica.Alergias.CreateAlergia;
using Application.UseCases.Clinica.Alergias.UpdateAlergia;
using Application.UseCases.Clinica.Alergias.GetAlergia;
using Application.UseCases.Clinica.Alergias.ListAlergiasByPaciente;
using Application.UseCases.Clinica.Alergias.DeleteAlergia;
using Application.UseCases.Clinica.Antecedentes.CreateAntecedente;
using Application.UseCases.Clinica.Antecedentes.UpdateAntecedente;
using Application.UseCases.Clinica.Antecedentes.GetAntecedente;
using Application.UseCases.Clinica.Antecedentes.ListAntecedentesByPaciente;
using Application.UseCases.Clinica.Antecedentes.DeleteAntecedente;
using Application.UseCases.Clinica.Consultas.CreateConsulta;
using Application.UseCases.Clinica.Consultas.UpdateConsulta;
using Application.UseCases.Clinica.Consultas.GetConsulta;
using Application.UseCases.Clinica.Consultas.ListConsultasByPaciente;
using Application.UseCases.Clinica.Consultas.CerrarConsulta;
using Application.UseCases.Clinica.Consultas.AnularConsulta;
using Application.UseCases.Clinica.SignosVitales.CreateSignoVital;
using Application.UseCases.Clinica.SignosVitales.UpdateSignoVital;
using Application.UseCases.Clinica.SignosVitales.GetSignoVital;
using Application.UseCases.Clinica.SignosVitales.GetSignoVitalByConsulta;
using Application.UseCases.Clinica.SignosVitales.DeleteSignoVital;
using Application.UseCases.Clinica.ExamenesFisicos.CreateExamenFisico;
using Application.UseCases.Clinica.ExamenesFisicos.UpdateExamenFisico;
using Application.UseCases.Clinica.ExamenesFisicos.GetExamenFisico;
using Application.UseCases.Clinica.ExamenesFisicos.GetExamenFisicoByConsulta;
using Application.UseCases.Clinica.ExamenesFisicos.DeleteExamenFisico;
using Application.UseCases.Clinica.Diagnosticos.CreateDiagnostico;
using Application.UseCases.Clinica.Diagnosticos.UpdateDiagnostico;
using Application.UseCases.Clinica.Diagnosticos.GetDiagnostico;
using Application.UseCases.Clinica.Diagnosticos.ListDiagnosticosByConsulta;
using Application.UseCases.Clinica.Diagnosticos.DeleteDiagnostico;
using Application.UseCases.Clinica.Tratamientos.CreateTratamiento;
using Application.UseCases.Clinica.Tratamientos.UpdateTratamiento;
using Application.UseCases.Clinica.Tratamientos.GetTratamiento;
using Application.UseCases.Clinica.Tratamientos.ListTratamientosByConsulta;
using Application.UseCases.Clinica.Tratamientos.DeleteTratamiento;
using Application.UseCases.Clinica.OrdenesLaboratorio.CreateOrdenLaboratorio;
using Application.UseCases.Clinica.OrdenesLaboratorio.UpdateOrdenLaboratorio;
using Application.UseCases.Clinica.OrdenesLaboratorio.GetOrdenLaboratorio;
using Application.UseCases.Clinica.OrdenesLaboratorio.ListOrdenesLaboratorioByConsulta;
using Application.UseCases.Clinica.OrdenesLaboratorio.DeleteOrdenLaboratorio;
using Application.UseCases.Clinica.ExamenesLaboratorio.CreateExamenLaboratorio;
using Application.UseCases.Clinica.ExamenesLaboratorio.UpdateExamenLaboratorio;
using Application.UseCases.Clinica.ExamenesLaboratorio.GetExamenLaboratorio;
using Application.UseCases.Clinica.ExamenesLaboratorio.ListExamenesLaboratorioByOrden;
using Application.UseCases.Clinica.ExamenesLaboratorio.DeleteExamenLaboratorio;
using Application.UseCases.Clinica.Recetas.CreateReceta;
using Application.UseCases.Clinica.Recetas.UpdateReceta;
using Application.UseCases.Clinica.Recetas.GetReceta;
using Application.UseCases.Clinica.Recetas.ListRecetasByConsulta;
using Application.UseCases.Clinica.Recetas.DeleteReceta;
using Application.UseCases.Configuracion.ConfiguracionEmpresa.CreateConfiguracionEmpresa;
using Application.UseCases.Configuracion.ConfiguracionEmpresa.UpdateConfiguracionEmpresa;
using Application.UseCases.Configuracion.ConfiguracionEmpresa.GetConfiguracionEmpresa;
using Application.UseCases.Clinica.Medicos.CreateMedico;
using Application.UseCases.Clinica.Medicos.UpdateMedico;
using Application.UseCases.Clinica.Medicos.GetMedico;
using Application.UseCases.Clinica.Medicos.ListMedicos;
using Application.UseCases.Clinica.Medicos.DeleteMedico;
using Application.UseCases.Dashboard.Estadisticas.ObtenerConsultasPorDia;
using Application.UseCases.Dashboard.Estadisticas.ObtenerConsultasPorMedico;
using Application.UseCases.Dashboard.Estadisticas.ObtenerDistribucionEstados;
using Application.UseCases.Dashboard.Estadisticas.ObtenerPacientesPorMes;
using Application.UseCases.Dashboard.Estadisticas.ObtenerResumenGeneral;

namespace API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // CORS Configuration - Dinámica desde appsettings
        var allowedOrigins = builder.Configuration.GetSection("Cors:AllowedOrigins").Get<string[]>()
            ?? new[] { "http://localhost:4200" }; // Fallback por defecto

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAngular", policy =>
            {
                policy.WithOrigins(allowedOrigins)
                      .AllowAnyMethod()
                      .AllowAnyHeader();
                      // Sin AllowCredentials() porque usamos JWT en header Authorization
            });
        });

        // Controllers
        builder.Services.AddControllers();

        // HttpContextAccessor - Necesario para ICurrentUserService
        builder.Services.AddHttpContextAccessor();

        // FluentValidation
        builder.Services.AddFluentValidationAutoValidation();
        builder.Services.AddValidatorsFromAssemblyContaining<CreateUsuarioRequestValidator>();

        // Swagger
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Clinica API",
                Version = "v1"
            });

            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "JWT Authorization header usando el esquema Bearer. \r\n\r\n Escribe 'Bearer' [espacio] y luego tu token.\r\n\r\nEjemplo: \"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9\"",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                BearerFormat = "JWT"
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] {}
                }
            });
        });


        // Infrastructure
        builder.Services.AddInfrastructure();

        // Auth Handlers
        builder.Services.AddScoped<LoginHandler>();
        builder.Services.AddScoped<MeHandler>();

        // Usuarios Handlers
        builder.Services.AddScoped<CreateUsuarioHandler>();
        builder.Services.AddScoped<UpdateUsuarioHandler>();
        builder.Services.AddScoped<GetUsuarioHandler>();
        builder.Services.AddScoped<ListUsuariosHandler>();
        builder.Services.AddScoped<DeleteUsuarioHandler>();
        builder.Services.AddScoped<ListUsuariosByRolHandler>(); // <-- Nuevo handler agregado

        // Roles Handlers
        builder.Services.AddScoped<CreateRolHandler>();
        builder.Services.AddScoped<UpdateRolHandler>();
        builder.Services.AddScoped<GetRolHandler>();
        builder.Services.AddScoped<ListRolesHandler>();
        builder.Services.AddScoped<DeleteRolHandler>();

        // Permisos Handlers
        builder.Services.AddScoped<CreatePermisoHandler>();
        builder.Services.AddScoped<UpdatePermisoHandler>();
        builder.Services.AddScoped<GetPermisoHandler>();
        builder.Services.AddScoped<ListPermisosHandler>();
        builder.Services.AddScoped<ListPermisosByModuloHandler>();
        builder.Services.AddScoped<ListModulosHandler>();
        builder.Services.AddScoped<DeletePermisoHandler>();

        // RolPermisos Handlers
        builder.Services.AddScoped<GetPermisosByRolHandler>();
        builder.Services.AddScoped<AsignarPermisosHandler>();
        builder.Services.AddScoped<AsignarPermisoHandler>();
        builder.Services.AddScoped<RemoverPermisoHandler>();

        // Pacientes Handlers
        builder.Services.AddScoped<CreatePacienteHandler>();
        builder.Services.AddScoped<UpdatePacienteHandler>();
        builder.Services.AddScoped<GetPacienteHandler>();
        builder.Services.AddScoped<ListPacientesHandler>();
        builder.Services.AddScoped<DeletePacienteHandler>();
        builder.Services.AddScoped<SearchPacientesHandler>();

        // Alergias Handlers
        builder.Services.AddScoped<CreateAlergiaHandler>();
        builder.Services.AddScoped<UpdateAlergiaHandler>();
        builder.Services.AddScoped<GetAlergiaHandler>();
        builder.Services.AddScoped<ListAlergiasByPacienteHandler>();
        builder.Services.AddScoped<DeleteAlergiaHandler>();

        // Antecedentes Handlers
        builder.Services.AddScoped<CreateAntecedenteHandler>();
        builder.Services.AddScoped<UpdateAntecedenteHandler>();
        builder.Services.AddScoped<GetAntecedenteHandler>();
        builder.Services.AddScoped<ListAntecedentesByPacienteHandler>();
        builder.Services.AddScoped<DeleteAntecedenteHandler>();

        // Consultas Handlers
        builder.Services.AddScoped<CreateConsultaHandler>();
        builder.Services.AddScoped<UpdateConsultaHandler>();
        builder.Services.AddScoped<GetConsultaHandler>();
        builder.Services.AddScoped<ListConsultasByPacienteHandler>();
        builder.Services.AddScoped<CerrarConsultaHandler>();
        builder.Services.AddScoped<AnularConsultaHandler>();

        // Signos Vitales Handlers
        builder.Services.AddScoped<CreateSignoVitalHandler>();
        builder.Services.AddScoped<UpdateSignoVitalHandler>();
        builder.Services.AddScoped<GetSignoVitalHandler>();
        builder.Services.AddScoped<GetSignoVitalByConsultaHandler>();
        builder.Services.AddScoped<DeleteSignoVitalHandler>();

        // Examenes Físicos Handlers
        builder.Services.AddScoped<CreateExamenFisicoHandler>();
        builder.Services.AddScoped<UpdateExamenFisicoHandler>();
        builder.Services.AddScoped<GetExamenFisicoHandler>();
        builder.Services.AddScoped<GetExamenFisicoByConsultaHandler>();
        builder.Services.AddScoped<DeleteExamenFisicoHandler>();

        // Diagnosticos Handlers
        builder.Services.AddScoped<CreateDiagnosticoHandler>();
        builder.Services.AddScoped<UpdateDiagnosticoHandler>();
        builder.Services.AddScoped<GetDiagnosticoHandler>();
        builder.Services.AddScoped<ListDiagnosticosByConsultaHandler>();
        builder.Services.AddScoped<DeleteDiagnosticoHandler>();

        // Tratamientos Handlers
        builder.Services.AddScoped<CreateTratamientoHandler>();
        builder.Services.AddScoped<UpdateTratamientoHandler>();
        builder.Services.AddScoped<GetTratamientoHandler>();
        builder.Services.AddScoped<ListTratamientosByConsultaHandler>();
        builder.Services.AddScoped<DeleteTratamientoHandler>();

        // Ordenes Laboratorio Handlers
        builder.Services.AddScoped<CreateOrdenLaboratorioHandler>();
        builder.Services.AddScoped<UpdateOrdenLaboratorioHandler>();
        builder.Services.AddScoped<GetOrdenLaboratorioHandler>();
        builder.Services.AddScoped<ListOrdenesLaboratorioByConsultaHandler>();
        builder.Services.AddScoped<DeleteOrdenLaboratorioHandler>();

        // Examenes Laboratorio Handlers
        builder.Services.AddScoped<CreateExamenLaboratorioHandler>();
        builder.Services.AddScoped<UpdateExamenLaboratorioHandler>();
        builder.Services.AddScoped<GetExamenLaboratorioHandler>();
        builder.Services.AddScoped<ListExamenesLaboratorioByOrdenHandler>();
        builder.Services.AddScoped<DeleteExamenLaboratorioHandler>();

        // Recetas Handlers
        builder.Services.AddScoped<CreateRecetaHandler>();
        builder.Services.AddScoped<UpdateRecetaHandler>();
        builder.Services.AddScoped<GetRecetaHandler>();
        builder.Services.AddScoped<ListRecetasByConsultaHandler>();
        builder.Services.AddScoped<DeleteRecetaHandler>();

        // Configuración Empresa Handlers
        builder.Services.AddScoped<CreateConfiguracionEmpresaHandler>();
        builder.Services.AddScoped<UpdateConfiguracionEmpresaHandler>();
        builder.Services.AddScoped<GetConfiguracionEmpresaHandler>();

        // Médicos Handlers
        builder.Services.AddScoped<CreateMedicoHandler>();
        builder.Services.AddScoped<UpdateMedicoHandler>();
        builder.Services.AddScoped<GetMedicoHandler>();
        builder.Services.AddScoped<ListMedicosHandler>();
        builder.Services.AddScoped<DeleteMedicoHandler>();

        // Dashboard - Estadísticas Handlers
        builder.Services.AddScoped<ObtenerResumenGeneralHandler>();
        builder.Services.AddScoped<ObtenerConsultasPorDiaHandler>();
        builder.Services.AddScoped<ObtenerConsultasPorMedicoHandler>();
        builder.Services.AddScoped<ObtenerPacientesPorMesHandler>();
        builder.Services.AddScoped<ObtenerDistribucionEstadosHandler>();

        // JWT Authentication
        var jwtSettings = builder.Configuration.GetSection("JwtSettings");
        var secretKey = jwtSettings["Secret"]!;

        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings["Issuer"],
                ValidAudience = jwtSettings["Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(secretKey))
            };
        });

        var app = builder.Build();

        // Middleware
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        // CORS debe ir antes de Authentication y Authorization
        app.UseCors("AllowAngular");

        app.UseMiddleware<ExceptionMiddleware>();
        app.UseMiddleware<PermissionLoggingMiddleware>(); // 👈 Logging de permisos
        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}