namespace Application.UseCases.Clinica.Medicos.UpdateMedico;

public class UpdateMedicoResponse
{
    public int Id { get; init; }
    public int UsuarioId { get; init; }
    public string CedulaProfesional { get; init; } = string.Empty;
    public string Especialidad { get; init; } = string.Empty;
    public string? Subespecialidad { get; init; }
    public bool Activo { get; init; }
}