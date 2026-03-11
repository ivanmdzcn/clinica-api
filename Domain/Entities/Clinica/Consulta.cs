namespace Domain.Entities.Clinica;

public class Consulta
{
    public int Id { get; private set; }
    public int PacienteId { get; private set; }
    public int MedicoId { get; private set; }
    public string? TipoConsulta { get; private set; } // 'primera_vez', 'seguimiento', 'emergencia'
    public string MotivoConsulta { get; private set; }
    public string? Observaciones { get; private set; }
    public DateTime? ProximaCita { get; private set; }
    public DateTime FechaConsulta { get; private set; }
    public DateTime FechaActualizacion { get; private set; }
    public string Estado { get; private set; } // 'abierta', 'cerrada', 'anulada'

    // Constructor para crear nueva consulta
    public Consulta(
        int pacienteId,
        int medicoId,
        string motivoConsulta,
        string? tipoConsulta = null,
        string? observaciones = null,
        DateTime? proximaCita = null)
    {
        PacienteId = pacienteId;
        MedicoId = medicoId;
        TipoConsulta = tipoConsulta;
        MotivoConsulta = motivoConsulta;
        Observaciones = observaciones;
        ProximaCita = proximaCita;
        FechaConsulta = DateTime.Now;
        FechaActualizacion = DateTime.Now;
        Estado = "abierta";
    }

    // Constructor para recuperar desde BD
    public Consulta(
        int id,
        int pacienteId,
        int medicoId,
        string? tipoConsulta,
        string motivoConsulta,
        string? observaciones,
        DateTime? proximaCita,
        DateTime fechaConsulta,
        DateTime fechaActualizacion,
        string estado)
    {
        Id = id;
        PacienteId = pacienteId;
        MedicoId = medicoId;
        TipoConsulta = tipoConsulta;
        MotivoConsulta = motivoConsulta;
        Observaciones = observaciones;
        ProximaCita = proximaCita;
        FechaConsulta = fechaConsulta;
        FechaActualizacion = fechaActualizacion;
        Estado = estado;
    }

    public void Actualizar(
        string? tipoConsulta,
        string motivoConsulta,
        string? observaciones,
        DateTime? proximaCita)
    {
        TipoConsulta = tipoConsulta;
        MotivoConsulta = motivoConsulta;
        Observaciones = observaciones;
        ProximaCita = proximaCita;
        FechaActualizacion = DateTime.Now;
    }

    public void CambiarEstado(string nuevoEstado)
    {
        if (nuevoEstado != "abierta" && nuevoEstado != "cerrada" && nuevoEstado != "anulada")
            throw new ArgumentException("Estado inválido. Debe ser 'abierta', 'cerrada' o 'anulada'", nameof(nuevoEstado));

        Estado = nuevoEstado;
        FechaActualizacion = DateTime.Now;
    }

    public void Cerrar()
    {
        Estado = "cerrada";
        FechaActualizacion = DateTime.Now;
    }

    public void Anular()
    {
        Estado = "anulada";
        FechaActualizacion = DateTime.Now;
    }
}