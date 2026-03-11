namespace Application.UseCases.Clinica.Alergias.CreateAlergia;

public class CreateAlergiaRequest
{
    public int PacienteId { get; init; }
    public string MedicamentoOElemento { get; init; } = string.Empty;
    public string? Reaccion { get; init; }
}