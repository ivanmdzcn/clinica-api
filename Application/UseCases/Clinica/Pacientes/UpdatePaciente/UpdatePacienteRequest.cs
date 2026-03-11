namespace Application.UseCases.Pacientes.UpdatePaciente;

public class UpdatePacienteRequest
{
    public string? Dpi { get; init; }
    public string Nombres { get; init; } = default!;
    public string Apellidos { get; init; } = default!;
    public DateTime FechaNacimiento { get; init; }
    public string Sexo { get; init; } = default!;
    public string? Telefono { get; init; }
    public string? Direccion { get; init; }
    public string? Email { get; init; }
}