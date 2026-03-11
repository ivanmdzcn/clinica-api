namespace Application.UseCases.Clinica.Medicos.UpdateMedico;

public class UpdateMedicoRequest
{
    public string CedulaProfesional { get; init; } = string.Empty;
    public string Especialidad { get; init; } = string.Empty;
    public string? Subespecialidad { get; init; }
    public string? Consultorio { get; init; }
    public string? TelefonoConsultorio { get; init; }
    public string? HorarioAtencion { get; init; }
    public string? Observaciones { get; init; }
    public bool Activo { get; init; } = true;
}