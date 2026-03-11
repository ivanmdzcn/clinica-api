namespace Application.UseCases.Clinica.Alergias.CreateAlergia;

public class CreateAlergiaResponse
{
    public int Id { get; init; }
    public int PacienteId { get; init; }
    public string MedicamentoOElemento { get; init; } = string.Empty;
    public string? Reaccion { get; init; }
}