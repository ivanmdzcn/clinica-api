namespace Application.UseCases.Clinica.OrdenesLaboratorio.CreateOrdenLaboratorio;

public class CreateOrdenLaboratorioResponse
{
    public int Id { get; init; }
    public int ConsultaId { get; init; }
    public string NumeroOrden { get; init; } = string.Empty;
    public DateTime FechaOrden { get; init; }
    public DateTime FechaRegistro { get; init; }
}