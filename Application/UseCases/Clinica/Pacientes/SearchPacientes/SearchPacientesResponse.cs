namespace Application.UseCases.Pacientes.SearchPacientes;

public class SearchPacientesResponse
{
    public int Id { get; init; }
    public string? Dpi { get; init; }
    public string NombreCompleto { get; init; } = default!;
    public DateTime FechaNacimiento { get; init; }
    public int Edad { get; init; }
    public string Sexo { get; init; } = default!;
    public string? Telefono { get; init; }
}