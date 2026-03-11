namespace Domain.Entities.Clinica;

public class OrdenLaboratorio
{
    public int Id { get; private set; }
    public int ConsultaId { get; private set; }
    public string NumeroOrden { get; private set; }
    public DateTime FechaOrden { get; private set; }
    public int PacienteId { get; private set; }
    public int MedicoId { get; private set; }
    public string? DiagnosticoCie10 { get; private set; }
    public string? Observaciones { get; private set; }
    public DateTime FechaRegistro { get; private set; }

    // Constructor para crear nueva orden
    public OrdenLaboratorio(
        int consultaId,
        string numeroOrden,
        DateTime fechaOrden,
        int pacienteId,
        int medicoId,
        string? diagnosticoCie10 = null,
        string? observaciones = null)
    {
        ConsultaId = consultaId;
        NumeroOrden = numeroOrden;
        FechaOrden = fechaOrden;
        PacienteId = pacienteId;
        MedicoId = medicoId;
        DiagnosticoCie10 = diagnosticoCie10;
        Observaciones = observaciones;
        FechaRegistro = DateTime.Now;
    }

    // Constructor para recuperar desde BD
    public OrdenLaboratorio(
        int id,
        int consultaId,
        string numeroOrden,
        DateTime fechaOrden,
        int pacienteId,
        int medicoId,
        string? diagnosticoCie10,
        string? observaciones,
        DateTime fechaRegistro)
    {
        Id = id;
        ConsultaId = consultaId;
        NumeroOrden = numeroOrden;
        FechaOrden = fechaOrden;
        PacienteId = pacienteId;
        MedicoId = medicoId;
        DiagnosticoCie10 = diagnosticoCie10;
        Observaciones = observaciones;
        FechaRegistro = fechaRegistro;
    }

    public void Actualizar(
        string numeroOrden,
        DateTime fechaOrden,
        string? diagnosticoCie10,
        string? observaciones)
    {
        NumeroOrden = numeroOrden;
        FechaOrden = fechaOrden;
        DiagnosticoCie10 = diagnosticoCie10;
        Observaciones = observaciones;
    }
}