namespace Domain.Entities.Clinica;

public class Receta
{
    public int Id { get; private set; }
    public int ConsultaId { get; private set; }
    public string Medicamento { get; private set; }
    public string? Dosis { get; private set; }
    public string? Frecuencia { get; private set; }
    public string? Duracion { get; private set; }
    public string? ViaAdministracion { get; private set; }
    public string? Indicaciones { get; private set; }
    public DateTime FechaRegistro { get; private set; }

    // Constructor para crear nueva receta
    public Receta(
        int consultaId,
        string medicamento,
        string? dosis = null,
        string? frecuencia = null,
        string? duracion = null,
        string? viaAdministracion = null,
        string? indicaciones = null)
    {
        ConsultaId = consultaId;
        Medicamento = medicamento;
        Dosis = dosis;
        Frecuencia = frecuencia;
        Duracion = duracion;
        ViaAdministracion = viaAdministracion;
        Indicaciones = indicaciones;
        FechaRegistro = DateTime.Now;
    }

    // Constructor para recuperar desde BD
    public Receta(
        int id,
        int consultaId,
        string medicamento,
        string? dosis,
        string? frecuencia,
        string? duracion,
        string? viaAdministracion,
        string? indicaciones,
        DateTime fechaRegistro)
    {
        Id = id;
        ConsultaId = consultaId;
        Medicamento = medicamento;
        Dosis = dosis;
        Frecuencia = frecuencia;
        Duracion = duracion;
        ViaAdministracion = viaAdministracion;
        Indicaciones = indicaciones;
        FechaRegistro = fechaRegistro;
    }

    public void Actualizar(
        string medicamento,
        string? dosis,
        string? frecuencia,
        string? duracion,
        string? viaAdministracion,
        string? indicaciones)
    {
        Medicamento = medicamento;
        Dosis = dosis;
        Frecuencia = frecuencia;
        Duracion = duracion;
        ViaAdministracion = viaAdministracion;
        Indicaciones = indicaciones;
    }
}