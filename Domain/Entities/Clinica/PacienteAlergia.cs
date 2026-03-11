namespace Domain.Entities.Clinica;

public class PacienteAlergia
{
    public int Id { get; private set; }
    public int PacienteId { get; private set; }
    public string MedicamentoOElemento { get; private set; }
    public string? Reaccion { get; private set; }

    // Constructor para crear nueva alergia
    public PacienteAlergia(
        int pacienteId,
        string medicamentoOElemento,
        string? reaccion = null)
    {
        PacienteId = pacienteId;
        MedicamentoOElemento = medicamentoOElemento;
        Reaccion = reaccion;
    }

    // Constructor para recuperar desde BD
    public PacienteAlergia(
        int id,
        int pacienteId,
        string medicamentoOElemento,
        string? reaccion)
    {
        Id = id;
        PacienteId = pacienteId;
        MedicamentoOElemento = medicamentoOElemento;
        Reaccion = reaccion;
    }

    public void Actualizar(string medicamentoOElemento, string? reaccion)
    {
        MedicamentoOElemento = medicamentoOElemento;
        Reaccion = reaccion;
    }
}