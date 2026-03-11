namespace Application.UseCases.Clinica.Alergias.UpdateAlergia;

public class UpdateAlergiaRequest
{
    public string MedicamentoOElemento { get; init; } = string.Empty;
    public string? Reaccion { get; init; }
}