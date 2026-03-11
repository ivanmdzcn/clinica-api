namespace Application.UseCases.Clinica.Medicos.CreateMedico;

public class CreateMedicoResponse
{
    public int Id { get; init; }
    public int UsuarioId { get; init; }
    public string CedulaProfesional { get; init; } = string.Empty;
    public string Especialidad { get; init; } = string.Empty;
    public DateTime FechaCreacion { get; init; }
}