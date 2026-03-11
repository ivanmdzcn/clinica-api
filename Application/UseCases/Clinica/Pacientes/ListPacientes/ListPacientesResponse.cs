namespace Application.UseCases.Pacientes.ListPacientes;

public class ListPacientesResponse
{
    public int Id { get; init; }
    public string? Dpi { get; init; }
    public string NombreCompleto { get; init; } = default!;
    public DateTime FechaNacimiento { get; init; }
    public int Edad { get; init; }
    public string Sexo { get; init; } = default!;
    public string? Telefono { get; init; }
    public string? Email { get; init; }
    public DateTime FechaRegistro { get; init; }
}