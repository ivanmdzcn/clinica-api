namespace Domain.Entities.Clinica;

public class Tratamiento
{
    public int Id { get; private set; }
    public int ConsultaId { get; private set; }
    public string Descripcion { get; private set; }
    public string? Indicaciones { get; private set; }
    public DateTime? FechaInicio { get; private set; }
    public DateTime? FechaFin { get; private set; }
    public DateTime FechaRegistro { get; private set; }

    // Constructor para crear nuevo tratamiento
    public Tratamiento(
        int consultaId,
        string descripcion,
        string? indicaciones = null,
        DateTime? fechaInicio = null,
        DateTime? fechaFin = null)
    {
        ConsultaId = consultaId;
        Descripcion = descripcion;
        Indicaciones = indicaciones;
        FechaInicio = fechaInicio;
        FechaFin = ValidarFechaFin(fechaInicio, fechaFin);
        FechaRegistro = DateTime.Now;
    }

    // Constructor para recuperar desde BD
    public Tratamiento(
        int id,
        int consultaId,
        string descripcion,
        string? indicaciones,
        DateTime? fechaInicio,
        DateTime? fechaFin,
        DateTime fechaRegistro)
    {
        Id = id;
        ConsultaId = consultaId;
        Descripcion = descripcion;
        Indicaciones = indicaciones;
        FechaInicio = fechaInicio;
        FechaFin = fechaFin;
        FechaRegistro = fechaRegistro;
    }

    public void Actualizar(
        string descripcion,
        string? indicaciones,
        DateTime? fechaInicio,
        DateTime? fechaFin)
    {
        Descripcion = descripcion;
        Indicaciones = indicaciones;
        FechaInicio = fechaInicio;
        FechaFin = ValidarFechaFin(fechaInicio, fechaFin);
    }

    private static DateTime? ValidarFechaFin(DateTime? fechaInicio, DateTime? fechaFin)
    {
        if (fechaInicio.HasValue && fechaFin.HasValue && fechaFin.Value < fechaInicio.Value)
            throw new ArgumentException("La fecha de fin no puede ser anterior a la fecha de inicio", nameof(fechaFin));
        return fechaFin;
    }
}