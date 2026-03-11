namespace Application.UseCases.Clinica.ExamenesLaboratorio.CreateExamenLaboratorio;

public class CreateExamenLaboratorioResponse
{
    public int Id { get; init; }
    public int OrdenLaboratorioId { get; init; }
    public string NombreExamen { get; init; } = string.Empty;
    public DateTime FechaRegistro { get; init; }
}