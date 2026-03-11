namespace Application.UseCases.Pacientes.UpdatePaciente;

public class UpdatePacienteResponse
{
    public int Id { get; init; }
    public string NombreCompleto { get; init; } = default!;
    public string? Dpi { get; init; }
}