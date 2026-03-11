namespace Application.UseCases.Pacientes.CreatePaciente;

public class CreatePacienteResponse
{
    public int Id { get; init; }
    public string NombreCompleto { get; init; } = default!;
    public string? Dpi { get; init; }
}