namespace Application.UseCases.Clinica.Alergias.UpdateAlergia;

public class UpdateAlergiaResponse
{
    public int Id { get; init; }
    public int PacienteId { get; init; }
    public string MedicamentoOElemento { get; init; } = string.Empty;
    public string? Reaccion { get; init; }
}